CREATE TABLE [dbo].[RequirementReply]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DevRequirementID] INT NOT NULL, 
    [Message] VARCHAR(500) NULL
)
