USE [BoxManager]
GO

CREATE TABLE tenant(
	id integer primary key identity(1,1) not null,
	nombre varchar(50),
);
GO

CREATE TABLE administrador(
	id int primary key identity(1,1) not null,
	nombre varchar(50),
	usuario varchar(100),
	contrasenia varchar(16),
	idTenant int foreign key references tenant(id) not null,
);
GO

CREATE TABLE nivel(
	id integer primary key identity(1,1) not null,
	nombre varchar(50),
	idTenant int foreign key references tenant(id) not null
);
GO

CREATE TABLE cliente(
	id int primary key identity(1,1) not null,
	nombre varchar(50),
	nivel int foreign key references nivel(id),
	idTenant int foreign key references tenant(id) not null,
);
GO

CREATE TABLE tipoConteo(
	id integer primary key identity(1,1) not null,
	nombre varchar(50),
	idTenant int foreign key references tenant(id) not null
);
GO

CREATE TABLE wod(
	id int primary key identity(1,1) not null,
	fecha date,
	descripcion varchar(max),
	nivel int foreign key references nivel(id),
	tipoConteo int foreign key references tipoConteo(id),
	idTenant int foreign key references tenant(id) not null,
);
GO

CREATE TABLE wodCliente(
	id int primary key identity(1,1) not null,
	fecha date,
	descripcion varchar(max),
	cliente int foreign key references cliente(id),
	tipoConteo int foreign key references tipoConteo(id),
	idTenant int foreign key references tenant(id) not null,
);
GO

CREATE OR ALTER PROCEDURE wods @idTenant int
AS
	SELECT w.id, w.fecha Fecha, n.nombre Nivel, tc.nombre Tipo, w.descripcion Descripcion
	FROM wod w, nivel n, tipoConteo tc
	WHERE w.idTenant = @idTenant AND w.nivel = n.id AND w.tipoConteo = tc.id;
GO

CREATE OR ALTER PROCEDURE wodsCliente @idTenant int
AS
	SELECT w.id, w.fecha Fecha, c.nombre Cliente, tc.nombre Tipo, w.descripcion Descripcion
	FROM wodCliente w, cliente c, tipoConteo tc
	WHERE w.idTenant = @idTenant AND w.cliente = c.id AND w.tipoConteo = tc.id;
GO

INSERT INTO tenant(nombre) VALUES('SteelBox');
INSERT INTO tenant(nombre) VALUES('OnWay');
INSERT INTO tenant(nombre) VALUES('WolfBox');

INSERT INTO nivel(nombre, idTenant)
VALUES('L1', 1);
INSERT INTO nivel(nombre, idTenant)
VALUES('L2', 1);
INSERT INTO nivel(nombre, idTenant)
VALUES('L3', 1);
INSERT INTO nivel(nombre, idTenant)
VALUES('Principiante', 2);
INSERT INTO nivel(nombre, idTenant)
VALUES('Intermedio', 2);
INSERT INTO nivel(nombre, idTenant)
VALUES('Avanzado', 2);
INSERT INTO nivel(nombre, idTenant)
VALUES('Regular', 3);
INSERT INTO nivel(nombre, idTenant)
VALUES('Competencia', 3);

INSERT INTO tipoConteo(nombre, idTenant)
VALUES('AMRAP', 1);
INSERT INTO tipoConteo(nombre, idTenant)
VALUES('RFT', 1);
INSERT INTO tipoConteo(nombre, idTenant)
VALUES('AMRAP', 2);
INSERT INTO tipoConteo(nombre, idTenant)
VALUES('FORTIME', 2);
INSERT INTO tipoConteo(nombre, idTenant)
VALUES('AMRAP', 3);
INSERT INTO tipoConteo(nombre, idTenant)
VALUES('FORTIME', 3);
INSERT INTO tipoConteo(nombre, idTenant)
VALUES('EMOM', 3);
INSERT INTO tipoConteo(nombre, idTenant)
VALUES('TABATA', 3);

INSERT INTO administrador(nombre, usuario, contrasenia, idTenant)
VALUES('Franklin Astorga', 'fastorga', '123', 1);
INSERT INTO administrador(nombre, usuario, contrasenia, idTenant)
VALUES('Ruben Urena',  'rurena', '123', 2);
INSERT INTO administrador(nombre, usuario, contrasenia, idTenant)
VALUES('Abraham Chacon', 'achacon', '123', 3);

INSERT INTO cliente(nombre, nivel, idTenant)
VALUES('Federico Lopez', 3, 1);
INSERT INTO cliente(nombre, nivel, idTenant)
VALUES('Armando Brenes', 2, 2);
INSERT INTO cliente(nombre, nivel, idTenant)
VALUES('Carlos Rodriguez', 1, 3);

INSERT INTO wod(fecha, descripcion, nivel, tipoConteo, idTenant)
VALUES('2019-12-16', '20 minutos,25 HRPU,25 Lunges,10 Burpees', 3, 1, 1);
INSERT INTO wod(fecha, descripcion, nivel, tipoConteo, idTenant)
VALUES('2019-12-16', '20 minutos,20 Pull Ups,20 Pistols,400m run', 2, 1, 1);
INSERT INTO wod(fecha, descripcion, nivel, tipoConteo, idTenant)
VALUES('2019-12-16', '4 Reps,20 Push Jerk,20 Pull Ups,20 Bastards', 1, 2, 1);
INSERT INTO wod(fecha, descripcion, nivel, tipoConteo, idTenant)
VALUES('2019-12-16', '100 squats,100 HRPU,50 Burpees', 1, 2, 3);

INSERT INTO wodCliente(fecha, descripcion, cliente, tipoConteo, idTenant)
VALUES('2019-12-16', '20 minutos,20 pull ups,20 pistols', 1, 1, 1);