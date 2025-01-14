﻿CREATE TABLE [dbo].[Todos]
(
	[Id_Todo] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	TodoName VARCHAR(150) NOT NULL,
    TodoDescription VARCHAR(250) NOT NULL,
    TodoCreatedAt DATETIME NOT NULL,
    TodoFinishedAt DATETIME,
    TodoIsClosed BIT NOT NULL DEFAULT 0,
    TodoUpdatedAt DATETIME,
    TodoPriority BIT NOT NULL DEFAULT 0,
    FK_TodoStatus UNIQUEIDENTIFIER FOREIGN KEY REFERENCES TodoStatus(Id_TodoStatus) NOT NULL,
    FK_User UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(Id_User) NOT NULL
)
