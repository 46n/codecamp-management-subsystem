from __future__ import annotations

import re
import sys
import zipfile
from collections import OrderedDict
from datetime import UTC, datetime
from pathlib import Path
from xml.sax.saxutils import escape


ROOT = Path(__file__).resolve().parents[1]
FORMS_ROOT = ROOT / "AsTest1" / "Forms"
OUTPUT_PATH = ROOT / "APUCC_UI_Form_Inventory.docx"
STUDENT_OUTPUT_PATH = ROOT / "APUCC_Student_UI_Proper_Naming.docx"

SECTION_LAYOUT = [
    ("Common / Base", ["Base", "Common"]),
    ("Student", ["Student"]),
    ("Trainer", ["Trainer"]),
    ("Lecturer", ["Lecturer"]),
    ("Admin", ["Admin"]),
]

DECLARATION_RE = re.compile(r"^\s*(private|protected)\s+([\w\.]+)\s+(\w+);", re.MULTILINE)
CLASS_RE = re.compile(r"namespace\s+([^\s{]+).*?partial\s+class\s+(\w+)", re.DOTALL)

STUDENT_PROPER_NAMES = {
    "StudentShellForm": {
        "panelMenu": "Sidebar Menu Panel",
        "homebtn": "Home Navigation Button",
        "panelLogo": "Logo Panel",
        "iconButton4": "Settings Navigation Button",
        "iconButton3": "Fees Navigation Button",
        "iconButton2": "My Courses Navigation Button",
        "pictureBox1": "Application Logo Picture Box",
        "panelSidebarContainer": "Sidebar Container Panel",
        "Profile": "Profile Navigation Button",
        "MainPanel": "Main Content Panel",
    },
    "StudentHomeForm": {
        "lblGreeting": "Greeting Label",
        "lblWelcome": "Welcome Message Label",
        "panelScheduleCard": "Schedule Card Panel",
        "dgvSchedule": "Schedule Data Grid",
        "ModuleColumnHome": "Module Column",
        "TrainerColumn": "Trainer Column",
        "DateColumnHome": "Date Column",
        "DayColumnHome": "Day Column",
        "TimeColumnHome": "Time Column",
        "RoomColumnHome": "Room Column",
        "StatusColumnHome": "Status Column",
        "btnUpcomingSchedule": "Upcoming Schedule Button",
        "btnCurrentSchedule": "Current Schedule Button",
    },
    "StudentCoursesForm": {
        "FillPanelCourses": "Courses Content Panel",
        "groupBox2": "Request New Course Group",
        "button3": "Request Course Button",
        "comboBox1": "Available Course Combo Box",
        "label2": "Available Course Label",
        "CurrentCourses": "Current Enrolled Courses Group",
        "dataGridView1": "Current Courses Data Grid",
        "TrainerColumn": "Trainer Column",
        "ScheduleColumn": "Schedule Column",
        "StatusColumn": "Status Column",
        "CourseNameColumn": "Course Name Column",
    },
    "StudentFeesForm": {
        "OutstandingPaymentGroupBox": "Outstanding Fees Group",
        "dataGridView1": "Outstanding Fees Data Grid",
        "InvoiceIDHiddenColumn": "Hidden Invoice ID Column",
        "ModuleColumn": "Module Column",
        "Column2": "Level Column",
        "Column3": "Trainer Column",
        "Column4": "Amount Column",
        "Column5": "Status Column",
        "ActionColumn": "Pay Now Action Column",
        "groupBox2": "Payment History Group",
        "dataGridView2": "Payment History Data Grid",
        "InvoiceIDColumn": "Invoice Column",
        "ModuleColumn2": "Paid Module Column",
        "AmountColumn": "Amount Paid Column",
        "dataGridViewTextBoxColumn4": "Payment Method Column",
        "DatePaidColumn": "Paid Date Column",
        "ReceiptColumn": "Paid Status Column",
    },
}


