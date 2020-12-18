ALTER TABLE [dbo].[Records]
	ADD CONSTRAINT  [ForeignKey_Record_Patient] 
	FOREIGN KEY ([PatientId]) 
	REFERENCES [dbo].[Patients] ([Id]) ON DELETE CASCADE
