using SWC_Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWC_Flooring.Models;

namespace SWC_Flooring.Data
{
    public class TaxesTestRepository : ITaxesRepository
    {
        private static Tax _tax = new Tax()
        {
            StateAbbreviation = "MN",
            StateName = "Minnesota",
            TaxRate = 6.875M
        };
        private static Tax _tax2 = new Tax()
        {
            StateAbbreviation = "TX",
            StateName = "Texas",
            TaxRate = 7.5M
        };
        private static Tax _tax3 = new Tax()
        {
            StateAbbreviation = "CO",
            StateName = "Colorado",
            TaxRate = 7.0M
        };


        public Tax LoadTax(string stateAbbreviation)
        {
            List<Tax> taxes = new List<Tax>();
            taxes.Add(_tax);
            taxes.Add(_tax2);
            var tax = taxes.Find(x => x.StateAbbreviation == stateAbbreviation);
            return tax;

        }
        public List<Tax> LoadTaxes()
        {
            List<Tax> taxes = new List<Tax>();
            taxes.Add(_tax);
            taxes.Add(_tax2);
            taxes.Add(_tax3);
            return taxes;

        }
    }
}

