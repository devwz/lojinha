CREATE DATABASE [market.CartService]
GO

USE [market.CartService]
GO

CREATE TABLE [dbo].[Cart]
(
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[CartKey] NVARCHAR(64) NOT NULL,
	[Created] DATETIME DEFAULT(GETDATE()),
    [Modified] DATETIME DEFAULT(GETDATE())
)
GO

CREATE TABLE [dbo].[CartItem]
(
	[Id] INT NOT NULL,
	[ImgUrl] NVARCHAR(128),
	[Price] DECIMAL(10,2) NOT NULL,
	[Title] NVARCHAR(64) NOT NULL,
	[Unid] INT NOT NULL,
	[Cart_Id] INT FOREIGN KEY REFERENCES [dbo].[Cart]([Id]) ON DELETE CASCADE NOT NULL,
	[Created] DATETIME DEFAULT(GETDATE()),
    [Modified] DATETIME DEFAULT(GETDATE())
)
GO

CREATE PROCEDURE Add_Cart
(
	@CartKey NVARCHAR(64)
)
AS BEGIN
	INSERT INTO [dbo].[Cart]
	(
		[CartKey]
	)
	VALUES
	(
		@CartKey
	)
	SELECT SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE Add_CartItem
(
	@Id INT,
	@ImgUrl NVARCHAR(128),
	@Price DECIMAL(10,2),
	@Title NVARCHAR(64),
	@Unid INT,
	@Cart_Id INT
)
AS BEGIN
	INSERT INTO [dbo].[CartItem]
	(
		[Id], [ImgUrl], [Price], [Title], [Unid], [Cart_Id]
	)
	VALUES
	(
		@Id, @ImgUrl, @Price, @Title, @Unid, @Cart_Id
	)
END
GO

CREATE VIEW All_Cart
AS
SELECT [Id],
	[CartKey],
	[Created],
	[Modified]
FROM [dbo].[Cart]
GO

CREATE VIEW All_CartItem
AS
SELECT [Id],
	[ImgUrl],
	[Price],
	[Title],
	[Unid],
	[Cart_Id],
	[Created],
    [Modified]
FROM [dbo].[CartItem]
GO

CREATE PROCEDURE Delete_Cart
(
	@CartKey NVARCHAR(64)
)
AS BEGIN
	DELETE FROM [dbo].[Cart]
	WHERE [CartKey] = @CartKey
END
GO

CREATE PROCEDURE Delete_CartItem
(
	@Id INT,
	@Cart_Id INT
)
AS BEGIN
	DELETE FROM [dbo].[CartItem]
	WHERE [Id] = @Id AND [Cart_Id] = @Cart_Id
END
GO

CREATE PROCEDURE Update_Cart
(
	@Id INT,
	@ImgUrl NVARCHAR(128),
	@Price DECIMAL(10,2),
	@Title NVARCHAR(64),
	@Unid INT,
	@Cart_Id INT
)
AS BEGIN
	IF EXISTS (SELECT TOP(1) * FROM [dbo].[CartItem] WHERE Id = @Id AND Cart_Id = @Cart_Id)
		BEGIN
			UPDATE [dbo].[Cart]
			SET
				[Modified] = GETDATE()
			WHERE [Id] = @Id
			UPDATE [dbo].[CartItem]
			SET
				[Unid] = @Unid,
				[Modified] = GETDATE()
			WHERE [Id] = @Id
		END
	ELSE
		EXECUTE Add_CartItem @Id, @ImgUrl, @Price, @Title, @Unid, @Cart_Id
END
GO