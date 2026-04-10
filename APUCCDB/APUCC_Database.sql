/* =========================================
   APU CodeCamp Management System
   Full Database Script
   Includes Admin, Trainer, Lecturer, Student
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

/* =========================================
   5. CLASS SCHEDULE TABLE
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
   Student requests extra coaching
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
   Approved or lecturer-enrolled classes
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
   Kept for compatibility with existing code
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
   12. SAMPLE USERS
========================================= */
INSERT INTO Users (Username, [Password], [Role], [Name], Email, Phone, [Address])
VALUES
('admin1',    '123', 'Admin',    'Admin User',   'admin@test.com',    '0000000000', 'Admin Address'),
('trainer1',  '123', 'Trainer',  'Abdalla',      'abdalla@test.com',  '1234567890', 'Trainer Address'),
('trainer2',  '123', 'Trainer',  'Waleed',       'waleed@test.com',   '0987654321', 'Trainer Address 2'),
('lecturer1', '123', 'Lecturer', 'Dr Ahmad',     'ahmad@test.com',    '0133333333', 'APU'),
('lecturer2', '123', 'Lecturer', 'Ms Farah',     'farah@test.com',    '0144444444', 'APU'),
('student1',  '123', 'Student',  'Ali Ahmad',    'ali@test.com',      '0111111111', 'KL'),
('student2',  '123', 'Student',  'Nur Aina',     'aina@test.com',     '0122222222', 'Selangor'),
('student3',  '123', 'Student',  'John Lee',     'john@test.com',     '0155555555', 'Penang');
GO

/* =========================================
   13. SAMPLE TRAINERS
========================================= */
INSERT INTO Trainers (UserID, Qualifications, Specialisation, AssignedModuleId, AssignedModuleName, AssignedLevel)
VALUES
(2, 'BSc Computer Science', 'Programming', '120', 'Programming Fundamentals', 'Beginner'),
(3, 'MSc Software Engineering', 'Database', '220', 'Object Oriented Programming', 'Intermediate');
GO

/* =========================================
   14. SAMPLE LECTURERS
========================================= */
INSERT INTO Lecturers (UserID, Department, Specialisation)
VALUES
(4, 'School of Computing', 'Programming'),
(5, 'School of Computing', 'Database');
GO

/* =========================================
   15. SAMPLE STUDENTS
========================================= */
INSERT INTO Students (UserID, TPNumber, StudyLevel, ContactNumber, StudentAddress, MonthOfEnrollment, StudentStatus)
VALUES
(6, 'TP001', 'Level 1', '0111111111', 'KL',       'April 2026', 'Active'),
(7, 'TP002', 'Level 1', '0122222222', 'Selangor', 'April 2026', 'Active'),
(8, 'TP003', 'Level 2', '0155555555', 'Penang',   'April 2026', 'Active');
GO

/* =========================================
   16. SAMPLE CLASS SCHEDULE
========================================= */
INSERT INTO ClassSchedule (ModuleId, ModuleName, ClassDate, ClassTime, Charges, TrainerID, [Level], Room)
VALUES
('120', 'Programming Fundamentals', '2026-04-22', '09:00', 150.00, 1, 'Beginner',    'B-01'),
('220', 'Object Oriented Programming', '2026-04-23', '10:00', 200.00, 2, 'Intermediate', 'B-02'),
('320', 'Database Systems', '2026-04-24', '14:00', 260.00, 2, 'Advance', 'B-03');
GO

/* =========================================
   17. SAMPLE FEEDBACK
========================================= */
INSERT INTO Feedback (TrainerID, FeedbackType, [Message], DateSent, [Status])
VALUES
(1, 'General',    'Course completed successfully.', GETDATE(), 'Unread'),
(1, 'Suggestion', 'Need more practice sessions.',   GETDATE(), 'Unread'),
(2, 'Complaint',  'Project deadline is too short.', GETDATE(), 'Read');
GO

/* =========================================
   18. SAMPLE ENROLLMENT REQUESTS
========================================= */
INSERT INTO EnrollmentRequests (StudentID, ClassScheduleID, RequestDate, RequestStatus, Remarks, HandledByLecturerID, HandledDate)
VALUES
(1, 2, GETDATE(), 'Pending',   'Interested in extra OOP coaching', NULL, NULL),
(2, 1, GETDATE(), 'Approved',  'Requested by student', 1, GETDATE()),
(3, 3, GETDATE(), 'Rejected',  'Class already full',   2, GETDATE());
GO

/* =========================================
   19. SAMPLE STUDENT ENROLLMENTS
========================================= */
INSERT INTO StudentEnrollments (StudentID, ClassScheduleID, EnrolledDate, EnrollmentStatus, EnrolledByLecturerID, CompletedDate)
VALUES
(1, 1, GETDATE(), 'Active',    1, NULL),
(2, 2, GETDATE(), 'Active',    1, NULL),
(3, 3, GETDATE(), 'Completed', 2, GETDATE());
GO