def normalize_value(raw: str) -> str:
    value = raw.strip().rstrip(";").strip()
    if value.startswith('"') and value.endswith('"'):
        return value[1:-1]
    return value


def escape_xml(text: str) -> str:
    return escape(text, {'"': "&quot;"})


def extract_method_body(source: str, pattern: str) -> str:
    match = re.search(pattern, source, re.MULTILINE)
    if not match:
        return ""

    brace_index = source.find("{", match.end() - 1)
    if brace_index == -1:
        return ""

    depth = 0
    for index in range(brace_index, len(source)):
        char = source[index]
        if char == "{":
            depth += 1
        elif char == "}":
            depth -= 1
            if depth == 0:
                return source[brace_index + 1:index]
    return ""


def parse_items_add_range(line: str) -> list[str] | None:
    match = re.search(r"(\w+)\.Items\.AddRange\(new object\[\]\s*\{(.*?)\}\);", line)
    if not match:
        return None
    raw_items = match.group(2)
    items = re.findall(r'"([^"]*)"', raw_items)
    return items


def get_or_create_control(controls: OrderedDict[str, dict], name: str) -> dict:
    return controls.setdefault(name, {"name": name, "type": "", "properties": OrderedDict()})


def parse_initialize_component(source: str, class_name: str, controls: OrderedDict[str, dict]) -> None:
    body = extract_method_body(source, r"private\s+void\s+InitializeComponent\s*\(\s*\)")
    if not body:
        return

    current_block = None
    for line in body.splitlines():
        block_match = re.match(r"^\s*//\s*(\w+)\s*$", line)
        if block_match:
            current_block = block_match.group(1)
            get_or_create_control(controls, current_block)
            continue

        init_match = re.match(r"^\s*(\w+)\s*=\s*new\s+([\w\.]+)\s*\(", line)
        if init_match:
            control = get_or_create_control(controls, init_match.group(1))
            control["type"] = init_match.group(2).split(".")[-1]
            continue

        items = parse_items_add_range(line)
        if items:
            target_name = re.search(r"(\w+)\.Items\.AddRange", line).group(1)
            control = get_or_create_control(controls, target_name)
            control["properties"]["Items"] = ", ".join(items)
            continue

        scoped_match = re.match(r"^\s*(\w+)\.(\w+)\s*=\s*(.+);$", line)
        if scoped_match:
            target_name, prop_name, prop_value = scoped_match.groups()
            if prop_name in {"Text", "HeaderText", "Name", "Visible"}:
                control = get_or_create_control(controls, target_name)
                control["properties"][prop_name] = normalize_value(prop_value)
            continue

        if current_block:
            local_match = re.match(r"^\s*(\w+)\s*=\s*(.+);$", line)
            if local_match:
                prop_name, prop_value = local_match.groups()
                if prop_name in {"Text", "HeaderText", "Name", "Visible"}:
                    control = get_or_create_control(controls, current_block)
                    control["properties"][prop_name] = normalize_value(prop_value)

    if class_name in controls:
        controls[class_name]["type"] = controls[class_name]["type"] or "Form"


def parse_declarations(source: str, controls: OrderedDict[str, dict]) -> None:
    for _, control_type, control_name in DECLARATION_RE.findall(source):
        control = get_or_create_control(controls, control_name)
        control["type"] = control["type"] or control_type.split(".")[-1]


def parse_constructor_overrides(source: str, class_name: str, controls: OrderedDict[str, dict]) -> None:
    body = extract_method_body(source, rf"public\s+{re.escape(class_name)}\s*\([^)]*\)")
    if not body:
        return

    for line in body.splitlines():
        scoped_match = re.match(r"^\s*(this|\w+)\.(\w+)\s*=\s*(.+);$", line)
        if not scoped_match:
            continue

        target_name, prop_name, prop_value = scoped_match.groups()
        if prop_name not in {"Text", "Visible"}:
            continue

        target_name = class_name if target_name == "this" else target_name
        control = get_or_create_control(controls, target_name)
        control["properties"][prop_name] = normalize_value(prop_value)


