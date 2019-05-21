USE PersonaDB
GO

CREATE TABLE Managers (
	ID int identity(1,1) NOT NULL
		CONSTRAINT PK_Manager Primary Key,
	Correo nvarchar(50) NOT NULL UNIQUE,
	PassWordManager varchar(44) NOT NULL,
	Nombre nvarchar(30) NOT NULL,
	Apellidos nvarchar(30) NOT NULL,
	FotoPerfil nvarchar(30) NULL,
	FechaNacimiento smalldatetime
)

CREATE TABLE Notas (
	ID_nota int identity(1,1) NOT NULL
		CONSTRAINT PK_Notas Primary Key,
	ID_Manager int NOT NULL,
	Titulo nvarchar(30),
	TextoNota nvarchar(2000),
	CONSTRAINT FK_Notas_Manager 
		Foreign Key (ID_Manager) REFERENCES Managers(ID) 
		ON DELETE CASCADE
)

CREATE TABLE Entrenos (
	ID_Manager int NOT NULL,
	Dia tinyint NOT NULL,
	Sesion1 nvarchar(50) NULL,
	Sesion2 nvarchar(50) NULL,
	SesionExtra nvarchar(50) NULL,
	CONSTRAINT PK_Entrenos Primary Key (ID_Manager, Dia),
	CONSTRAINT FK_Entrenos_Manager 
		Foreign Key (ID_Manager) REFERENCES Managers(ID) 
		ON DELETE CASCADE
)

CREATE TABLE Tacticas (
	ID_Tactica tinyint identity NOT NULL
		CONSTRAINT PK_Tacticas Primary Key,
	Sistema nvarchar(30) NOT NULL
)

CREATE TABLE ManagersTacticas (
	ID_Manager int NOT NULL,
	ID_Tactica tinyint NOT NULL,
	Mentalidad nvarchar(20) NOT NULL,
	Descripcion nvarchar(1000) NULL,
	CONSTRAINT PK_ManagersTacticas Primary Key (ID_Manager, ID_Tactica),
	CONSTRAINT FK_ManagersTacticas_Managers 
		Foreign Key (ID_Manager) REFERENCES Managers(ID)
		ON DELETE CASCADE,
	CONSTRAINT FK_ManagersTacticas_Tacticas 
		Foreign Key (ID_Tactica) REFERENCES Tacticas(ID_Tactica)
		ON DELETE NO ACTION 
		ON UPDATE CASCADE
)