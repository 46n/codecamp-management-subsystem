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
   3. CLASS SCHEDULE TABLE
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
    CONSTRAINT FK_ClassSchedule_Trainers
        FOREIGN KEY (TrainerID) REFERENCES Trainers(TrainerID)
);
GO

ALTER TABLE ClassSchedule
ADD CONSTRAINT UQ_ClassSchedule_ModuleDateTime
UNIQUE (ModuleId, ClassDate, ClassTime);
GO

/* =========================================
   4. FEEDBACK TABLE
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
   5. STUDENT PAYMENTS TABLE
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
   6. SAMPLE USERS
========================================= */
INSERT INTO Users (Username, [Password], [Role], [Name], Email, Phone, [Address])
VALUES
('admin1',   '123', 'Admin',   'Admin User', 'admin@test.com',   '0000000000', 'Admin Address'),
('trainer1', '123', 'Trainer', 'Abdalla',    'abdalla@test.com', '1234567890', 'Trainer Address'),
('trainer2', '123', 'Trainer', 'Waleed',     'waleed@test.com',  '0987654321', 'Trainer Address 2');
GO

/* =========================================
   7. SAMPLE TRAINERS
========================================= */
INSERT INTO Trainers (UserID, Qualifications, Specialisation, AssignedModuleId, AssignedModuleName, AssignedLevel)
VALUES
(2, 'BSc', 'Math',    'M1', 'Mathematics', 'Level 1'),
(3, 'MSc', 'Science', 'M2', 'Science',     'Level 2');
GO

/* =========================================
   8. SAMPLE CLASS SCHEDULE
========================================= */
INSERT INTO ClassSchedule (ModuleId, ModuleName, ClassDate, ClassTime, Charges, TrainerID, [Level])
VALUES
('M1', 'Mathematics', '2026-04-22', '04:00', 299.00, 1, 'Level 1'),
('M2', 'Science',     '2026-04-23', '05:30', 350.00, 2, 'Level 2');
GO

/* =========================================
   9. SAMPLE FEEDBACK
========================================= */
INSERT INTO Feedback (TrainerID, FeedbackType, [Message], DateSent, [Status])
VALUES
(1, 'General',    'Course completed successfully.', GETDATE(), 'Unread'),
(1, 'Suggestion', 'Need more practice sessions.',   GETDATE(), 'Unread'),
(2, 'Complaint',  'Project deadline is too short.', GETDATE(), 'Read');
GO

/* =========================================
   10. SAMPLE STUDENT PAYMENTS
========================================= */
INSERT INTO StudentPayments (ClassScheduleID, StudentName, Amount, PaymentDate, [Status])
VALUES
(1, 'Ali',  299.00, GETDATE(), 'Paid'),
(1, 'Sara', 299.00, GETDATE(), 'Paid'),
(2, 'Omar', 350.00, GETDATE(), 'Paid');
GO

/* =========================================
   11. TEST QUERIES
========================================= */
SELECT * FROM Users;
SELECT * FROM Trainers;
SELECT * FROM ClassSchedule;
SELECT * FROM Feedback;
SELECT * FROM StudentPayments;

SELECT 
    f.FeedbackID,
    u.Name AS TrainerName,
    f.FeedbackType,
    f.[Message],
    f.DateSent,
    f.[Status]
FROM Feedback f
INNER JOIN Trainers t ON f.TrainerID = t.TrainerID
INNER JOIN Users u ON t.UserID = u.UserID
ORDER BY f.FeedbackID DESC;
GO
USE MyDatabase;
GO

IF COL_LENGTH('ClassSchedule', 'TrainerID') IS NULL
BEGIN
    ALTER TABLE ClassSchedule
    ADD TrainerID INT NULL;
END
GO

IF COL_LENGTH('ClassSchedule', 'Level') IS NULL
BEGIN
    ALTER TABLE ClassSchedule
    ADD [Level] NVARCHAR(20) NULL;
END
GO

IF OBJECT_ID('StudentPayments', 'U') IS NULL
BEGIN
    CREATE TABLE StudentPayments
    (
        PaymentID INT PRIMARY KEY IDENTITY(1,1),
        ClassScheduleID INT NOT NULL,
        StudentName NVARCHAR(100) NOT NULL,
        Amount DECIMAL(10,2) NOT NULL,
        PaymentDate DATE NOT NULL DEFAULT GETDATE(),
        [Status] NVARCHAR(20) NOT NULL DEFAULT 'Paid'
    );
END
GO
USE MyDatabase;
GO

-- Example: assign trainer and level to existing class schedule rows
UPDATE ClassSchedule
SET TrainerID = 1, [Level] = 'Beginner'
WHERE ModuleId = '120';
GO

-- Add more sample class rows if needed
INSERT INTO ClassSchedule (ModuleId, ModuleName, ClassDate, ClassTime, Charges, TrainerID, [Level])
VALUES
('220', 'OOP', '2026-04-23', '10:00', 200, 2, 'Intermediate'),
('320', 'Database', '2026-04-24', '14:00', 260, 2, 'Advance');
GO

-- Sample student payments
INSERT INTO StudentPayments (ClassScheduleID, StudentName, Amount, PaymentDate, [Status])
VALUES
(1, 'Ali Ahmad', 299.00, '2026-04-10', 'Paid'),
(1, 'Nur Aina', 299.00, '2026-04-12', 'Paid'),
(1, 'John Lee', 299.00, '2026-04-15', 'Paid'),
(2, 'Suresh', 200.00, '2026-04-11', 'Paid'),
(2, 'Mina', 200.00, '2026-04-13', 'Paid'),
(3, 'Amir', 260.00, '2026-04-14', 'Paid');
GO
USE MyDatabase;
GO

SELECT TrainerID, UserID
FROM Trainers;
SELECT Id, ModuleId, ModuleName, TrainerID, [Level]
FROM ClassSchedule;