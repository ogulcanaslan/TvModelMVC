
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/05/2022 21:45:36
-- Generated from EDMX file: C:\Users\reisd\source\repos\TvModelMVC\TvModelMVC\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TvYayinDeneme];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Kanal'
CREATE TABLE [dbo].[Kanal] (
    [KanalId] int IDENTITY(1,1) NOT NULL,
    [KanalAdi] nvarchar(max)  NOT NULL,
    [KanalCiro] decimal(18,0)  NOT NULL,
    [KanalAdres] nvarchar(max)  NOT NULL,
    [KanalReyting] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Sorumlu'
CREATE TABLE [dbo].[Sorumlu] (
    [SorumluId] int IDENTITY(1,1) NOT NULL,
    [SorumluIsim] nvarchar(max)  NOT NULL,
    [SorumluGorevi] nvarchar(max)  NOT NULL,
    [SorumluMaas] decimal(18,0)  NOT NULL,
    [YayinYayinId] int  NOT NULL
);
GO

-- Creating table 'Yayin'
CREATE TABLE [dbo].[Yayin] (
    [YayinId] int IDENTITY(1,1) NOT NULL,
    [YayinAdi] nvarchar(max)  NOT NULL,
    [YayinTarihi] nvarchar(max)  NOT NULL,
    [YayinReyting] decimal(18,0)  NOT NULL,
    [KanalKanalId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [KanalId] in table 'Kanal'
ALTER TABLE [dbo].[Kanal]
ADD CONSTRAINT [PK_Kanal]
    PRIMARY KEY CLUSTERED ([KanalId] ASC);
GO

-- Creating primary key on [SorumluId] in table 'Sorumlu'
ALTER TABLE [dbo].[Sorumlu]
ADD CONSTRAINT [PK_Sorumlu]
    PRIMARY KEY CLUSTERED ([SorumluId] ASC);
GO

-- Creating primary key on [YayinId] in table 'Yayin'
ALTER TABLE [dbo].[Yayin]
ADD CONSTRAINT [PK_Yayin]
    PRIMARY KEY CLUSTERED ([YayinId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KanalKanalId] in table 'Yayin'
ALTER TABLE [dbo].[Yayin]
ADD CONSTRAINT [FK_KanalYayin]
    FOREIGN KEY ([KanalKanalId])
    REFERENCES [dbo].[Kanal]
        ([KanalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KanalYayin'
CREATE INDEX [IX_FK_KanalYayin]
ON [dbo].[Yayin]
    ([KanalKanalId]);
GO

-- Creating foreign key on [YayinYayinId] in table 'Sorumlu'
ALTER TABLE [dbo].[Sorumlu]
ADD CONSTRAINT [FK_YayinSorumlu]
    FOREIGN KEY ([YayinYayinId])
    REFERENCES [dbo].[Yayin]
        ([YayinId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_YayinSorumlu'
CREATE INDEX [IX_FK_YayinSorumlu]
ON [dbo].[Sorumlu]
    ([YayinYayinId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------