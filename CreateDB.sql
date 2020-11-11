--create database Course1
--go

use Course1
go

CREATE TABLE [Staffs] (
  [staffId] int PRIMARY KEY identity(1,1),
  [FIO] varchar(100),
  [trainId] int,
  [postId] int,
  [age] int,
  [workExp] int
)
GO

--CREATE TABLE [Posts] (
--  [postId] int PRIMARY KEY identity(1,1),
--  [nameOfPost] varchar(50)
--)
--GO

CREATE TABLE [Trains] (
  [trainId] int PRIMARY KEY identity(1,1),
  [typeId] int,
  [isFirm] bit,
  [isStation] bit,
  [isHall] bit
)
GO

CREATE TABLE [Types] (
  [typeId] int PRIMARY KEY identity(1,1),
  [nameOfType] varchar(30)
)
GO

CREATE TABLE [Schedules] (
  [scheduleId] int PRIMARY KEY identity(1,1),
  [trainId] int,
  [day] varchar(10),
  [stopId] int,
  [distance] float,
  [timeOfDeparture] time,
  [timeOfArrive] time
)
GO

--CREATE TABLE [Stops] (
--  [stopId] int PRIMARY KEY identity(1,1),
--  [nameOfStop] varchar(30),
--  [isStation] bit,
--  [isHall] bit
--)
--GO

ALTER TABLE [Staffs] ADD FOREIGN KEY ([trainId]) REFERENCES [Trains] ([trainId])
GO

ALTER TABLE [Staffs] ADD FOREIGN KEY ([postId]) REFERENCES [Posts] ([postId])
GO

ALTER TABLE [Trains] ADD FOREIGN KEY ([typeId]) REFERENCES [Types] ([typeId])
GO

ALTER TABLE [Schedules] ADD FOREIGN KEY ([trainId]) REFERENCES [Trains] ([trainId])
GO

ALTER TABLE [Schedules] ADD FOREIGN KEY ([stopId]) REFERENCES [Stops] ([stopId])
GO
