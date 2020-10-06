using SWC_Flooring.BLL;
using SWC_Flooring.Models;
using SWC_Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.UI.Workflows
{
    public class OrderAddWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order newOrder = new Order();

            Console.Clear();
            Console.WriteLine("Add an Order");
            Console.WriteLine(ConsoleIO.SeparatorBar);

            newOrder.OrderDate = ConsoleIO.GetRequiredFutureDateFromUser("Enter an order date: ");
            newOrder.CustomerName = ConsoleIO.GetRequiredStringFromUser("Enter the customer name: ");

            TaxesResponse taxesResponse = manager.LookupTaxes();
            ConsoleIO.DisplayTaxRates(taxesResponse.Taxes);

            int input = ConsoleIO.GetRequiredIntFromUser($"Please make a selection: ");

            Tax thisTax = taxesResponse.Taxes.ElementAt(input - 1);
            newOrder.TaxRate = thisTax.TaxRate;
            newOrder.State = thisTax.StateName;

            ProductsResponse productsResponse = manager.LookupProducts();
            ConsoleIO.DisplayProducts(productsResponse.Products);

            int choice = ConsoleIO.GetRequiredIntFromUser("Please make a selection: ");
            Product thisProduct = productsResponse.Products.ElementAt(choice - 1);
            
            newOrder.ProductType = thisProduct.ProductType;
            newOrder.CostPerSquareFoot = thisProduct.CostPerSquareFoot;
            newOrder.LaborCostPerSquareFoot = thisProduct.LaborCostPerSquareFoot;

            newOrder.Area = ConsoleIO.GetRequiredAreaFromUser("Enter the area (minimum 100sq.ft.): ");

            ConsoleIO.DisplayOrder(newOrder);

            if (ConsoleIO.GetYesNoAnswerFromUser("Add the following order") == "Y")
            {
                OrderResponse orderResponse = manager.AddOrder(newOrder, newOrder.OrderDate);
                if (orderResponse.Success)
                {
                    Console.WriteLine("Order number {0} added to file.", newOrder.OrderNumber);
                }
                else
                {
                    Console.WriteLine("An error occured: ");
                    Console.WriteLine(orderResponse.Message);
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Add Cancelled");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
