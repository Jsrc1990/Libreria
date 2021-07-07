CREATE TABLE Autor
(
Id VARCHAR(32) DEFAULT sys_guid() PRIMARY KEY,
NombreCompleto VARCHAR(100) NOT NULL,
FechaNacimiento DATE NOT NULL,
CiudadProcedencia VARCHAR(32) NOT NULL,
CorreoElectronico VARCHAR(100) UNIQUE NOT NULL,
FOREIGN KEY(CiudadProcedencia) REFERENCES Ciudad(Id)
)