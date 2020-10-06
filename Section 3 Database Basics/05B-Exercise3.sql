/*
	Get all the order information for any order where Chai was sold.
*/

USE Northwind;
GO

SELECT Products.ProductName, Orders.OrderDate, Customers.CompanyName, Quantity, Discount
FROM [Order Details]
JOIN Orders
ON Orders.OrderID = [Order Details].OrderID
JOIN Customers
ON Customers.CustomerID = Orders.CustomerID
JOIN Products
ON [Order Details].ProductID = Products.ProductID
WHERE Products.ProductID = 1