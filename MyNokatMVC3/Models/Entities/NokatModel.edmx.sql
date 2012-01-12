
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 01/10/2012 17:04:40
-- Generated from EDMX file: D:\MyNokatMVC3\MyNokatMVC3\Models\Entities\NokatModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [db83ec0a93d2944c588bc69fd30099f6a1];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Votes_Jokes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Votes] DROP CONSTRAINT [FK_Votes_Jokes];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Jokes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Jokes];
GO
IF OBJECT_ID(N'[dbo].[Votes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Votes];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Jokes'
CREATE TABLE [dbo].[Jokes] (
    [JokeId] int IDENTITY(1,1) NOT NULL,
    [UserId] bigint  NOT NULL,
    [Joke] nvarchar(200)  NOT NULL,
    [AddDate] datetime  NOT NULL
);
GO

-- Creating table 'Votes'
CREATE TABLE [dbo].[Votes] (
    [VoteId] int IDENTITY(1,1) NOT NULL,
    [JokeId] int  NOT NULL,
    [UserId] bigint  NOT NULL,
    [VoteType] bit  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [JokeId] in table 'Jokes'
ALTER TABLE [dbo].[Jokes]
ADD CONSTRAINT [PK_Jokes]
    PRIMARY KEY CLUSTERED ([JokeId] ASC);
GO

-- Creating primary key on [VoteId] in table 'Votes'
ALTER TABLE [dbo].[Votes]
ADD CONSTRAINT [PK_Votes]
    PRIMARY KEY CLUSTERED ([VoteId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [JokeId] in table 'Votes'
ALTER TABLE [dbo].[Votes]
ADD CONSTRAINT [FK_Votes_Jokes]
    FOREIGN KEY ([JokeId])
    REFERENCES [dbo].[Jokes]
        ([JokeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Votes_Jokes'
CREATE INDEX [IX_FK_Votes_Jokes]
ON [dbo].[Votes]
    ([JokeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------