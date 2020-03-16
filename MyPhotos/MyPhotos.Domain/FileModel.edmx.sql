
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/16/2020 20:38:50
-- Generated from EDMX file: G:\Facultate\an3\sem2\tspnet\tspnet-my-photos\MyPhotos\MyPhotos.Domain\FileModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyPhotos];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_FileAttributeAttribute]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileAttributes] DROP CONSTRAINT [FK_FileAttributeAttribute];
GO
IF OBJECT_ID(N'[dbo].[FK_FileFileAttribute]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FileAttributes] DROP CONSTRAINT [FK_FileFileAttribute];
GO
IF OBJECT_ID(N'[dbo].[FK_Video_inherits_File]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Files_Video] DROP CONSTRAINT [FK_Video_inherits_File];
GO
IF OBJECT_ID(N'[dbo].[FK_Photo_inherits_File]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Files_Photo] DROP CONSTRAINT [FK_Photo_inherits_File];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Files]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Files];
GO
IF OBJECT_ID(N'[dbo].[Attributes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Attributes];
GO
IF OBJECT_ID(N'[dbo].[FileAttributes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FileAttributes];
GO
IF OBJECT_ID(N'[dbo].[Files_Video]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Files_Video];
GO
IF OBJECT_ID(N'[dbo].[Files_Photo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Files_Photo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [Id] uniqueidentifier  NOT NULL,
    [CreatedAt] datetime  NOT NULL,
    [Path] nvarchar(max)  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'Attributes'
CREATE TABLE [dbo].[Attributes] (
    [Id] uniqueidentifier  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [AllowsMultipleValues] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'FileAttributes'
CREATE TABLE [dbo].[FileAttributes] (
    [Id] uniqueidentifier  NOT NULL,
    [Value] nvarchar(max)  NOT NULL,
    [AttributeId] uniqueidentifier  NULL,
    [FileId] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Files_Video'
CREATE TABLE [dbo].[Files_Video] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- Creating table 'Files_Photo'
CREATE TABLE [dbo].[Files_Photo] (
    [Id] uniqueidentifier  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Attributes'
ALTER TABLE [dbo].[Attributes]
ADD CONSTRAINT [PK_Attributes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FileAttributes'
ALTER TABLE [dbo].[FileAttributes]
ADD CONSTRAINT [PK_FileAttributes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Files_Video'
ALTER TABLE [dbo].[Files_Video]
ADD CONSTRAINT [PK_Files_Video]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Files_Photo'
ALTER TABLE [dbo].[Files_Photo]
ADD CONSTRAINT [PK_Files_Photo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AttributeId] in table 'FileAttributes'
ALTER TABLE [dbo].[FileAttributes]
ADD CONSTRAINT [FK_FileAttributeAttribute]
    FOREIGN KEY ([AttributeId])
    REFERENCES [dbo].[Attributes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileAttributeAttribute'
CREATE INDEX [IX_FK_FileAttributeAttribute]
ON [dbo].[FileAttributes]
    ([AttributeId]);
GO

-- Creating foreign key on [FileId] in table 'FileAttributes'
ALTER TABLE [dbo].[FileAttributes]
ADD CONSTRAINT [FK_FileFileAttribute]
    FOREIGN KEY ([FileId])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FileFileAttribute'
CREATE INDEX [IX_FK_FileFileAttribute]
ON [dbo].[FileAttributes]
    ([FileId]);
GO

-- Creating foreign key on [Id] in table 'Files_Video'
ALTER TABLE [dbo].[Files_Video]
ADD CONSTRAINT [FK_Video_inherits_File]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Files_Photo'
ALTER TABLE [dbo].[Files_Photo]
ADD CONSTRAINT [FK_Photo_inherits_File]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Files]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------