CREATE DATABASE Bolsa_de_Empleados
USE Bolsa_de_Empleados

CREATE TABLE ADMINISTRADOR
(
id int not null identity primary key,
Correo_Administrador varchar(100) not null unique,
Contrase�a_Administrador varchar(60) not null
)

CREATE TABLE POSTER
(
id int not null identity primary key,
Correo_Poster varchar(100) not null unique,
Contrase�a_Poster varchar(60) not null,
Nombre_de_Compa�ia varchar(60) not null unique
)

CREATE TABLE DATOS_VACANTE
(
id int not null identity primary key,
Compa�ia varchar(60) not null,
Tipo varchar(60) not null,
Posicion varchar(100) not null,
Ubicacion varchar(100) not null,
Categoria varchar(60) not null,
Descripcion_Trabajo text not null,
Como_Aplicar text not null,
Email varchar(100) not null
)






CREATE TABLE NUMERO_DE_PAGINACION
(
id int not null identity primary key,
Numero_de_Paginas int not null
)

CREATE TABLE CATEGORIAS
(
id int not null identity primary key,
CATEGORIA varchar(60) not null
)

select *from ADMINISTRADOR

insert into ADMINISTRADOR VALUES('hector1234@gmail.com','1234')

insert into NUMERO_DE_PAGINACION VALUES(10)


insert into CATEGORIAS  values ('Programacion'), ('Diseno'), ('Deseno')
delete  from CATEGORIAS


insert into DATOS_VACANTE VALUES('Tecno Software','desig','tester','Canada, culo tromp','Programacion','El capit�n Barbossa le roba el barco al pirata Jack Sparrow y secuestra a Elizabeth, amiga de Will Turner. Barbossa y su tripulaci�n son v�ctimas de un conjuro que los condena a vivir eternamente y a transformarse cada noche en esqueletos vivientes.','Vaiana Waialiki es una joven entusiasta del mar y la �nica hija de un jefe marinero. Cuando los marineros de su aldea no pueden pescar ning�n pez y todas las cosechas fallan, Vaiana descubre que el semidi�s Maui caus� el infortunio despu�s de robar el coraz�n de la diosa Te Fiti. La �nica manera de salvar el destino de la isla es persuadiendo a Maui para que le devuelva el coraz�n a Te Fiti. Entonces, Vaiana emprende una arriesgada aventura para salvar a su aldea junto al semidi�s Maui.','reyesubierahectorisaac02@gmail.com'),
								('rol','desig','tato','peru','Diseno','duro','educate','hector@gmail.com'),
								('nol','desig','tutu','mexico','Deseno','duro','educate','hector@gmail.com'),
								('infor','desig','tester','francia','Programacion','duro','educate','hector@gmail.com'),
								('rol','desig','tato','peru','Diseno','duro','educate','hector@gmail.com'),
								('nol','desig','tutu','mexico','Deseno','duro','educate','hector@gmail.com'),
								('infor','desig','tester','francia','Programacion','duro','educate','hector@gmail.com')

delete  from POSTER where Nombre_de_Compa�ia='Joses'
delete  from CATEGORIAS where id=24


select * from CATEGORIAS

select * from CATEGORIAS order by CATEGORIA

select * from DATOS_VACANTE where Categoria = 'Programacion'
select * from DATOS_VACANTE where Compa�ia = 'info'

select * from POSTER



create procedure Numero_de_Vacantes
@numero int
as
begin

update

end

insert into NUMERO_DE_PAGINACION VALUES(10)