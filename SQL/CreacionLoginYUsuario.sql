
--Creación de login y usuario

USE master--escribir manualmente

CREATE LOGIN FTMUser with password = '123qwerty.'--, default_database=personasDB
GO

USE personaDB--escribir manualmente

CREATE USER FTMUser FOR LOGIN FTMUser GRANT INSERT, UPDATE, DELETE, EXECUTE TO FTMUser
GO

ALTER ROLE db_owner ADD MEMBER FTMUser
ALTER ROLE db_datareader ADD MEMBER FTMUser
ALTER ROLE db_datawriter ADD MEMBER FTMUser