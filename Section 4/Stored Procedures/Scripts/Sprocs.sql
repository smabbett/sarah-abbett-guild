USE SWCCorp;
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EmployeeRatesSelect')
BEGIN
   DROP PROCEDURE EmployeeRatesSelect
END
GO

CREATE PROCEDURE EmployeeRatesSelect
AS

	SELECT e.EmpID, e.FirstName, e.LastName, pr.HourlyRate,
		pr.MonthlySalary, pr.YearlySalary 
    FROM Employee e 
		INNER JOIN PayRates pr ON e.EmpID = pr.EmpID

GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'EmployeeRatesSelectByCity')
BEGIN
   DROP PROCEDURE EmployeeRatesSelectByCity
END
GO

CREATE PROCEDURE EmployeeRatesSelectByCity (
	@City varchar(20)
)
AS
	SELECT e.EmpID, e.FirstName, e.LastName, pr.HourlyRate,
		   pr.MonthlySalary, pr.YearlySalary
    FROM Employee e 
		INNER JOIN PayRates pr ON e.EmpID = pr.EmpID 
        INNER JOIN [Location] l on e.LocationID = l.LocationID 
    WHERE l.City = @City
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GrantUpdate')
BEGIN
	DROP PROCEDURE GrantUpdate
END
GO

CREATE PROCEDURE GrantUpdate (
	@GrantId char(3), @GrantName nvarchar(50), @Amount decimal (9,2)
)
AS 
	UPDATE [Grant] 
    SET GrantName = @GrantName,
    Amount = @Amount
    WHERE GrantId = @GrantId
GO


IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GrantInsert')
BEGIN
	DROP PROCEDURE GrantInsert
END
GO

CREATE PROCEDURE GrantInsert(
	@GrantId char(3), @GrantName nvarchar(50), @Amount decimal (9,2)
)
AS
	INSERT INTO [Grant] (GrantId, GrantName, EmpID, Amount)
	VALUES (@GrantId, @GrantName, null, @Amount)
GO

IF EXISTS(
	SELECT *
	FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'GrantDelete')
BEGIN
	DROP PROCEDURE GrantDelete
END
GO

CREATE PROCEDURE GrantDelete (
	@GrantId char(3)
)
AS 
	DELETE FROM [Grant]
	WHERE GrantId = @GrantId
GO