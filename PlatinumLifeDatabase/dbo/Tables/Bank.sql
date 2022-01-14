CREATE TABLE [dbo].[Bank] (
    [BankID]   INT          IDENTITY (1, 1) NOT NULL,
    [BankName] VARCHAR (50) NULL,
    CONSTRAINT [PK_Bank] PRIMARY KEY CLUSTERED ([BankID] ASC)
);

