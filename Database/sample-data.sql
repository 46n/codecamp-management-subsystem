/*
    Cleaned portfolio-ready sample data for the APU CodeCamp Management System.
    This is not the original messy development dump.

    Purpose:
    - Seed fictional demo data only.
    - Support administrator, lecturer, trainer, and student login.
    - Demonstrate dashboards, classes, requests, approval flow, fees, invoices,
      payments, trainer feedback, and monthly income reports.
*/

USE MyDatabase;
GO

SET NOCOUNT ON;

DECLARE
    @adminUserId INT,
    @lecturerUserId INT,
    @trainerUserId INT,
    @trainerTwoUserId INT,
    @studentUserId INT,
    @studentTwoUserId INT,
    @lecturerId INT,
    @trainerId INT,
    @trainerTwoId INT,
    @studentId INT,
    @studentTwoId INT,
    @moduleProgrammingId INT,
    @moduleOopId INT,
    @moduleDatabaseId INT,
    @moduleWebId INT,
    @moduleAiId INT,
    @classProgrammingTodayId INT,
    @classOopTomorrowId INT,
    @classDatabaseFutureId INT,
    @classWebCompletedId INT,
    @classAiRequestableId INT,
    @enrollmentProgrammingId INT,
    @enrollmentOopId INT,
    @enrollmentWebCompletedId INT,
    @enrollmentStudentTwoDbId INT,
    @invoicePaidId INT;

INSERT INTO dbo.Users (Username, [Password], [Role], [Name], Email, Phone, [Address])
VALUES ('admin.demo', '10000001', 'Admin', 'Demo Administrator', 'admin.demo@apu.edu.my', '010-0000001', 'APU Demo Campus');
SET @adminUserId = SCOPE_IDENTITY();

INSERT INTO dbo.Users (Username, [Password], [Role], [Name], Email, Phone, [Address])
VALUES ('lecturer.demo', '10000002', 'Lecturer', 'Demo Lecturer', 'lecturer.demo@apu.edu.my', '010-0000002', 'School of Computing');
SET @lecturerUserId = SCOPE_IDENTITY();

INSERT INTO dbo.Users (Username, [Password], [Role], [Name], Email, Phone, [Address])
VALUES ('trainer.demo', '10000003', 'Trainer', 'Demo Trainer', 'trainer.demo@apu.edu.my', '010-0000003', 'CodeCamp Training Office');
SET @trainerUserId = SCOPE_IDENTITY();

INSERT INTO dbo.Users (Username, [Password], [Role], [Name], Email, Phone, [Address])
VALUES ('trainer.assistant', '10000004', 'Trainer', 'Demo Assistant Trainer', 'trainer.assistant@apu.edu.my', '010-0000004', 'CodeCamp Training Office');
SET @trainerTwoUserId = SCOPE_IDENTITY();

INSERT INTO dbo.Users (Username, [Password], [Role], [Name], Email, Phone, [Address])
VALUES ('student.demo', '10000005', 'Student', 'Demo Student One', 'TP000001@mail.apu.edu.my', '010-0000005', 'Demo Student Residence');
SET @studentUserId = SCOPE_IDENTITY();

INSERT INTO dbo.Users (Username, [Password], [Role], [Name], Email, Phone, [Address])
VALUES ('student.two', '10000006', 'Student', 'Demo Student Two', 'TP000002@mail.apu.edu.my', '010-0000006', 'Demo Student Residence');
SET @studentTwoUserId = SCOPE_IDENTITY();

INSERT INTO dbo.Lecturers (UserID, Department, Specialisation)
VALUES (@lecturerUserId, 'School of Computing', 'Object-Oriented Programming');
SET @lecturerId = SCOPE_IDENTITY();

INSERT INTO dbo.Modules (ModuleCode, ModuleName, AcademicLevel, CreditHours, Status)
VALUES
    ('PF101', 'Programming Fundamentals', 'Beginner', 3, 'Active'),
    ('IOOP102', 'Object Oriented Programming', 'Intermediate', 3, 'Active'),
    ('DB103', 'Database Systems', 'Intermediate', 3, 'Active'),
    ('WEB104', 'Web Development', 'Intermediate', 3, 'Active'),
    ('AI105', 'Introduction to Artificial Intelligence', 'Advance', 3, 'Active');

