using NUnit.Framework;
using SWC_Flooring.Data;
using SWC_Flooring.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.Test.IntegrationTests
{
    [TestFixture]
    class ProductFileTest
    {
        [Test]
        public void CanLoadProductFileData()
        {
            string _filepath = ConfigurationManager.AppSettings["productFilepath"].ToString();
            FileProductRepository repo = new FileProductRepository(_filepath);

            List<Product> products = repo.LoadProducts();

            Assert.AreEqual("Carpet", products[0].ProductType);
            Assert.AreEqual(2.25, products[0].CostPerSquareFoot);
            Assert.AreEqual(2.10, products[0].LaborCostPerSquareFoot);
            Assert.AreEqual(4, products.Count);
        }
    }
}
