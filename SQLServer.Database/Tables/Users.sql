﻿CREATE TABLE [dbo].[Users]
(
	[Id_User] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	UserName VARCHAR(200) NOT NULL,
	Email VARCHAR(254) NOT NULL UNIQUE,
	PasswordHash VARCHAR(250) NOT NULL,
	FK_Role UNIQUEIDENTIFIER FOREIGN KEY REFERENCES [Roles](Id_Role) NOT NULL
)
