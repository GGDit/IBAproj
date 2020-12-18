CREATE PROCEDURE [dbo].[DeletePatient]
	@id int
AS
Begin
	Delete from [dbo].Patients
	Where Id = @id
End
