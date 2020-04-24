IF DB_ID('TeamClub') IS NULL
CREATE DATABASE TeamClub
GO
USE TeamClub

-- DROP FOREIGN KEY CONSTRAINTS
IF OBJECT_ID('tblCoaches', 'U') IS NOT NULL 
	ALTER TABLE tblCoaches DROP CONSTRAINT FK_tblCoaches_tblTeams;

IF OBJECT_ID('tblPlayers', 'U') IS NOT NULL 
	ALTER TABLE tblPlayers DROP CONSTRAINT FK_tblPlayers_tblTeams;

--DROP PRIMARY KEY CONSTRAINTS

IF OBJECT_ID('tblTeams', 'U') IS NOT NULL 
	ALTER TABLE tblTeams DROP CONSTRAINT PK_TeamID;

IF OBJECT_ID('tblCoaches', 'U') IS NOT NULL 
	ALTER TABLE tblCoaches DROP CONSTRAINT PK_CoachID;

IF OBJECT_ID('tblPlayers', 'U') IS NOT NULL 
	ALTER TABLE tblPlayers DROP CONSTRAINT PK_PlayerID;

--DROP CHECK AND UNIQUE CONSTRAINTS
IF OBJECT_ID('tblPlayers', 'U') IS NOT NULL 
	ALTER TABLE tblPlayers DROP CONSTRAINT CH_PlayerSalary;

IF OBJECT_ID('tblPlayers', 'U') IS NOT NULL 
	ALTER TABLE tblPlayers DROP CONSTRAINT UQ_Number;

IF OBJECT_ID('tblCoaches', 'U') IS NOT NULL 
	ALTER TABLE tblCoaches DROP CONSTRAINT CH_CoachSalary;

--TABLES

IF OBJECT_ID('tblTeams', 'U') IS NOT NULL 
	DROP TABLE tblTeams;

CREATE TABLE tblTeams(
	TeamID int identity(1,1) not null,
	TeamName varchar(50) not null,
	DateOfEstablishment varchar(30) not null,
	HomeTown varchar(30) not null,
	constraint PK_TeamID primary key (TeamID)
)

IF OBJECT_ID('tblCoaches', 'U') IS NOT NULL 
	DROP TABLE tblCoaches;

CREATE TABLE tblCoaches(
	CoachID int identity(1,1) not null,
	TeamID int not null,
	CoachName varchar(50) not null,
	Salary decimal(8,2) not null,
	constraint PK_CoachID primary key (CoachID),
	constraint FK_tblCoaches_tblTeams foreign key (TeamID) references tblTeams (TeamID),
	constraint CH_CoachSalary check(Salary >= 0)
)


IF OBJECT_ID('tblPlayers', 'U') IS NOT NULL 
	DROP TABLE tblPlayers;

CREATE TABLE tblPlayers(
	PlayerID int identity(1,1) not null,
	TeamID int not null,
	PlayerName varchar(50) not null,
	Position varchar(50) not null,
	Number int not null,
	Salary decimal(8,2) not null,
	constraint PK_PlayerID primary key (PlayerID),
	constraint FK_tblPlayers_tblTeams foreign key (TeamID) references tblTeams (TeamID),
	constraint CH_PlayerSalary check(Salary >= 0),
	constraint UQ_Number unique(Number)
)

IF OBJECT_ID('vwPlayers', 'V') IS NOT NULL 
	DROP VIEW vwPlayers;

go
CREATE VIEW vwPlayers AS
SELECT p.PlayerName, t.TeamName, c.CoachName, p.Number, p.Position, p.PlayerID, t.TeamID, c.CoachID, p.Salary
FROM tblPlayers p left join tblTeams t
ON p.TeamID = t.TeamID left join tblCoaches c
ON c.TeamID = t.TeamID
go


insert into tblTeams values ('Drina', '2020-03-04', 'Ljubovija');
insert into tblTeams values ('Red Star', '2020-04-04', 'Belgrade');
insert into tblTeams values ('FC Barcelona', '2019-03-04', 'Barcelona');

insert into tblPlayers values (1, 'Pera', 'Left', 1, 10000);
insert into tblPlayers values (2, 'Zika', 'Center', 10, 20000);
insert into tblPlayers values (3, 'Mika', 'Right', 7, 50000);

insert into tblCoaches values (1, 'Marko', 15000);
insert into tblCoaches values (2, 'Filip', 30000);
insert into tblCoaches values (3, 'Kosta', 25000);