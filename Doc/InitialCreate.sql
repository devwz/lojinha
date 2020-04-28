CREATE DATABASE [lojinha.ProductCatalog]
GO
USE [lojinha.ProductCatalog]
GO

CREATE TABLE [dbo].[Product] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Created] DATETIME DEFAULT(GETDATE()),
    [Modified] DATETIME DEFAULT(GETDATE()),
    [Bio] NVARCHAR(512),
    [Enabled] BIT DEFAULT(0),
    [ImgUrl] NVARCHAR(128),
    [Price] DECIMAL(10,2),
    [Title] NVARCHAR(64) NOT NULL
)

INSERT INTO [dbo].[Product]
    ([Title], [Price])
VALUES
    ('Product 0', 10),
    ('Product 1', 6),
    ('Product 2', 12)