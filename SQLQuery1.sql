CREATE DATABASE Vezeeta;
USE Vezeeta;

CREATE TABLE Patient(ID INT IDENTITY(1,1) PRIMARY KEY, FirstName VARCHAR(100),
LastName VARCHAR(100), Password VARCHAR(100), Email VARCHAR(100), Age DECIMAL(18,2),
Type VARCHAR(100), Status INT,CreatedOn Datetime);

CREATE TABLE Doctor(ID INT IDENTITY(1,1) PRIMARY KEY, Name VARCHAR(100),
Specialization VARCHAR(100), UnitPrice DECIMAL(18,2),Discount DECIMAL(18,2),
Experience INT, ImageUrl VARCHAR(100), Status INT );

CREATE TABLE PatientHistory(ID INT IDENTITY(1,1) PRIMARY KEY, PatientId INT, DoctorId INT,
UnitPrice DECIMAL(18,2), Discont DECIMAL(18,2), TotalPrice DECIMAL(18,2));

CREATE TABLE AppointmentBookings(ID INT IDENTITY(1,1) PRIMARY KEY, PatientId INT,
AppointmentNo VARCHAR(100), AppointmentTotal DECIMAL(18,2), AppointmentStatus VARCHAR(100));

CREATE TABLE Appointment(ID INT IDENTITY(1,1) PRIMARY KEY, AppointmentId INT, DoctorId INT,
UnitPrice DECIMAL(18,2), Discount DECIMAL(18,2),Dates Datetime, TotalPrice DECIMAL);


