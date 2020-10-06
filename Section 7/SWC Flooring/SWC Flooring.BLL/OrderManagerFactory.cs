using SWC_Flooring.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.BLL
{
    public static class OrderManagerFactory
    {
        public static OrderManager Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Test":
                    return new OrderManager(new OrderTestRepository(), new ProductTestRepository(), new TaxesTestRepository());
                case "Prod":
                    string orderFilepath = ConfigurationManager.AppSettings["orderFilepath"].ToString();
                    string productFilepath = ConfigurationManager.AppSettings["productFilepath"].ToString();
                    string taxesFilepath = ConfigurationManager.AppSettings["taxesFilepath"].ToString();
                    return new OrderManager(new FileOrderRepository(orderFilepath), new FileProductRepository(productFilepath), new FileTaxesRepository(taxesFilepath));
                default:
                    throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
