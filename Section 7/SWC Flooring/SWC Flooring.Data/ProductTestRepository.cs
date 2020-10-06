using SWC_Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWC_Flooring.Models;

namespace SWC_Flooring.Data
{
    public class ProductTestRepository : IProductRepository
    {
        private static Product _product = new Product()
        {
            ProductType = "Laminate",
            CostPerSquareFoot = 1.25M,
            LaborCostPerSquareFoot = 1.30M
        };
        private static Product _product2 = new Product()
        {
            ProductType = "Wood",
            CostPerSquareFoot = 3.25M,
            LaborCostPerSquareFoot = 1.50M
        };
        private static Product _product3 = new Product()
        {
            ProductType = "Pergo",
            CostPerSquareFoot = 1.00M,
            LaborCostPerSquareFoot = 1.00M
        };

        public List<Product> LoadProducts()
        {
            List<Product> products = new List<Product>();

            products.Add(_product);
            products.Add(_product2);
            products.Add(_product3);

            return products;
        }
    }
}
