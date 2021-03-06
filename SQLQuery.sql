CREATE PROCEDURE [dbo].[CreatePersona]
    @Nombre Varchar(50)
AS
BEGIN
    Insert into personas(
           Nombre
           )
 Values (@Nombre)
END

CREATE PROCEDURE [dbo].[GetPersonas]
AS
BEGIN
    SELECT * FROM personas
END

CREATE proc [dbo].[DeletePersona]
  @Id int
  as
  begin
	delete from personas where Id = @Id
	END
    
CREATE proc [dbo].[EditarPersona]
  @Id int, 
  @Nombre varchar(50)
  as
  begin
	update personas
	set Nombre = @Nombre
	where Id = @Id
	end