SELECT @moduleProgrammingId = ModuleID FROM dbo.Modules WHERE ModuleCode = 'PF101';
SELECT @moduleOopId = ModuleID FROM dbo.Modules WHERE ModuleCode = 'IOOP102';
SELECT @moduleDatabaseId = ModuleID FROM dbo.Modules WHERE ModuleCode = 'DB103';
SELECT @moduleWebId = ModuleID FROM dbo.Modules WHERE ModuleCode = 'WEB104';
SELECT @moduleAiId = ModuleID FROM dbo.Modules WHERE ModuleCode = 'AI105';

INSERT INTO dbo.Trainers (UserID, Qualifications, Specialisation, AssignedModuleId, AssignedModuleName, AssignedLevel)
VALUES
    (@trainerUserId, 'MSc Computing', 'C# and OOP', CONVERT(NVARCHAR(50), @moduleOopId), 'Object Oriented Programming', 'Intermediate'),
    (@trainerTwoUserId, 'BSc Software Engineering', 'Database and Web Systems', CONVERT(NVARCHAR(50), @moduleDatabaseId), 'Database Systems', 'Intermediate');

SELECT @trainerId = TrainerID FROM dbo.Trainers WHERE UserID = @trainerUserId;
SELECT @trainerTwoId = TrainerID FROM dbo.Trainers WHERE UserID = @trainerTwoUserId;

INSERT INTO dbo.Students (UserID, TPNumber, StudyLevel, ContactNumber, StudentAddress, MonthOfEnrollment, StudentStatus)
VALUES
    (@studentUserId, 'TP000001', 'Level 1', '010-0000005', 'Demo Student Residence', 'May 2026', 'Active'),
    (@studentTwoUserId, 'TP000002', 'Level 1', '010-0000006', 'Demo Student Residence', 'May 2026', 'Active');

SELECT @studentId = StudentID FROM dbo.Students WHERE UserID = @studentUserId;
SELECT @studentTwoId = StudentID FROM dbo.Students WHERE UserID = @studentTwoUserId;

INSERT INTO dbo.Intakes (IntakeCode, IntakeName, StartDate, EndDate, Status)
VALUES ('DEMO2026', 'Demo 2026 Intake', '2026-01-01', '2026-12-31', 'Active');

INSERT INTO dbo.ClassSchedule (ModuleId, ModuleName, ClassDate, ClassTime, Charges, TrainerID, [Level], Room)
VALUES
    ('PF101', 'Programming Fundamentals', CAST(GETDATE() AS DATE), '09:00', 150.00, @trainerId, 'Beginner', 'B-01'),
    ('IOOP102', 'Object Oriented Programming', DATEADD(DAY, 1, CAST(GETDATE() AS DATE)), '10:30', 200.00, @trainerId, 'Intermediate', 'B-02'),
    ('DB103', 'Database Systems', DATEADD(DAY, 2, CAST(GETDATE() AS DATE)), '14:00', 220.00, @trainerTwoId, 'Intermediate', 'C-01'),
    ('WEB104', 'Web Development', DATEADD(DAY, -7, CAST(GETDATE() AS DATE)), '11:00', 180.00, @trainerTwoId, 'Intermediate', 'C-02'),
    ('AI105', 'Introduction to Artificial Intelligence', DATEADD(DAY, 3, CAST(GETDATE() AS DATE)), '15:30', 250.00, @trainerId, 'Advance', 'D-01');

SELECT @classProgrammingTodayId = Id FROM dbo.ClassSchedule WHERE ModuleId = 'PF101';
SELECT @classOopTomorrowId = Id FROM dbo.ClassSchedule WHERE ModuleId = 'IOOP102';
SELECT @classDatabaseFutureId = Id FROM dbo.ClassSchedule WHERE ModuleId = 'DB103';
SELECT @classWebCompletedId = Id FROM dbo.ClassSchedule WHERE ModuleId = 'WEB104';
SELECT @classAiRequestableId = Id FROM dbo.ClassSchedule WHERE ModuleId = 'AI105';

INSERT INTO dbo.EnrollmentRequests (StudentID, ClassScheduleID, RequestDate, RequestStatus, Remarks, HandledByLecturerID, HandledDate)
VALUES
    (@studentId, @classOopTomorrowId, DATEADD(DAY, -1, CAST(GETDATE() AS DATE)), 'Approved', 'Approved demo request for subscribed course', @lecturerId, CAST(GETDATE() AS DATE)),
    (@studentTwoId, @classAiRequestableId, CAST(GETDATE() AS DATE), 'Pending', 'Pending demo request for lecturer approval', NULL, NULL),
    (@studentId, @classDatabaseFutureId, DATEADD(DAY, -2, CAST(GETDATE() AS DATE)), 'Rejected', 'Rejected demo request that can be retried', @lecturerId, DATEADD(DAY, -1, CAST(GETDATE() AS DATE)));

