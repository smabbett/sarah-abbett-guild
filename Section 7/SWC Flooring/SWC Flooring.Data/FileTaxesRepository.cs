using SWC_Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWC_Flooring.Models;
using System.IO;

namespace SWC_Flooring.Data
{
    public class FileTaxesRepository : ITaxesRepository
    {
        private string _filepath;

        public FileTaxesRepository(string filepath)
        {
            _filepath = filepath;

            if (!File.Exists(_filepath))
            {
                string[] header = new string[]
                {
                    "StateAbbreviation,StateName,TaxRate"
                };
                File.AppendAllLines(_filepath, header);
            }
        }
        public Tax LoadTax(string stateAbbreviation)
        {
            var taxes = LoadTaxes();
            var tax = taxes.Find(x => x.StateAbbreviation == stateAbbreviation);
            return tax;
        }

        public List<Tax> LoadTaxes()
        {
            List<Tax> taxes = new List<Tax>();

            using (StreamReader sr = new StreamReader(_filepath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    Tax tax = new Tax()
                    {
                        StateAbbreviation = columns[0],
                        StateName = columns[1],
                        TaxRate = decimal.Parse(columns[2]),                     
                    };
                    taxes.Add(tax);
                }
            }
            return taxes;
        }
    }
}
