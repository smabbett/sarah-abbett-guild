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
    public class OrderDeleteWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Delete Order");
            Console.WriteLine(ConsoleIO.SeparatorBar);

            DateTime orderDate = ConsoleIO.GetRequiredDateFromUser("Enter an order date: ");
            int orderNumber = ConsoleIO.GetRequiredIntFromUser("Enter the order number: ");
            OrderResponse orderResponse = manager.LookupOrder(orderNumber, orderDate);
            if (!orderResponse.Success)
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(orderResponse.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Order orderToDelete = orderResponse.order;

                ConsoleIO.DisplayOrder(orderToDelete);

                if (ConsoleIO.GetYesNoAnswerFromUser("Delete the following order") == "Y")
                {
                    Response response = manager.DeleteOrder(orderNumber, orderDate);
                    if (response.Success)
                    {
                        Console.WriteLine("Order number {0} has been deleted.", orderNumber);
                    }
                    else
                    {
                        Console.WriteLine(response.Message);
                    }      
                }
                else
                {
                    Console.WriteLine("Delete Cancelled.");
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }         
        }
    }
}

