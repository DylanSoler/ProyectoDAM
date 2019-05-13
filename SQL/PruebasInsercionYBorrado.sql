
/*Pruebas insercion y borrado*/

----------------------------------------------------------INSERCION--------------------------------------------------------------

INSERT INTO Managers(Correo,PasswordManager, Nombre, Apellidos, FotoPerfil, FechaNacimiento)
				--VALUES('dylan@gmail.com',CAST('C0E7AEC81A1A194E9F54F6B297F6544041188C741AE8F55C2133B5C510A7DC1D' AS BINARY)
				--		,'Dylan','Soler Patino','/fotazas/micareto.png',NULL)
						VALUES('dylan@gmail.com',CONVERT(BINARY(64),'C0E7AEC81A1A194E9F54F6B297F6544041188C741AE8F55C2133B5C510A7DC1D')
						,'Dylan','Soler Patino','/fotazas/micareto.png',NULL)
				
SELECT * FROM Managers
---------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Entrenos(ID_Manager,Dia,Sesion1,Sesion2,SesionExtra)
				VALUES	(5,'Lunes','Fisico','Recuperacion','Descanso'),
						(5,'Martes','Defensivo','Tactico','Descanso'),
						(5,'Miercoles','Ofensivo','Tecnico','Descanso'),
						(5,'Jueves','Balon parado','Control','Descanso'),
						(5,'Viernes','Tacticas prepartido','Recuperacion','Descanso'),
						(5,'Sabado','','',''),
						(5,'Domingo','','','')
						
SELECT * FROM Entrenos

---------------------------------------------------------------------------------------------------------------------------------

INSERT INTO Notas(ID_Manager, Titulo, TextoNota)
				VALUES(5,'Retrasos','El jugador Luis Z ha llegado tarde hoy otra vez, como de costumbre'),
					  (5,'Entenos','Aumentar con sesion fisica')
				
SELECT * FROM Notas
DELETE FROM NOTAS --WHERE ID_Manager=5 AND ID_nota=8

---------------------------------------------------------------------------------------------------------------------------------

INSERT INTO ManagersTacticas(ID_Manager,ID_Tactica,Mentalidad,Descripcion)
								VALUES(5,5,'Ofensiva','Juego de posesión, con presión constante alta y verticalidad ofensiva')
								
SELECT * FROM ManagersTacticas


-----------------------------------------------------------BORRADO---------------------------------------------------------------

DELETE FROM Managers WHERE ID=5

SELECT * FROM Managers
SELECT * FROM ManagersTacticas
SELECT * FROM Entrenos
SELECT * FROM Notas
SELECT * FROM Tacticas

