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
cli_rol_Id int NOT NULL DEFAULT 2, --Los Clientes tienen ID_ROL = 2
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

/*------------------------------------------------------------------*/
/*-------------------CREAMOS TABLA CANJE----------------------------*/

CREATE TABLE DATACENTER.Canje
(canj_Id int IDENTITY (1,1) NOT NULL,
canj_cli_Dni numeric (18,0) NOT NULL,
canj_prem_Id int NOT NULL,
canj_cant_retirada int  NULL,
canj_fecha datetime NULL
PRIMARY KEY (canj_Id),
FOREIGN KEY (canj_cli_Dni) REFERENCES DATACENTER.Cliente (cli_Dni)
)
GO

/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA PREMIO-----------------------------*/

CREATE TABLE DATACENTER.Premio
(prem_Id int IDENTITY (1,1) NOT NULL,
prem_nombre nvarchar(255) NULL,
prem_costo_Puntos int NULL,
prem_stock int NULL,
PRIMARY KEY (prem_Id)
)
GO

/*------------------------------------------------------------------*/
/*---------------CREAMOS TABLA PREMIOPORCANJE-----------------------*/

CREATE TABLE DATACENTER.PremioPorCanje
(premxCanj_canj_Id int NOT NULL,
premxCanj_prem_Id int NOT NULL,
FOREIGN KEY (premxCanj_canj_Id) REFERENCES DATACENTER.Canje (canj_Id),
FOREIGN KEY (premxCanj_prem_Id) REFERENCES DATACENTER.Premio (prem_Id),
PRIMARY KEY (premxCanj_canj_Id, premxCanj_prem_Id)
)
GO

/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA TIPO TARJETA-----------------------*/

CREATE TABLE DATACENTER.TipoTarjeta
(tipo_Id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
tipo_descripcion nvarchar(255) NULL,
tipo_cuotas char NULL
)
GO
/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA SERVICIO---------------------------*/

CREATE TABLE DATACENTER.Servicio
(serv_Id int IDENTITY (1,1) PRIMARY KEY NOT NULL ,
serv_tipo char NULL,
serc_porc_adicional numeric (18,2) NULL
)
GO

/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA CIUDAD-------------------------*/

CREATE TABLE DATACENTER.Ciudad
(ciu_nombre nvarchar(255) NOT NULL PRIMARY KEY,
ciu_Id int IDENTITY (1,1) NOT NULL)
GO

/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA RECORRIDO--------------------------*/

CREATE TABLE DATACENTER.Recorrido
(reco_Id int IDENTITY (1,1) NOT NULL,
reco_serv_Id int NOT NULL,
reco_origen nvarchar(255) NOT NULL,
reco_destino nvarchar(255) NOT NULL,
reco_precio_base_KG numeric(18,2) NULL,
reco_precio_base_pasaje numeric (18,2) NULL,
FOREIGN KEY (reco_serv_Id) REFERENCES DATACENTER.Servicio (serv_Id),
FOREIGN KEY (reco_origen) REFERENCES DATACENTER.Ciudad (ciu_nombre),
FOREIGN KEY (reco_destino) REFERENCES DATACENTER.Ciudad (ciu_nombre),
PRIMARY KEY (reco_Id)
)
GO

/*------------------------------------------------------------------*/
/*-----------------CREAMOS TABLA COMPRA-----------------------------*/

CREATE TABLE DATACENTER.Compra
(comp_Id int IDENTITY (1,1) NOT NULL,
comp_comprador_Dni numeric (18,0) NOT NULL,
comp_tipo_Tarj_Id int NOT NULL,
comp_reco_Id int NOT NULL,
comp_cant_pasajes int NULL,
comp_cant_total_KG numeric (18,0) NULL, 
comp_costo_Total numeric (18,2) NULL,
comp_fecha_compra datetime NULL,
FOREIGN KEY (comp_comprador_Dni) REFERENCES DATACENTER.Cliente (cli_Dni),
FOREIGN KEY (comp_tipo_Tarj_Id) REFERENCES DATACENTER.TipoTarjeta (tipo_Id),
FOREIGN KEY (comp_reco_Id) REFERENCES DATACENTER.Recorrido (reco_Id),
PRIMARY KEY (comp_Id)
)
GO

/*------------------------------------------------------------------*/
/*-------------------CREAMOS TABLA MARCA----------------------------*/

CREATE TABLE DATACENTER.Marca
(marc_Id int IDENTITY (1,1) NOT NULL PRIMARY KEY,
marc_nombre nvarchar(255) NULL
)
GO

/*------------------------------------------------------------------*/
/*-------------------CREAMOS TABLA MICRO----------------------------*/

CREATE TABLE DATACENTER.Micro
(mic_patente nvarchar(255) NOT NULL,
mic_marc_Id int NOT NULL,
mic_serv_Id int NOT NULL,
mic_cant_butacas int NULL,
mic_cant_kg_disponibles numeric (18,0) NULL,
mic_modelo nvarchar(255) NULL,
mic_nro int IDENTITY (1,1) NOT NULL,  -------------VERIFICAR--------------
mic_fecha_alta datetime NULL,
mic_fecha_baja_def datetime NULL,
FOREIGN KEY (mic_marc_Id) REFERENCES DATACENTER.Marca (marc_Id),
FOREIGN KEY (mic_serv_Id) REFERENCES DATACENTER.Servicio (serv_Id),
PRIMARY KEY (mic_patente)
)
GO

/*------------------------------------------------------------------*/
/*----------------CREAMOS TABLA ESTADOMICRO-------------------------*/

