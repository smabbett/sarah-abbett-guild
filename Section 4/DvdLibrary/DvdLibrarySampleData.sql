USE DvdLibrary
GO

-- Sample Data

SET IDENTITY_INSERT Dvd ON

INSERT INTO Dvd (DvdId, Title, ReleaseYear, Director, Rating, Notes)
VALUES (1, 'The Lion King', 1994, 'Roger Allers', 'G', 'The adventures of the lion, Simba.'),
	(2, 'Terminator', 1984, 'James Cameron', 'R', 'A cyborg sent from the future.'),
	(3, 'Friday the 13th', 1980, 'Sean Cunningham', 'R', 'Jason is killing campers.'),
	(4, 'The Abyss', 1989, 'James Cameron', 'PG-13', 'A underwater UFO.')

SET IDENTITY_INSERT Dvd OFF