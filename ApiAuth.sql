CREATE DATABASE ApiAuth

go

Use ApiAuth

go

CREATE TABLE usuario(idUsuario uniqueidentifier primary key,
correoUsuario varchar(70), contraseniaUsuario varchar(40));


CREATE TABLE usuarioToken(
idToken uniqueidentifier primary key, idUsuario
uniqueidentifier, token varchar(max), fechaAltaToken date
, fechaVencimientoToken date foreign key (idUsuario) references usuario(idUsuario));

INSERT INTO usuario values(NEWID(),'alfredosv97@gmail.com','prueba123');