def parse_form(designer_path: Path) -> dict:
    code_path = designer_path.with_name(designer_path.name.replace(".Designer", ""))
    designer_source = designer_path.read_text(encoding="utf-8")
    code_source = code_path.read_text(encoding="utf-8") if code_path.exists() else ""

    class_match = CLASS_RE.search(designer_source) or CLASS_RE.search(code_source)
    if not class_match:
        raise RuntimeError(f"Unable to find class definition in {designer_path}")

    namespace, class_name = class_match.groups()
    controls: OrderedDict[str, dict] = OrderedDict()
    get_or_create_control(controls, class_name)["type"] = "Form"

    parse_declarations(designer_source, controls)
    parse_declarations(code_source, controls)
    parse_initialize_component(designer_source, class_name, controls)
    parse_initialize_component(code_source, class_name, controls)
    parse_constructor_overrides(code_source, class_name, controls)

    form_control = controls.get(class_name, {"properties": {}})
    items = [control for name, control in controls.items() if name != class_name]

    return {
        "class_name": class_name,
        "namespace": namespace,
        "section": designer_path.parent.name,
        "designer_path": designer_path,
        "code_path": code_path if code_path.exists() else None,
        "form_title": form_control.get("properties", {}).get("Text", ""),
        "items": items,
    }


def build_inventory() -> list[dict]:
    forms = [parse_form(path) for path in sorted(FORMS_ROOT.rglob("*.Designer.cs"))]
    return sorted(forms, key=lambda item: (item["section"], item["class_name"].lower()))


def p(text: str, style: str | None = None, bold: bool = False) -> str:
    style_xml = f'<w:pPr><w:pStyle w:val="{style}"/></w:pPr>' if style else ""
    run_props = "<w:rPr><w:b/></w:rPr>" if bold else ""
    return (
        "<w:p>"
        f"{style_xml}"
        "<w:r>"
        f"{run_props}"
        f"<w:t xml:space=\"preserve\">{escape_xml(text)}</w:t>"
        "</w:r>"
        "</w:p>"
    )


def table_cell(text: str, bold: bool = False, width: int = 2400) -> str:
    run_props = "<w:rPr><w:b/></w:rPr>" if bold else ""
    return (
        "<w:tc>"
        f"<w:tcPr><w:tcW w:w=\"{width}\" w:type=\"dxa\"/></w:tcPr>"
        "<w:p>"
        "<w:r>"
        f"{run_props}"
        f"<w:t xml:space=\"preserve\">{escape_xml(text)}</w:t>"
        "</w:r>"
        "</w:p>"
        "</w:tc>"
    )


def table_row(values: list[str], bold: bool = False, widths: list[int] | None = None) -> str:
    widths = widths or [2400] * len(values)
    cells = "".join(table_cell(value, bold=bold, width=widths[index]) for index, value in enumerate(values))
    return f"<w:tr>{cells}</w:tr>"


def table(rows: list[list[str]]) -> str:
    widths = [1800, 3000, 3000, 7200]
    tbl_pr = (
        "<w:tblPr>"
        "<w:tblW w:w=\"0\" w:type=\"auto\"/>"
        "<w:tblBorders>"
        "<w:top w:val=\"single\" w:sz=\"8\" w:space=\"0\" w:color=\"000000\"/>"
        "<w:left w:val=\"single\" w:sz=\"8\" w:space=\"0\" w:color=\"000000\"/>"
        "<w:bottom w:val=\"single\" w:sz=\"8\" w:space=\"0\" w:color=\"000000\"/>"
        "<w:right w:val=\"single\" w:sz=\"8\" w:space=\"0\" w:color=\"000000\"/>"
        "<w:insideH w:val=\"single\" w:sz=\"6\" w:space=\"0\" w:color=\"808080\"/>"
        "<w:insideV w:val=\"single\" w:sz=\"6\" w:space=\"0\" w:color=\"808080\"/>"
        "</w:tblBorders>"
        "</w:tblPr>"
    )
    grid = "".join(f"<w:gridCol w:w=\"{width}\"/>" for width in widths)
    header = table_row(["Type", "Name", "Text", "Description"], bold=True, widths=widths)
    body = "".join(table_row(row, widths=widths) for row in rows)
    return f"<w:tbl>{tbl_pr}<w:tblGrid>{grid}</w:tblGrid>{header}{body}</w:tbl>"


