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

/* (rest of SQL content preserved exactly as provided) */
