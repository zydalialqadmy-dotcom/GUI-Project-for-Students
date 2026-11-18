-- =========================================================
-- StudentGradesDB Database Setup Script
-- System: SQL Server Express LocalDB
-- =========================================================

-- 1. Create Database if not exists
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'StudentGradesDB')
BEGIN
    CREATE DATABASE StudentGradesDB;
END
GO

USE StudentGradesDB;
GO

-- 2. Drop Tables if exist (for clean setup)
IF OBJECT_ID('dbo.Grades', 'U') IS NOT NULL DROP TABLE dbo.Grades;
IF OBJECT_ID('dbo.Subjects', 'U') IS NOT NULL DROP TABLE dbo.Subjects;
IF OBJECT_ID('dbo.Students', 'U') IS NOT NULL DROP TABLE dbo.Students;
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL DROP TABLE dbo.Users;
GO

-- 3. Create Users Table
CREATE TABLE Users (
    UserId INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL
);
GO

-- 4. Create Students Table
CREATE TABLE Students (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    StudentName NVARCHAR(100) NOT NULL,
    StudentNumber NVARCHAR(50) NOT NULL,
    Department NVARCHAR(100) NOT NULL
);
GO

-- 5. Create Subjects Table
CREATE TABLE Subjects (
    SubjectId INT PRIMARY KEY IDENTITY(1,1),
    SubjectName NVARCHAR(100) NOT NULL,
    Hours INT NOT NULL
);
GO

-- 6. Create Grades Table (Note: Grade only, Result & Evaluation calculated in C#)
CREATE TABLE Grades (
    GradeId INT PRIMARY KEY IDENTITY(1,1),
    StudentId INT NOT NULL FOREIGN KEY REFERENCES Students(StudentId) ON DELETE CASCADE,
    SubjectId INT NOT NULL FOREIGN KEY REFERENCES Subjects(SubjectId) ON DELETE CASCADE,
    Grade DECIMAL(5,2) NOT NULL
);
GO

-- 7. Insert Sample Seed Data
INSERT INTO Users (Username, Password, Role) VALUES
('Admin', '1234', 'Admin'),
('Teacher', '1234', 'Teacher');

INSERT INTO Students (StudentName, StudentNumber, Department) VALUES
('Ahmed Ali', 'S1001', 'Computer Science'),
('Sara Mohamed', 'S1002', 'Information Technology'),
('Omar Hassan', 'S1003', 'Software Engineering');

INSERT INTO Subjects (SubjectName, Hours) VALUES
('Programming 1', 3),
('Database Systems', 3),
('Visual Programming', 4);

INSERT INTO Grades (StudentId, SubjectId, Grade) VALUES
(1, 1, 95.50),
(1, 2, 88.00),
(2, 1, 72.00),
(2, 3, 45.00),
(3, 2, 64.50);
GO
