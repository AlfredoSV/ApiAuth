CREATE DATABASE ApiAuth
go

Use ApiAuth
go

IF not EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME= 'userApi')
begin
CREATE TABLE userApi(id uniqueidentifier primary key,
email varchar(70), password varchar(40));
print 'CREATE TABLE userApi'
end;


IF not EXISTS(SELECT * FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_NAME= 'userToken')
begin
CREATE TABLE userToken(
id uniqueidentifier primary key, userId
uniqueidentifier, token varchar(max), dateCreated date
, dateExpired date foreign key (userId) references userApi(id));
print 'CREATE TABLE userToken'
end;



