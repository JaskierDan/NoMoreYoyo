use [NoMoreYoyo]
DELETE FROM [NoMoreYoyo].[dbo].[MeasurementType]
DBCC CHECKIDENT ('[NoMoreYoyo].[dbo].[MeasurementType]', RESEED, 0);
INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('cm','Chest');

INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('cm','Waist');
INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('cm','Hip');
INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('cm','Left');
INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('cm','Shoulder');
INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('cm','Left Biceps');
INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('cm','Right Biceps');
INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('cm','Left Forearm');
INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('cm','Right Forearm');
INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('cm','Neck');
INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('cm','Height');
INSERT INTO [NoMoreYoyo].[dbo].[MeasurementType] ([Metric],[Name]) VALUES ('kg','Weight');
