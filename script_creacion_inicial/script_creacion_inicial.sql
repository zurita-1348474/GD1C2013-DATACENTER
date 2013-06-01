Use [GD1C2013]    /* Utilizamos una base de datos EXTERNA,la base a la cual se dirigirán las próximas consultas SQL en el proceso actual. */
Go 
/* Signo de finalización de lotes de sentencia*/

Create Schema DATACENTER AUTHORIZATION [gd]   /* Creamos un Schema nuevo(Modelo de Datos/contiene Tablas,Indices y demas estructuras de negocio) ; El usuario que poseerá el schema (OWNER) sera: GD*/
Go								    

/*------------------INICIO DE CREACION DE TABLAS--------------------*/
/*------------------------------------------------------------------*/

CREATE TABLE DATACENTER.Cliente
(Cli_Dni numeric(18,0) PRIMARY KEY NOT NULL,
Cli_Nombre nvarchar(255) NULL,
Cli_Apellido nvarchar(255) NULL,
Cli_Dir nvarchar(255) NULL,
Cli_Telefono numeric(18,0) NULL,
Cli_Mail nvarchar(255) NULL,
Cli_Fecha_Nac datetime NULL)
GO

/*------------------------------------------------------------------*/
/*------------------------------------------------------------------*/

CREATE TABLE DATACENTER.Paquete
(Paquete_Codigo numeric(18,0) PRIMARY KEY NOT NULL,
Paquete_Cli_DNI numeric(18,0) NOT NULL references DATACENTER.Cliente (Cli_Dni),
Paquete_Precio numeric(18,2) NULL,
Paquete_KG numeric(18,0) NULL,
Paquete_FechaCompra datetime NULL)
GO


/*------------------------------------------------------------------*/
/*------------------------------------------------------------------*/

CREATE TABLE DATACENTER.Recorrido
(Recorrido_Codigo numeric(18,0) PRIMARY KEY NOT NULL,
Recorrido_Precio_BaseKG numeric(18,2) NULL,
Recorrido_Precio_BasePasaje numeric(18,2) NULL,
Recorrido_Ciudad_Origen nvarchar(255) NULL,
Recorrido_Ciudad_Destino nvarchar(255) NULL)
GO


/*------------------------------------------------------------------*/
/*------------------------------------------------------------------*/

CREATE TABLE DATACENTER.Pasaje
(Pasaje_Codigo numeric(18,0) PRIMARY KEY NOT NULL,
Pasaje_Cli_DNI numeric(18,0) NOT NULL references DATACENTER.Cliente (Cli_Dni),
Pasaje_Recorrido_Codigo numeric(18,0) NOT NULL references DATACENTER.Recorrido (Recorrido_Codigo),
Pasaje_Precio numeric(18,0) NULL,
Pasaje_Fecha_Compra datetime NULL)
GO

/*------------------------------------------------------------------*/
/*------------------------------------------------------------------*/

CREATE TABLE DATACENTER.Viaje
(Viaje_Recorrido_Codigo numeric(18,0) PRIMARY KEY NOT NULL references DATACENTER.Recorrido (Recorrido_Codigo),
/*Viaje_Micro_Patente nvarchar(255) PRIMARY KEY NOT NULL references Micro (Micro_Patente), FALTA DEFINIR UNA PK COMPUESTA*/
FechaSalida datetime NULL,
Fecha_Llegada_Estimada datetime NULL,
Fecha_Llegada datetime NULL)
GO

/*------------------------------------------------------------------*/
/*------------------------------------------------------------------*/

CREATE TABLE DATACENTER.Micro
(Micro_Patente nvarchar(255) PRIMARY KEY NOT NULL,
Micro_Modelo nvarchar(255) NULL,
Micro_KG_Disponibles numeric(18,0) NULL,
Micro_Marca nvarchar(255) NULL,
Tipo_Servicio nvarchar(255) NULL)
GO

/*------------------------------------------------------------------*/
/*------------------------------------------------------------------*/

CREATE TABLE DATACENTER.Butaca
(Butaca_Nro numeric(18,0) PRIMARY KEY NOT NULL,
Butaca_Tipo nvarchar(255) NULL,
Butaca_Piso numeric(18,0) NULL)
GO

/*------------------------------------------------------------------*/
/*------------------------------------------------------------------*/


