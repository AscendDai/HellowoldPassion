CREATE TABLE [dbo].[DevRequirement]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY,
	Require nvarchar(50) not null, 
    [Description] NVARCHAR(500) NULL, 
    [CreateDateTime] DATETIME NOT NULL, 
    [CreateUser] NVARCHAR(20) NOT NULL, 
    [Developor] NVARCHAR(20) NULL, 
    [StartDateTime] DATETIME NULL, 
    [CompleteDateTime] DATETIME NULL, 
    [Status] INT NOT NULL default 0
)
