CREATE TYPE [dbo].[ttCoverSheet] AS TABLE (
    [CoverSheetID]       INT          NOT NULL,
    [FirstName]          VARCHAR (50) NULL,
    [LastName]           VARCHAR (50) NULL,
    [DepartmentID]       INT          NULL,
    [DateOfInvoce]       DATETIME     NULL,
    [DateOfPayment]      DATETIME     NULL,
    [ManagerID]          INT          NULL,
    [CompanyID]          INT          NULL,
    [FK_PaymentStatusID] INT          NULL);

