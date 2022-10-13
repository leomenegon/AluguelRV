CREATE TABLE [dbo].[Person]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [Resident] BIT NOT NULL DEFAULT 0,
    [DefaultRoom] INT,
    [Deleted] BIT NOT NULL DEFAULT 0
)
