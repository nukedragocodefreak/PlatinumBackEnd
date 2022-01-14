CREATE TABLE [dbo].[Position] (
    [PositionID]   INT          IDENTITY (1, 1) NOT NULL,
    [PositionName] VARCHAR (50) NULL,
    CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED ([PositionID] ASC)
);

