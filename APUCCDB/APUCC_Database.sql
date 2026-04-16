/* =========================================
   APU CodeCamp Management System
   Full Database Script
   Updated from older version
   Keeps existing tables and adds university-style structure
========================================= */

USE master;
GO

IF DB_ID('MyDatabase') IS NOT NULL
BEGIN
    ALTER DATABASE MyDatabase SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE MyDatabase;
END
GO

CREATE DATABASE MyDatabase;
GO

USE MyDatabase;
GO

/* =========================================
   1. USERS TABLE
========================================= */
CREATE TABLE Users
(
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    [Password] NVARCHAR(100) NOT NULL,
    [Role] NVARCHAR(20) NOT NULL,
    [Name] NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Phone NVARCHAR(20) NOT NULL,
    [Address] NVARCHAR(200) NULL
);
GO

ALTER TABLE Users
ADD CONSTRAINT CHK_Users_Role
CHECK ([Role] IN ('Admin', 'Trainer', 'Lecturer', 'Student'));
GO

ALTER TABLE Users
ADD CONSTRAINT CHK_Users_Email_Format
CHECK
(
    ([Role] = 'Student' AND Email LIKE 'TP%@mail.apu.edu.my')
    OR
    ([Role] IN ('Admin', 'Trainer', 'Lecturer') AND Email LIKE '%@apu.edu.my' AND Email NOT LIKE '%@mail.apu.edu.my')
);
GO

