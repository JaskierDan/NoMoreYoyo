use [NoMoreYoyo]
DELETE FROM [NoMoreYoyo].[dbo].[User]
DBCC CHECKIDENT ('[NoMoreYoyo].[dbo].[User]', RESEED, 0);
INSERT INTO [NoMoreYoyo].[dbo].[User]([UserName],[EmailAddress],[Password],[Weight],[Height],[Sex],[RegisteredDate],[Age]) VALUES ('Test','test@test.com','DORKKDPLRLDTMLMDPM',75,175,1,'2022-03-22',20);
INSERT INTO [NoMoreYoyo].[dbo].[User]([UserName],[EmailAddress],[Password],[Weight],[Height],[Sex],[RegisteredDate],[Age]) VALUES ('Admin','admin@test.com','DORKKDPLRLDTMLMDPMOK',75,175,1,'2022-03-22',20);
