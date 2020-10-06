	/*
		This script creates the SG Roster database
		in a step-wise manner according to the 04A writeup.
	*/
	CREATE DATABASE SGRoster;
	GO

	USE SGRoster;
	GO


	CREATE TABLE Cohort (
		CohortID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
		StartDate DATE NOT NULL,
		[Subject] VARCHAR(30) NOT NULL,
		Location VARCHAR(30) NOT NULL
	)
	GO

	CREATE TABLE Apprentice (
		ApprenticeID INT IDENTITY(1,1) NOT NULL,
		FirstName VARCHAR(30) NOT NULL,
		LastName VARCHAR(30) NOT NULL,
		CohortID INT NOT NULL,
		CONSTRAINT PK_Apprentice PRIMARY KEY (ApprenticeID),
		CONSTRAINT FK_Apprentice_Cohort FOREIGN KEY(CohortID) 
			REFERENCES Cohort(CohortID)
	)
	GO

	ALTER TABLE Apprentice 
	DROP CONSTRAINT FK_Apprentice_Cohort;
	GO

	ALTER TABLE Apprentice 
	DROP COLUMN CohortID;
	GO

	CREATE TABLE ApprenticeCohort (
		ApprenticeID INT NOT NULL,
		CohortID INT NOT NULL,
		CONSTRAINT PK_ApprenticeCohort 
			PRIMARY KEY (ApprenticeID, CohortID),
		CONSTRAINT FK_Cohort_ApprenticeCohort 
			FOREIGN KEY(CohortID) REFERENCES Cohort(CohortID),
		CONSTRAINT FK_Apprentice_ApprenticeCohort 
			FOREIGN KEY(ApprenticeID) REFERENCES Apprentice(ApprenticeID)
	)
	GO