# Database Cleanup Report

## Scope

The original messy SQL dump was replaced for publishing. The official database scripts now live in `Database/` as `schema.sql`, `sample-data.sql`, `setup-instructions.md`, and this cleanup report.

The C# code was inspected for SQL usage through `SELECT`, `INSERT`, `UPDATE`, `DELETE`, `JOIN`, `WHERE`, `SqlCommand`, `SqlDataReader`, `ExecuteReader`, `ExecuteNonQuery`, and `ExecuteScalar`.

## Tables Found

The original database defines these tables:

- `Users`
- `Trainers`
- `Lecturers`
- `Students`
- `UserProfileDetails`
- `ClassSchedule`
- `Feedback`
- `EnrollmentRequests`
- `StudentEnrollments`
- `Invoices`
- `PaymentHistory`
- `StudentPayments`
- `Intakes`
- `Modules`
- `StudentIntakes`
- `LecturerModules`
- `TrainerAssignments`
- `WeeklySchedules`
- `StudentWeeklyEnrollments`

The app also depends on these views:

- `vw_StudentHomeSchedule`
- `vw_StudentSubscribedCourses`
- `vw_RequestableCourseOptions`
- `vw_StudentOutstandingFees`
- `vw_StudentPaymentHistory`
- `vw_UserProfiles`

## Tables and Columns Used by the C# Code

`Users`:

- `UserID`, `Username`, `Password`, `Role`, `Name`, `Email`, `Phone`, `Address`
- Used for login, role routing, profile display/update, trainer/student management, feedback display, and report names.

`Trainers`:

- `TrainerID`, `UserID`, `Qualifications`, `Specialisation`, `AssignedModuleId`, `AssignedModuleName`, `AssignedLevel`
- Used for trainer dashboards, trainer creation/editing, assignment, feedback, and class filtering.

`Lecturers`:

- `LecturerID`, `UserID`, `Department`, `Specialisation`
- Used by enrollment request approval and enrollment audit fields.

`Students`:

- `StudentID`, `UserID`, `TPNumber`, `StudyLevel`, `ContactNumber`, `StudentAddress`, `MonthOfEnrollment`, `StudentStatus`, `DateRegistered`
- Used for login role routing, student dashboard, lecturer student management, profile update, request approval, and student lists.

`ClassSchedule`:

- `Id`, `ModuleId`, `ModuleName`, `ClassDate`, `ClassTime`, `Charges`, `TrainerID`, `Level`, `Room`
- Used by trainer class management, student schedules/courses, lecturer student filters, requests, invoices, and monthly reports.

`Feedback`:

- `FeedbackID`, `TrainerID`, `FeedbackType`, `Message`, `DateSent`, `Status`
- Used for trainer feedback submission and admin feedback review.

`EnrollmentRequests`:

- `RequestID`, `StudentID`, `ClassScheduleID`, `RequestDate`, `RequestStatus`, `Remarks`, `HandledByLecturerID`, `HandledDate`
- Used for student course requests, request cancellation, lecturer approval/rejection, and student enrollment type display.

`StudentEnrollments`:

- `EnrollmentID`, `StudentID`, `ClassScheduleID`, `EnrolledDate`, `EnrollmentStatus`, `EnrolledByLecturerID`, `CompletedDate`
- Used by student home, courses, fees, lecturer student views, trainer enrolled-student view, and delete flows.

`Invoices`:

- `InvoiceID`, `EnrollmentID`, `InvoiceDate`, `Amount`, `InvoiceStatus`, `DueDate`
- Used by student fees, payment flow, invoice preview, and trainer enrolled-student view.

`PaymentHistory`:

- `PaymentHistoryID`, `InvoiceID`, `AmountPaid`, `PaymentDate`, `PaymentMethod`, `ReceiptNo`, `PaymentStatus`
- Used by student payment history, invoice preview, trainer enrolled-student view, and lecturer delete flows.

`StudentPayments`:

- `PaymentID`, `ClassScheduleID`, `StudentName`, `Amount`, `PaymentDate`, `Status`
- Used by the admin monthly income report.

`Modules`:

- `ModuleID`, `ModuleCode`, `ModuleName`, `AcademicLevel`, `CreditHours`, `Status`
- Used by admin trainer assignment dropdown.

`UserProfileDetails`:

- Read through `vw_UserProfiles`, but no direct C# writes were found.

`Intakes`, `StudentIntakes`, `LecturerModules`, `TrainerAssignments`, `WeeklySchedules`, `StudentWeeklyEnrollments`:

- Present in the original schema, but no active C# query depends on them.

## Data Kept and Why

The cleaned sample data keeps only fictional rows needed for a working demo:

- One administrator account for admin login and admin dashboard access.
- One lecturer account for lecturer login, student management, and request approval screens.
- Two trainer accounts so trainer lists, trainer assignment, class schedules, feedback, and income reports have useful data.
- Two student accounts so student login, schedules, course requests, fees, and lecturer student lists can be demonstrated.
- Five modules/classes covering current schedule, upcoming schedule, requestable course, completed enrollment, and trainer dashboards.
- Enrollment requests in `Approved`, `Pending`, and `Rejected` states.
- Active and completed enrollments.
- Paid and unpaid invoices.
- One payment history row for student payment history and invoice preview.
- Legacy `StudentPayments` rows because `AdminMonthlyIncome` reads that table directly.
- Feedback rows in `Unread` and `Read` states.

## Data Removed or Excluded

The cleaned scripts exclude:

- Real student names.
- Real TP numbers.
- Private emails.
- Real phone numbers.
- Private passwords.
- Duplicate user rows.
- Random repeated test rows.
- Raw diagnostic `SELECT *` blocks.
- Late ad-hoc updates from the original dump.
- `.bak`, `.mdf`, and `.ldf` files.

Synthetic demo identifiers such as `TP000001` and `TP000002` are included only because the existing app and database constraints require student TP-style values and `TP%@mail.apu.edu.my` email format for student accounts.

## Uncertain Data Kept for Safety

The optional academic-planning tables were kept in `schema.sql` because they exist in the original schema and may be useful for future project work:

- `Intakes`
- `StudentIntakes`
- `LecturerModules`
- `TrainerAssignments`
- `WeeklySchedules`
- `StudentWeeklyEnrollments`

Rows were not inserted into most of those optional tables because the current C# delete flows do not delete from them. Seeding those rows would make normal demo delete actions fail through foreign-key restrictions.

## Possible Warnings

- `schema.sql` drops and recreates `MyDatabase`; use it only for local demo/development setup.
- The app has some hardcoded connection strings in lecturer forms that still point to `localhost\SQLEXPRESS` and `MyDatabase`.
- Several C# forms use hardcoded current lecturer ID `1`; the sample data inserts the demo lecturer first so this remains safe for the demo.
- `StudentPayments` is a legacy reporting table and is separate from `Invoices`/`PaymentHistory`; it is still seeded because the monthly income report reads it directly.
- No C# changes were made.
