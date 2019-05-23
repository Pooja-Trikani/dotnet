use sqlpractice 
GO

IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME='Certificates') 
DROP TABLE Participant
GO

CREATE TABLE Participant
(
    VourcherNumber VARCHAR(30) 
	CONSTRAINT PK_Participant_VourcherNumber PRIMARY KEY,
	ParticipantName VARCHAR(30),
	Technology VARCHAR(30), 
	CertificationCode VARCHAR(30),
	CertificaionName VARCHAR(30), 
	CertificationDate DATETIME
)
GO

CREATE PROC prcParticipantSearch
					@VourcherNumber VARCHAR(30)

AS
BEGIN
	IF EXISTS(SELECT * FROM Participant WHERE VourcherNumber=@VourcherNumber )
	BEGIN 
		SELECT * FROM Participant WHERE VourcherNumber=@VourcherNumber
	END
END
GO

INSERT INTO Participant VALUES('1234-1234-1234','pooja','JAVA','OCJP','CoreJava','12-12-2000'),
								('1234-1234-1235','pooo','JAVA','OCJP','CoreJava','12-12-2000')
GO

select * from Certificates