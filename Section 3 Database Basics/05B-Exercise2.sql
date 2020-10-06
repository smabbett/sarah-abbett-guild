/*
	Get the Customer Name, Order Date, and each order detail’s 
	Product name for USA customers only.

	Get the Customer Name (Customers.Company Name?), Order Date (Orders.OrderDate), and each order detail’s (OrderDetails.ProductId) 
	Product (Products.ProductID)name for USA customers only. (WHERE Customers.Country = USA)
*/

USE Northwind;
GO

SELECT Customers.CompanyName, Orders.OrderDate, Products.ProductName
FROM Customers
JOIN Orders
ON Customers.CustomerID = Orders.CustomerID
JOIN [Order Details]
ON Orders.OrderID = [Order Details].OrderID
JOIN Products
ON [Order Details].ProductID = Products.ProductID
WHERE Customers.Country = 'USA'