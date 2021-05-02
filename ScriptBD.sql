USE master
GO

DROP DATABASE IF EXISTS CrudRazorPages
GO

CREATE DATABASE CrudRazorPages
GO

USE CrudRazorPages
GO

CREATE TABLE Director(
	Id int identity(1,1),
	Name varchar(50) not null,
	AmountOfPrizes int not null,
	Birthdate date not null,

	PRIMARY KEY(Id)
);
GO

CREATE TABLE Movie(
	Id int identity(1,1),
	Title varchar(50) not null,
	Description varchar(500) not null,
	Duration int not null,
	Premiere date not null,
	Takings int not null,
	DirectorId int not null,

	PRIMARY KEY(Id),
	FOREIGN KEY(DirectorId) REFERENCES Director(Id)
);
GO

CREATE PROCEDURE SP_Director_Get(
	@Option int,
	@Id		int = null
)
AS
BEGIN
	IF @Option = 1			--GET_ALL
		SELECT Id,
			   Name,
			   AmountOfPrizes,
			   Birthdate
		FROM Director;
	ELSE IF @Option = 2		--GET_BY_ID
		SELECT Id,			
			   Name,
			   AmountOfPrizes,
			   Birthdate
		FROM Director
		WHERE Id = @Id
	ELSE IF @Option = 3		--GET_FOR_DDL
		SELECT Id,
			   Name
		FROM Director;
END
GO

CREATE PROCEDURE SP_Director_Transaction(
	@Option			int,
	@Id				int = null,
	@Name			varchar(50) = null,
	@AmountOfPrizes int = null,
	@Birthdate		date = null
)
AS 
BEGIN
	IF @Option = 1			--INSERT
		INSERT INTO Director(Name,Birthdate,AmountOfPrizes) 
		VALUES(@Name,@Birthdate,@AmountOfPrizes);
		
	ELSE IF @Option = 2		--UPDATE
		UPDATE Director SET Name = @Name,
							Birthdate = @Birthdate,
							AmountOfPrizes = @AmountOfPrizes
		WHERE Id = @Id;
	ELSE IF @Option = 3		--DELETE
		DELETE FROM Director WHERE Id = @Id;
END
GO

CREATE PROCEDURE SP_Movie_Get(
	@Option int,
	@Id		int = null
)
AS
BEGIN
	IF @Option = 1			--GET_ALL
		SELECT Id,
			   Title,
			   Description,
			   Duration,
			   Premiere,
			   Takings,
			   DirectorId
		FROM Movie;
	ELSE IF @Option = 2		--GET_BY_ID
		SELECT Id,
			   Title,
			   Description,
			   Duration,
			   Premiere,
			   Takings,
			   DirectorId
		FROM Movie
		WHERE Id = @Id;
	ELSE IF @Option = 3		--GET_FOR_DETAILS_BY_ID
		SELECT m.Id,
			   m.Title,
			   m.Description,
			   m.Duration,
			   m.Premiere,
			   m.Takings,
			   m.DirectorId,
			   d.Name
		FROM Movie m, Director d
		WHERE m.Id = @Id AND m.DirectorId = d.Id;
END
GO

CREATE PROCEDURE SP_Movie_Transaction(
	@Option			int,
	@Id				int = null,
	@Title			varchar(50) = null,
	@Description	varchar(500) = null,
	@Duration		int = null,
	@Premiere		date = null,
	@Takings		int = null,	
	@DirectorId		int = null
)
AS 
BEGIN
	IF @Option = 1			--INSERT
		INSERT INTO Movie(Title,Description,Duration,Premiere,Takings,DirectorId)
		VALUES(@Title,@Description,@Duration,@Premiere,@Takings,@DirectorId);
	ELSE IF @Option = 2		--UPDATE
		UPDATE Movie SET Title = @Title,
						 Description = @Description,
						 Duration = @Duration,
						 Premiere = @Premiere,
						 Takings = @Takings,
						 DirectorId = @DirectorId
		WHERE Id = @Id;
	ELSE IF @Option = 3		--DELETE
		DELETE FROM Movie WHERE Id = @Id;
END
GO

INSERT INTO Director(Name,AmountOfPrizes,Birthdate) 
VALUES('Steven Spielberg',50,'2021-12-18'),('Quentin Tarantino',36,'1963-03-27');

INSERT INTO Movie(Title,Description,Duration,Premiere,Takings,DirectorId)
VALUES('E.T., el extraterrestre','El encuentro cercano de un niño con un alienígena perdido deriva en una amistad única.',121,'1982-06-10',792200000,1),
('Parque Jurásico','Tres expertos y otras personas son invitados a un parque de diversiones, donde se encuentran dinosaurios creados en base al ADN.',128,'1993-06-09',1033000000,1),
('Django sin cadenas','Un exesclavo une fuerzas con un cazador de recompensas alemán que lo liberó y lo ayuda a buscar a los criminales más buscados del sur de los Estados Unidos, con la esperanza de reencontrarse con su esposa.',165,'2012-12-25',425400000,1),
('Prueba','Prueba',128,'1993-06-09',802300400,2);
GO


select * from CrudRazorPages.dbo.Movie