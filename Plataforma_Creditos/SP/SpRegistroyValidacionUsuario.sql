create database DB_ACCESO

use DB_ACCESO 

create table USUARIO (
IdUsuario int primary key identity(1,1),
Correo varchar(100) not null, 
Clave varchar(500) not null)

create proc Sp_RegistrarUsuario(
@Correo varchar(100),
@Clave varchar(500),
@Registrado bit output,
@Mensaje varchar(100) output)
as
  begin 
	if(not exists(select*from USUARIO where Correo = @Correo))
	begin 
	insert into USUARIO (Correo,Clave) values (@Correo,@Clave)
		set @Registrado = 1
		set @Mensaje = 'Usuario registrado'
	end
	else
		begin
		set @Registrado = 0
		set @Mensaje = 'Este usuario ya existe'
		end
	end

create proc Sp_ValidarUsuario(
@Correo varchar(100),
@Clave varchar(500))
as
  begin
    if(exists(select * from USUARIO where
		Correo = @Correo and Clave = @Clave))
		select IdUsuario from USUARIO
		where Correo = @Correo and Clave =@Clave 
	else 
	  select '0'
	end 

declare @Registrado bit, @Mensaje varchar(100)

exec Sp_RegistrarUsuario 'JoseV@gmail.com','4321',
@Registrado output, @Mensaje output 

select @Registrado 
select @Mensaje 

select * from usuario 

exec Sp_ValidarUsuario 'Fabiolab@gmail.com','1234'

