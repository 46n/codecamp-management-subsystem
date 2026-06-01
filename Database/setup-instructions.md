# Clean Database Setup Instructions

These scripts are the official cleaned, portfolio-ready database scripts for the IOOP APU CodeCamp project. The old development dump has been replaced by this split schema/data setup.

## Files

- `schema.sql` recreates the `MyDatabase` database, tables, keys, constraints, relationships, and app-required views.
- `sample-data.sql` inserts fictional demo rows only.
- `database-cleanup-report.md` explains what was kept, removed, and why.

## Setup

1. Open SQL Server Management Studio, Azure Data Studio, or another SQL Server tool.
2. Connect to `localhost\SQLEXPRESS` using Windows authentication.
3. Run `schema.sql`.
4. Run `sample-data.sql`.
5. Confirm the WinForms app connection string still points to:

```text
Data Source=localhost\SQLEXPRESS;Initial Catalog=MyDatabase;Integrated Security=True;TrustServerCertificate=True
```

## Demo Logins

| Role | Username | Password |
| --- | --- | --- |
| Administrator | `admin.demo` | `10000001` |
| Lecturer | `lecturer.demo` | `10000002` |
| Trainer | `trainer.demo` | `10000003` |
| Student | `student.demo` | `10000005` |

All names, emails, phone numbers, TP-style identifiers, and passwords are fictional demo placeholders.

## Important Safety Note

`schema.sql` drops and recreates `MyDatabase`. Run it only in a local development/demo environment, not against a database containing work you need to keep.
