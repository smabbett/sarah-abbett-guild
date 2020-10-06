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
    public class TaxFileTest
    {
        [Test]
        public void CanLoadTaxFileData()
        {
            string _filepath = ConfigurationManager.AppSettings["taxesFilepath"].ToString();
            FileTaxesRepository repo = new FileTaxesRepository(_filepath);

            List<Tax> taxes = repo.LoadTaxes();

            Assert.AreEqual("OH", taxes[0].StateAbbreviation);
            Assert.AreEqual("Ohio", taxes[0].StateName);
            Assert.AreEqual(6.25, taxes[0].TaxRate);
            Assert.AreEqual(4, taxes.Count);
        }
    }
}
