﻿CREATE TABLE [dbo].[Roles]
(
	[Id_Role] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	RoleName VARCHAR(50) NOT NULL UNIQUE
)
