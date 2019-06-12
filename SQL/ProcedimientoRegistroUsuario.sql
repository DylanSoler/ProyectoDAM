

--Procedimiento creación inicial de manager
GO
CREATE PROCEDURE RegistroManager (@correo nvarchar(50), @passwManager varchar(44), @nombre nvarchar(30), @apellidos nvarchar(30), @fotoPerfil nvarchar(60), @fechaNac smalldatetime, @filas int OUTPUT)
AS
	BEGIN

		--Variable donde almacenaremos el id del manager creado
		DECLARE @ID INT
		
		INSERT INTO Managers(Correo,PasswordManager, Nombre, Apellidos, FotoPerfil, FechaNacimiento)
					VALUES(@correo, @passwManager, @nombre, @apellidos, @fotoPerfil, @fechaNac)

		SET @ID=@@IDENTITY
		SET @filas=@@ROWCOUNT
		
		IF (@filas > 0)
		BEGIN
			INSERT INTO Entrenos(ID_Manager,Dia,Sesion1,Sesion2,SesionExtra)
						VALUES	(@ID,1,'','',''), (@ID,2,'','',''), (@ID,3,'','',''), (@ID,4,'','',''),
								(@ID,5,'','',''), (@ID,6,'','',''), (@ID,7,'','','')

			INSERT INTO ManagersTacticas(ID_Manager,ID_Tactica,Mentalidad,Descripcion) VALUES (@ID,5,'','')
		END
		
		RETURN @filas

	END
GO



--Prueba
DECLARE @resultado int
DECLARE @fechaActual smalldatetime = CONVERT(smalldatetime, CURRENT_TIMESTAMP)
EXECUTE RegistroManager @correo ='dylansio2@gmail.com', @passwManager='wOeuyBoaGU6fVPayl/ZUQEEYjHQa6PVcITO1xRCn3B0='
						, @nombre='Dylansio', @apellidos='Gonzalez', @fotoPerfil='ms-appx:///Assets/avatar.png'
						, @fechaNac=@fechaActual, @filas = @resultado OUTPUT

select @resultado
select * from Managers
select * from Entrenos
select * from ManagersTacticas
