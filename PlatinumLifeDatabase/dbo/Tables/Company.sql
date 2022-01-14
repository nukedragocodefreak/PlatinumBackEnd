CREATE TABLE [dbo].[Company] (
    [CompanyID]    INT           IDENTITY (1, 1) NOT NULL,
    [Name]         VARCHAR (50)  NULL,
    [Address]      VARCHAR (100) NULL,
    [Email]        VARCHAR (50)  NULL,
    [Phonenumbers] VARCHAR (100) NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED ([CompanyID] ASC)
);

