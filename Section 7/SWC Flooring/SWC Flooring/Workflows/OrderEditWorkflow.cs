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
    public class OrderEditWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Edit an Order");
            Console.WriteLine(ConsoleIO.SeparatorBar);

            DateTime orderDate = ConsoleIO.GetRequiredDateFromUser("Enter the order date: ");
            int orderNumber = ConsoleIO.GetRequiredIntFromUser("Enter the order number: ");
            OrderResponse response = manager.LookupOrder(orderNumber, orderDate);

            if (!response.Success)
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(response.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Order orderToEdit = response.order;
                orderToEdit.CustomerName = ConsoleIO.GetOptionalStringFromUser($"Enter the customer name ({orderToEdit.CustomerName}): ", orderToEdit.CustomerName);

                TaxesResponse taxResponse = manager.LookupTaxes();
                ConsoleIO.DisplayTaxRates(taxResponse.Taxes);

                int input = ConsoleIO.GetOptionalIntFromUser($"Please make a selection ({orderToEdit.State}): ");
                if(input > 0)
                {
                    Tax thisTax = taxResponse.Taxes.ElementAt(input - 1);
                    orderToEdit.TaxRate = thisTax.TaxRate;
                    orderToEdit.State = thisTax.StateName;
                }
                

                ProductsResponse productsresponse = manager.LookupProducts();
                ConsoleIO.DisplayProducts(productsresponse.Products);

                int choice = ConsoleIO.GetOptionalIntFromUser($"Please make a selection ({orderToEdit.ProductType}): ");
                if (choice > 0)
                {
                    Product thisProduct = productsresponse.Products.ElementAt(choice - 1);
                    orderToEdit.ProductType = thisProduct.ProductType;
                    orderToEdit.CostPerSquareFoot = thisProduct.CostPerSquareFoot;
                    orderToEdit.LaborCostPerSquareFoot = thisProduct.LaborCostPerSquareFoot;
                }
                

                orderToEdit.Area = ConsoleIO.GetOptionalAreaFromUser($"Enter the area ({orderToEdit.Area}): ", orderToEdit.Area);

                ConsoleIO.DisplayOrder(orderToEdit);

                if (ConsoleIO.GetYesNoAnswerFromUser("Edit the following order") == "Y")
                {
                    OrderResponse orderResponse = manager.EditOrder(orderToEdit, orderDate);
                    if (response.Success)
                    {
                        Console.WriteLine("Order number {0} has been edited.", orderToEdit.OrderNumber);
                    }
                    else
                    {
                        Console.WriteLine(orderResponse.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Edit Cancelled.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
