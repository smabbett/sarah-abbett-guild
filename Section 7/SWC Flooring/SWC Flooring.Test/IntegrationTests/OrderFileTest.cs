using NUnit.Framework;
using SWC_Flooring.BLL;
using SWC_Flooring.Data;
using SWC_Flooring.Models;
using SWC_Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.Test.IntegrationTests
{
    [TestFixture]
    public class OrderFileTest
    {
        private const string _filepath = @"C:\Data\SWCFlooring\Orders_06012013.txt";
        private const string _originalData = @"C:\Data\SWCFlooring\Orders_06012013_Seed.txt";
        private string _filepathWithoutExtension = ConfigurationManager.AppSettings["orderFilepath"].ToString();

        [SetUp]
        public void Setup()
        {
            if (File.Exists(_filepath))
            {
                File.Delete(_filepath);
            }

            File.Copy(_originalData, _filepath);
        }
        [Test]
        public void CanLoadOrdersFileData()
        {
            DateTime orderDate = new DateTime(2013, 06, 01);
            FileOrderRepository repo = new FileOrderRepository(_filepathWithoutExtension);

            List<Order> orders = repo.LoadOrders(orderDate);

            Assert.AreEqual("Wise", orders[0].CustomerName);
            Assert.AreEqual("Wood", orders[0].ProductType);
            Assert.AreEqual(1, orders.Count);
        }
        [Test]
        public void CanLoadOrderFromList()
        {
            DateTime orderDate = new DateTime(2013, 06, 01);
            int orderNumber = 1;

            FileOrderRepository repo = new FileOrderRepository(_filepathWithoutExtension);

            var order = repo.LoadOrder(orderNumber, orderDate);

            Assert.AreEqual("Wise", order.CustomerName);
            Assert.AreEqual("Wood", order.ProductType);
            Assert.AreEqual(100, order.Area);
        }
        [Test]
        public void CanEditOrderFileData()
        {
            DateTime orderDate = new DateTime(2013, 06, 01);
            int orderNumber = 1;

            FileOrderRepository repo = new FileOrderRepository(_filepathWithoutExtension);

            var order = repo.LoadOrder(orderNumber, orderDate);
            order.CustomerName = "John Smith";
            order.ProductType = "Laminate";
            order.Area = 200M;
            order.CostPerSquareFoot = 1.75M;
            order.LaborCostPerSquareFoot = 2.10M;

            repo.EditOrder(order, orderDate);
            var newOrder = repo.LoadOrder(orderNumber, orderDate);

            Assert.AreEqual("John Smith", newOrder.CustomerName);
            Assert.AreEqual("Ohio", newOrder.State);
            Assert.AreEqual("Laminate", newOrder.ProductType);
            Assert.AreEqual(200M, newOrder.Area);
            Assert.AreEqual(350M, newOrder.MaterialCost);
            Assert.AreEqual(420M, newOrder.LaborCost);
        }
        [Test]
        public void CanDeleteOrderFileData()
        {
            DateTime orderDate = new DateTime(2013, 06, 01);
            int orderNumber = 1;

            FileOrderRepository repo = new FileOrderRepository(_filepathWithoutExtension);
          
            repo.DeleteOrder(orderNumber, orderDate);
            var orders = repo.LoadOrders(orderDate);

            Assert.AreEqual(0, orders.Count);          
        }
        [Test]
        public void CanAddOrderFileData()
        {
            DateTime orderDate = new DateTime(2013, 06, 01);

            FileOrderRepository repo = new FileOrderRepository(_filepathWithoutExtension);
            Order newOrder = new Order()
            {
                OrderDate = new DateTime(2013, 06, 01),
                CustomerName = "Sarah Abbett",
                State = "MN",
                TaxRate = 10m,
                ProductType = "Wood",
                Area = 1000,
                CostPerSquareFoot = 1,
                LaborCostPerSquareFoot = 1
            };

            repo.AddOrder(newOrder, orderDate);

            Assert.AreEqual(2, newOrder.OrderNumber);
            Assert.AreEqual(1000, newOrder.MaterialCost);
        }
        [Test]
        public void CannotLoadOrderNumberNotFound()
        {
            DateTime orderDate = new DateTime(2013, 06, 01);
            int orderNumber = 2;

            FileOrderRepository repo = new FileOrderRepository(_filepathWithoutExtension);

            var order = repo.LoadOrder(orderNumber, orderDate);

            Assert.IsNull(order);
        }
        [Test]
        public void CannotLoadOrdersByDateNotFound()
        {
            DateTime orderDate = new DateTime(2020, 06, 01);

            FileOrderRepository repo = new FileOrderRepository(_filepathWithoutExtension);

            var orders = repo.LoadOrders(orderDate);

            Assert.IsEmpty(orders);
        }
    }
}
