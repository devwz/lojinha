CREATE DATABASE [market.ProductCatalog]
GO

USE [market.ProductCatalog]
GO

CREATE TABLE [dbo].[Product]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Bio] NVARCHAR(512),
    [Enabled] BIT DEFAULT(1),
    [ImgUrl] NVARCHAR(128),
    [Price] DECIMAL(10,2) NOT NULL,
    [Title] NVARCHAR(64) NOT NULL,
	[Type] NVARCHAR(32) NOT NULL,
	[Created] DATETIME DEFAULT(GETDATE()),
    [Modified] DATETIME DEFAULT(GETDATE())
)
GO

CREATE PROCEDURE Add_Product
(
    @Bio NVARCHAR(512),
    @ImgUrl NVARCHAR(128),
    @Price DECIMAL(10,2),
    @Title NVARCHAR(64),
	@Type NVARCHAR(32)
)
AS BEGIN
    INSERT INTO [dbo].[Product]
	(
		[Bio], [ImgUrl], [Price], [Title], [Type]
	)
    VALUES
	(
		@Bio, @ImgUrl, @Price, @Title, @Type
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
	[Type],
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
    @Title NVARCHAR(64),
	@Type NVARCHAR(32)
)
AS BEGIN
    UPDATE [dbo].[Product] SET
        [Bio] = @Bio,
        [Enabled] = @Enabled,
        [ImgUrl] = @ImgUrl,
        [Price] = @Price,
        [Title] = @Title,
		[Type] = @Type,
        [Modified] = GETDATE()
    WHERE [Id] = @Id
END
GO

--

INSERT INTO [dbo].[Product] ([Title], [Type], [Price], [ImgUrl])
VALUES
	('Carne de Soja', 'Alimentos', 8, '/assets/carne-de-soja.jpg'),
	('Cebola', 'Alimentos', 6, '/assets/cebola.jpg'),
	('Tomate', 'Alimentos', 4, '/assets/tomate.jpg'),
	('Batata', 'Alimentos', 2, '/assets/batata.jpg')
GO