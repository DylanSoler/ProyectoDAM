
/*Pruebas insercion y borrado*/

----------------------------------------------------------INSERCION--------------------------------------------------------------

INSERT INTO Managers(Correo,PasswordManager, Nombre, Apellidos, FotoPerfil, FechaNacimiento)
					VALUES('dylanadriansoler@gmail.com','wOeuyBoaGU6fVPayl/ZUQEEYjHQa6PVcITO1xRCn3B0='
							,'Dylan','Soler Patino','ms-appx:///Assets/Avatares/man1.png','1993-04-12 19:36:00')
				
SELECT * FROM Managers

DECLARE @ID int
	SET @ID = @@IDENTITY
---------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Entrenos(ID_Manager,Dia,Sesion1,Sesion2,SesionExtra)
				VALUES	(@ID,1,'Fisico','Recuperacion','Descanso'),
						(@ID,2,'Defensivo','Tactico','Descanso'),
						(@ID,3,'Ofensivo','Tecnico','Descanso'),
						(@ID,4,'Balon parado','Control','Descanso'),
						(@ID,5,'Tacticas prepartido','Recuperacion','Descanso'),
						(@ID,6,'','',''),
						(@ID,7,'','','')
						

---------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Notas(ID_Manager, Titulo, TextoNota, FechaCreacion)
				VALUES(@ID,'Retrasos','El jugador Luis Z ha llegado tarde hoy otra vez, como de costumbre',GETDATE()),
					  (@ID,'Entenos','Aumentar con sesion fisica',GETDATE()),
					  (@ID,'Retrasos','El jugador Luis Z ha llegado tarde hoy otra vez, como de costumbre',GETDATE()),
					  (@ID,'Entenos','Aumentar con sesion fisica',GETDATE()),
					  (@ID,'Retrasos','El jugador Luis Z ha llegado tarde hoy otra vez, como de costumbre',GETDATE()),
					  (@ID,'Entenos','Aumentar con sesion fisica',GETDATE()),
					  (@ID,'Retrasos','El jugador Luis Z ha llegado tarde hoy otra vez, como de costumbre. El jugador Luis Z ha llegado tarde hoy otra vez, como de costumbre
						El jugador Luis Z ha llegado tarde hoy otra vez, como de costumbreEl jugador Luis Z ha llegado tarde hoy otra vez, como de costumbre dfhdhrhehrehrhrhr
						El jugador Luis Z ha llegado tarde hoy otra vez, como de costumbreEl jugador Luis Z ha llegado tarde hoy otra vez, como de costumbre',GETDATE()),
					  (@ID,'Entenos','Aumentar con sesion fisica',GETDATE()),
					  (@ID,'Retrasos','El jugador Luis Z ha llegado tarde hoy otra vez, como de costumbre',GETDATE()),
					  (@ID,'Entenos','Aumentar con sesion fisica',GETDATE())

---------------------------------------------------------------------------------------------------------------------------------

INSERT INTO ManagersTacticas(ID_Manager,ID_Tactica,Mentalidad,Descripcion)
								VALUES(@ID,5,'Ofensiva','Juego de posesión, con presión constante alta y verticalidad ofensiva. Tirar fuera de juego con linea defensiva adelantada.')
								

-----------------------------------------------------------BORRADO---------------------------------------------------------------

--DELETE FROM Managers WHERE ID=@ID

SELECT * FROM Managers
SELECT * FROM ManagersTacticas
SELECT * FROM Entrenos
SELECT * FROM Notas
SELECT * FROM Tacticas