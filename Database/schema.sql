/*
    Cleaned portfolio-ready schema for the APU CodeCamp Management System.
    This is not the original messy development dump.

    Purpose:
    - Recreate the MyDatabase database structure used by the WinForms app.
    - Keep tables, columns, keys, constraints, relationships, and required views.
    - Keep data out of this file; use sample-data.sql for demo rows.
*/

USE master;
GO

IF DB_ID('MyDatabase') IS NOT NULL
BEGIN
    ALTER DATABASE MyDatabase SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MyDatabase;
END;
GO

CREATE DATABASE MyDatabase;
GO

USE MyDatabase;
GO

CREATE TABLE dbo.Users
(
    UserID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL CONSTRAINT UQ_Users_Username UNIQUE,
    [Password] NVARCHAR(100) NOT NULL,
    [Role] NVARCHAR(20) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    [Address] NVARCHAR(200) NULL,
    CONSTRAINT CHK_Users_Role CHECK ([Role] IN ('Admin', 'Trainer', 'Lecturer', 'Student')),
    CONSTRAINT CHK_Users_Password_Length CHECK (LEN([Password]) >= 8),
    CONSTRAINT CHK_Users_Email_Format CHECK
    (
        ([Role] = 'Student' AND Email LIKE 'TP%@mail.apu.edu.my')
        OR
        ([Role] IN ('Admin', 'Trainer', 'Lecturer') AND Email LIKE '%@apu.edu.my' AND Email NOT LIKE '%@mail.apu.edu.my')
    )
);
GO

CREATE TABLE dbo.Trainers
(
    TrainerID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Trainers PRIMARY KEY,
    UserID INT NOT NULL CONSTRAINT UQ_Trainers_UserID UNIQUE,
    Qualifications NVARCHAR(100) NULL,
    Specialisation NVARCHAR(100) NULL,
    AssignedModuleId NVARCHAR(50) NULL,
    AssignedModuleName NVARCHAR(100) NULL,
    AssignedLevel NVARCHAR(20) NULL,
    CONSTRAINT FK_Trainers_Users FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID)
);
GO

CREATE TABLE dbo.Lecturers
(
    LecturerID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Lecturers PRIMARY KEY,
    UserID INT NOT NULL CONSTRAINT UQ_Lecturers_UserID UNIQUE,
    Department NVARCHAR(100) NULL,
    Specialisation NVARCHAR(100) NULL,
    CONSTRAINT FK_Lecturers_Users FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID)
);
GO

CREATE TABLE dbo.Students
(
    StudentID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Students PRIMARY KEY,
    UserID INT NOT NULL CONSTRAINT UQ_Students_UserID UNIQUE,
    TPNumber NVARCHAR(20) NOT NULL CONSTRAINT UQ_Students_TPNumber UNIQUE,
    StudyLevel NVARCHAR(20) NOT NULL,
    ContactNumber NVARCHAR(20) NULL,
    StudentAddress NVARCHAR(200) NULL,
    MonthOfEnrollment NVARCHAR(20) NULL,
    StudentStatus NVARCHAR(20) NOT NULL CONSTRAINT DF_Students_StudentStatus DEFAULT 'Active',
    DateRegistered DATE NOT NULL CONSTRAINT DF_Students_DateRegistered DEFAULT (GETDATE()),
    CONSTRAINT FK_Students_Users FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID)
);
GO

CREATE TABLE dbo.UserProfileDetails
(
    UserProfileDetailID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_UserProfileDetails PRIMARY KEY,
    UserID INT NOT NULL CONSTRAINT UQ_UserProfileDetails_UserID UNIQUE,
    ProfileCode NVARCHAR(30) NULL,
    SecondaryCode NVARCHAR(60) NULL,
    IdentityNumber NVARCHAR(50) NULL,
    Country NVARCHAR(60) NULL,
    ProgrammeName NVARCHAR(150) NULL,
    MentorName NVARCHAR(100) NULL,
    ProgrammeLeader NVARCHAR(100) NULL,
    PassExpiryDate DATE NULL,
    CONSTRAINT FK_UserProfileDetails_Users FOREIGN KEY (UserID) REFERENCES dbo.Users(UserID)
);
GO