INSERT INTO dbo.StudentEnrollments (StudentID, ClassScheduleID, EnrolledDate, EnrollmentStatus, EnrolledByLecturerID, CompletedDate)
VALUES
    (@studentId, @classProgrammingTodayId, CAST(GETDATE() AS DATE), 'Active', @lecturerId, NULL),
    (@studentId, @classOopTomorrowId, CAST(GETDATE() AS DATE), 'Active', @lecturerId, NULL),
    (@studentId, @classWebCompletedId, DATEADD(DAY, -7, CAST(GETDATE() AS DATE)), 'Completed', @lecturerId, DATEADD(DAY, -1, CAST(GETDATE() AS DATE))),
    (@studentTwoId, @classDatabaseFutureId, CAST(GETDATE() AS DATE), 'Active', @lecturerId, NULL);

SELECT @enrollmentProgrammingId = EnrollmentID FROM dbo.StudentEnrollments WHERE StudentID = @studentId AND ClassScheduleID = @classProgrammingTodayId;
SELECT @enrollmentOopId = EnrollmentID FROM dbo.StudentEnrollments WHERE StudentID = @studentId AND ClassScheduleID = @classOopTomorrowId;
SELECT @enrollmentWebCompletedId = EnrollmentID FROM dbo.StudentEnrollments WHERE StudentID = @studentId AND ClassScheduleID = @classWebCompletedId;
SELECT @enrollmentStudentTwoDbId = EnrollmentID FROM dbo.StudentEnrollments WHERE StudentID = @studentTwoId AND ClassScheduleID = @classDatabaseFutureId;

INSERT INTO dbo.Invoices (EnrollmentID, InvoiceDate, Amount, InvoiceStatus, DueDate)
VALUES
    (@enrollmentProgrammingId, CAST(GETDATE() AS DATE), 150.00, 'Unpaid', DATEADD(DAY, 14, CAST(GETDATE() AS DATE))),
    (@enrollmentOopId, DATEADD(DAY, -1, CAST(GETDATE() AS DATE)), 200.00, 'Paid', DATEADD(DAY, 13, CAST(GETDATE() AS DATE))),
    (@enrollmentWebCompletedId, DATEADD(DAY, -7, CAST(GETDATE() AS DATE)), 180.00, 'Paid', DATEADD(DAY, 7, CAST(GETDATE() AS DATE))),
    (@enrollmentStudentTwoDbId, CAST(GETDATE() AS DATE), 220.00, 'Unpaid', DATEADD(DAY, 14, CAST(GETDATE() AS DATE)));

SELECT @invoicePaidId = InvoiceID FROM dbo.Invoices WHERE EnrollmentID = @enrollmentOopId;

INSERT INTO dbo.PaymentHistory (InvoiceID, AmountPaid, PaymentDate, PaymentMethod, ReceiptNo, PaymentStatus)
VALUES
    (@invoicePaidId, 200.00, CAST(GETDATE() AS DATE), 'Online Banking', CONCAT('RCPT-DEMO-', @invoicePaidId), 'Paid');

INSERT INTO dbo.StudentPayments (ClassScheduleID, StudentName, Amount, PaymentDate, [Status])
VALUES
    (@classOopTomorrowId, 'Demo Student One', 200.00, CAST(GETDATE() AS DATE), 'Paid'),
    (@classWebCompletedId, 'Demo Student One', 180.00, CAST(GETDATE() AS DATE), 'Paid');

INSERT INTO dbo.Feedback (TrainerID, FeedbackType, [Message], DateSent, [Status])
VALUES
    (@trainerId, 'Suggestion', 'Demo feedback: add more lab exercises for OOP students.', CAST(GETDATE() AS DATE), 'Unread'),
    (@trainerTwoId, 'General', 'Demo feedback: database class attendance was good this week.', DATEADD(DAY, -1, CAST(GETDATE() AS DATE)), 'Read');

PRINT 'Clean fictional demo data inserted successfully.';
PRINT 'Demo logins: admin.demo / 10000001, lecturer.demo / 10000002, trainer.demo / 10000003, student.demo / 10000005.';
GO
