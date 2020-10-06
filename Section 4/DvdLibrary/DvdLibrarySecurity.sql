USE master
GO

CREATE LOGIN DvdLibraryApp WITH PASSWORD='testing123'
GO

USE DvdLibrary
GO

CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT EXECUTE ON DvdSelectAll TO DvdLibraryApp
GRANT EXECUTE ON DvdSelectById TO DvdLibraryApp
GRANT EXECUTE ON DvdInsert TO DvdLibraryApp
GRANT EXECUTE ON DvdUpdate TO DvdLibraryApp
GRANT EXECUTE ON DvdDelete TO DvdLibraryApp
GRANT EXECUTE ON DvdSelectByDirector TO DvdLibraryApp
GRANT EXECUTE ON DvdSelectByRating TO DvdLibraryApp
GRANT EXECUTE ON DvdSelectByTitle TO DvdLibraryApp
GRANT EXECUTE ON DvdSelectByTitle TO DvdLibraryApp

GO

GRANT SELECT ON Dvd TO DvdLibraryApp
GRANT INSERT ON Dvd TO DvdLibraryApp
GRANT UPDATE ON Dvd TO DvdLibraryApp
GRANT DELETE ON Dvd TO DvdLibraryApp
GO

USE DvdLibraryEF
GO

CREATE USER DvdLibraryApp FOR LOGIN DvdLibraryApp
GO

GRANT SELECT ON Dvds TO DvdLibraryApp
GRANT INSERT ON Dvds TO DvdLibraryApp
GRANT UPDATE ON Dvds TO DvdLibraryApp
GRANT DELETE ON Dvds TO DvdLibraryApp
GO
