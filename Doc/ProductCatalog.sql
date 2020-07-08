CREATE DATABASE [lojinha.ProductCatalog]
GO

USE [lojinha.ProductCatalog]
GO

CREATE TABLE [dbo].[Product]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Bio] NVARCHAR(512),
    [Enabled] BIT DEFAULT(1),
    [ImgUrl] NVARCHAR(128),
    [Price] DECIMAL(10,2) NOT NULL,
    [Title] NVARCHAR(64) NOT NULL,
	[Created] DATETIME DEFAULT(GETDATE()),
    [Modified] DATETIME DEFAULT(GETDATE())
)
GO

CREATE PROCEDURE Add_Product
(
    @Bio NVARCHAR(512),
    @ImgUrl NVARCHAR(128),
    @Price DECIMAL(10,2),
    @Title NVARCHAR(64)
)
AS BEGIN
    INSERT INTO [dbo].[Product]
	(
		[Bio], [ImgUrl], [Price], [Title]
	)
    VALUES
	(
		@Bio, @ImgUrl, @Price, @Title
	)
    SELECT SCOPE_IDENTITY()
END
GO

CREATE VIEW All_Product
AS
SELECT [Id],
    [Bio],
    [Enabled],
    [ImgUrl],
    [Price],
    [Title],
    [Created],
    [Modified]
FROM [dbo].[Product]
GO

CREATE PROCEDURE Delete_Product
(
    @Id INT
)
AS BEGIN
    DELETE FROM [dbo].[Product]
    WHERE [Id] = @Id
END
GO

CREATE PROCEDURE Update_Product
(
    @Id INT,
    @Bio NVARCHAR(512),
    @Enabled BIT,
    @ImgUrl NVARCHAR(128),
    @Price DECIMAL(10,2),
    @Title NVARCHAR(64)
)
AS BEGIN
    UPDATE [dbo].[Product] SET
        [Bio] = @Bio,
        [Enabled] = @Enabled,
        [ImgUrl] = @ImgUrl,
        [Price] = @Price,
        [Title] = @Title,
        [Modified] = GETDATE()
    WHERE [Id] = @Id
END
GO

--

INSERT INTO [dbo].[Product] ([Title], [Price], [ImgUrl])
VALUES
	('Product 0', 8, '/assets/image_1.jpg'),
	('Product 1', 6, '/assets/image_2.jpg'),
	('Product 2', 4, '/assets/image_3.jpg'),
	('Product 3', 2, '/assets/image_4.jpg')
GO