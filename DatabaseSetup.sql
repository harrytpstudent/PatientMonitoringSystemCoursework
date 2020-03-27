-- Create tables

CREATE TABLE [dbo].[Permission]
(
	[PermissionId] BIGINT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(MAX) NOT NULL
);

CREATE TABLE [dbo].[Role]
(
	[RoleId] BIGINT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(MAX) NOT NULL
);

CREATE TABLE [dbo].[RolePermission]
(
	[RolePermissionId] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[RoleId] BIGINT NOT NULL,
	[PermissionId] BIGINT NOT NULL,
	CONSTRAINT [FK_RolePermission_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role]([RoleId]),
	CONSTRAINT [FK_RolePermission_Permission_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [Permission]([PermissionId]),
	CONSTRAINT [IXU_RolePermission_RoleId_PermissionId] UNIQUE (RoleId, PermissionId)
);

CREATE TABLE [dbo].[User]
(
	[UserId] BIGINT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[RoleId] BIGINT NOT NULL, -- No need to normalise this at the moment.
	[Name] NVARCHAR(MAX) NOT NULL,
	[Username] NVARCHAR(450) NOT NULL,
	[PasswordHash] CHAR(64) NOT NULL,
	CONSTRAINT [FK_User_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Role]([RoleId]),
	CONSTRAINT [IXU_User_Username] UNIQUE (Username)
);

CREATE TABLE [dbo].[NotificationType]
(
	[NotificationTypeId] BIGINT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Name] NVARCHAR(MAX) NOT NULL
);

CREATE TABLE [dbo].[Subscription]
(
	[SubscriptionId] BIGINT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[UserId] BIGINT NOT NULL,
	[NotificationTypeId] BIGINT NOT NULL,
	[Destination] NVARCHAR(MAX) NOT NULL, -- No need to normalise this at the moment.
	CONSTRAINT [FK_Subscription_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]),
	CONSTRAINT [FK_Subscription_NotificationType_NotificationTypeId] FOREIGN KEY ([NotificationTypeId]) REFERENCES [NotificationType]([NotificationTypeId]),
	CONSTRAINT [IXU_Subscription_UserId_NotificationTypeId] UNIQUE (UserId, NotificationTypeId)
);

CREATE TABLE [dbo].[Alarm]
(
	[AlarmId] BIGINT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[RaiseTime] DATETIME2 NOT NULL,
	[ResetTime] DATETIME2 NOT NULL,
	[ResetUserId] BIGINT NULL, -- This is nullable because you don't need to be logged in to reset alarms.
	CONSTRAINT [FK_Alarm_User_UserId] FOREIGN KEY ([ResetUserId]) REFERENCES [User]([UserId])
);

-- Insert data into tables

INSERT INTO [dbo].[Permission]
([Name])
VALUES
('ReceivePagerNotifications'),
('ReceiveSmsNotifications'),
('ReceiveEmailNotifications');

INSERT INTO [dbo].[Role]
([Name])
VALUES
('Doctor'),
('Consultant');

DECLARE @RoleId_Doctor BIGINT = (SELECT [RoleId] FROM [dbo].[Role] WHERE Name = 'Doctor');
DECLARE @RoleId_Consultant BIGINT = (SELECT [RoleId] FROM [dbo].[Role] WHERE Name = 'Consultant');
DECLARE @PermissionId_Pager BIGINT = (SELECT [PermissionId] FROM [dbo].[Permission] WHERE Name = 'ReceivePagerNotifications');
DECLARE @PermissionId_Sms BIGINT = (SELECT [PermissionId] FROM [dbo].[Permission] WHERE Name = 'ReceiveSmsNotifications');
DECLARE @PermissionId_Email BIGINT = (SELECT [PermissionId] FROM [dbo].[Permission] WHERE Name = 'ReceiveEmailNotifications');

INSERT INTO [dbo].[RolePermission]
([RoleId], [PermissionId])
VALUES
(@RoleId_Doctor, @PermissionId_Pager),
(@RoleId_Doctor, @PermissionId_Sms),
(@RoleId_Consultant, @PermissionId_Email);

INSERT INTO [dbo].[User]
([RoleId], [Name], [Username], [PasswordHash])
VALUES
(@RoleId_Doctor, 'John Doe', 'john', 'cf80cd8aed482d5d1527d7dc72fceff84e6326592848447d2dc0b0e87dfc9a90'), -- Password = 'testing'
(@RoleId_Consultant, 'Jane Doe', 'jane', '2cf24dba5fb0a30e26e83b2ac5b9e29e1b161e5c1fa7425e73043362938b9824'); -- Password = 'hello'

INSERT INTO [dbo].[NotificationType]
([Name])
VALUES
('Pager'),
('Sms'),
('Email');

DECLARE @UserId_John BIGINT = (SELECT [UserId] FROM [dbo].[User] WHERE Name = 'John Doe');
DECLARE @UserId_Jane BIGINT = (SELECT [UserId] FROM [dbo].[User] WHERE Name = 'Jane Doe');
DECLARE @NotificationTypeId_Pager BIGINT = (SELECT [NotificationTypeId] FROM [dbo].[NotificationType] WHERE Name = 'Pager');
DECLARE @NotificationTypeId_Sms BIGINT = (SELECT [NotificationTypeId] FROM [dbo].[NotificationType] WHERE Name = 'Sms');
DECLARE @NotificationTypeId_Email BIGINT = (SELECT [NotificationTypeId] FROM [dbo].[NotificationType] WHERE Name = 'Email');

INSERT INTO [dbo].[Subscription]
([UserId], [NotificationTypeId], [Destination])
VALUES
(@UserId_John, @NotificationTypeId_Pager, '1234567890'),
(@UserId_John, @NotificationTypeId_Sms, '0987654321'),
(@UserId_Jane, @NotificationTypeId_Email, 'jane.doe@example.com');