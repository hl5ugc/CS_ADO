CREATE TABLE [dbo].[AppointmentsType]
(
	[Id] INT PRIMARY KEY IDENTITY(1,1), 
    [AppointmentTypeName] NVARCHAR(50) NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [DateCreate] DATETIME NOT NULL DEFAULT GETDATE()
)
