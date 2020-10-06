/*
	Write a query to show every combination of employee and location.
*/

USE SWCCorp;
GO

SELECT FirstName, LastName, [Location].Street, [Location].City, [Location].[State]
FROM Employee
FULL OUTER JOIN [Location]
ON Employee.LocationID = Location.LocationID