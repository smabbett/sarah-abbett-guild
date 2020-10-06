using NUnit.Framework;
using SWC_Flooring.BLL;
using SWC_Flooring.Data;
using SWC_Flooring.Models;
using SWC_Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.Test
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void OrderCalculationsTest()
        {
            Order order = new Order
            {
                Area = 500,
                CostPerSquareFoot = 1,
                LaborCostPerSquareFoot = 2,
                TaxRate = 10
            };

            Assert.AreEqual(500, order.MaterialCost);
            Assert.AreEqual(1000, order.LaborCost);
            Assert.AreEqual(150, order.Tax);
            Assert.AreEqual(1650, order.Total);
        }
        [Test]
        public void CanLoadOrderTestData()
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrdersResponse response = manager.LookupOrders(DateTime.Parse("01-01-2017"));

            Assert.IsNotNull(response.Orders);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(2, response.Orders.Count);
        }
        [Test]  
        public void CannotLoadDateNotFoundTest()
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrdersResponse response = manager.LookupOrders(DateTime.Parse("01-05-1999"));

            Assert.IsTrue(!response.Success);
            Assert.AreEqual("No orders were found to match the date given.", response.Message);
        }

        [Test]    
        public void CanAddOrdertoListTest()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order newOrder = new Order()
            {
                OrderDate = new DateTime(2017, 01, 01),
                CustomerName = "Sarah Abbett",
                State = "MN",
                TaxRate = 10m,
                ProductType = "Wood",
                Area = 1000,
                CostPerSquareFoot = 1,
                LaborCostPerSquareFoot = 1                             
            };
   
            OrderResponse response = manager.AddOrder(newOrder, newOrder.OrderDate);

            Assert.AreEqual("Sarah Abbett", response.order.CustomerName);
            Assert.AreEqual("Wood", response.order.ProductType);
            Assert.AreEqual(1000m, response.order.LaborCost);
            Assert.AreEqual(2200m, response.order.Total);
            Assert.AreEqual(3, response.order.OrderNumber);

            
        }
        [Test]
        public void CanEditOrder()
        {           
            DateTime orderDate = new DateTime(2017, 01, 01);
            int orderNumber = 2;

            OrderManager manager = OrderManagerFactory.Create();
            OrderResponse response = manager.LookupOrder(orderNumber, orderDate);
            var order = response.order;
            
            order.ProductType = "Pergo";
            order.State = "CO";

            manager.EditOrder(order, orderDate);

            var ordersResponse = manager.LookupOrders(orderDate);
            Order check = ordersResponse.Orders[1];

            Assert.AreEqual("Pergo", check.ProductType);
            Assert.AreEqual("John Smith", check.CustomerName);
            Assert.AreEqual("CO", check.State);
            Assert.AreEqual(950, check.Area);
        }
    }
}
