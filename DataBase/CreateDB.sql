create database Course1
go

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

CREATE TABLE [Posts] (
  [postId] int PRIMARY KEY identity(1,1),
  [nameOfPost] varchar(50)
)
GO

CREATE TABLE [Trains] (
  [trainId] int PRIMARY KEY identity(1,1),
  [typeId] int,
  isFirm bit
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
  [beginStopId] int,
  [endStopId] int,
  [distance] float,
  [timeOfArrive] time
)
GO

CREATE TABLE [Stops] (
  [stopId] int PRIMARY KEY identity(1,1),
  [nameOfStop] varchar(30)
)
GO

ALTER TABLE [Staffs] ADD FOREIGN KEY ([trainId]) REFERENCES [Trains] ([trainId])
GO

ALTER TABLE [Staffs] ADD FOREIGN KEY ([postId]) REFERENCES [Posts] ([postId])
GO

ALTER TABLE [Trains] ADD FOREIGN KEY ([typeId]) REFERENCES [Types] ([typeId])
GO

ALTER TABLE [Schedules] ADD FOREIGN KEY ([trainId]) REFERENCES [Trains] ([trainId])
GO

ALTER TABLE [Schedules] ADD FOREIGN KEY ([beginStopId]) REFERENCES [Stops] ([stopId])
GO

ALTER TABLE [Schedules] ADD FOREIGN KEY ([endStopId]) REFERENCES [Stops] ([stopId])
GO