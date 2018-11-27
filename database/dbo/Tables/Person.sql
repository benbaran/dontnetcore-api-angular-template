CREATE TABLE [dbo].[Person] (
    [PersonId]       UNIQUEIDENTIFIER CONSTRAINT [DF_Person_PersonId] DEFAULT (newid()) NOT NULL,
    [FirstName]      VARCHAR (255)    NULL,
    [LastName]       VARCHAR (255)    NULL,
    [CreateDateTime] DATE             CONSTRAINT [DF_Person_CreateDateTime] DEFAULT (getutcdate()) NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC)
);

