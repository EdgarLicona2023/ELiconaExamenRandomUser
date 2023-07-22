CREATE DATABASE ELiocnaPracticoApoloServives

CREATE TABLE Sexo
(
IdSexo INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Sexos VARCHAR (10)NOT NULL
)
--INSERT INTO Sexo VALUES ('Hombre'),('Mujer')
--SELECT*FROM Sexo

CREATE TABLE EstadoCivil
(
IdEstadoCivil INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
EstadoCivil VARCHAR(50)NOT NULL
)
--INSERT INTO EstadoCivil VALUES ('Soltero(a)'),('Casado(a)'),('Union Libre')
--SELECT*FROM EstadoCivil


CREATE TABLE Puesto
(
IdPuesto INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Puestos VARCHAR(50)NOT NULL
)
--INSERT INTO Puesto VALUES ('Supervisor(a)'),('Director(a)'),('Jefe(a) Carrera'),('Profesor(a)'),('Tutor(a)')
--SELECT*FROM Puesto

CREATE TABLE Area
(
IdArea INT IDENTITY(1,1) PRIMARY KEY,
Areas VARCHAR(50) NOT NULL
)

--INSERT INTO Area VALUES ('Sistemas Computacionales'),('Electronica'),('Administracion'),('Industrial'),('Electromecanica')
--SELECT*FROM Area

CREATE TABLE Departamento
(
IdDepartamento INT IDENTITY(1,1) PRIMARY KEY,
Departamentos VARCHAR(50) NOT NULL
)
ALTER TABLE Departamento
ADD IdArea INT REFERENCES Area(IdArea)

--INSERT INTO Departamento VALUES ('Informatica',1),('Simulacion',1),('Arquitectura',1),
--('Electricidad', 2),('Circuitos',2),('Admin Empresas',3),('Finanzas',3),
--('Control de Calidad',4),('Higiene',4),('Motores',5),('Soldaduras',5)
--SELECT*FROM Departamento




CREATE TABLE Usuario
(
IdUser INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
UserName VARCHAR(50)NOT NULL,
Nombre VARCHAR(50)NOT NULL,
ApellidoPaterno VARCHAR(50)NOT NULL,
ApellidoMaterno VARCHAR(50)NOT NULL,
Email VARCHAR(50)NOT NULL,
Password VARCHAR(50)NOT NULL,
FechaNacimiento VARCHAR(50) NOT NULL,
Telefono Numeric(12)NULL,
Imagen VARBINARY (MAX)NULL
) 

ALTER TABLE Usuario
ADD IdSexo INT REFERENCES Sexo(IdSexo)

ALTER TABLE Usuario
ADD IdEstadoCivil INT REFERENCES EstadoCivil(IdEstadoCivil)

ALTER TABLE Usuario
ADD IdPuesto INT REFERENCES Puesto(IdPuesto)

ALTER TABLE Usuario
ADD  IdDepartamento INT REFERENCES Departamento(IdDepartamento)

--INSERT INTO Usuario VALUES('LICONSS','EDGAR','LICONA','GRANDE','ALE@GMAIL.COM','1111','06/02/1998',5631457841,0,1,1,1,1)
--SELECT * FROM Usuario

CREATE PROCEDURE GetAllUsuario
AS
SELECT 
U.IdUser,
U.UserName,
U.Nombre,
U.ApellidoPaterno,
U.ApellidoMaterno,
U.Email,
U.Password,
--U.FechaNacimiento,
U.FechaNacimiento,
U.Telefono,
U.Imagen,
S.IdSexo,
s.Sexos,
EV.IdEstadoCivil,
EV.EstadoCivil,
P.IdPuesto,
P.Puestos,
D.IdDepartamento,
D.Departamentos,
A.IdArea,
A.Areas


FROM Usuario U

INNER JOIN Sexo S ON U.IdSexo = S.IdSexo
INNER JOIN EstadoCivil EV ON U.IdEstadoCivil = EV.IdEstadoCivil
INNER JOIN Puesto P ON U.IdPuesto = P.IdPuesto
INNER JOIN Departamento D ON U.IdDepartamento = D.IdDepartamento
INNER JOIN Area A on D.IdArea = A.IdArea

--'JIME','JIMENA','HERNANDEZ','MORALES','JIME@GMAIL.COM','2222','25-06-2000',554323456787,0,2,2,3,3