def humanize_identifier(value: str) -> str:
    value = re.sub(r"(?<!^)([A-Z])", r" \1", value)
    value = value.replace("_", " ").strip()
    return re.sub(r"\s+", " ", value)


def infer_description(item: dict) -> str:
    control_type = item["type"] or "Control"
    name = item["name"]
    text_value = (item["properties"].get("Text") or item["properties"].get("HeaderText") or "").strip()
    items_value = item["properties"].get("Items", "").strip()
    lowered_type = control_type.lower()
    label = humanize_identifier(name)

    if lowered_type in {"label"}:
        if text_value:
            return f'Displays "{text_value}" as a label or heading.'
        return f"Displays {label.lower()} information."
    if lowered_type in {"button", "iconbutton"}:
        if text_value:
            return f'Triggers the "{text_value}" action.'
        return f"Triggers the {label.lower()} action."
    if lowered_type in {"textbox"}:
        if "password" in name.lower():
            return "Text input for entering a password."
        return f"Text input for {label.lower()}."
    if lowered_type in {"combobox"}:
        return f"Dropdown selector for {label.lower()}."
    if lowered_type in {"checkedlistbox"}:
        if items_value:
            return f"Multi-select list with options: {items_value}."
        return f"Multi-select list for {label.lower()}."
    if lowered_type in {"datagridview"}:
        return f"Table for displaying {label.lower()} data."
    if lowered_type in {"datagridviewtextboxcolumn", "datagridviewbuttoncolumn", "datagridviewlinkcolumn"}:
        header_text = item["properties"].get("HeaderText") or text_value or label
        return f'Column displayed in a grid for "{header_text}".'
    if lowered_type in {"panel", "flowlayoutpanel"}:
        return f"Container used to group related UI elements for {label.lower()}."
    if lowered_type in {"groupbox"}:
        if text_value:
            return f'Groups controls under the "{text_value}" section.'
        return f"Groups related controls for {label.lower()}."
    if lowered_type in {"picturebox"}:
        return "Displays an image or logo."
    if lowered_type in {"datetimepicker"}:
        return f"Date/time selector for {label.lower()}."
    if lowered_type in {"numericupdown"}:
        return f"Numeric input for {label.lower()}."

    if text_value:
        return f'Displays or manages "{text_value}".'
    return f"UI object for {label.lower()}."


def title_case_words(text: str) -> str:
    cleaned = re.sub(r"\s+", " ", text.replace("/", " / ").strip())
    if not cleaned:
        return ""
    return " ".join(word.capitalize() if word.islower() else word for word in cleaned.split())


def fallback_proper_name(form_name: str, item: dict) -> str:
    control_type = item["type"] or "Control"
    text_value = (item["properties"].get("Text") or item["properties"].get("HeaderText") or "").strip(" :")
    base_name = humanize_identifier(item["name"])
    base_name = re.sub(r"^(lbl|txt|btn|cbo|grp|dgv|pnl)\s+", "", base_name, flags=re.IGNORECASE)

    if text_value and control_type.lower() in {"button", "iconbutton", "groupbox", "datagridviewtextboxcolumn", "datagridviewbuttoncolumn", "label"}:
        semantic = title_case_words(text_value)
    else:
        semantic = title_case_words(base_name)

    suffix_map = {
        "button": "Button",
        "iconbutton": "Button",
        "label": "Label",
        "textbox": "Text Box",
        "combobox": "Combo Box",
        "groupbox": "Group",
        "panel": "Panel",
        "flowlayoutpanel": "Panel",
        "picturebox": "Picture Box",
        "datagridview": "Data Grid",
        "datagridviewtextboxcolumn": "Column",
        "datagridviewbuttoncolumn": "Column",
        "checkedlistbox": "Checked List Box",
    }
    suffix = suffix_map.get(control_type.lower(), control_type)
    if semantic.endswith(suffix):
        return semantic
    if control_type.lower() == "iconbutton" and "Navigation" in semantic:
        return semantic
    if form_name == "StudentShellForm" and control_type.lower() == "iconbutton":
        return f"{semantic} Navigation Button"
    return f"{semantic} {suffix}".strip()


