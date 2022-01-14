CREATE TYPE [dbo].[ttEmployee] AS TABLE (
    [EmployeeCode]    VARCHAR (50)  NOT NULL,
    [FirstName]       VARCHAR (50)  NOT NULL,
    [LastName]        VARCHAR (50)  NOT NULL,
    [FK_DepartmentID] INT           NOT NULL,
    [Position]        VARCHAR (50)  NOT NULL,
    [Signature]       VARCHAR (MAX) NOT NULL);