CREATE TABLE dbo.ClassSchedule
(
    Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ClassSchedule PRIMARY KEY,
    ModuleId NVARCHAR(50) NOT NULL,
    ModuleName NVARCHAR(100) NOT NULL,
    ClassDate DATE NOT NULL,
    ClassTime TIME NOT NULL,
    Charges DECIMAL(10,2) NOT NULL,
    TrainerID INT NULL,
    [Level] NVARCHAR(20) NULL,
    Room NVARCHAR(50) NULL,
    CONSTRAINT FK_ClassSchedule_Trainers FOREIGN KEY (TrainerID) REFERENCES dbo.Trainers(TrainerID),
    CONSTRAINT UQ_ClassSchedule_ModuleDateTime UNIQUE (ModuleId, ClassDate, ClassTime)
);
GO

CREATE TABLE dbo.Feedback
(
    FeedbackID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Feedback PRIMARY KEY,
    TrainerID INT NOT NULL,
    FeedbackType NVARCHAR(20) NOT NULL,
    [Message] NVARCHAR(500) NOT NULL,
    DateSent DATE NOT NULL CONSTRAINT DF_Feedback_DateSent DEFAULT (GETDATE()),
    [Status] NVARCHAR(20) NOT NULL CONSTRAINT DF_Feedback_Status DEFAULT 'Unread',
    CONSTRAINT FK_Feedback_Trainers FOREIGN KEY (TrainerID) REFERENCES dbo.Trainers(TrainerID)
);
GO

CREATE TABLE dbo.EnrollmentRequests
(
    RequestID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_EnrollmentRequests PRIMARY KEY,
    StudentID INT NOT NULL,
    ClassScheduleID INT NOT NULL,
    RequestDate DATE NOT NULL CONSTRAINT DF_EnrollmentRequests_RequestDate DEFAULT (GETDATE()),
    RequestStatus NVARCHAR(20) NOT NULL CONSTRAINT DF_EnrollmentRequests_RequestStatus DEFAULT 'Pending',
    Remarks NVARCHAR(255) NULL,
    HandledByLecturerID INT NULL,
    HandledDate DATE NULL,
    CONSTRAINT FK_EnrollmentRequests_Students FOREIGN KEY (StudentID) REFERENCES dbo.Students(StudentID),
    CONSTRAINT FK_EnrollmentRequests_ClassSchedule FOREIGN KEY (ClassScheduleID) REFERENCES dbo.ClassSchedule(Id),
    CONSTRAINT FK_EnrollmentRequests_Lecturers FOREIGN KEY (HandledByLecturerID) REFERENCES dbo.Lecturers(LecturerID)
);
GO

CREATE UNIQUE INDEX UQ_EnrollmentRequests_Student_Class
ON dbo.EnrollmentRequests(StudentID, ClassScheduleID);
GO

CREATE TABLE dbo.StudentEnrollments
(
    EnrollmentID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_StudentEnrollments PRIMARY KEY,
    StudentID INT NOT NULL,
    ClassScheduleID INT NOT NULL,
    EnrolledDate DATE NOT NULL CONSTRAINT DF_StudentEnrollments_EnrolledDate DEFAULT (GETDATE()),
    EnrollmentStatus NVARCHAR(20) NOT NULL CONSTRAINT DF_StudentEnrollments_Status DEFAULT 'Active',
    EnrolledByLecturerID INT NULL,
    CompletedDate DATE NULL,
    CONSTRAINT FK_StudentEnrollments_Students FOREIGN KEY (StudentID) REFERENCES dbo.Students(StudentID),
    CONSTRAINT FK_StudentEnrollments_ClassSchedule FOREIGN KEY (ClassScheduleID) REFERENCES dbo.ClassSchedule(Id),
    CONSTRAINT FK_StudentEnrollments_Lecturers FOREIGN KEY (EnrolledByLecturerID) REFERENCES dbo.Lecturers(LecturerID)
);
GO

