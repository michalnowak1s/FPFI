CREATE DATABASE FPFI


USE FPFI;
GO


CREATE TABLE Accounts (
AccountID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
Login char(255) UNIQUE,
Password char(255)
);



select *
from Accounts



INSERT INTO Accounts(
	Login,
	Password)
	VALUES(
	'Tomek',
	'Admin');


INSERT INTO Accounts(
	Login,
	Password)
	VALUES(
	'Ola',
	'Admin');



INSERT INTO Accounts(
	Login,
	Password)
	VALUES(
	'Kasia',
	'Admin');