/* =========================================
   20. SAMPLE INVOICES
========================================= */
INSERT INTO Invoices (EnrollmentID, InvoiceDate, Amount, InvoiceStatus, DueDate)
VALUES
(1, GETDATE(), 150.00, 'Unpaid', DATEADD(DAY, 7, GETDATE())),
(2, GETDATE(), 200.00, 'Paid',   DATEADD(DAY, 7, GETDATE())),
(3, GETDATE(), 260.00, 'Paid',   DATEADD(DAY, 7, GETDATE()));
GO

/* =========================================
   21. SAMPLE PAYMENT HISTORY
========================================= */
INSERT INTO PaymentHistory (InvoiceID, AmountPaid, PaymentDate, PaymentMethod, ReceiptNo, PaymentStatus)
VALUES
(2, 200.00, GETDATE(), 'Cash', 'RCPT-1001', 'Paid'),
(3, 260.00, GETDATE(), 'Card', 'RCPT-1002', 'Paid');
GO

/* =========================================
   22. SAMPLE LEGACY STUDENT PAYMENTS
========================================= */
INSERT INTO StudentPayments (ClassScheduleID, StudentName, Amount, PaymentDate, [Status])
VALUES
(1, 'Ali Ahmad', 150.00, GETDATE(), 'Paid'),
(2, 'Nur Aina',  200.00, GETDATE(), 'Paid'),
(3, 'John Lee',  260.00, GETDATE(), 'Paid');
GO

/* =========================================
   23. TEST QUERIES
========================================= */

-- All base tables
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
GO

/* =========================================
   24. STUDENT HOME FORM QUERY
   View enrolled schedule
========================================= */
SELECT 
    se.EnrollmentID,
    s.StudentID,
    su.[Name] AS StudentName,
    cs.ModuleId,
    cs.ModuleName,
    cs.ClassDate,
    cs.ClassTime,
    cs.Room,
    cs.[Level],
    tu.[Name] AS TrainerName,
    se.EnrollmentStatus
FROM StudentEnrollments se
INNER JOIN Students s ON se.StudentID = s.StudentID
INNER JOIN Users su ON s.UserID = su.UserID
INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
LEFT JOIN Trainers t ON cs.TrainerID = t.TrainerID
LEFT JOIN Users tu ON t.UserID = tu.UserID
ORDER BY cs.ClassDate, cs.ClassTime;
GO

/* =========================================
   25. STUDENT COURSES FORM QUERY
   Current enrolled courses
========================================= */
SELECT
    s.StudentID,
    u.[Name] AS StudentName,
    cs.ModuleName,
    cs.[Level],
    cs.ClassDate,
    cs.ClassTime,
    se.EnrollmentStatus
FROM StudentEnrollments se
INNER JOIN Students s ON se.StudentID = s.StudentID
INNER JOIN Users u ON s.UserID = u.UserID
INNER JOIN ClassSchedule cs ON se.ClassScheduleID = cs.Id
ORDER BY u.[Name];
GO

/* =========================================
   26. STUDENT REQUESTS QUERY
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
   27. STUDENT FEES FORM QUERY
   Outstanding invoices + payment history
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
   28. LECTURER VIEW STUDENT LIST
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
   29. LECTURER APPROVE REQUEST EXAMPLE
========================================= */
-- Example only:
-- UPDATE EnrollmentRequests
-- SET RequestStatus = 'Approved',
--     HandledByLecturerID = 1,
--     HandledDate = GETDATE()
-- WHERE RequestID = 1;

-- INSERT INTO StudentEnrollments (StudentID, ClassScheduleID, EnrolledDate, EnrollmentStatus, EnrolledByLecturerID)
-- SELECT StudentID, ClassScheduleID, GETDATE(), 'Active', 1
-- FROM EnrollmentRequests
-- WHERE RequestID = 1;
GO

/* =========================================
   30. STUDENT PAYMENT EXAMPLE
========================================= */
-- Example only:
-- INSERT INTO PaymentHistory (InvoiceID, AmountPaid, PaymentDate, PaymentMethod, ReceiptNo, PaymentStatus)
-- VALUES (1, 150.00, GETDATE(), 'Online Transfer', 'RCPT-2001', 'Paid');

-- UPDATE Invoices
-- SET InvoiceStatus = 'Paid'
-- WHERE InvoiceID = 1;
GO

SELECT * FROM Lecturers;
SELECT * FROM Students;
SELECT * FROM EnrollmentRequests;
SELECT * FROM StudentEnrollments;
SELECT * FROM Invoices;
SELECT * FROM PaymentHistory;