CREATE TABLE [dbo].[Doctor] (
    [Docid]     INT            IDENTITY (100, 1) NOT NULL,
    [DocName]   NVARCHAR (50)  NOT NULL,
    [DocGender] NVARCHAR (50)  NOT NULL,
    [DocDob]    DATE           NOT NULL,
    [DocAdd]    NVARCHAR (100) NOT NULL,
    [DocPhone]  NVARCHAR (10)  NOT NULL,
    [DocYear]   INT            NOT NULL,
    [DocSpec]   NVARCHAR (50)  NOT NULL,
    [DocPass]   NVARCHAR (101) NOT NULL,
    PRIMARY KEY CLUSTERED ([Docid] ASC)
);
GO

CREATE TRIGGER [reassign_prescriptions_before_delete_doctor]
	ON [dbo].[Doctor]
	INSTEAD OF DELETE
	AS
	BEGIN
		SET NOCOUNT ON;
		DECLARE @newDocId INT, @newDocName NVARCHAR(50); -- adjust the data type and length to match your table schema
		SELECT TOP 1 @newDocId = DocId, @newDocName = DocName FROM Doctor WHERE DocId NOT IN (SELECT DocId FROM deleted) ORDER BY DocId;
		UPDATE Pres SET DocId = @newDocId, DocName = @newDocName WHERE DocId IN (SELECT DocId FROM deleted);
		DELETE FROM Doctor WHERE DocId IN (SELECT DocId FROM deleted);
	END
GO

CREATE TABLE [dbo].[Pet] (
    [Petid]        INT            IDENTITY (200, 1) NOT NULL,
    [Petname]      VARCHAR (101)  NOT NULL,
    [Petgender]    VARCHAR (10)   NOT NULL,
    [Petage]       INT            NOT NULL,
    [Petadd]       VARCHAR (100)  NOT NULL,
    [Petphone]     NVARCHAR (10)  NOT NULL,
    [Petallergies] VARCHAR (1011) NOT NULL,
    [PetCategory]  VARCHAR (101)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Petid] ASC)
);
GO

CREATE TRIGGER [delete_prescriptions_before_delete_pet]
	ON [dbo].[Pet]
	INSTEAD OF DELETE
	AS
	BEGIN
		SET NOCOUNT ON;
		DELETE FROM Pres WHERE PetId IN (SELECT Petid FROM deleted);
		DELETE FROM Pet WHERE Petid IN (SELECT Petid FROM deleted);
	END
GO

CREATE TABLE [dbo].[Pres] (
    [PresId]   INT           IDENTITY (2000, 1) NOT NULL,
    [DocId]    INT           NOT NULL,
    [DocName]  NVARCHAR (50) NOT NULL,
    [PetId]    INT           NOT NULL,
    [PetName]  NVARCHAR (50) NOT NULL,
    [TestId]   INT           NULL,
    [TestName] NVARCHAR (50) NULL,
    [Medicine] NVARCHAR (50) NOT NULL,
    [Cost]     INT           NOT NULL,
    [Date]     DATETIME      NOT NULL,
    [Paid]     NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([PresId] ASC),
    CONSTRAINT [FKPresDoc] FOREIGN KEY ([DocId]) REFERENCES [dbo].[Doctor] ([Docid]),
    CONSTRAINT [FkPresPet] FOREIGN KEY ([PetId]) REFERENCES [dbo].[Pet] ([Petid]),
    CONSTRAINT [FKPresTest] FOREIGN KEY ([TestId]) REFERENCES [dbo].[Test] ([TestNum])
);
GO

CREATE TABLE [dbo].[Recep] (
    [RecepId]    INT            IDENTITY (500, 1) NOT NULL,
    [RecepName]  NVARCHAR (50)  NOT NULL,
    [RecepPass]  NVARCHAR (101) NOT NULL,
    [RecepAdd]   NVARCHAR (100) NOT NULL,
    [RecepPhone] NVARCHAR (10)  NOT NULL,
    PRIMARY KEY CLUSTERED ([RecepId] ASC)
);
GO

CREATE TABLE [dbo].[Test] (
    [TestNum]  INT         IDENTITY (800, 1) NOT NULL,
    [TestName] NCHAR (101) NOT NULL,
    [TestCost] INT         NOT NULL,
    PRIMARY KEY CLUSTERED ([TestNum] ASC)
);
GO

CREATE TRIGGER [delete_prescriptions_before_delete_test]
	ON [dbo].[Test]
	INSTEAD OF DELETE
	AS
	BEGIN
		SET NOCOUNT ON;
		UPDATE Pres SET TestId = NULL, TestName = NULL WHERE TestId IN (SELECT TestNum FROM deleted);
		DELETE FROM Test WHERE TestNum IN (SELECT TestNum FROM deleted);
	END
GO

CREATE PROCEDURE [dbo].[CountPets]
AS
BEGIN
    SELECT COUNT(*) FROM Pet;
END;
GO

CREATE PROCEDURE [dbo].[totCost]
AS
BEGIN
    SELECT SUM(Cost) FROM Pres WHERE Paid LIKE 'No';
END;
GO

CREATE FUNCTION dbo.PetHighCat()
RETURNS TABLE
AS
RETURN (
    SELECT TOP 1 PetCategory, COUNT(*) as count 
    FROM Pet 
    GROUP BY PetCategory 
    ORDER BY count DESC
);
GO
