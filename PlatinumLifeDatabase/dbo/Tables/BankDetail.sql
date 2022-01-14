CREATE TABLE [dbo].[BankDetail] (
    [BankDetailID]  INT          IDENTITY (1, 1) NOT NULL,
    [FK_BankID]     INT          NULL,
    [FK_CompanyID]  INT          NULL,
    [BranchName]    VARCHAR (50) NULL,
    [BranchCode]    VARCHAR (50) NULL,
    [AccountNumber] INT          NULL,
    CONSTRAINT [PK_BankDetail] PRIMARY KEY CLUSTERED ([BankDetailID] ASC)
);

