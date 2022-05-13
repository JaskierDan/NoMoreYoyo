CREATE TABLE [dbo].[User] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [UserName]       NVARCHAR (50)  NOT NULL,
    [EmailAddress]   NVARCHAR (MAX) NOT NULL,
    [Password]       NVARCHAR (MAX) NOT NULL,
    [Weight]         DECIMAL (6)    NULL,
    [Height]         DECIMAL (6)    NULL,
    [Sex]            BIT            NOT NULL,
    [RegisteredDate] DATETIME       NOT NULL,
    [Age]            INT            NULL,
    [Salt]           NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);





