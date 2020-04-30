CREATE DATABASE [lojinha.ProductCatalog]
GO

USE [lojinha.ProductCatalog]
GO

CREATE TABLE [dbo].[Product]
(
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Created] DATETIME DEFAULT(GETDATE()),
    [Modified] DATETIME DEFAULT(GETDATE()),
    [Bio] NVARCHAR(512),
    [Enabled] BIT DEFAULT(1),
    [ImgUrl] NVARCHAR(128),
    [Price] DECIMAL(10,2) NOT NULL,
    [Title] NVARCHAR(64) NOT NULL
)
GO

INSERT INTO [dbo].[Product] ([Title], [Price]) VALUES ('Product 0', 0)
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

CREATE VIEW [ProductCatalog.Product]
AS
SELECT [Id],
    [Created],
    [Modified],
    [Bio],
    [Enabled],
    [ImgUrl],
    [Price],
    [Title]
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
        [Modified] = GETDATE(),
        [Bio] = @Bio,
        [Enabled] = @Enabled,
        [ImgUrl] = @ImgUrl,
        [Price] = @Price,
        [Title] = @Title
    WHERE [Id] = @Id
END
GO