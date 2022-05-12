CREATE TABLE [dbo].[BodyAttributes] (
    [Id]                INT         IDENTITY (1, 1) NOT NULL,
    [UserId]            INT         NOT NULL,
    [MeasurementTypeId] INT         NOT NULL,
    [Value]             DECIMAL (6) NOT NULL,
    [Date]              DATETIME    NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([MeasurementTypeId]) REFERENCES [dbo].[MeasurementType] ([Id]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

