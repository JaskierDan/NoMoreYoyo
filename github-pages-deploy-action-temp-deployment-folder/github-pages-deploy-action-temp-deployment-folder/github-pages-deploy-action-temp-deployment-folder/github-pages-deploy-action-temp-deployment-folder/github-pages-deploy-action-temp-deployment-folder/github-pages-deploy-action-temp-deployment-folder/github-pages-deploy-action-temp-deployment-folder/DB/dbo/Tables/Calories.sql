CREATE TABLE [dbo].[Calories] (
    [Id]            INT         IDENTITY (1, 1) NOT NULL,
    [UserId]        INT         NOT NULL,
    [Date]          DATETIME    NOT NULL,
    [Amount]        DECIMAL (6) NOT NULL,
    [Fats]          DECIMAL (6) NULL,
    [Carbohydrates] DECIMAL (6) NULL,
    [Proteins]      DECIMAL (6) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

