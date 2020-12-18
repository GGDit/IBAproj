ALTER TABLE [dbo].[Records]
	ADD CONSTRAINT [ForeignKey_Record_Doctor]
	FOREIGN KEY (DoctorId)
	REFERENCES [dbo].[Doctors] ([Id]) ON DELETE CASCADE
