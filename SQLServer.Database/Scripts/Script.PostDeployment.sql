/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


-- VARIABLES
DECLARE @UserGUID UNIQUEIDENTIFIER = NEWID()
DECLARE @AdminGUID UNIQUEIDENTIFIER = NEWID()

DECLARE @RoleUserGUID UNIQUEIDENTIFIER = NEWID()
DECLARE @RoleAdminGUID UNIQUEIDENTIFIER = NEWID()

DECLARE @TodoStatusPendingGUID UNIQUEIDENTIFIER = NEWID()
DECLARE @TodoStatusInProgressGUID UNIQUEIDENTIFIER = NEWID()
DECLARE @TodoStatusFinishedGUID UNIQUEIDENTIFIER = NEWID()

DECLARE @Todo1GUID UNIQUEIDENTIFIER = NEWID()
DECLARE @Todo2GUID UNIQUEIDENTIFIER = NEWID()
DECLARE @Todo3GUID UNIQUEIDENTIFIER = NEWID()



-- ROLES
IF (SELECT * FROM Roles) = 0
    BEGIN
        INSERT INTO Roles (Id_Role, RoleName)
        VALUES 
                (@RoleUserGUID,'User'),
                (@RoleAdminGUID,'Admin')
    END


-- USERS
IF (SELECT * FROM Users) = 0
    BEGIN
        INSERT INTO Users (Id_User,UserName,Email,PasswordHash,FK_Role)
        VALUES
                (@UserGUID, 'user', 'user@mail.be','Test1234*',@RoleUserGUID),
                (@AdminGUID, 'admin', 'admin@mail.be','Test1234*',@RoleAdminGUID)
    END

-- TODOSTATUS
IF (SELECT * FROM TodoStatus) = 0
    BEGIN
        INSERT INTO TodoStatus (Id_TodoStatus, TodoStatusName)
        VALUES
                (@TodoStatusPendingGUID, 'Pending'),
                (@TodoStatusInProgressGUID, 'InProgress'),
                (@TodoStatusFinishedGUID, 'Finished')
    END


-- TODOS
IF (SELECT * FROM Todos) = 0
    BEGIN
        INSERT INTO Todos (Id_Todo, TodoName, TodoDescription, TodoCreatedAt, TodoUpdatedAt, TodoFinishedAt, TodoIsClosed, TodoPriority, FK_TodoStatus)
        VALUES
                (@Todo1GUID, 'Angular', 'Mise en pratique de RXJS', GETDATE(), NULL, NULL, 0, 0, @TodoStatusPendingGUID),
                (@Todo1GUID, 'Blazor Hybrid', 'Créer une app pour up mes skills en Anglais', GETDATE(), DATEADD(HOUR, 3, GETDATE()), NULL, 0, 1, @TodoStatusInProgressGUID),
                (@Todo1GUID, 'C#', 'Apprendre la clean architecture', GETDATE(), NULL, '2025-01-26 00:00:00',1,0,@TodoStatusFinishedGUID)
    END