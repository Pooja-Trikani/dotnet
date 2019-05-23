IF EXISTS(SELECT * FROM SYSOBJECTS WHERE NAME='Participant')
DROP TABLE Participant
GO


CREATE TABLE Participant
(
  VoucherNumber VARCHAR(30) PRIMARY KEY,
  ParticipantName VARCHAR(30),
  Technology VARCHAR(30),
  CertificationCode VARCHAR(30),
  CertificationName VARCHAR(30),
  CertificationDate DATE
)
INSERT INTO Participant
VALUES
('ABCD-1234-1234-1234','pooja','Microsoft','70-461','Microsoft SQL Server 2012','4/25/2018'),
('ABCD-6789-6789-6789','poo','Microsoft','70-461','Microsoft SQL Server 2012','4/25/2018')



CREATE PROC prcParticipantSearch
					@VourcherNumber VARCHAR(30)

AS
BEGIN
	IF EXISTS(SELECT * FROM Participant WHERE VoucherNumber=@VourcherNumber )
	BEGIN 
		SELECT * FROM Participant WHERE VoucherNumber=@VourcherNumber
	END
END
GO


Select * from Participant