CREATE TABLE DATACENTER.EstadoMicro
(est_Id int IDENTITY (1,1) NOT NULL,
est_mic_patente nvarchar(255) NOT NULL,
est_fecha_fuera_serv datetime NULL,
est_fecha_reingreso datetime NULL,
FOREIGN KEY (est_mic_patente) REFERENCES DATACENTER.Micro (mic_patente),
PRIMARY KEY (est_Id)
)
GO

/*------------------------------------------------------------------*/
/*-------------------CREAMOS TABLA BUTACA---------------------------*/

CREATE TABLE DATACENTER.Butaca
(but_nro numeric (18,0) NOT NULL,
but_mic_patente nvarchar(255) NOT NULL,
but_tipo nvarchar(255) NULL,
but_piso numeric (18,0) NULL,
FOREIGN KEY (but_mic_patente) REFERENCES DATACENTER.Micro (mic_patente),
PRIMARY KEY (but_nro, but_mic_patente)
)
GO

/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA PASAJE-------------------------*/

CREATE TABLE DATACENTER.Pasaje
(pas_Id int IDENTITY (1,1) NOT NULL,
pas_nro_butaca numeric (18,0) NOT NULL,
pas_micro_patente nvarchar(255) NOT NULL,
pas_cli_Dni numeric (18,0) NOT NULL,
pas_compra_Id int NOT NULL,
pas_precio numeric(18,2) NULL,
FOREIGN KEY (pas_nro_butaca, pas_micro_patente) REFERENCES DATACENTER.Butaca (but_nro, but_mic_patente),
FOREIGN KEY (pas_cli_Dni) REFERENCES DATACENTER.Cliente (cli_Dni),
FOREIGN KEY (pas_compra_Id) REFERENCES DATACENTER.Compra (comp_Id),
PRIMARY KEY (pas_Id)
)
GO

/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA PAQUETE-------------------------*/

CREATE TABLE DATACENTER.Paquete
(paq_Id int IDENTITY (1,1) NOT NULL,
paq_comp_Id int NOT NULL,
paq_precio numeric (18,2) NULL,
paq_KG numeric (18,0)NULL,
FOREIGN KEY (paq_comp_Id) REFERENCES DATACENTER.Compra (comp_Id),
PRIMARY KEY (paq_Id)
)
GO

/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA DEVOLUCION-------------------------*/

CREATE TABLE DATACENTER.Devolucion
(dev_Id int IDENTITY (1,1) NOT NULL,
dev_comp_Id int NOT NULL,
dev_pas_Id int NULL,       --NULL POR QUE LA DEVOLUCION PUEDE TENER PAQ Y/O PASAJES
dev_paq_Id int NULL,
dev_fecha datetime NULL,
dev_motivo nvarchar(255) NULL,
FOREIGN KEY (dev_pas_Id) REFERENCES DATACENTER.Pasaje (pas_Id),
FOREIGN KEY (dev_paq_Id) REFERENCES DATACENTER.Paquete (paq_Id),
PRIMARY KEY (dev_Id)
)
GO


/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA VIAJE-------------------------*/

CREATE TABLE DATACENTER.Viaje
(viaj_Id int IDENTITY (1,1) NOT NULL,
viaj_mic_patente nvarchar(255) NOT NULL,
viaj_reco_Id int NOT NULL,
viaj_fecha_salida datetime NULL,
viaj_fecha_lleg_estimada datetime NULL,
viaj_fecha_llegada datetime NULL,
FOREIGN KEY (viaj_mic_patente) REFERENCES DATACENTER.Micro (mic_patente), 
FOREIGN KEY (viaj_reco_Id) REFERENCES DATACENTER.Recorrido (reco_Id),
PRIMARY KEY (viaj_Id)
)
GO

/*------------------------------------------------------------------*/
/*---------------------CREAMOS TABLA ARRIBO-------------------------*/

CREATE TABLE DATACENTER.Arribo
(arri_fecha_llegada datetime NOT NULL,   
arri_mic_patente nvarchar(255) NOT NULL,         --DATO INGRESADO EN LA TERMINAL DE LLEGADA NO ES FK
arri_viaj_Id int NOT NULL,
arri_ciu_arribada nvarchar(255) NOT NULL, 
FOREIGN KEY (arri_ciu_arribada) REFERENCES DATACENTER.Ciudad (ciu_nombre), --SEGUN DER ES FK => CONSULTA TABLA CIUDAD
FOREIGN KEY (arri_viaj_Id) REFERENCES DATACENTER.Viaje (viaj_Id),          --SEGUN DER ES FK => CONSULTA TABLA VIAJE
PRIMARY KEY (arri_fecha_llegada, arri_mic_patente)
)
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
VALUES ('Administrador', 'H') --H HABILITADO D DESHABILITADO
GO

INSERT INTO DATACENTER.Rol(rol_Nombre, rol_Estado) --no ponemos ID ya que se autoincrementa
VALUES ('Cliente', 'H') --H HABILITADO D DESHABILITADO
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


--AGREGAMOS PREMIOS

INSERT INTO 
DATACENTER.Premio(prem_nombre, prem_costo_Puntos, prem_stock)
VALUES ('Televisor Led 32', 100, 50)
GO

INSERT INTO 
DATACENTER.Premio(prem_nombre, prem_costo_Puntos, prem_stock)
VALUES ('Notebook Lenovo G470', 150, 30)
GO

/*------------------------------------------------------------------*/
/*-----------------MIGRACION DE CLIENTES----------------------------*/

INSERT INTO DATACENTER.Cliente(cli_Dni, cli_Nombre, cli_Apellido, cli_Dir, cli_Telefono, cli_Mail, Cli_Fecha_Nac)
	SELECT DISTINCT cli_Dni, cli_Nombre, cli_Apellido, cli_Dir, cli_Telefono, cli_Mail, Cli_Fecha_Nac
	FROM gd_esquema.Maestra
GO


