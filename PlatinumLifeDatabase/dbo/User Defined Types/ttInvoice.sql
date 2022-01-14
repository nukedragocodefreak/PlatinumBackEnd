CREATE TYPE [dbo].[ttInvoice] AS TABLE (
    [InvoiceNumber]   VARCHAR (50)  NULL,
    [Date]            DATETIME      NULL,
    [location]        VARCHAR (100) NULL,
    [FIleName]        VARCHAR (50)  NULL,
    [FK_CoverSheetID] INT           NULL,
    [FK_SupplierID]   INT           NULL);

