CREATE TABLE [dbo].[Supplier] (
    [SupplierID]   INT          IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50) NULL,
    [Address]      VARCHAR (50) NULL,
    [Phonenumbers] VARCHAR (50) NULL,
    [Email]        VARCHAR (50) NULL,
    CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED ([SupplierID] ASC)
);

