CREATE TABLE [dbo].[Users] (
    [UserID]       INT          IDENTITY (1, 1) NOT NULL,
    [EmployeeCode] VARCHAR (50) NULL,
    [Password]     VARCHAR (50) NULL,
    [Position]     INT          NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserID] ASC)
);

