CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Title] NCHAR(20) NULL, 
    [Description] NCHAR(30) NULL, 
    [Start] DATETIME NULL, 
    [End] DATETIME NULL, 
    [Color] NCHAR(15) NULL, 
    [IsFullDay] NCHAR(15) NULL
)
