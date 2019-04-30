
/*Pruebas insercion y borrado*/

----------------------------------------------------------INSERCION--------------------------------------------------------------

INSERT INTO Managers(Correo,PasswordManager, Nombre, Apellidos, FotoPerfil, FechaNacimiento)
				VALUES('dylan@gmail.com',CAST('5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8' AS BINARY)
						,'Dylan','Soler Patino','/fotazas/micareto.png',NULL)
				
SELECT * FROM Managers

---------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Entrenos(ID_Manager,Dia,Sesion1,Sesion2,SesionExtra)
				VALUES	(2,'Lunes','Fisico','Recuperacion','Descanso'),
						(2,'Martes','Defensivo','Tactico','Descanso'),
						(2,'Miercoles','Ofensivo','Tecnico','Descanso'),
						(2,'Jueves','Balon parado','Control','Descanso'),
						(2,'Viernes','Tacticas prepartido','Recuperacion','Descanso'),
						(2,'Sabado','','',''),
						(2,'Domingo','','','')
						
SELECT * FROM Entrenos

---------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Notas(ID_Manager, Titulo, TextoNota)
				VALUES(2,'Retrasos','El jugador Luis Z ha llegado tarde hoy otra vez, como de costumbre')
				
SELECT * FROM Notas

---------------------------------------------------------------------------------------------------------------------------------

INSERT INTO ManagersTacticas(ID_Manager,ID_Tactica,Mentalidad,Descripcion)
								VALUES(2,5,'Ofensiva','Juego de posesión, con presión constante alta y verticalidad ofensiva')
								
SELECT * FROM ManagersTacticas


-----------------------------------------------------------BORRADO---------------------------------------------------------------

DELETE FROM Managers WHERE ID=2

SELECT * FROM Managers
SELECT * FROM ManagersTacticas
SELECT * FROM Entrenos
SELECT * FROM Notas
SELECT * FROM Tacticas

