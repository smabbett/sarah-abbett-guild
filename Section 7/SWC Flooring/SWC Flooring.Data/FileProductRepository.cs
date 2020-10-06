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
    public class FileProductRepository : IProductRepository
    {
        private string _filepath;

        public FileProductRepository(string filepath)
        {
            _filepath = filepath;

            if (!File.Exists(_filepath))
            {
                string[] header = new string[]
                {
                    "ProductType,CostPerSquareFoot,LaborCostPerSquareFoot"
                };
                File.AppendAllLines(_filepath, header);
            }
        }
        public List<Product> LoadProducts()
        {
            List<Product> products = new List<Product>();

            using (StreamReader sr = new StreamReader(_filepath))
            {
                sr.ReadLine();
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    Product product = new Product()
                    {
                        ProductType = columns[0],
                        CostPerSquareFoot = decimal.Parse(columns[1]),
                        LaborCostPerSquareFoot = decimal.Parse(columns[2]),
                    };
                    products.Add(product);
                }
            }
            return products;
        }
    }
}
