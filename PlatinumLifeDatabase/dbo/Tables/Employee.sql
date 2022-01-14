CREATE TABLE [dbo].[Employee] (
    [EmployeeID]      INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeCode]    VARCHAR (50)  NOT NULL,
    [FirstName]       VARCHAR (50)  NOT NULL,
    [LastName]        VARCHAR (50)  NOT NULL,
    [FK_DepartmentID] INT           NOT NULL,
    [Position]        VARCHAR (50)  NOT NULL,
    [Signature]       VARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [FK_Employee_Department] FOREIGN KEY ([FK_DepartmentID]) REFERENCES [dbo].[Department] ([DepartmentID])
);

