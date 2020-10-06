using NUnit.Framework;
using SWC_Flooring.BLL;
using SWC_Flooring.Data;
using SWC_Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.Test
{
    [TestFixture]
    class ProductTest
    {
        [Test]
        public void CanLoadProductTestData()
        {
            OrderManager manager = OrderManagerFactory.Create();
            ProductsResponse response = manager.LookupProducts();

            Assert.AreEqual(response.Products.Count, 3);
            Assert.AreEqual("Laminate", response.Products[0].ProductType);
            Assert.AreEqual(1.25M, response.Products[0].CostPerSquareFoot);
            Assert.AreEqual(1.30M, response.Products[0].LaborCostPerSquareFoot);
        }
    }
}