CREATE UNIQUE INDEX UQ_StudentEnrollments_Student_Class
ON dbo.StudentEnrollments(StudentID, ClassScheduleID);
GO

CREATE TABLE dbo.Invoices
(
    InvoiceID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Invoices PRIMARY KEY,
    EnrollmentID INT NOT NULL,
    InvoiceDate DATE NOT NULL CONSTRAINT DF_Invoices_InvoiceDate DEFAULT (GETDATE()),
    Amount DECIMAL(10,2) NOT NULL,
    InvoiceStatus NVARCHAR(20) NOT NULL CONSTRAINT DF_Invoices_Status DEFAULT 'Unpaid',
    DueDate DATE NULL,
    CONSTRAINT FK_Invoices_StudentEnrollments FOREIGN KEY (EnrollmentID) REFERENCES dbo.StudentEnrollments(EnrollmentID)
);
GO

CREATE TABLE dbo.PaymentHistory
(
    PaymentHistoryID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_PaymentHistory PRIMARY KEY,
    InvoiceID INT NOT NULL,
    AmountPaid DECIMAL(10,2) NOT NULL,
    PaymentDate DATE NOT NULL CONSTRAINT DF_PaymentHistory_PaymentDate DEFAULT (GETDATE()),
    PaymentMethod NVARCHAR(30) NULL,
    ReceiptNo NVARCHAR(50) NULL,
    PaymentStatus NVARCHAR(20) NOT NULL CONSTRAINT DF_PaymentHistory_Status DEFAULT 'Paid',
    CONSTRAINT FK_PaymentHistory_Invoices FOREIGN KEY (InvoiceID) REFERENCES dbo.Invoices(InvoiceID)
);
GO

CREATE TABLE dbo.StudentPayments
(
    PaymentID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_StudentPayments PRIMARY KEY,
    ClassScheduleID INT NOT NULL,
    StudentName NVARCHAR(100) NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentDate DATE NOT NULL CONSTRAINT DF_StudentPayments_PaymentDate DEFAULT (GETDATE()),
    [Status] NVARCHAR(20) NOT NULL CONSTRAINT DF_StudentPayments_Status DEFAULT 'Paid',
    CONSTRAINT FK_StudentPayments_ClassSchedule FOREIGN KEY (ClassScheduleID) REFERENCES dbo.ClassSchedule(Id)
);
GO

CREATE TABLE dbo.Intakes
(
    IntakeID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Intakes PRIMARY KEY,
    IntakeCode NVARCHAR(20) NOT NULL CONSTRAINT UQ_Intakes_IntakeCode UNIQUE,
    IntakeName NVARCHAR(100) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_Intakes_Status DEFAULT 'Active'
);
GO

CREATE TABLE dbo.Modules
(
    ModuleID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Modules PRIMARY KEY,
    ModuleCode NVARCHAR(20) NOT NULL CONSTRAINT UQ_Modules_ModuleCode UNIQUE,
    ModuleName NVARCHAR(100) NOT NULL,
    AcademicLevel NVARCHAR(20) NOT NULL,
    CreditHours INT NULL,
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_Modules_Status DEFAULT 'Active'
);
GO

CREATE TABLE dbo.StudentIntakes
(
    StudentIntakeID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_StudentIntakes PRIMARY KEY,
    StudentID INT NOT NULL,
    IntakeID INT NOT NULL,
    AssignedDate DATE NOT NULL CONSTRAINT DF_StudentIntakes_AssignedDate DEFAULT (GETDATE()),
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_StudentIntakes_Status DEFAULT 'Active',
    CONSTRAINT FK_StudentIntakes_Students FOREIGN KEY (StudentID) REFERENCES dbo.Students(StudentID),
    CONSTRAINT FK_StudentIntakes_Intakes FOREIGN KEY (IntakeID) REFERENCES dbo.Intakes(IntakeID)
);
GO

