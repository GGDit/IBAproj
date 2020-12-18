CREATE PROCEDURE [dbo].[UpdatePatient]
	@id int,
	 @lastname nvarchar(120) 
AS
Begin
	Update Patients
			set Lastname = @lastname
			where id=@id;
End