CREATE PROCEDURE AddUsuario --'LICONSS','EDGAR','LICONA','GRANDE','LICONA@GMAIL.COM','1111','06-02-1998',5631457841,0,1,1,1,1
@UserName VARCHAR(50),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Email VARCHAR(50),
@Password VARCHAR(50),
@FechaNacimiento VARCHAR(50),
@Telefono Numeric(12),
@Imagen VARBINARY (MAX),
@IdSexo INT,
@IdEstadoCivil INT,
@IdPuesto INT,
@IdDepartamento INT

AS
BEGIN
INSERT INTO [Usuario]
(
[UserName],
[Nombre],
[ApellidoPaterno],
[ApellidoMaterno],
[Email],
[Password],
[FechaNacimiento],
[Telefono],
[Imagen],
[IdSexo],
[IdEstadoCivil],
[IdPuesto],
[IdDepartamento]
)
VALUES 
(
@UserName,
@Nombre,
@ApellidoPaterno,
@ApellidoMaterno,
@Email,
@Password,
--@FechaNacimiento,
CONVERT (DATE,@FechaNacimiento,103),
@Telefono,
@Imagen,
@IdSexo,
@IdEstadoCivil,
@IdPuesto,
@IdDepartamento
)
END


CREATE PROCEDURE UpdateUsuario --2,'AMRY','IRMA','GRANDE','SALAZAR','AMRY@GMAIL.COM','3333','17-03-1978',553465764532,0,2,3,4,4
@IdUser INT,
@UserName VARCHAR(50),
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Email VARCHAR(50),
@Password VARCHAR(50),
@FechaNacimiento VARCHAR(50),
@Telefono Numeric(12),
@Imagen VARBINARY (MAX),
@IdSexo INT,
@IdEstadoCivil INT,
@IdPuesto INT,
@IdDepartamento INT
AS
UPDATE Usuario SET 
UserName = @UserName,
Nombre = @Nombre,
ApellidoPaterno =@ApellidoPaterno,
ApellidoMaterno =@ApellidoMaterno,
Email =@Email,
Password = @Password,
FechaNacimiento=CONVERT (DATE,@FechaNacimiento,105),
Telefono = @Telefono,
Imagen = @Imagen,
IdSexo = @IdSexo,
IdEstadoCivil = @IdEstadoCivil,
IdPuesto = @IdPuesto,
IdDepartamento = @IdDepartamento
WHERE IdUser = @IdUser
--GetAllUsuario


CREATE PROCEDURE GetByIdUsuario 2
@IdUser INT 
AS
SELECT
U.IdUser,
U.UserName,
U.Nombre,
U.ApellidoPaterno,
U.ApellidoMaterno,
U.Email,
U.Password,
--U.FechaNacimiento,
U.FechaNacimiento,
U.Telefono,
U.Imagen,
S.IdSexo,
s.Sexos,
EV.IdEstadoCivil,
EV.EstadoCivil,
P.IdPuesto,
P.Puestos,
D.IdDepartamento,
D.Departamentos,
A.IdArea,
A.Areas


FROM Usuario U

INNER JOIN Sexo S ON U.IdSexo = S.IdSexo
INNER JOIN EstadoCivil EV ON U.IdEstadoCivil = EV.IdEstadoCivil
INNER JOIN Puesto P ON U.IdPuesto = P.IdPuesto
INNER JOIN Departamento D ON U.IdDepartamento = D.IdDepartamento
INNER JOIN Area A on D.IdArea = A.IdArea

WHERE U.IdUser = @IdUser


CREATE PROCEDURE DeleteUsuario 
@IdUser INT 
AS
DELETE FROM Usuario
WHERE IdUser = @IdUser

--GetAllUsuario
CREATE PROCEDURE GetAllArea
AS
SELECT 
	IdArea,
	Areas
FROM Area
GO

CREATE PROCEDURE GetAllDepartamento
AS
SELECT 
	IdDepartamento,
	Departamentos
FROM Departamento
GO

CREATE PROCEDURE DepartamentoGetBYIdArea 
@IdArea INT
AS
SELECT 
IdDepartamento,
Departamentos,
IdArea
From Departamento
WHERE IdArea = @IdArea
GO

CREATE PROCEDURE GetAllSexo
AS
SELECT 
	IdSexo,
	Sexos
FROM Sexo
GO

CREATE PROCEDURE GetAllPuesto
AS
SELECT 
	IdPuesto,
	Puestos
FROM Puesto
GO

CREATE PROCEDURE GetAllEstadoCivil
AS
SELECT 
	IdEstadoCivil,
	EstadoCivil
FROM EstadoCivil
GO



--GetAllUsuario
--TRUNCATE TABLE Usuario