CREATE TABLE dbo.LecturerModules
(
    LecturerModuleID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_LecturerModules PRIMARY KEY,
    LecturerID INT NOT NULL,
    ModuleID INT NOT NULL,
    IntakeID INT NOT NULL,
    AssignedDate DATE NOT NULL CONSTRAINT DF_LecturerModules_AssignedDate DEFAULT (GETDATE()),
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_LecturerModules_Status DEFAULT 'Active',
    CONSTRAINT FK_LecturerModules_Lecturers FOREIGN KEY (LecturerID) REFERENCES dbo.Lecturers(LecturerID),
    CONSTRAINT FK_LecturerModules_Modules FOREIGN KEY (ModuleID) REFERENCES dbo.Modules(ModuleID),
    CONSTRAINT FK_LecturerModules_Intakes FOREIGN KEY (IntakeID) REFERENCES dbo.Intakes(IntakeID)
);
GO

CREATE TABLE dbo.TrainerAssignments
(
    TrainerAssignmentID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_TrainerAssignments PRIMARY KEY,
    TrainerID INT NOT NULL,
    ModuleID INT NOT NULL,
    IntakeID INT NULL,
    CoachingLevel NVARCHAR(20) NOT NULL,
    AssignedDate DATE NOT NULL CONSTRAINT DF_TrainerAssignments_AssignedDate DEFAULT (GETDATE()),
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_TrainerAssignments_Status DEFAULT 'Active',
    CONSTRAINT FK_TrainerAssignments_Trainers FOREIGN KEY (TrainerID) REFERENCES dbo.Trainers(TrainerID),
    CONSTRAINT FK_TrainerAssignments_Modules FOREIGN KEY (ModuleID) REFERENCES dbo.Modules(ModuleID),
    CONSTRAINT FK_TrainerAssignments_Intakes FOREIGN KEY (IntakeID) REFERENCES dbo.Intakes(IntakeID)
);
GO

CREATE TABLE dbo.WeeklySchedules
(
    WeeklyScheduleID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_WeeklySchedules PRIMARY KEY,
    ModuleID INT NOT NULL,
    IntakeID INT NOT NULL,
    TrainerID INT NULL,
    LecturerID INT NULL,
    CoachingLevel NVARCHAR(20) NOT NULL,
    DayOfWeek NVARCHAR(20) NOT NULL,
    StartTime TIME NOT NULL,
    EndTime TIME NULL,
    Room NVARCHAR(50) NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,
    Status NVARCHAR(20) NOT NULL CONSTRAINT DF_WeeklySchedules_Status DEFAULT 'Active',
    CONSTRAINT FK_WeeklySchedules_Modules FOREIGN KEY (ModuleID) REFERENCES dbo.Modules(ModuleID),
    CONSTRAINT FK_WeeklySchedules_Intakes FOREIGN KEY (IntakeID) REFERENCES dbo.Intakes(IntakeID),
    CONSTRAINT FK_WeeklySchedules_Trainers FOREIGN KEY (TrainerID) REFERENCES dbo.Trainers(TrainerID),
    CONSTRAINT FK_WeeklySchedules_Lecturers FOREIGN KEY (LecturerID) REFERENCES dbo.Lecturers(LecturerID)
);
GO

