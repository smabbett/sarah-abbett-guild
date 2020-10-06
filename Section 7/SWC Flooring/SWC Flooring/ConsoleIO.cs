using SWC_Flooring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.UI
{
    public class ConsoleIO
    {
        public const string SeparatorBar = "**************************************************************";
        public const string OrderDisplayFormat = "{0,-30}|{1,30}";

        public static void DisplayOrders(List<Order> orders)
        {
            Console.Clear();
            foreach (Order o in orders)
            {
                Console.WriteLine(ConsoleIO.SeparatorBar);               
                Console.WriteLine(OrderDisplayFormat, $"Order Number: {o.OrderNumber}", $"Order Date: {o.OrderDate:MMMM d, yyyy}");
                Console.WriteLine(OrderDisplayFormat, $"", $"");
                Console.WriteLine(OrderDisplayFormat, $"", $"");
                Console.WriteLine(OrderDisplayFormat, $"Customer Name: {o.CustomerName}", $"Material Cost: {o.MaterialCost:c}");        
                Console.WriteLine(OrderDisplayFormat, $" ", $"Labor Cost: {o.LaborCost:c}");
                Console.WriteLine(OrderDisplayFormat, $"State: {o.State} ", $"Tax: {o.Tax:c}");
                Console.WriteLine(OrderDisplayFormat, $"Product Type: {o.ProductType}", $"Total: {o.Total:c}");
                Console.WriteLine();
            }
        }

        public static string GetOptionalStringFromUser(string prompt, string customerName)
        {          
                string pattern = @"[^A-Za-z0-9., ]";

                while (true)
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();

                    if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
                    {
                        Console.WriteLine("Customer name may contain the following characters: A-Z, a-z, 0-9, [,.] ");
                    }
                    else if (string.IsNullOrEmpty(input))
                    {
                    return customerName;
                    }
                    else
                    {
                        return input;
                    }
                }
            }

        public static int GetRequiredIntFromUser(string prompt)
        {
            int output;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return output;
                }
            }
        }

        public static int GetOptionalIntFromUser(string prompt)
        {
            int output;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input.Length <= 0)
                {
                    return 0;
                }

                if (!int.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid number.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return output;
                }
            }
        }
        public static void DisplayOrder(Order order)
        {    
            Console.Clear();
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine(OrderDisplayFormat, $" ", $"Order Date: {order.OrderDate:MMMM d, yyyy}");
            Console.WriteLine(OrderDisplayFormat, $"",$"");
            Console.WriteLine(OrderDisplayFormat, $"",$"");
            Console.WriteLine(OrderDisplayFormat, $"Customer Name: {order.CustomerName}",$"Material Cost: {order.MaterialCost:c}");
            Console.WriteLine(OrderDisplayFormat, $" ", $"Labor Cost: {order.LaborCost:c}");
            Console.WriteLine(OrderDisplayFormat, $"State: {order.State} ", $"Tax: {order.Tax:c}");
            Console.WriteLine(OrderDisplayFormat, $"Product Type: {order.ProductType}", $"Total: {order.Total:c}");
            Console.WriteLine();
        }
       
        public static void DisplayProducts(List<Product> products)
        {
            int counter = 0;
            Console.Clear();
            Console.WriteLine("List of Products");
            Console.WriteLine(SeparatorBar);
            foreach (Product p in products)
            {
                counter += 1;
                Console.WriteLine($"{counter}. Product Name: {p.ProductType}");
                Console.WriteLine($"   Cost Per Square Foot: {p.CostPerSquareFoot}");
                Console.WriteLine($"   Labor Cost Per Square Foot: {p.LaborCostPerSquareFoot}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine(ConsoleIO.SeparatorBar);
        }
      
        public static void DisplayTaxRates(List<Tax> taxes)
        {
            int counter = 0;
            Console.Clear();
            Console.WriteLine("List of Taxable States");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            foreach (Tax t in taxes)
            {
                counter += 1;
                Console.WriteLine($"{counter}. {t.StateName }");
            }
            Console.WriteLine();
            Console.WriteLine(ConsoleIO.SeparatorBar);
        }

        public static decimal GetRequiredAreaFromUser(string prompt)
        {
            Console.Clear();
            decimal output;

            

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid decimal.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (output < 100)
                {
                    Console.WriteLine("Minimum order size is 100 sq.ft.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return output;
                }
            }
        }

        public static decimal GetOptionalAreaFromUser(string prompt,decimal area)
        {
            Console.Clear();
            decimal output;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (input.Length == 0)
                {
                    return area;
                }
                else if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid decimal.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (output < 100)
                {
                    Console.WriteLine("Minimum order size is 100 sq.ft.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return output;
                }
            }
        }
        public static string GetRequiredStringFromUser(string prompt)
        {          
            string pattern = @"[^A-Za-z0-9., ]";
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
                {
                    Console.WriteLine("Customer name may contain the following characters: A-Z, a-z, 0-9, [,.] ");
                }
                else if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }
        public static decimal GetRequiredDecimalFromUser(string prompt)
        {
            decimal output;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(input, out output))
                {
                    Console.WriteLine("You must enter valid decimal.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return output;
                }
            }
        }
        public static DateTime GetRequiredFutureDateFromUser(string prompt)
        {
            DateTime date;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!DateTime.TryParse(input, out date))
                {
                    Console.WriteLine("You must enter a valid date.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else if (date < DateTime.Now)
                {
                    Console.WriteLine("You must enter a future date.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return date;
                }
            }
        }
        public static DateTime GetRequiredDateFromUser(string prompt)
        {
            DateTime date;

            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (!DateTime.TryParse(input, out date))
                {
                    Console.WriteLine("You must enter a valid date.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return date;
                }
            }
        }
        public static string GetYesNoAnswerFromUser(string prompt)
        {
            while (true)
            {
                Console.Write(prompt + " (Y/N)? ");
                string input = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }

                    return input;
                }
            }
        }
    }
}
