CREATE DATABASE CourseAndResultManagement

CREATE TABLE Department
(
	DepartmentId INT IDENTITY(1,1) PRIMARY KEY,
	Code VARCHAR(8) NOT NULL UNIQUE,
	[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Semester
(
	SemesterId INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL UNIQUE
)

CREATE TABLE Course
(
	CourseId INT IDENTITY(1,1) PRIMARY KEY,
	Code VARCHAR(15) NOT NULL UNIQUE,
	[Name] VARCHAR(30) NOT NULL UNIQUE,
	Cradit DECIMAL(2,2) NOT NULL,
	[Description] VARCHAR(50),
	DepartmentId INT NOT NULL,
	SemesterId INT NOT NULL,

	FOREIGN KEY(DepartmentId) REFERENCES Department(DepartmentId),
	FOREIGN KEY(SemesterId) REFERENCES Semester(SemesterId) 
)

CREATE TABLE Designation 
(
	DesignationId INT IDENTITY(1,1) PRIMARY KEY,
	DesignationCode VARCHAR(10) UNIQUE NOT NULL,
	[Description] VARCHAR(30) NOT NULL 
)

CREATE TABLE Teacher 
(
	TeacherId INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	Email VARCHAR(50) UNIQUE NOT NULL,
	ContactNo VARCHAR(14) UNIQUE NOT NULL,
	DesignationId INT NOT NULL,
	DepartmentId INT NOT NULL,
	CraditToBeTaken DECIMAL(18,2) NOT NULL,
	[Address] VARCHAR(50),
	
	 FOREIGN KEY(DesignationId) REFERENCES Designation(DesignationId),
	 FOREIGN KEY(DepartmentId) REFERENCES Department(DepartmentId)
)

CREATE TABLE CourseAssignToTeacher
(
	CourseAssignToTeacherId INT IDENTITY(1,1) PRIMARY KEY,
	DepartmentId INT NOT NULL,
	TeacherId INT NOT NULL,
	CourseId INT NOT NULL UNIQUE,
	RemainingCradit DECIMAL(18,2),
	
	FOREIGN KEY(DepartmentId) REFERENCES Department(DepartmentId),
	FOREIGN KEY(TeacherId) REFERENCES Teacher(TeacherId),
	FOREIGN KEY(CourseId) REFERENCES Course(CourseId)	
)

CREATE TABLE RegisterStudent
(
	RegisterStudentId INT IDENTITY(1,1) PRIMARY KEY,
	RegistrationNumber VARCHAR(30) NOT NULL UNIQUE,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL,
	Email VARCHAR(30) NOT NULL UNIQUE,
	ContactNo VARCHAR(14) NOT NULL UNIQUE,
	RegistrationDate DATE,
	[Address] VARCHAR(100),

	FOREIGN KEY(DepartmentId) REFERENCES Department(DepartmentId)
)

CREATE TABLE [Week]
(
	WeekId INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(30) UNIQUE NOT NULL
)