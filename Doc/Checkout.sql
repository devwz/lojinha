CREATE DATABASE [lojinha.Checkout]
GO

USE [lojinha.Checkout]
GO

CREATE TABLE [dbo].[Client]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
	[Login] NVARCHAR(128) NOT NULL,
	[Created] DATETIME DEFAULT(GETDATE()),
    [Modified] DATETIME DEFAULT(GETDATE())
)
GO

CREATE TABLE [dbo].[Address]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
	[AddressLine] NVARCHAR(512) NOT NULL,
	[StateProvince] NVARCHAR(128) NOT NULL,
	[CountryRegion] NVARCHAR(56) NOT NULL,
	[PostalCode] CHAR(8) NOT NULL,
	[Client_Id] INT FOREIGN KEY REFERENCES [dbo].[Client]([Id]) NOT NULL,
	[Created] DATETIME DEFAULT(GETDATE()),
    [Modified] DATETIME DEFAULT(GETDATE())
)
GO

CREATE TABLE [dbo].[Order]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
	[Method] NVARCHAR(128) NOT NULL,
	[Client_Id] INT FOREIGN KEY REFERENCES [dbo].[Client]([Id]) NOT NULL,
	[Created] DATETIME DEFAULT(GETDATE()),
    [Modified] DATETIME DEFAULT(GETDATE())
)
GO

CREATE TABLE [dbo].[ProductOrder]
(
	[Id] INT NOT NULL,
	[Price] DECIMAL(10,2) NOT NULL,
	[Title] NVARCHAR(64) NOT NULL,
	[Unid] INT NOT NULL,
	[Order_Id] INT FOREIGN KEY REFERENCES [dbo].[Order]([Id]) NOT NULL,
	[Created] DATETIME DEFAULT(GETDATE()),
    [Modified] DATETIME DEFAULT(GETDATE())
)
GO

CREATE PROCEDURE Add_Order
(
	@Login NVARCHAR(128),
	@AddressLine NVARCHAR(512),
	@StateProvince NVARCHAR(128),
	@CountryRegion NVARCHAR(56),
	@PostalCode CHAR(8),
	@Method NVARCHAR(128)
)
AS BEGIN

	DECLARE @Client_Id INT
	IF EXISTS (SELECT TOP(1) * FROM [dbo].[Client] WHERE [Login] = @Login)
		SET @Client_Id = (SELECT [Id] FROM [dbo].[Client] WHERE [Login] = @Login)
	ELSE
		BEGIN
			INSERT INTO [dbo].[Client]
			(
				[Login]
			)
			VALUES
			(
				@Login
			)
		SET @Client_Id = SCOPE_IDENTITY()
	END
	
	INSERT INTO [dbo].[Address]
	(
		[AddressLine], [StateProvince], [CountryRegion], [PostalCode], [Client_Id]
	)
	VALUES
	(
		@AddressLine, @StateProvince, @CountryRegion, @PostalCode, @Client_Id
	)

	INSERT INTO [dbo].[Order]
	(
		[Method], [Client_Id]
	)
	VALUES
	(
		@Method, @Client_Id
	)

	SELECT SCOPE_IDENTITY()

END
GO

CREATE PROCEDURE Add_ProductOrder
(
	@Id INT,
	@Title NVARCHAR(64),
	@Price DECIMAL(10,2),
	@Unid INT,
	@Order_Id INT
)
AS BEGIN

	INSERT INTO [dbo].[ProductOrder]
	(
		[Id], [Title], [Price], [Unid], [Order_Id]
	)
	VALUES
	(
		@Id, @Title, @Price, @Unid, @Order_Id
	)

END
GO

CREATE VIEW All_Order
AS
SELECT [Id],
	[Method],
	[Client_Id],
	[Created],
    [Modified]
FROM [dbo].[Order]
GO

CREATE VIEW All_Client
AS
SELECT [Id],
	[Login],
	[Created],
    [Modified]
FROM [dbo].[Client]
GO

CREATE VIEW All_Address
AS
SELECT [Id],
	[AddressLine],
	[StateProvince],
	[CountryRegion],
	[PostalCode],
	[Client_Id],
	[Created],
    [Modified]
FROM [dbo].[Address]
GO

CREATE VIEW All_ProductOrder
AS
SELECT [Id],
	[Price],
	[Title],
	[Unid],
	[Order_Id],
	[Created],
    [Modified]
FROM [dbo].[ProductOrder]
GO

CREATE PROCEDURE Update_Order
(
	@Id INT,
	@Title NVARCHAR(64),
	@Price DECIMAL(10,2),
	@Unid INT,
	@Order_Id INT
)
AS BEGIN
	IF EXISTS (SELECT TOP(1) * FROM [dbo].[ProductOrder] WHERE Id = @Id AND Order_Id = @Order_Id)
		BEGIN
			UPDATE [dbo].[Order]
			SET
				[Modified] = GETDATE()
			WHERE [Id] = @Id
			UPDATE [dbo].[ProductOrder]
			SET
				[Unid] = @Unid,
				[Modified] = GETDATE()
			WHERE [Id] = @Id
		END
	ELSE
		EXECUTE Add_ProductOrder @Id, @Title, @Price, @Unid, @Order_Id
END
GO