Use [GD1C2013]    /* Utilizamos una base de datos EXTERNA,la base a la cual se dirigirán las próximas consultas SQL en el proceso actual. */
Go 
/* Signo de finalización de lotes de sentencia*/

Create Schema DATACENTER AUTHORIZATION [gd]   /* Creamos un Schema nuevo(Modelo de Datos/contiene Tablas,Indices y demas estructuras de negocio) ; El usuario que poseerá el schema (OWNER) sera: GD*/   
Go
/*------------------INICIO DE CREACION DE TABLAS--------------------*/
/*------------------------------------------------------------------*/

CREATE TABLE DATACENTER.Funcionalidad
(func_Id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
func_Nombre nvarchar(255) NOT NULL)
GO

/*------------------------------------------------------------------*/
/*------------------------------------------------------------------*/

CREATE TABLE DATACENTER.Rol
(rol_Id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
rol_Nombre nvarchar(255) NOT NULL,
rol_Estado char NOT NULL)
GO

/*------------------------------------------------------------------*/
/*------------------------------------------------------------------*/

CREATE TABLE DATACENTER.FuncionalidadPorRol
(fxrol_rol_Id int NOT NULL, 
fxrol_func_Id int NOT NULL, 
fxrol_Estado char NOT NULL,
FOREIGN KEY(fxrol_rol_Id) references DATACENTER.Rol (rol_Id),
FOREIGN KEY(fxrol_func_Id) references DATACENTER.Funcionalidad (func_Id),
PRIMARY KEY (fxrol_rol_Id, fxrol_func_Id)
)
GO

--------------DUDOSOO-----------------------
/*
CREATE TABLE DATACENTER.Usuario
(usu_Id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
usu_Rol_Id int NOT NULL,
FOREIGN KEY (usu_Rol_Id) references DATACENTER.Rol (rol_Id) 
)
*/

/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA ADMINISTRADOR----------------------*/

CREATE TABLE DATACENTER.Administrador
(adm_Username nvarchar(255) NOT NULL,
adm_password nvarchar(255) NOT NULL, --FALTA CIFRADO DE CLAVE
adm_cant_intentos int NOT NULL, 
adm_rol_Id int NOT NULL, 
PRIMARY KEY (adm_username),
FOREIGN KEY (adm_rol_ID) REFERENCES DATACENTER.Rol (rol_Id))
GO

/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA CLIENTE----------------------------*/

CREATE TABLE DATACENTER.Cliente
(cli_Dni numeric(18,0) NOT NULL,
cli_rol_Id int NOT NULL,
cli_Nombre nvarchar(255) NULL,
cli_Apellido nvarchar(255) NULL,
cli_Dir nvarchar(255) NULL,
cli_Telefono nvarchar(255) NULL,
cli_Mail nvarchar(255) NULL, 
Cli_Fecha_Nac datetime NULL,
Cli_puntos_Acum int NULL,
Cli_Condicion char NULL,
Cli_Sexo char NULL,
FOREIGN KEY (cli_rol_Id) REFERENCES DATACENTER.Rol (rol_Id),
PRIMARY KEY (cli_Dni))
GO

/* ---------------------PRUEBAS-------------------------- */

--AGREGAMOS FUNCIONALIDADES 
INSERT INTO DATACENTER.Funcionalidad(func_Nombre) --no ponemos ID ya que se autoincrementa
VALUES ('Comprar')
GO

INSERT INTO DATACENTER.Funcionalidad(func_Nombre) --no ponemos ID ya que se autoincrementa
VALUES ('ABM Recorrido')
GO

INSERT INTO DATACENTER.Funcionalidad(func_Nombre) --no ponemos ID ya que se autoincrementa
VALUES ('ABM Micro')
GO

--AGREGAMOS ROLES

INSERT INTO DATACENTER.Rol(rol_Nombre, rol_Estado) --no ponemos ID ya que se autoincrementa
VALUES ('Administrador', 'T')
GO

INSERT INTO DATACENTER.Rol(rol_Nombre, rol_Estado) --no ponemos ID ya que se autoincrementa
VALUES ('Cliente', 'F')
GO

--ASOCIAMOS ROLES CON FUNCIONES

INSERT INTO DATACENTER.FuncionalidadPorRol(fxrol_rol_Id,fxrol_func_Id, fxrol_Estado)
VALUES (1, 1, 'H') --H HABILITADO D DESHABILITADO
GO

INSERT INTO DATACENTER.FuncionalidadPorRol(fxrol_rol_Id,fxrol_func_Id, fxrol_Estado)
VALUES (1, 2, 'H') --H HABILITADO D DESHABILITADO
GO

INSERT INTO DATACENTER.FuncionalidadPorRol(fxrol_rol_Id,fxrol_func_Id, fxrol_Estado)
VALUES (1, 3, 'H') --H HABILITADO D DESHABILITADO
GO

INSERT INTO DATACENTER.FuncionalidadPorRol(fxrol_rol_Id,fxrol_func_Id, fxrol_Estado)
VALUES (2, 1, 'H') --H HABILITADO D DESHABILITADO
GO

----INSERTAMOS ADMINISTRADORES 
INSERT INTO DATACENTER.Administrador(adm_Username, adm_password, adm_cant_intentos, adm_rol_Id)
VALUES ('frann96','w23e',0,1)

INSERT INTO DATACENTER.Administrador(adm_Username, adm_password, adm_cant_intentos, adm_rol_Id)
VALUES ('dieguito12','w23e',0,1)

INSERT INTO DATACENTER.Administrador(adm_Username, adm_password, adm_cant_intentos, adm_rol_Id)
VALUES ('maty32','w23e',0,1)

INSERT INTO DATACENTER.Administrador(adm_Username, adm_password, adm_cant_intentos, adm_rol_Id)
VALUES ('ani18','w23e',0,1)