/* =========================================
   2. TRAINERS TABLE
========================================= */
CREATE TABLE Trainers
(
    TrainerID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL UNIQUE,
    Qualifications NVARCHAR(100) NULL,
    Specialisation NVARCHAR(100) NULL,
    AssignedModuleId NVARCHAR(50) NULL,
    AssignedModuleName NVARCHAR(100) NULL,
    AssignedLevel NVARCHAR(20) NULL,
    CONSTRAINT FK_Trainers_Users
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

/* =========================================
   3. LECTURERS TABLE
========================================= */
CREATE TABLE Lecturers
(
    LecturerID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL UNIQUE,
    Department NVARCHAR(100) NULL,
    Specialisation NVARCHAR(100) NULL,
    CONSTRAINT FK_Lecturers_Users
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

/* =========================================
   4. STUDENTS TABLE
========================================= */
CREATE TABLE Students
(
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL UNIQUE,
    TPNumber NVARCHAR(20) NOT NULL UNIQUE,
    StudyLevel NVARCHAR(20) NOT NULL,
    ContactNumber NVARCHAR(20) NULL,
    StudentAddress NVARCHAR(200) NULL,
    MonthOfEnrollment NVARCHAR(20) NULL,
    StudentStatus NVARCHAR(20) NOT NULL DEFAULT 'Active',
    DateRegistered DATE NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Students_Users
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

ALTER TABLE Users
ADD CONSTRAINT CHK_Users_Password_Length
CHECK (LEN([Password]) >= 8);
GO

/* =========================================
   4A. USER PROFILE DETAILS TABLE
   Shared profile extension for all roles
========================================= */
CREATE TABLE UserProfileDetails
(
    UserProfileDetailID INT PRIMARY KEY IDENTITY(1,1),
    UserID INT NOT NULL UNIQUE,
    ProfileCode NVARCHAR(30) NULL,
    SecondaryCode NVARCHAR(60) NULL,
    IdentityNumber NVARCHAR(50) NULL,
    Country NVARCHAR(60) NULL,
    ProgrammeName NVARCHAR(150) NULL,
    MentorName NVARCHAR(100) NULL,
    ProgrammeLeader NVARCHAR(100) NULL,
    PassExpiryDate DATE NULL,
    CONSTRAINT FK_UserProfileDetails_Users
        FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

/* =========================================
   5. CLASS SCHEDULE TABLE
   Original table kept for compatibility
========================================= */
CREATE TABLE ClassSchedule
(
    Id INT PRIMARY KEY IDENTITY(1,1),
    ModuleId NVARCHAR(50) NOT NULL,
    ModuleName NVARCHAR(100) NOT NULL,
    ClassDate DATE NOT NULL,
    ClassTime TIME NOT NULL,
    Charges DECIMAL(10,2) NOT NULL,
    TrainerID INT NULL,
    [Level] NVARCHAR(20) NULL,
    Room NVARCHAR(50) NULL,
    CONSTRAINT FK_ClassSchedule_Trainers
        FOREIGN KEY (TrainerID) REFERENCES Trainers(TrainerID)
);
GO

ALTER TABLE ClassSchedule
ADD CONSTRAINT UQ_ClassSchedule_ModuleDateTime
UNIQUE (ModuleId, ClassDate, ClassTime);
GO

/* =========================================
   6. FEEDBACK TABLE
========================================= */
CREATE TABLE Feedback
(
    FeedbackID INT PRIMARY KEY IDENTITY(1,1),
    TrainerID INT NOT NULL,
    FeedbackType NVARCHAR(20) NOT NULL,
    [Message] NVARCHAR(500) NOT NULL,
    DateSent DATE NOT NULL DEFAULT GETDATE(),
    [Status] NVARCHAR(20) NOT NULL DEFAULT 'Unread',
    CONSTRAINT FK_Feedback_Trainers
        FOREIGN KEY (TrainerID) REFERENCES Trainers(TrainerID)
);
GO

/* =========================================
   7. ENROLLMENT REQUESTS TABLE
========================================= */
CREATE TABLE EnrollmentRequests
(
    RequestID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    ClassScheduleID INT NOT NULL,
    RequestDate DATE NOT NULL DEFAULT GETDATE(),
    RequestStatus NVARCHAR(20) NOT NULL DEFAULT 'Pending',
    Remarks NVARCHAR(255) NULL,
    HandledByLecturerID INT NULL,
    HandledDate DATE NULL,
    CONSTRAINT FK_EnrollmentRequests_Students
        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_EnrollmentRequests_ClassSchedule
        FOREIGN KEY (ClassScheduleID) REFERENCES ClassSchedule(Id),
    CONSTRAINT FK_EnrollmentRequests_Lecturers
        FOREIGN KEY (HandledByLecturerID) REFERENCES Lecturers(LecturerID)
);
GO

CREATE UNIQUE INDEX UQ_EnrollmentRequests_Student_Class
ON EnrollmentRequests(StudentID, ClassScheduleID);
GO

/* =========================================
   8. STUDENT ENROLLMENTS TABLE
========================================= */
CREATE TABLE StudentEnrollments
(
    EnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    ClassScheduleID INT NOT NULL,
    EnrolledDate DATE NOT NULL DEFAULT GETDATE(),
    EnrollmentStatus NVARCHAR(20) NOT NULL DEFAULT 'Active',
    EnrolledByLecturerID INT NULL,
    CompletedDate DATE NULL,
    CONSTRAINT FK_StudentEnrollments_Students
        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_StudentEnrollments_ClassSchedule
        FOREIGN KEY (ClassScheduleID) REFERENCES ClassSchedule(Id),
    CONSTRAINT FK_StudentEnrollments_Lecturers
        FOREIGN KEY (EnrolledByLecturerID) REFERENCES Lecturers(LecturerID)
);
GO

CREATE UNIQUE INDEX UQ_StudentEnrollments_Student_Class
ON StudentEnrollments(StudentID, ClassScheduleID);
GO

/* =========================================
   9. INVOICES TABLE
========================================= */
CREATE TABLE Invoices
(
    InvoiceID INT PRIMARY KEY IDENTITY(1,1),
    EnrollmentID INT NOT NULL,
    InvoiceDate DATE NOT NULL DEFAULT GETDATE(),
    Amount DECIMAL(10,2) NOT NULL,
    InvoiceStatus NVARCHAR(20) NOT NULL DEFAULT 'Unpaid',
    DueDate DATE NULL,
    CONSTRAINT FK_Invoices_StudentEnrollments
        FOREIGN KEY (EnrollmentID) REFERENCES StudentEnrollments(EnrollmentID)
);
GO

/* =========================================
   10. PAYMENT HISTORY TABLE
========================================= */
CREATE TABLE PaymentHistory
(
    PaymentHistoryID INT PRIMARY KEY IDENTITY(1,1),
    InvoiceID INT NOT NULL,
    AmountPaid DECIMAL(10,2) NOT NULL,
    PaymentDate DATE NOT NULL DEFAULT GETDATE(),
    PaymentMethod NVARCHAR(30) NULL,
    ReceiptNo NVARCHAR(50) NULL,
    PaymentStatus NVARCHAR(20) NOT NULL DEFAULT 'Paid',
    CONSTRAINT FK_PaymentHistory_Invoices
        FOREIGN KEY (InvoiceID) REFERENCES Invoices(InvoiceID)
);
GO

/* =========================================
   11. LEGACY STUDENT PAYMENTS TABLE
========================================= */
CREATE TABLE StudentPayments
(
    PaymentID INT PRIMARY KEY IDENTITY(1,1),
    ClassScheduleID INT NOT NULL,
    StudentName NVARCHAR(100) NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentDate DATE NOT NULL DEFAULT GETDATE(),
    [Status] NVARCHAR(20) NOT NULL DEFAULT 'Paid',
    CONSTRAINT FK_StudentPayments_ClassSchedule
        FOREIGN KEY (ClassScheduleID) REFERENCES ClassSchedule(Id)
);
GO

/* =========================================
   12. NEW TABLE: INTAKES
========================================= */
CREATE TABLE Intakes
(
    IntakeID INT PRIMARY KEY IDENTITY(1,1),
    IntakeCode NVARCHAR(20) NOT NULL UNIQUE,
    IntakeName NVARCHAR(100) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active'
);
GO

/* =========================================
   13. NEW TABLE: MODULES
========================================= */
CREATE TABLE Modules
(
    ModuleID INT PRIMARY KEY IDENTITY(1,1),
    ModuleCode NVARCHAR(20) NOT NULL UNIQUE,
    ModuleName NVARCHAR(100) NOT NULL,
    AcademicLevel NVARCHAR(20) NOT NULL,
    CreditHours INT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active'
);
GO

/* =========================================
   14. NEW TABLE: STUDENT INTAKES
========================================= */
CREATE TABLE StudentIntakes
(
    StudentIntakeID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    IntakeID INT NOT NULL,
    AssignedDate DATE NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CONSTRAINT FK_StudentIntakes_Students
        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_StudentIntakes_Intakes
        FOREIGN KEY (IntakeID) REFERENCES Intakes(IntakeID)
);
GO

/* =========================================
   15. NEW TABLE: LECTURER MODULES
========================================= */
CREATE TABLE LecturerModules
(
    LecturerModuleID INT PRIMARY KEY IDENTITY(1,1),
    LecturerID INT NOT NULL,
    ModuleID INT NOT NULL,
    IntakeID INT NOT NULL,
    AssignedDate DATE NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CONSTRAINT FK_LecturerModules_Lecturers
        FOREIGN KEY (LecturerID) REFERENCES Lecturers(LecturerID),
    CONSTRAINT FK_LecturerModules_Modules
        FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID),
    CONSTRAINT FK_LecturerModules_Intakes
        FOREIGN KEY (IntakeID) REFERENCES Intakes(IntakeID)
);
GO

/* =========================================
   16. NEW TABLE: TRAINER ASSIGNMENTS
========================================= */
CREATE TABLE TrainerAssignments
(
    TrainerAssignmentID INT PRIMARY KEY IDENTITY(1,1),
    TrainerID INT NOT NULL,
    ModuleID INT NOT NULL,
    IntakeID INT NULL,
    CoachingLevel NVARCHAR(20) NOT NULL,
    AssignedDate DATE NOT NULL DEFAULT GETDATE(),
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CONSTRAINT FK_TrainerAssignments_Trainers
        FOREIGN KEY (TrainerID) REFERENCES Trainers(TrainerID),
    CONSTRAINT FK_TrainerAssignments_Modules
        FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID),
    CONSTRAINT FK_TrainerAssignments_Intakes
        FOREIGN KEY (IntakeID) REFERENCES Intakes(IntakeID)
);
GO

/* =========================================
   17. NEW TABLE: WEEKLY SCHEDULES
========================================= */
CREATE TABLE WeeklySchedules
(
    WeeklyScheduleID INT PRIMARY KEY IDENTITY(1,1),
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
    Status NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CONSTRAINT FK_WeeklySchedules_Modules
        FOREIGN KEY (ModuleID) REFERENCES Modules(ModuleID),
    CONSTRAINT FK_WeeklySchedules_Intakes
        FOREIGN KEY (IntakeID) REFERENCES Intakes(IntakeID),
    CONSTRAINT FK_WeeklySchedules_Trainers
        FOREIGN KEY (TrainerID) REFERENCES Trainers(TrainerID),
    CONSTRAINT FK_WeeklySchedules_Lecturers
        FOREIGN KEY (LecturerID) REFERENCES Lecturers(LecturerID)
);
GO

/* =========================================
   18. NEW TABLE: STUDENT WEEKLY ENROLLMENTS
========================================= */
CREATE TABLE StudentWeeklyEnrollments
(
    StudentWeeklyEnrollmentID INT PRIMARY KEY IDENTITY(1,1),
    StudentID INT NOT NULL,
    WeeklyScheduleID INT NOT NULL,
    EnrollmentDate DATE NOT NULL DEFAULT GETDATE(),
    EnrollmentStatus NVARCHAR(20) NOT NULL DEFAULT 'Active',
    CONSTRAINT FK_StudentWeeklyEnrollments_Students
        FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    CONSTRAINT FK_StudentWeeklyEnrollments_WeeklySchedules
        FOREIGN KEY (WeeklyScheduleID) REFERENCES WeeklySchedules(WeeklyScheduleID)
);
GO

/* =========================================
   19. STUDENT HOME SCHEDULE VIEW
   DB-level logic for Current / Upcoming / Hidden
========================================= */
IF OBJECT_ID('vw_StudentHomeSchedule', 'V') IS NOT NULL
    DROP VIEW vw_StudentHomeSchedule;
GO

CREATE VIEW vw_StudentHomeSchedule
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
FROM StudentEnrollments se
INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
LEFT JOIN Trainers t ON cs.TrainerID = t.TrainerID
LEFT JOIN Users tu ON t.UserID = tu.UserID
WHERE se.EnrollmentStatus = 'Active';
GO

/* =========================================
   20. STUDENT COURSES VIEWS
   DB-level support for subscribed and requestable courses
========================================= */
IF OBJECT_ID('vw_StudentSubscribedCourses', 'V') IS NOT NULL
    DROP VIEW vw_StudentSubscribedCourses;
GO

CREATE VIEW vw_StudentSubscribedCourses
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
FROM StudentEnrollments se
INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
LEFT JOIN Trainers t ON cs.TrainerID = t.TrainerID
LEFT JOIN Users tu ON t.UserID = tu.UserID
WHERE se.EnrollmentStatus = 'Active';
GO

IF OBJECT_ID('vw_RequestableCourseOptions', 'V') IS NOT NULL
    DROP VIEW vw_RequestableCourseOptions;
GO

CREATE VIEW vw_RequestableCourseOptions
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
FROM ClassSchedule cs
LEFT JOIN Trainers t ON cs.TrainerID = t.TrainerID
LEFT JOIN Users tu ON t.UserID = tu.UserID
WHERE cs.ClassDate >= CAST(GETDATE() AS DATE);
GO

/* =========================================
   21. STUDENT FEES VIEWS
   DB-level support for outstanding fees and payment history
========================================= */
IF OBJECT_ID('vw_StudentOutstandingFees', 'V') IS NOT NULL
    DROP VIEW vw_StudentOutstandingFees;
GO

CREATE VIEW vw_StudentOutstandingFees
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
FROM Invoices i
INNER JOIN StudentEnrollments se ON i.EnrollmentID = se.EnrollmentID
INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
LEFT JOIN Trainers t ON cs.TrainerID = t.TrainerID
LEFT JOIN Users tu ON t.UserID = tu.UserID
WHERE i.InvoiceStatus = 'Unpaid';
GO

IF OBJECT_ID('vw_StudentPaymentHistory', 'V') IS NOT NULL
    DROP VIEW vw_StudentPaymentHistory;
GO

CREATE VIEW vw_StudentPaymentHistory
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
FROM PaymentHistory ph
INNER JOIN Invoices i ON ph.InvoiceID = i.InvoiceID
INNER JOIN StudentEnrollments se ON i.EnrollmentID = se.EnrollmentID
INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
WHERE ph.PaymentStatus = 'Paid';
GO

/* =========================================
   22. SHARED USER PROFILE VIEW
========================================= */
IF OBJECT_ID('vw_UserProfiles', 'V') IS NOT NULL
    DROP VIEW vw_UserProfiles;
GO

CREATE VIEW vw_UserProfiles
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
FROM Users u
LEFT JOIN Students s ON u.UserID = s.UserID
LEFT JOIN UserProfileDetails upd ON u.UserID = upd.UserID;
GO

/* =========================================
   37. TEST QUERIES
========================================= */
SELECT * FROM Users;
SELECT * FROM Trainers;
SELECT * FROM Lecturers;
SELECT * FROM Students;
SELECT * FROM ClassSchedule;
SELECT * FROM Feedback;
SELECT * FROM EnrollmentRequests;
SELECT * FROM StudentEnrollments;
SELECT * FROM Invoices;
SELECT * FROM PaymentHistory;
SELECT * FROM StudentPayments;
SELECT * FROM Intakes;
SELECT * FROM Modules;
SELECT * FROM StudentIntakes;
SELECT * FROM LecturerModules;
SELECT * FROM TrainerAssignments;
SELECT * FROM WeeklySchedules;
SELECT * FROM StudentWeeklyEnrollments;
SELECT * FROM vw_StudentHomeSchedule;
SELECT * FROM vw_StudentSubscribedCourses;
SELECT * FROM vw_RequestableCourseOptions;
SELECT * FROM vw_StudentOutstandingFees;
SELECT * FROM vw_StudentPaymentHistory;
SELECT * FROM vw_UserProfiles;
GO

/* =========================================
   38. STUDENT HOME FORM QUERY
   DB-driven home schedule view
========================================= */
SELECT 
    StudentID,
    Module,
    Trainer,
    [Date],
    [Day],
    [Time],
    Room,
    ScheduleType
FROM vw_StudentHomeSchedule
WHERE IsVisibleOnHome = 1
ORDER BY StudentID, SortDate, SortTime;
GO

/* =========================================
   39. NEW WEEKLY STUDENT HOME QUERY
   University-style weekly schedule
========================================= */
SELECT
    swe.StudentWeeklyEnrollmentID,
    s.StudentID,
    u.[Name] AS StudentName,
    i.IntakeCode,
    m.ModuleCode,
    m.ModuleName,
    ws.DayOfWeek,
    ws.StartTime,
    ws.EndTime,
    ws.Room,
    tu.[Name] AS TrainerName,
    swe.EnrollmentStatus
FROM StudentWeeklyEnrollments swe
INNER JOIN Students s ON swe.StudentID = s.StudentID
INNER JOIN Users u ON s.UserID = u.UserID
INNER JOIN WeeklySchedules ws ON swe.WeeklyScheduleID = ws.WeeklyScheduleID
INNER JOIN Modules m ON ws.ModuleID = m.ModuleID
INNER JOIN Intakes i ON ws.IntakeID = i.IntakeID
LEFT JOIN Trainers t ON ws.TrainerID = t.TrainerID
LEFT JOIN Users tu ON t.UserID = tu.UserID
ORDER BY i.IntakeCode, ws.DayOfWeek, ws.StartTime;
GO

/* =========================================
   40. STUDENT COURSES FORM QUERY
========================================= */
SELECT
    StudentID,
    CourseName,
    Trainer,
    Schedule,
    [Status]
FROM vw_StudentSubscribedCourses
ORDER BY StudentID, SortDate, SortTime;
GO

SELECT
    ClassScheduleID,
    CourseName,
    Trainer,
    DisplayText
FROM vw_RequestableCourseOptions
ORDER BY SortDate, SortTime;
GO

/* =========================================
   40A. STUDENT FEES FORM QUERY
========================================= */
SELECT
    StudentID,
    Module,
    [Level],
    Trainer,
    Fee,
    [Status]
FROM vw_StudentOutstandingFees
ORDER BY StudentID, SortDueDate, InvoiceID;
GO

SELECT
    StudentID,
    InvoiceNo,
    Module,
    AmountPaid,
    PaymentMethod,
    PaidDate
FROM vw_StudentPaymentHistory
ORDER BY StudentID, SortPaymentDate DESC, PaymentHistoryID DESC;
GO

/* =========================================
   41. STUDENT REQUESTS QUERY
========================================= */
SELECT
    er.RequestID,
    su.[Name] AS StudentName,
    cs.ModuleName,
    cs.[Level],
    er.RequestDate,
    er.RequestStatus,
    er.Remarks,
    lu.[Name] AS HandledByLecturer
FROM EnrollmentRequests er
INNER JOIN Students s ON er.StudentID = s.StudentID
INNER JOIN Users su ON s.UserID = su.UserID
INNER JOIN ClassSchedule cs ON er.ClassScheduleID = cs.Id
LEFT JOIN Lecturers l ON er.HandledByLecturerID = l.LecturerID
LEFT JOIN Users lu ON l.UserID = lu.UserID
ORDER BY er.RequestID DESC;
GO

/* =========================================
   42. STUDENT FEES FORM QUERY
========================================= */
SELECT
    i.InvoiceID,
    su.[Name] AS StudentName,
    cs.ModuleName,
    cs.[Level],
    i.Amount,
    i.InvoiceDate,
    i.DueDate,
    i.InvoiceStatus
FROM Invoices i
INNER JOIN StudentEnrollments se ON i.EnrollmentID = se.EnrollmentID
INNER JOIN Students s ON se.StudentID = s.StudentID
INNER JOIN Users su ON s.UserID = su.UserID
INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
ORDER BY i.InvoiceID;
GO

SELECT
    ph.PaymentHistoryID,
    i.InvoiceID,
    su.[Name] AS StudentName,
    cs.ModuleName,
    ph.AmountPaid,
    ph.PaymentDate,
    ph.PaymentMethod,
    ph.ReceiptNo,
    ph.PaymentStatus
FROM PaymentHistory ph
INNER JOIN Invoices i ON ph.InvoiceID = i.InvoiceID
INNER JOIN StudentEnrollments se ON i.EnrollmentID = se.EnrollmentID
INNER JOIN Students s ON se.StudentID = s.StudentID
INNER JOIN Users su ON s.UserID = su.UserID
INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
ORDER BY ph.PaymentHistoryID DESC;
GO

/* =========================================
   43. LECTURER VIEW STUDENT LIST
========================================= */
SELECT
    s.StudentID,
    u.[Name] AS StudentName,
    s.TPNumber,
    s.StudyLevel,
    s.StudentStatus,
    cs.ModuleName,
    cs.[Level] AS ClassLevel,
    se.EnrollmentStatus
FROM Students s
INNER JOIN Users u ON s.UserID = u.UserID
LEFT JOIN StudentEnrollments se ON s.StudentID = se.StudentID
LEFT JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
ORDER BY u.[Name];
GO

/* =========================================
   44. LECTURER VIEW STUDENTS BY INTAKE
========================================= */
SELECT
    s.StudentID,
    u.[Name] AS StudentName,
    s.TPNumber,
    i.IntakeCode,
    i.IntakeName,
    s.StudyLevel,
    s.StudentStatus
FROM Students s
INNER JOIN Users u ON s.UserID = u.UserID
INNER JOIN StudentIntakes si ON s.StudentID = si.StudentID
INNER JOIN Intakes i ON si.IntakeID = i.IntakeID
ORDER BY i.IntakeCode, u.[Name];
GO

/* =========================================
   45. TRAINER WEEKLY TEACHING VIEW
========================================= */
SELECT
    t.TrainerID,
    u.[Name] AS TrainerName,
    i.IntakeCode,
    m.ModuleCode,
    m.ModuleName,
    ws.DayOfWeek,
    ws.StartTime,
    ws.EndTime,
    ws.Room,
    ws.CoachingLevel
FROM WeeklySchedules ws
INNER JOIN Trainers t ON ws.TrainerID = t.TrainerID
INNER JOIN Users u ON t.UserID = u.UserID
INNER JOIN Modules m ON ws.ModuleID = m.ModuleID
INNER JOIN Intakes i ON ws.IntakeID = i.IntakeID
ORDER BY u.[Name], ws.DayOfWeek, ws.StartTime;
GO

/* =========================================
   46. QUICK CHECKS
========================================= */
SELECT * FROM StudentEnrollments;
GO

SELECT 
    se.StudentID,
    cs.ModuleName,
    cs.ClassDate,
    cs.ClassTime,
    cs.Room,
    se.EnrollmentStatus
FROM StudentEnrollments se
INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
WHERE se.StudentID = 1;
GO


USE MyDatabase;
GO

/* =========================================================
   EXTRA DEMO DATA FOR STUDENT FORMS
   This script adds realistic fake university data
   without changing your table structure.
========================================================= */

/* =========================================================
   0. BASE USERS FOR LOGIN / PROFILE / STUDENT DEMOS
========================================================= */
INSERT INTO Users (Username, [Password], [Role], [Name], Email, Phone, [Address])
VALUES
('admin1',    '123456789', 'Admin',    'Admin User', 'admin1@apu.edu.my',               '0111000001', 'APU Main Campus'),
('trainer1',  '123456789', 'Trainer',  'Abdalla',    'abdalla@apu.edu.my',              '0111000002', 'Bukit Jalil'),
('trainer2',  '123456789', 'Trainer',  'Waleed',     'waleed@apu.edu.my',               '0111000003', 'Sri Petaling'),
('lecturer1', '123456789', 'Lecturer', 'Dr Ahmad',   'ahmad@apu.edu.my',                '0111000004', 'School of Computing'),
('lecturer2', '123456789', 'Lecturer', 'Ms Farah',   'farah@apu.edu.my',                '0111000005', 'School of Computing'),
('student1',  '123456789', 'Student',  'Ali Ahmad',  'TP001@mail.apu.edu.my',           '0111000006', 'Kuala Lumpur'),
('student2',  '123456789', 'Student',  'Nur Aina',   'TP002@mail.apu.edu.my',           '0111000007', 'Selangor'),
('student3',  '123456789', 'Student',  'John Lee',   'TP003@mail.apu.edu.my',           '0111000008', 'Penang');
GO

INSERT INTO Trainers (UserID, Qualifications, Specialisation, AssignedModuleId, AssignedModuleName, AssignedLevel)
VALUES
(2, 'BSc Software Engineering', 'Programming Fundamentals', '120', 'Programming Fundamentals', 'Beginner'),
(3, 'MSc Information Systems',  'Object Oriented Programming', '220', 'Object Oriented Programming', 'Intermediate');
GO

INSERT INTO Lecturers (UserID, Department, Specialisation)
VALUES
(4, 'School of Computing', 'Computer Science'),
(5, 'School of Computing', 'Software Engineering');
GO

INSERT INTO Students (UserID, TPNumber, StudyLevel, ContactNumber, StudentAddress, MonthOfEnrollment, StudentStatus)
VALUES
(6, 'TP001', 'Level 1', '0111000006', 'Kuala Lumpur', 'February 2026', 'Active'),
(7, 'TP002', 'Level 1', '0111000007', 'Selangor', 'February 2026', 'Active'),
(8, 'TP003', 'Level 2', '0111000008', 'Penang', 'February 2026', 'Active');
GO

INSERT INTO Intakes (IntakeCode, IntakeName, StartDate, EndDate, Status)
VALUES
('APU1F2507CSAI', 'Computer Science Artificial Intelligence July 2025', '2025-07-01', '2028-06-30', 'Active'),
('APU1F2507SE',   'Software Engineering July 2025',                     '2025-07-01', '2028-06-30', 'Active');
GO

INSERT INTO Modules (ModuleCode, ModuleName, AcademicLevel, CreditHours, Status)
VALUES
('PF101',  'Programming Fundamentals',      'Level 1', 3, 'Active'),
('OOP102', 'Object Oriented Programming',   'Level 1', 3, 'Active');
GO

INSERT INTO StudentIntakes (StudentID, IntakeID, AssignedDate, Status)
VALUES
(1, 1, GETDATE(), 'Active'),
(2, 1, GETDATE(), 'Active'),
(3, 2, GETDATE(), 'Active');
GO

INSERT INTO UserProfileDetails
(
    UserID,
    ProfileCode,
    SecondaryCode,
    IdentityNumber,
    Country,
    ProgrammeName,
    MentorName,
    ProgrammeLeader,
    PassExpiryDate
)
VALUES
(1, 'ADM001', 'OPERATIONS',         'A-1001',    'Malaysia', 'Administration and Operations',                   'Executive Office',             'Campus Director',           NULL),
(2, 'TRN001', 'FOUNDATION',         'T-2001',    'Sudan',    'Programming Coaching Unit',                      'Lead Trainer Manager',         'Training Director',         NULL),
(3, 'TRN002', 'INTERMEDIATE',       'T-2002',    'Jordan',   'Object Oriented Programming Unit',               'Lead Trainer Manager',         'Training Director',         NULL),
(4, 'LEC001', 'ACADEMIC',           'L-3001',    'Malaysia', 'School of Computing',                            'Deputy Dean',                  'Dean of Computing',         NULL),
(5, 'LEC002', 'ACADEMIC',           'L-3002',    'Malaysia', 'School of Computing',                            'Deputy Dean',                  'Dean of Computing',         NULL),
(6, 'TP001',  'APU1F2507CS(AI)',    '13417752',  'Yemen',    'Bachelor of Computer Science (Hons) (Artificial Intelligence)', 'Assoc. Prof. Dr. Imran Medi', 'Lai Chew Ping', '2026-07-18'),
(7, 'TP002',  'APU1F2507CS(AI)',    '24588910',  'Malaysia', 'Bachelor of Computer Science (Hons) (Artificial Intelligence)', 'Dr Ahmad',                    'Lai Chew Ping', '2026-12-31'),
(8, 'TP003',  'APU1F2507SE',        '77881234',  'Singapore','Bachelor of Software Engineering (Hons)',        'Ms Farah',                     'Prof. Tan Mei Lin',         '2027-02-14');
GO

/* =========================================================
   A. ADD MORE USERS
========================================================= */
INSERT INTO Users (Username, [Password], [Role], [Name], Email, Phone, [Address])
VALUES
('trainer3',  '123456789', 'Trainer',  'Sarah Lim',        'sarah.lim@apu.edu.my',        '0161000001', 'Bukit Jalil'),
('trainer4',  '123456789', 'Trainer',  'Jason Tan',        'jason.tan@apu.edu.my',        '0161000002', 'Cheras'),
('trainer5',  '123456789', 'Trainer',  'Priya Nair',       'priya.nair@apu.edu.my',       '0161000003', 'Puchong'),
('trainer6',  '123456789', 'Trainer',  'Daniel Wong',      'daniel.wong@apu.edu.my',      '0161000004', 'Subang'),
('lecturer3', '123456789', 'Lecturer', 'Dr Lim Mei Yan',   'meiyan@apu.edu.my',           '0172000001', 'APU Campus'),
('lecturer4', '123456789', 'Lecturer', 'Mr Hafiz Rahman',  'hafiz.rahman@apu.edu.my',     '0172000002', 'APU Campus'),
('lecturer5', '123456789', 'Lecturer', 'Ms Tan Li Wen',    'liwen.tan@apu.edu.my',        '0172000003', 'APU Campus'),

('student4',  '123456789', 'Student',  'Muhammad Amir',    'TP100001@mail.apu.edu.my',    '0183000001', 'Kuala Lumpur'),
('student5',  '123456789', 'Student',  'Siti Hajar',       'TP100002@mail.apu.edu.my',    '0183000002', 'Selangor'),
('student6',  '123456789', 'Student',  'Ethan Koh',        'TP100003@mail.apu.edu.my',    '0183000003', 'Penang'),
('student7',  '123456789', 'Student',  'Nurul Syafiqah',   'TP100004@mail.apu.edu.my',    '0183000004', 'Johor'),
('student8',  '123456789', 'Student',  'Adam Faris',       'TP100005@mail.apu.edu.my',    '0183000005', 'Perak'),
('student9',  '123456789', 'Student',  'Alicia Chan',      'TP100006@mail.apu.edu.my',    '0183000006', 'Malacca'),
('student10', '123456789', 'Student',  'Ryan Goh',         'TP100007@mail.apu.edu.my',    '0183000007', 'Negeri Sembilan'),
('student11', '123456789', 'Student',  'Izzah Sofea',      'TP100008@mail.apu.edu.my',    '0183000008', 'Sabah'),
('student12', '123456789', 'Student',  'Marcus Teo',       'TP100009@mail.apu.edu.my',    '0183000009', 'Sarawak'),
('student13', '123456789', 'Student',  'Farhan Iskandar',  'TP100010@mail.apu.edu.my',    '0183000010', 'Kedah'),
('student14', '123456789', 'Student',  'Grace Yap',        'TP100011@mail.apu.edu.my',    '0183000011', 'Selangor'),
('student15', '123456789', 'Student',  'Haziq Roslan',     'TP100012@mail.apu.edu.my',    '0183000012', 'Kuala Lumpur'),
('student16', '123456789', 'Student',  'Chloe Lee',        'TP100013@mail.apu.edu.my',    '0183000013', 'Penang'),
('student17', '123456789', 'Student',  'Aiman Hakim',      'TP100014@mail.apu.edu.my',    '0183000014', 'Johor'),
('student18', '123456789', 'Student',  'Natalie Wong',     'TP100015@mail.apu.edu.my',    '0183000015', 'Sabah'),
('student19', '123456789', 'Student',  'Syed Danish',      'TP100016@mail.apu.edu.my',    '0183000016', 'Perlis'),
('student20', '123456789', 'Student',  'Mei Xin',          'TP100017@mail.apu.edu.my',    '0183000017', 'Sarawak'),
('student21', '123456789', 'Student',  'Hakim Zulkifli',   'TP100018@mail.apu.edu.my',    '0183000018', 'Selangor'),
('student22', '123456789', 'Student',  'Vanessa Low',      'TP100019@mail.apu.edu.my',    '0183000019', 'Kuala Lumpur'),
('student23', '123456789', 'Student',  'Farisya Jamal',    'TP100020@mail.apu.edu.my',    '0183000020', 'Johor');
GO

/* =========================================================
   B. ADD TRAINERS
========================================================= */
INSERT INTO Trainers (UserID, Qualifications, Specialisation, AssignedModuleId, AssignedModuleName, AssignedLevel)
VALUES
(9,  'MSc Data Science',            'Python Programming',     '130', 'Python Programming',         'Beginner'),
(10, 'BSc Software Engineering',    'Web Development',        '240', 'Web Development',            'Intermediate'),
(11, 'MSc Computer Science',        'Data Structures',        '340', 'Data Structures',            'Intermediate'),
(12, 'BSc Information Technology',  'Database Systems',       '350', 'Database Systems',           'Advance');
GO

/* =========================================================
   C. ADD LECTURERS
========================================================= */
INSERT INTO Lecturers (UserID, Department, Specialisation)
VALUES
(13, 'School of Computing', 'Software Engineering'),
(14, 'School of Computing', 'Programming'),
(15, 'School of Computing', 'Data Science');
GO

/* =========================================================
   D. ADD STUDENTS
   Existing students are 1,2,3 from your script.
   These new students continue from new UserIDs.
========================================================= */
INSERT INTO Students (UserID, TPNumber, StudyLevel, ContactNumber, StudentAddress, MonthOfEnrollment, StudentStatus)
VALUES
(16, 'TP100001', 'Level 1', '0183000001', 'Kuala Lumpur', 'April 2026', 'Active'),
(17, 'TP100002', 'Level 1', '0183000002', 'Selangor',     'April 2026', 'Active'),
(18, 'TP100003', 'Level 1', '0183000003', 'Penang',       'April 2026', 'Active'),
(19, 'TP100004', 'Level 1', '0183000004', 'Johor',        'April 2026', 'Active'),
(20, 'TP100005', 'Level 1', '0183000005', 'Perak',        'April 2026', 'Active'),
(21, 'TP100006', 'Level 1', '0183000006', 'Malacca',      'April 2026', 'Active'),
(22, 'TP100007', 'Level 1', '0183000007', 'Negeri Sembilan','April 2026','Active'),
(23, 'TP100008', 'Level 1', '0183000008', 'Sabah',        'April 2026', 'Active'),
(24, 'TP100009', 'Level 2', '0183000009', 'Sarawak',      'April 2026', 'Active'),
(25, 'TP100010', 'Level 2', '0183000010', 'Kedah',        'April 2026', 'Active'),
(26, 'TP100011', 'Level 2', '0183000011', 'Selangor',     'April 2026', 'Active'),
(27, 'TP100012', 'Level 2', '0183000012', 'Kuala Lumpur', 'April 2026', 'Active'),
(28, 'TP100013', 'Level 2', '0183000013', 'Penang',       'April 2026', 'Active'),
(29, 'TP100014', 'Level 2', '0183000014', 'Johor',        'April 2026', 'Active'),
(30, 'TP100015', 'Level 2', '0183000015', 'Sabah',        'April 2026', 'Active'),
(31, 'TP100016', 'Level 3', '0183000016', 'Perlis',       'April 2026', 'Active'),
(32, 'TP100017', 'Level 3', '0183000017', 'Sarawak',      'April 2026', 'Active'),
(33, 'TP100018', 'Level 3', '0183000018', 'Selangor',     'April 2026', 'Active'),
(34, 'TP100019', 'Level 3', '0183000019', 'Kuala Lumpur', 'April 2026', 'Active'),
(35, 'TP100020', 'Level 3', '0183000020', 'Johor',        'April 2026', 'Active');
GO

/* =========================================================
   E. ADD MORE INTAKES
========================================================= */
INSERT INTO Intakes (IntakeCode, IntakeName, StartDate, EndDate, Status)
VALUES
('UCDF2607CS', 'Computer Science July 2026',       '2026-07-01', '2028-06-30', 'Active'),
('UCDF2607SE', 'Software Engineering July 2026',   '2026-07-01', '2028-06-30', 'Active'),
('UCDF2607DS', 'Data Science July 2026',           '2026-07-01', '2028-06-30', 'Active'),
('UCDF2511CS', 'Computer Science November 2025',   '2025-11-01', '2027-10-31', 'Active');
GO

/* =========================================================
   F. ADD MORE MODULES
========================================================= */
INSERT INTO Modules (ModuleCode, ModuleName, AcademicLevel, CreditHours, Status)
VALUES
('PY102',   'Python Programming',            'Level 1', 3, 'Active'),
('WD105',   'Web Design Fundamentals',       'Level 1', 3, 'Active'),
('SE201',   'Software Engineering Basics',   'Level 2', 3, 'Active'),
('CN202',   'Computer Networks',             'Level 2', 4, 'Active'),
('OS203',   'Operating Systems',             'Level 2', 4, 'Active'),
('MAD301',  'Mobile App Development',        'Level 3', 4, 'Active'),
('AI302',   'Introduction to AI',            'Level 3', 4, 'Active'),
('ML303',   'Machine Learning Fundamentals', 'Level 3', 4, 'Active'),
('UI304',   'UI UX Design',                  'Level 2', 3, 'Active'),
('CSP305',  'Cloud Solutions Practice',      'Level 3', 4, 'Active');
GO

/* =========================================================
   G. ASSIGN STUDENTS TO INTAKES
========================================================= */
INSERT INTO StudentIntakes (StudentID, IntakeID, AssignedDate, Status)
VALUES
(4,1,GETDATE(),'Active'),
(5,1,GETDATE(),'Active'),
(6,1,GETDATE(),'Active'),
(7,1,GETDATE(),'Active'),
(8,1,GETDATE(),'Active'),
(9,1,GETDATE(),'Active'),
(10,1,GETDATE(),'Active'),
(11,1,GETDATE(),'Active'),

(12,2,GETDATE(),'Active'),
(13,2,GETDATE(),'Active'),
(14,2,GETDATE(),'Active'),
(15,2,GETDATE(),'Active'),
(16,2,GETDATE(),'Active'),

(17,3,GETDATE(),'Active'),
(18,3,GETDATE(),'Active'),
(19,3,GETDATE(),'Active'),

(20,4,GETDATE(),'Active'),
(21,4,GETDATE(),'Active'),
(22,5,GETDATE(),'Active'),
(23,6,GETDATE(),'Active');
GO

/* =========================================================
   H. ADD LECTURER MODULES
========================================================= */
INSERT INTO LecturerModules (LecturerID, ModuleID, IntakeID, AssignedDate, Status)
VALUES
(1, 1, 1, GETDATE(), 'Active'),
(1, 2, 1, GETDATE(), 'Active'),
(1, 4, 1, GETDATE(), 'Active'),
(2, 3, 2, GETDATE(), 'Active'),
(2, 5, 3, GETDATE(), 'Active'),
(3, 6, 1, GETDATE(), 'Active'),
(3, 7, 1, GETDATE(), 'Active'),
(4, 8, 2, GETDATE(), 'Active'),
(4, 9, 2, GETDATE(), 'Active'),
(5,10, 3, GETDATE(), 'Active'),
(5,11, 3, GETDATE(), 'Active'),
(5,12, 4, GETDATE(), 'Active');
GO

/* =========================================================
   I. ADD TRAINER ASSIGNMENTS
========================================================= */
INSERT INTO TrainerAssignments (TrainerID, ModuleID, IntakeID, CoachingLevel, AssignedDate, Status)
VALUES
(1, 1, 1, 'Beginner',     GETDATE(), 'Active'),
(2, 2, 1, 'Intermediate', GETDATE(), 'Active'),
(1, 4, 1, 'Beginner',     GETDATE(), 'Active'),
(2, 3, 2, 'Advance',      GETDATE(), 'Active'),
(3, 6, 1, 'Beginner',     GETDATE(), 'Active'),
(4, 7, 1, 'Intermediate', GETDATE(), 'Active'),
(5, 8, 2, 'Intermediate', GETDATE(), 'Active'),
(6, 9, 2, 'Advance',      GETDATE(), 'Active'),
(3,10, 3, 'Advance',      GETDATE(), 'Active'),
(4,11, 3, 'Advance',      GETDATE(), 'Active'),
(5,12, 4, 'Intermediate', GETDATE(), 'Active');
GO

/* =========================================================
   J. ADD MORE CLASS SCHEDULE
   IMPORTANT:
   - some rows use CAST(GETDATE() AS DATE) for Current Schedule
   - many rows use future dates for Upcoming Schedule
========================================================= */
INSERT INTO ClassSchedule (ModuleId, ModuleName, ClassDate, ClassTime, Charges, TrainerID, [Level], Room)
VALUES
('120', 'Programming Fundamentals', CAST(GETDATE() AS DATE),                '09:00', 150.00, 1, 'Beginner',     'B-01'),
('220', 'Object Oriented Programming', CAST(GETDATE() AS DATE),             '11:00', 200.00, 2, 'Intermediate', 'B-02'),
('130', 'Python Programming', DATEADD(DAY, 1, CAST(GETDATE() AS DATE)),     '10:00', 160.00, 3, 'Beginner',     'C-01'),
('240', 'Web Development', DATEADD(DAY, 1, CAST(GETDATE() AS DATE)),        '14:00', 180.00, 4, 'Intermediate', 'C-02'),
('340', 'Data Structures', DATEADD(DAY, 2, CAST(GETDATE() AS DATE)),        '09:00', 220.00, 5, 'Intermediate', 'C-03'),
('350', 'Database Systems', DATEADD(DAY, 2, CAST(GETDATE() AS DATE)),       '13:00', 240.00, 6, 'Advance',      'C-04'),
('360', 'Computer Networks', DATEADD(DAY, 3, CAST(GETDATE() AS DATE)),      '08:30', 210.00, 4, 'Intermediate', 'D-01'),
('370', 'Operating Systems', DATEADD(DAY, 3, CAST(GETDATE() AS DATE)),      '10:30', 230.00, 5, 'Advance',      'D-02'),
('380', 'Software Engineering Basics', DATEADD(DAY, 4, CAST(GETDATE() AS DATE)), '12:00', 200.00, 3, 'Intermediate', 'D-03'),
('390', 'UI UX Design', DATEADD(DAY, 4, CAST(GETDATE() AS DATE)),           '15:00', 170.00, 4, 'Beginner',     'D-04'),

('401', 'Introduction to AI', DATEADD(DAY, 5, CAST(GETDATE() AS DATE)),     '09:00', 260.00, 5, 'Advance',      'E-01'),
('402', 'Machine Learning Fundamentals', DATEADD(DAY, 5, CAST(GETDATE() AS DATE)), '11:00', 280.00, 6, 'Advance', 'E-02'),
('403', 'Mobile App Development', DATEADD(DAY, 6, CAST(GETDATE() AS DATE)), '10:00', 250.00, 3, 'Advance',      'E-03'),
('404', 'Cloud Solutions Practice', DATEADD(DAY, 6, CAST(GETDATE() AS DATE)),'14:00', 290.00, 6, 'Advance',      'E-04'),

('120A', 'Programming Fundamentals Group A', DATEADD(DAY, 7, CAST(GETDATE() AS DATE)),  '09:00', 150.00, 1, 'Beginner',     'B-05'),
('120B', 'Programming Fundamentals Group B', DATEADD(DAY, 8, CAST(GETDATE() AS DATE)),  '09:00', 150.00, 1, 'Beginner',     'B-06'),
('220A', 'Object Oriented Programming Group A', DATEADD(DAY, 8, CAST(GETDATE() AS DATE)),'11:00', 200.00, 2, 'Intermediate', 'B-07'),
('220B', 'Object Oriented Programming Group B', DATEADD(DAY, 9, CAST(GETDATE() AS DATE)),'13:00', 200.00, 2, 'Intermediate', 'B-08'),
('130A', 'Python Programming Lab', DATEADD(DAY, 9, CAST(GETDATE() AS DATE)), '15:00', 160.00, 3, 'Beginner',     'C-05'),
('240A', 'Web Development Workshop', DATEADD(DAY, 10, CAST(GETDATE() AS DATE)), '10:00', 180.00, 4, 'Intermediate','C-06'),

('340A', 'Data Structures Tutorial', DATEADD(DAY, 11, CAST(GETDATE() AS DATE)), '09:00', 220.00, 5, 'Intermediate', 'C-07'),
('350A', 'Database Systems Lab', DATEADD(DAY, 11, CAST(GETDATE() AS DATE)),   '14:00', 240.00, 6, 'Advance',      'C-08'),
('360A', 'Computer Networks Tutorial', DATEADD(DAY, 12, CAST(GETDATE() AS DATE)), '08:30', 210.00, 4, 'Intermediate', 'D-05'),
('370A', 'Operating Systems Tutorial', DATEADD(DAY, 12, CAST(GETDATE() AS DATE)), '10:30', 230.00, 5, 'Advance',    'D-06'),
('380A', 'Software Engineering Clinic', DATEADD(DAY, 13, CAST(GETDATE() AS DATE)), '12:00', 200.00, 3, 'Intermediate','D-07'),
('390A', 'UI UX Design Clinic', DATEADD(DAY, 13, CAST(GETDATE() AS DATE)),     '15:00', 170.00, 4, 'Beginner',     'D-08'),

('401A', 'Introduction to AI Tutorial', DATEADD(DAY, 14, CAST(GETDATE() AS DATE)), '09:00', 260.00, 5, 'Advance',   'E-05'),
('402A', 'Machine Learning Tutorial', DATEADD(DAY, 15, CAST(GETDATE() AS DATE)),   '11:00', 280.00, 6, 'Advance',   'E-06'),
('403A', 'Mobile App Development Lab', DATEADD(DAY, 15, CAST(GETDATE() AS DATE)),   '10:00', 250.00, 3, 'Advance',   'E-07'),
('404A', 'Cloud Solutions Workshop', DATEADD(DAY, 16, CAST(GETDATE() AS DATE)),    '14:00', 290.00, 6, 'Advance',   'E-08');
GO

/* =========================================================
   K. ADD ENROLLMENT REQUESTS
========================================================= */
INSERT INTO EnrollmentRequests (StudentID, ClassScheduleID, RequestDate, RequestStatus, Remarks, HandledByLecturerID, HandledDate)
VALUES
(1, 6,  GETDATE(), 'Pending',  'Interested in database systems coaching', NULL, NULL),
(2, 5,  GETDATE(), 'Approved', 'Need help with data structures', 1, GETDATE()),
(3, 6,  GETDATE(), 'Rejected', 'Schedule conflict with existing class', 2, GETDATE()),
(4, 7,  GETDATE(), 'Pending',  'Want extra computer networks class', NULL, NULL),
(5, 8,  GETDATE(), 'Approved', 'Lecturer recommended', 3, GETDATE()),
(6, 9,  GETDATE(), 'Pending',  'Request for software engineering support', NULL, NULL),
(7, 10, GETDATE(), 'Approved', 'Student self-request', 4, GETDATE()),
(8, 11, GETDATE(), 'Rejected', 'Class full', 5, GETDATE()),
(9, 12, GETDATE(), 'Pending',  'Needs help in machine learning basics', NULL, NULL),
(10,13, GETDATE(), 'Approved', 'Recommended after test results', 2, GETDATE());
GO

/* =========================================================
   L. ADD STUDENT ENROLLMENTS
   These are the rows your StudentHomeForm is using.
========================================================= */
INSERT INTO StudentEnrollments (StudentID, ClassScheduleID, EnrolledDate, EnrollmentStatus, EnrolledByLecturerID, CompletedDate)
VALUES
(1, 4,  GETDATE(), 'Active',    1, NULL),
(1, 5,  GETDATE(), 'Active',    1, NULL),
(1, 1,  GETDATE(), 'Active',    1, NULL),

(2, 2,  GETDATE(), 'Active',    1, NULL),
(2, 6,  GETDATE(), 'Active',    1, NULL),
(2, 7,  GETDATE(), 'Active',    1, NULL),

(3, 3,  GETDATE(), 'Completed', 2, GETDATE()),
(3, 8,  GETDATE(), 'Active',    2, NULL),

(4, 9,  GETDATE(), 'Active',    3, NULL),
(4, 10, GETDATE(), 'Active',    3, NULL),

(5, 11, GETDATE(), 'Active',    3, NULL),
(5, 12, GETDATE(), 'Active',    3, NULL),

(6, 13, GETDATE(), 'Active',    4, NULL),
(6, 14, GETDATE(), 'Active',    4, NULL),

(7, 15, GETDATE(), 'Active',    4, NULL),
(7, 17, GETDATE(), 'Active',    4, NULL),

(8, 16, GETDATE(), 'Active',    5, NULL),
(8, 18, GETDATE(), 'Active',    5, NULL),

(9, 19, GETDATE(), 'Active',    1, NULL),
(9, 20, GETDATE(), 'Active',    1, NULL),

(10,21, GETDATE(), 'Active',    2, NULL),
(10,22, GETDATE(), 'Active',    2, NULL),

(11,23, GETDATE(), 'Active',    2, NULL),
(11,24, GETDATE(), 'Active',    2, NULL),

(12,25, GETDATE(), 'Active',    3, NULL),
(12,26, GETDATE(), 'Active',    3, NULL),

(13,27, GETDATE(), 'Active',    3, NULL),
(13,28, GETDATE(), 'Active',    3, NULL),

(14,29, GETDATE(), 'Active',    4, NULL),
(14,30, GETDATE(), 'Active',    4, NULL);
GO

/* =========================================================
   L2. EXTRA STUDENT COURSE TEST DATA
   Keeps StudentCoursesForm request dropdown populated
========================================================= */
INSERT INTO ClassSchedule (ModuleId, ModuleName, ClassDate, ClassTime, Charges, TrainerID, [Level], Room)
VALUES
('510', 'Web API Development', DATEADD(DAY, 2, CAST(GETDATE() AS DATE)), '11:30', 210.00, 1, 'Intermediate', 'C-10'),
('520', 'Cloud Fundamentals', DATEADD(DAY, 3, CAST(GETDATE() AS DATE)), '13:30', 230.00, 2, 'Intermediate', 'C-11'),
('530', 'Data Analytics Essentials', DATEADD(DAY, 4, CAST(GETDATE() AS DATE)), '15:30', 240.00, 1, 'Advance', 'C-12');
GO

INSERT INTO EnrollmentRequests (StudentID, ClassScheduleID, RequestDate, RequestStatus, Remarks, HandledByLecturerID, HandledDate)
VALUES
(2, 31, GETDATE(), 'Pending', 'Requested from student course form demo data', NULL, NULL),
(3, 32, GETDATE(), 'Rejected', 'Schedule clash, can retry later', 1, GETDATE());
GO

/* =========================================================
   L3. NORMALISE REQUESTS AGAINST ACTIVE ENROLLMENTS
   Keeps seed data logically consistent in one master script
========================================================= */
UPDATE er
SET
    RequestStatus = 'Approved',
    HandledByLecturerID = ISNULL(er.HandledByLecturerID, 1),
    HandledDate = ISNULL(er.HandledDate, CAST(GETDATE() AS DATE)),
    Remarks = CASE
        WHEN er.Remarks IS NULL OR LTRIM(RTRIM(er.Remarks)) = '' THEN 'Request auto-aligned with active enrollment'
        ELSE er.Remarks
    END
FROM EnrollmentRequests er
WHERE EXISTS
(
    SELECT 1
    FROM StudentEnrollments se
    WHERE se.StudentID = er.StudentID
      AND se.ClassScheduleID = er.ClassScheduleID
      AND se.EnrollmentStatus = 'Active'
);
GO

/* =========================================================
   M. ADD INVOICES
========================================================= */
INSERT INTO Invoices (EnrollmentID, InvoiceDate, Amount, InvoiceStatus, DueDate)
SELECT EnrollmentID, GETDATE(),
       CASE 
           WHEN EnrollmentID % 5 = 0 THEN 290.00
           WHEN EnrollmentID % 4 = 0 THEN 250.00
           WHEN EnrollmentID % 3 = 0 THEN 220.00
           WHEN EnrollmentID % 2 = 0 THEN 200.00
           ELSE 150.00
       END,
       CASE 
           WHEN EnrollmentID IN (2,3,5,8,11,14,17,20,23,26) THEN 'Paid'
           ELSE 'Unpaid'
       END,
       DATEADD(DAY, 14, GETDATE())
FROM StudentEnrollments
WHERE EnrollmentID >= 1 AND EnrollmentID <= 30;
GO

/* =========================================================
   N. ADD PAYMENT HISTORY
========================================================= */
INSERT INTO PaymentHistory (InvoiceID, AmountPaid, PaymentDate, PaymentMethod, ReceiptNo, PaymentStatus)
SELECT InvoiceID, Amount, GETDATE(),
       CASE 
           WHEN InvoiceID % 3 = 0 THEN 'Card'
           WHEN InvoiceID % 3 = 1 THEN 'Online Banking'
           ELSE 'Cash'
       END,
       CONCAT('RCPT-', 2000 + InvoiceID),
       'Paid'
FROM Invoices
WHERE InvoiceStatus = 'Paid';
GO

/* =========================================================
   O. ADD LEGACY STUDENT PAYMENTS
========================================================= */
INSERT INTO StudentPayments (ClassScheduleID, StudentName, Amount, PaymentDate, [Status])
VALUES
(4,  'Ali Ahmad',       180.00, GETDATE(), 'Paid'),
(5,  'Nur Aina',        220.00, GETDATE(), 'Paid'),
(6,  'John Lee',        240.00, GETDATE(), 'Paid'),
(7,  'Muhammad Amir',   210.00, GETDATE(), 'Paid'),
(8,  'Siti Hajar',      230.00, GETDATE(), 'Paid'),
(9,  'Ethan Koh',       200.00, GETDATE(), 'Paid'),
(10, 'Nurul Syafiqah',  170.00, GETDATE(), 'Paid'),
(11, 'Adam Faris',      260.00, GETDATE(), 'Paid'),
(12, 'Alicia Chan',     280.00, GETDATE(), 'Paid'),
(13, 'Ryan Goh',        250.00, GETDATE(), 'Paid');
GO

/* =========================================================
   P. ADD MORE FEEDBACK
========================================================= */
INSERT INTO Feedback (TrainerID, FeedbackType, [Message], DateSent, [Status])
VALUES
(1, 'Suggestion', 'Students need more lab-based exercises for beginner modules.', GETDATE(), 'Unread'),
(2, 'General',    'OOP group showed strong improvement after week 2.', GETDATE(), 'Unread'),
(3, 'Suggestion', 'Python class would benefit from smaller coaching groups.', GETDATE(), 'Read'),
(4, 'Complaint',  'Projector in lab C-02 was not working during session.', GETDATE(), 'Unread'),
(5, 'General',    'Data structures workshop attendance was excellent.', GETDATE(), 'Read'),
(6, 'Suggestion', 'Need one more weekly session for advanced database learners.', GETDATE(), 'Unread');
GO

/* =========================================================
   Q. OPTIONAL CHECKS
========================================================= */
SELECT COUNT(*) AS TotalUsers FROM Users;
SELECT COUNT(*) AS TotalStudents FROM Students;
SELECT COUNT(*) AS TotalSchedules FROM ClassSchedule;
SELECT COUNT(*) AS TotalEnrollments FROM StudentEnrollments;
SELECT COUNT(*) AS TotalInvoices FROM Invoices;
GO
