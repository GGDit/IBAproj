CREATE TABLE [dbo].[Doctors]
(
	[Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [Lastname]           NVARCHAR (MAX) NOT NULL,
    [Specialty]          NVARCHAR (MAX) NOT NULL,
    [StartTimeOfReceipt] INT            NOT NULL,
    [EndTimeOfReceipt]   INT            NOT NULL,
    [Room]               INT            NOT NULL,
    CONSTRAINT [PK_dbo.Doctors] PRIMARY KEY CLUSTERED ([Id] ASC)
)
