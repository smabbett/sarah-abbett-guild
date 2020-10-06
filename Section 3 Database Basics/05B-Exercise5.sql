/*
	Find a list of all the Employees who have never found a Grant (1 6 8 9 12)
*/

USE SWCCorp;
GO

SELECT FirstName, LastName, Employee.EmpID
FROM Employee
LEFT JOIN [Grant]
ON Employee.EmpID = [Grant].EmpID
WHERE [Grant].EmpID IS NULL
