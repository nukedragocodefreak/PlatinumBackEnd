CREATE TYPE [dbo].[ttBankDetail] AS TABLE (
    [FK_BankID]     INT          NULL,
    [FK_CompanyID]  INT          NULL,
    [BranchName]    VARCHAR (50) NULL,
    [BranchCode]    VARCHAR (50) NULL,
    [AccountNumber] INT          NULL);

