CREATE TABLE [dbo].[CoverSheet] (
    [CoverSheetNumber]   INT          IDENTITY (1, 1) NOT NULL,
    [CoverSheetID]       INT          NOT NULL,
    [FirstName]          VARCHAR (50) NULL,
    [LastName]           VARCHAR (50) NULL,
    [DepartmentID]       INT          NULL,
    [DateOfInvoce]       DATETIME     NULL,
    [DateOfPayment]      DATETIME     NULL,
    [ManagerID]          INT          NULL,
    [CompanyID]          INT          NULL,
    [FK_PaymentStatusID] INT          NULL,
    CONSTRAINT [PK_CoverSheet_1] PRIMARY KEY CLUSTERED ([CoverSheetNumber] ASC)
);

