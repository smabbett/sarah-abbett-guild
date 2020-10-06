/*
	Get a list of each employee first name and lastname
	and the territory names they are associated with
*/

USE Northwind;
GO

SELECT Employees.FirstName, Employees.LastName, Territories.TerritoryDescription
FROM Employees
	INNER JOIN EmployeeTerritories ON EmployeeTerritories.EmployeeID = Employees.EmployeeID
	INNER JOIN Territories ON Territories.TerritoryID = EmployeeTerritories.TerritoryID