def build_student_proper_naming_doc_xml(forms: list[dict]) -> str:
    student_forms = [form for form in forms if form["section"] == "Student"]
    paragraphs = [
        p("APUCC Student UI Proper Naming", "Title"),
        p(f"Generated on {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}", "BodyText"),
        p("Student", "Heading1"),
    ]

    for form in student_forms:
        paragraphs.append(p(form["class_name"], "Heading2"))
        rows: list[list[str]] = []
        for item in form["items"]:
            proper_name = STUDENT_PROPER_NAMES.get(form["class_name"], {}).get(
                item["name"],
                fallback_proper_name(form["class_name"], item),
            )
            text_value = item["properties"].get("Text") or item["properties"].get("HeaderText") or ""
            description = f"{infer_description(item)} Existing control ID: {item['name']}."
            rows.append([
                item["type"] or "",
                proper_name,
                text_value,
                description,
            ])

        if not rows:
            rows.append(["", "", "", "No student design objects were declared in initialization."])

        paragraphs.append(table(rows))
        paragraphs.append(p(""))

    body = "".join(paragraphs) + (
        "<w:sectPr>"
        "<w:pgSz w:w=\"12240\" w:h=\"15840\"/>"
        "<w:pgMar w:top=\"1440\" w:right=\"1440\" w:bottom=\"1440\" w:left=\"1440\"/>"
        "</w:sectPr>"
    )

    return (
        "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>"
        "<w:document "
        "xmlns:wpc=\"http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas\" "
        "xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" "
        "xmlns:o=\"urn:schemas-microsoft-com:office:office\" "
        "xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" "
        "xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\" "
        "xmlns:v=\"urn:schemas-microsoft-com:vml\" "
        "xmlns:wp14=\"http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing\" "
        "xmlns:wp=\"http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing\" "
        "xmlns:w10=\"urn:schemas-microsoft-com:office:word\" "
        "xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\" "
        "xmlns:w14=\"http://schemas.microsoft.com/office/word/2010/wordml\" "
        "xmlns:wpg=\"http://schemas.microsoft.com/office/word/2010/wordprocessingGroup\" "
        "xmlns:wpi=\"http://schemas.microsoft.com/office/word/2010/wordprocessingInk\" "
        "xmlns:wne=\"http://schemas.microsoft.com/office/2006/wordml\" "
        "xmlns:wps=\"http://schemas.microsoft.com/office/word/2010/wordprocessingShape\" "
        "mc:Ignorable=\"w14 wp14\">"
        f"<w:body>{body}</w:body>"
        "</w:document>"
    )


