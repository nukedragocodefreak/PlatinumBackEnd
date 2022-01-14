CREATE TABLE [dbo].[Invoice] (
    [InvoiceID]       INT           IDENTITY (1, 1) NOT NULL,
    [InvoiceNumber]   VARCHAR (50)  NULL,
    [Date]            DATETIME      NULL,
    [location]        VARCHAR (100) NULL,
    [FIleName]        VARCHAR (50)  NULL,
    [FK_CoverSheetID] INT           NULL,
    [FK_SupplierID]   INT           NULL,
    CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED ([InvoiceID] ASC)
);

