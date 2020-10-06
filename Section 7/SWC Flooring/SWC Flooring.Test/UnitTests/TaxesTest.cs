using NUnit.Framework;
using SWC_Flooring.BLL;
using SWC_Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.Test
{
    [TestFixture]
    public class TaxesTest
    {
        [Test]
        public void CanLoadTaxTestData()
        {
            OrderManager manager = OrderManagerFactory.Create();
            TaxesResponse response = manager.LookupTaxes();

            Assert.AreEqual(response.Taxes.Count, 3);
            Assert.AreEqual(response.Taxes.ElementAtOrDefault(1).StateName, "Texas");
            Assert.IsTrue(response.Success);
        }
    }
}