CREATE TABLE dbo.StudentWeeklyEnrollments
(
    StudentWeeklyEnrollmentID INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_StudentWeeklyEnrollments PRIMARY KEY,
    StudentID INT NOT NULL,
    WeeklyScheduleID INT NOT NULL,
    EnrollmentDate DATE NOT NULL CONSTRAINT DF_StudentWeeklyEnrollments_EnrollmentDate DEFAULT (GETDATE()),
    EnrollmentStatus NVARCHAR(20) NOT NULL CONSTRAINT DF_StudentWeeklyEnrollments_Status DEFAULT 'Active',
    CONSTRAINT FK_StudentWeeklyEnrollments_Students FOREIGN KEY (StudentID) REFERENCES dbo.Students(StudentID),
    CONSTRAINT FK_StudentWeeklyEnrollments_WeeklySchedules FOREIGN KEY (WeeklyScheduleID) REFERENCES dbo.WeeklySchedules(WeeklyScheduleID)
);
GO

CREATE VIEW dbo.vw_StudentHomeSchedule
AS
SELECT
    se.EnrollmentID,
    se.StudentID,
    cs.Id AS ClassScheduleID,
    cs.ModuleId,
    cs.ModuleName AS Module,
    ISNULL(tu.[Name], 'TBA') AS Trainer,
    CONVERT(VARCHAR(10), cs.ClassDate, 23) AS [Date],
    DATENAME(WEEKDAY, cs.ClassDate) AS [Day],
    CONVERT(VARCHAR(5), cs.ClassTime, 108) AS [Time],
    ISNULL(cs.Room, 'TBA') AS Room,
    se.EnrollmentStatus,
    CASE
        WHEN cs.ClassDate = CAST(GETDATE() AS DATE) THEN 'Current'
        WHEN cs.ClassDate = DATEADD(DAY, 1, CAST(GETDATE() AS DATE)) THEN 'Upcoming'
        ELSE 'Hidden'
    END AS ScheduleType,
    CASE
        WHEN cs.ClassDate IN (CAST(GETDATE() AS DATE), DATEADD(DAY, 1, CAST(GETDATE() AS DATE))) THEN CAST(1 AS BIT)
        ELSE CAST(0 AS BIT)
    END AS IsVisibleOnHome,
    cs.ClassDate AS SortDate,
    cs.ClassTime AS SortTime
FROM dbo.StudentEnrollments se
INNER JOIN dbo.ClassSchedule cs ON se.ClassScheduleID = cs.Id
LEFT JOIN dbo.Trainers t ON cs.TrainerID = t.TrainerID
LEFT JOIN dbo.Users tu ON t.UserID = tu.UserID
WHERE se.EnrollmentStatus = 'Active';
GO

CREATE VIEW dbo.vw_StudentSubscribedCourses
AS
SELECT
    se.EnrollmentID,
    se.StudentID,
    cs.Id AS ClassScheduleID,
    cs.ModuleName AS CourseName,
    ISNULL(tu.[Name], 'TBA') AS Trainer,
    CONCAT(
        CONVERT(VARCHAR(10), cs.ClassDate, 23),
        ' (',
        DATENAME(WEEKDAY, cs.ClassDate),
        ') ',
        CONVERT(VARCHAR(5), cs.ClassTime, 108),
        ' - ',
        ISNULL(cs.Room, 'TBA')
    ) AS Schedule,
    se.EnrollmentStatus AS [Status],
    cs.ClassDate AS SortDate,
    cs.ClassTime AS SortTime
FROM dbo.StudentEnrollments se
INNER JOIN dbo.ClassSchedule cs ON se.ClassScheduleID = cs.Id
LEFT JOIN dbo.Trainers t ON cs.TrainerID = t.TrainerID
LEFT JOIN dbo.Users tu ON t.UserID = tu.UserID
WHERE se.EnrollmentStatus = 'Active';
GO