def build_document_xml(forms: list[dict]) -> str:
    paragraphs = [
        p("APUCC UI Form Inventory", "Title"),
        p(f"Generated on {datetime.now().strftime('%Y-%m-%d %H:%M:%S')}", "BodyText"),
    ]

    grouped: dict[str, list[dict]] = {name: [] for _, names in SECTION_LAYOUT for name in names}
    for form in forms:
        grouped.setdefault(form["section"], []).append(form)

    for heading, section_names in SECTION_LAYOUT:
        paragraphs.append(p(heading, "Heading1"))
        for section_name in section_names:
            section_forms = grouped.get(section_name, [])
            if not section_forms:
                continue

            if len(section_names) > 1:
                paragraphs.append(p(section_name, "Heading2"))

            for form in section_forms:
                label = form["class_name"]
                if form["designer_path"].stem.replace(".Designer", "") != form["class_name"]:
                    label += f" (source file: {form['designer_path'].stem.replace('.Designer', '')})"

                paragraphs.append(p(label, "Heading2" if len(section_names) == 1 else "Heading3"))
                rows: list[list[str]] = []
                for item in form["items"]:
                    text_value = item["properties"].get("Text") or item["properties"].get("HeaderText") or ""
                    rows.append([
                        item["type"] or "",
                        item["name"],
                        text_value,
                        infer_description(item),
                    ])

                if not rows:
                    rows.append(["", "", "", "No form-specific design objects were declared in initialization."])

                paragraphs.append(table(rows))
                paragraphs.append(p(""))

    body = "".join(paragraphs) + (
        "<w:sectPr>"
        "<w:pgSz w:w=\"12240\" w:h=\"15840\"/>"
        "<w:pgMar w:top=\"1440\" w:right=\"1440\" w:bottom=\"1440\" w:left=\"1440\"/>"
        "</w:sectPr>"
    )

    return (
        "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>"
        "<w:document "
        "xmlns:wpc=\"http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas\" "
        "xmlns:mc=\"http://schemas.openxmlformats.org/markup-compatibility/2006\" "
        "xmlns:o=\"urn:schemas-microsoft-com:office:office\" "
        "xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\" "
        "xmlns:m=\"http://schemas.openxmlformats.org/officeDocument/2006/math\" "
        "xmlns:v=\"urn:schemas-microsoft-com:vml\" "
        "xmlns:wp14=\"http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing\" "
        "xmlns:wp=\"http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing\" "
        "xmlns:w10=\"urn:schemas-microsoft-com:office:word\" "
        "xmlns:w=\"http://schemas.openxmlformats.org/wordprocessingml/2006/main\" "
        "xmlns:w14=\"http://schemas.microsoft.com/office/word/2010/wordml\" "
        "xmlns:wpg=\"http://schemas.microsoft.com/office/word/2010/wordprocessingGroup\" "
        "xmlns:wpi=\"http://schemas.microsoft.com/office/word/2010/wordprocessingInk\" "
        "xmlns:wne=\"http://schemas.microsoft.com/office/2006/wordml\" "
        "xmlns:wps=\"http://schemas.microsoft.com/office/word/2010/wordprocessingShape\" "
        "mc:Ignorable=\"w14 wp14\">"
        f"<w:body>{body}</w:body>"
        "</w:document>"
    )


def build_styles_xml() -> str:
    return """<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<w:styles xmlns:w="http://schemas.openxmlformats.org/wordprocessingml/2006/main">
  <w:style w:type="paragraph" w:default="1" w:styleId="Normal">
    <w:name w:val="Normal"/>
    <w:qFormat/>
    <w:rPr>
      <w:rFonts w:ascii="Calibri" w:hAnsi="Calibri"/>
      <w:sz w:val="22"/>
    </w:rPr>
  </w:style>
  <w:style w:type="paragraph" w:styleId="Title">
    <w:name w:val="Title"/>
    <w:basedOn w:val="Normal"/>
    <w:qFormat/>
    <w:rPr>
      <w:b/>
      <w:sz w:val="32"/>
    </w:rPr>
  </w:style>
  <w:style w:type="paragraph" w:styleId="Heading1">
    <w:name w:val="heading 1"/>
    <w:basedOn w:val="Normal"/>
    <w:qFormat/>
    <w:rPr>
      <w:b/>
      <w:sz w:val="28"/>
    </w:rPr>
  </w:style>
  <w:style w:type="paragraph" w:styleId="Heading2">
    <w:name w:val="heading 2"/>
    <w:basedOn w:val="Normal"/>
    <w:qFormat/>
    <w:rPr>
      <w:b/>
      <w:sz w:val="24"/>
    </w:rPr>
  </w:style>
  <w:style w:type="paragraph" w:styleId="Heading3">
    <w:name w:val="heading 3"/>
    <w:basedOn w:val="Normal"/>
    <w:qFormat/>
    <w:rPr>
      <w:b/>
      <w:sz w:val="22"/>
    </w:rPr>
  </w:style>
  <w:style w:type="paragraph" w:styleId="BodyText">
    <w:name w:val="Body Text"/>
    <w:basedOn w:val="Normal"/>
  </w:style>
</w:styles>
"""


