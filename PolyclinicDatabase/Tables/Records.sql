CREATE TABLE [dbo].[Records]
(
	[Id]           INT            IDENTITY (1, 1) NOT NULL,
    [DoctorId]     INT            NOT NULL,
    [TimeOfRecord] DATETIME NOT NULL,
    [PatientId]    INT            NOT NULL,     
    CONSTRAINT [PK_dbo.Records] PRIMARY KEY CLUSTERED ([Id] ASC)
)
