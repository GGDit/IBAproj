CREATE PROCEDURE [dbo].[CreatePatient]
	@lastname nvarchar(50)
AS
Begin
	INSERT INTO Patients(Lastname)
		VALUES(@lastname)
end