def write_docx(output_path: Path, document_xml: str) -> None:
    content_types = """<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
  <Default Extension="rels" ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
  <Default Extension="xml" ContentType="application/xml"/>
  <Override PartName="/word/document.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml"/>
  <Override PartName="/word/styles.xml" ContentType="application/vnd.openxmlformats-officedocument.wordprocessingml.styles+xml"/>
  <Override PartName="/docProps/core.xml" ContentType="application/vnd.openxmlformats-package.core-properties+xml"/>
  <Override PartName="/docProps/app.xml" ContentType="application/vnd.openxmlformats-officedocument.extended-properties+xml"/>
</Types>
"""

    root_rels = """<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
  <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument" Target="word/document.xml"/>
  <Relationship Id="rId2" Type="http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties" Target="docProps/core.xml"/>
  <Relationship Id="rId3" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties" Target="docProps/app.xml"/>
</Relationships>
"""

    document_rels = """<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
  <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles" Target="styles.xml"/>
</Relationships>
"""

    now = datetime.now(UTC).strftime("%Y-%m-%dT%H:%M:%SZ")
    core_xml = f"""<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<cp:coreProperties xmlns:cp="http://schemas.openxmlformats.org/package/2006/metadata/core-properties" xmlns:dc="http://purl.org/dc/elements/1.1/" xmlns:dcterms="http://purl.org/dc/terms/" xmlns:dcmitype="http://purl.org/dc/dcmitype/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <dc:title>APUCC UI Form Inventory</dc:title>
  <dc:creator>Codex</dc:creator>
  <cp:lastModifiedBy>Codex</cp:lastModifiedBy>
  <dcterms:created xsi:type="dcterms:W3CDTF">{now}</dcterms:created>
  <dcterms:modified xsi:type="dcterms:W3CDTF">{now}</dcterms:modified>
</cp:coreProperties>
"""

    app_xml = """<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Properties xmlns="http://schemas.openxmlformats.org/officeDocument/2006/extended-properties" xmlns:vt="http://schemas.openxmlformats.org/officeDocument/2006/docPropsVTypes">
  <Application>Microsoft Office Word</Application>
</Properties>
"""

    output_path.parent.mkdir(parents=True, exist_ok=True)
    with zipfile.ZipFile(output_path, "w", compression=zipfile.ZIP_DEFLATED) as archive:
        archive.writestr("[Content_Types].xml", content_types)
        archive.writestr("_rels/.rels", root_rels)
        archive.writestr("word/document.xml", document_xml)
        archive.writestr("word/_rels/document.xml.rels", document_rels)
        archive.writestr("word/styles.xml", build_styles_xml())
        archive.writestr("docProps/core.xml", core_xml)
        archive.writestr("docProps/app.xml", app_xml)


def main() -> int:
    forms = build_inventory()
    write_docx(OUTPUT_PATH, build_document_xml(forms))
    write_docx(STUDENT_OUTPUT_PATH, build_student_proper_naming_doc_xml(forms))
    print(f"Created {OUTPUT_PATH}")
    print(f"Created {STUDENT_OUTPUT_PATH}")
    print(f"Included {len(forms)} forms from {FORMS_ROOT}")
    return 0


if __name__ == "__main__":
    sys.exit(main())
