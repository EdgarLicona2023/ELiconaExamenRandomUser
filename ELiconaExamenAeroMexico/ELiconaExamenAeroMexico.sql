CREATE DATABASE ELiconaExamenAeroMexico


CREATE TABLE Pasajero (
    IdPasajero INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Nombre VARCHAR(50)NOT NULL,
	ApellidoPaterno VARCHAR(50)NOT NULL,
	ApellidoMaterno VARCHAR(50)NOT NULL,
	UserName VARCHAR(50)NOT NULL,
	Correo VARCHAR(50)NOT NULL,
    Password VARBINARY(20)NOT NULL
)
--SELECT*FROM Pasajero


CREATE TABLE Vuelo(
IdVuelo INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
NumeroVuelo VARCHAR(4) NOT NULL,
Origen VARCHAR(2) NOT NULL,
Destino VARCHAR(2) NOT NULL,
FechaSalida Datetime
)
--INSERT INTO Vuelo VALUES ('1005','44','66',SYSDATETIME())

CREATE PROCEDURE GetAllVuelo 
AS
SELECT
IdVuelo,
NumeroVuelo,
Origen,
Destino,
FechaSalida
FROM Vuelo
GO

CREATE PROCEDURE GetAllVueloRango --14-07-2023, 17-07-2023
@inicio DATE,
@fin DATE
AS	
SELECT 
IdVuelo,
NumeroVuelo,
Origen,
Destino,
FechaSalid
--CONVERT(datetime, FechaSalida, 103)
FROM Vuelo
WHERE FechaSalida BETWEEN '2023-07-17' AND '2023-07-17'
GO





TRUNCATE TABLE Vuelo
--SELECT*FROM Vuelo
--INSERT INTO Vuelo VALUES ('1002','22','45',GETDATE()),('1003','55','11',GETDATE())

CREATE TABLE ReservacionVuelos(
IdReservacionVuelos INT IDENTITY(1,1)PRIMARY KEY)

ALTER TABLE ReservacionVuelos
ADD IdPasajero INT REFERENCES Pasajero(IdPasajero)

ALTER TABLE ReservacionVuelos
ADD IdVuelo INT REFERENCES Vuelo(IdVuelo)

--TRUNCATE TABLE ReservacionVuelos
--SELECT*FROM ReservacionVuelos


--'EDGAR ALEJANDRO','LICONA','GRANDE','LICONSS','LICONA@GMAIL.COM',1111
--'JIMENA','HERNANDEZ','MORALES','JINENA','JIME@GMAIL.COM',2222



CREATE PROCEDURE AddPasajero 
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@UserName VARCHAR(50),
@Correo VARCHAR (50),
@Password VARBINARY(20)
AS
BEGIN
INSERT INTO Pasajero
(
Nombre,
ApellidoPaterno,
ApellidoMaterno,
UserName,
Correo,
Password)
VALUES
(
@Nombre,
@ApellidoPaterno,
@ApellidoMaterno,
@UserName,
@Correo,
@Password)
END
GO


CREATE PROCEDURE UsuarioGetByUserName 
@UserName VARCHAR(50)
AS
SELECT 
IdLogin,
Nombre,
ApellidoPaterno,
ApellidoMaterno,
UserName,
Correo,
Password
          
FROM Login
  
WHERE Login.Correo = @UserName


CREATE PROCEDURE GetAllPasajero
AS
SELECT
Nombre,
ApellidoPaterno,
ApellidoMaterno,
UserName,
Correo,
Password
FROM Pasajero
GO

CREATE PROCEDURE UsuarioGetByUserNamePasa 
@UserName VARCHAR(50)
AS
SELECT 
IdPasajero,
Nombre,
ApellidoPaterno,
ApellidoMaterno,
UserName,
Correo,
Password
          
FROM Pasajero
  
WHERE Pasajero.Correo = @UserName

TRUNCATE TABLE Pasajero
GetAllPasajero