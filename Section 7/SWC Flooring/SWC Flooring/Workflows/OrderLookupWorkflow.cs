using SWC_Flooring.BLL;
using SWC_Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.UI.Workflows
{
    public class OrderLookupWorkflow
    {   
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookup Orders by Date");
            Console.WriteLine(ConsoleIO.SeparatorBar);

            DateTime date = ConsoleIO.GetRequiredDateFromUser("Enter an order date: ");
            
            OrdersResponse response = manager.LookupOrders(date);

            if (response.Success)
            {
                ConsoleIO.DisplayOrders(response.Orders);
            }
            else
            {
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