CREATE VIEW dbo.vw_RequestableCourseOptions
AS
SELECT
    cs.Id AS ClassScheduleID,
    cs.ModuleName AS CourseName,
    ISNULL(tu.[Name], 'TBA') AS Trainer,
    cs.[Level],
    CONCAT(
        cs.ModuleName,
        ' | ',
        CONVERT(VARCHAR(10), cs.ClassDate, 23),
        ' ',
        CONVERT(VARCHAR(5), cs.ClassTime, 108),
        ' | ',
        DATENAME(WEEKDAY, cs.ClassDate),
        ' | Room ',
        ISNULL(cs.Room, 'TBA'),
        ' | Trainer ',
        ISNULL(tu.[Name], 'TBA')
    ) AS DisplayText,
    cs.ClassDate AS SortDate,
    cs.ClassTime AS SortTime
FROM dbo.ClassSchedule cs
LEFT JOIN dbo.Trainers t ON cs.TrainerID = t.TrainerID
LEFT JOIN dbo.Users tu ON t.UserID = tu.UserID
WHERE cs.ClassDate >= CAST(GETDATE() AS DATE);
GO

CREATE VIEW dbo.vw_StudentOutstandingFees
AS
SELECT
    i.InvoiceID,
    se.StudentID,
    cs.ModuleName AS Module,
    cs.[Level],
    ISNULL(tu.[Name], 'TBA') AS Trainer,
    CONCAT('RM ', CONVERT(VARCHAR(20), CAST(i.Amount AS DECIMAL(10,2)))) AS Fee,
    i.InvoiceStatus AS [Status],
    i.DueDate AS SortDueDate
FROM dbo.Invoices i
INNER JOIN dbo.StudentEnrollments se ON i.EnrollmentID = se.EnrollmentID
INNER JOIN dbo.ClassSchedule cs ON se.ClassScheduleID = cs.Id
LEFT JOIN dbo.Trainers t ON cs.TrainerID = t.TrainerID
LEFT JOIN dbo.Users tu ON t.UserID = tu.UserID
WHERE i.InvoiceStatus = 'Unpaid';
GO

CREATE VIEW dbo.vw_StudentPaymentHistory
AS
SELECT
    ph.PaymentHistoryID,
    se.StudentID,
    CONCAT('INV-', i.InvoiceID) AS InvoiceNo,
    cs.ModuleName AS Module,
    CONCAT('RM ', CONVERT(VARCHAR(20), CAST(ph.AmountPaid AS DECIMAL(10,2)))) AS AmountPaid,
    ISNULL(ph.PaymentMethod, 'Online Banking') AS PaymentMethod,
    CONVERT(VARCHAR(10), ph.PaymentDate, 23) AS PaidDate,
    ph.PaymentDate AS SortPaymentDate
FROM dbo.PaymentHistory ph
INNER JOIN dbo.Invoices i ON ph.InvoiceID = i.InvoiceID
INNER JOIN dbo.StudentEnrollments se ON i.EnrollmentID = se.EnrollmentID
INNER JOIN dbo.ClassSchedule cs ON se.ClassScheduleID = cs.Id
WHERE ph.PaymentStatus = 'Paid';
GO

CREATE VIEW dbo.vw_UserProfiles
AS
SELECT
    u.UserID,
    u.Username,
    u.[Role],
    u.[Name] AS FullName,
    u.Email,
    u.[Password] AS CurrentPassword,
    u.Phone,
    u.[Address],
    COALESCE(NULLIF(upd.ProfileCode, ''), NULLIF(s.TPNumber, ''), CONCAT('USER-', RIGHT(CONCAT('0000', u.UserID), 4))) AS PrimaryCode,
    COALESCE(NULLIF(upd.SecondaryCode, ''), NULLIF(s.StudyLevel, ''), u.[Role]) AS SecondaryCode,
    upd.IdentityNumber,
    upd.Country,
    upd.ProgrammeName,
    upd.MentorName,
    upd.ProgrammeLeader,
    upd.PassExpiryDate
FROM dbo.Users u
LEFT JOIN dbo.Students s ON u.UserID = s.UserID
LEFT JOIN dbo.UserProfileDetails upd ON u.UserID = upd.UserID;
GO
