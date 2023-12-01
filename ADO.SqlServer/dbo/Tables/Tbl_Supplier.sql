CREATE TABLE [dbo].[Tbl_Supplier]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Corporate_name] NVARCHAR(50) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [EMail] NVARCHAR(50) NOT NULL, 
    [Tel] NVARCHAR(50) NOT NULL, 
    [Address] NVARCHAR(50) NOT NULL
)
