using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {

        static void Main()
        {
            SelectExercises();
            //PrintAllProducts();
            //PrintAllCustomers();
        }

        private static void SelectExercises()
        {         
            do
            {
                Console.WriteLine("Enter the exercise number to run (1-31) ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Exercise1();
                        break;
                    case "2":
                        Exercise2();
                        break;
                    case "3":
                        Exercise3();
                        break;
                    case "4":
                        Exercise4();
                        break;
                    case "5":
                        Exercise5();
                        break;
                    case "6":
                        Exercise6();
                        break;
                    case "7":
                        Exercise7();
                        break;
                    case "8":
                        Exercise8();
                        break;
                    case "9":
                        Exercise9();
                        break;
                    case "10":
                        Exercise10();
                        break;
                    case "11":
                        Exercise11();
                        break;
                    case "12":
                        Exercise12();
                        break;
                    case "13":
                        Exercise13();
                        break;
                    case "14":
                        Exercise14();
                        break;
                    case "15":
                        Exercise15();
                        break;
                    case "16":
                        Exercise16();
                        break;
                    case "17":
                        Exercise17();
                        break;
                    case "18":
                        Exercise18();
                        break;
                    case "19":
                        Exercise19();
                        break;
                    case "20":
                        Exercise20();
                        break;
                    case "21":
                        Exercise21();
                        break;
                    case "22":
                        Exercise22();
                        break;
                    case "23":
                        Exercise23();
                        break;
                    case "24":
                        Exercise24();
                        break;
                    case "25":
                        Exercise25();
                        break;
                    case "26":
                        Exercise26();
                        break;
                    case "27":
                        Exercise27();
                        break;
                    case "28":
                        Exercise28();
                        break;
                    case "29":
                        Exercise29();
                        break;
                    case "30":
                        Exercise30();
                        break;
                    case "31":
                        Exercise31();
                        break;                    
                    default:
                        Console.WriteLine("That is not a valid entry. Please try again.");
                        continue;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (true);
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,8:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadLine();
        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
            //Console.WriteLine("Press any key to continue...");
            //Console.ReadLine();
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();
            var outOfStock = from product in products
                             where product.UnitsInStock == 0
                             select product;
            PrintProductInformation(outOfStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();
            var overThree = from product in products
                            where product.UnitsInStock >= 1 && product.UnitPrice > 3.00M
                            select product;
            PrintProductInformation(overThree);

        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var customers = DataLoader.LoadCustomers();
            var waCustomers = from customer in customers
                              where customer.Region == "WA"
                              select customer;
            PrintCustomerInformation(waCustomers);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            List<Product> products = DataLoader.LoadProducts();
            var result = from product in products
                         select new
                         {
                             productName = product.ProductName,
                         };
            foreach (var row in result)
            {
                Console.WriteLine("{0}", row.productName);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> products = DataLoader.LoadProducts();
            var result = from product in products
                         select new
                         {
                             productName = product.ProductName,
                             productPrice = (product.UnitPrice) * 1.25M,
                             productStock = product.UnitsInStock,
                             productID = product.ProductID,
                             productCategory = product.Category
                         };

            string line = "{0,-5} {1,-35} {2,-15} {3,8:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in result)
            {
                Console.WriteLine(line, product.productID, product.productName, product.productCategory,
                    product.productPrice, product.productStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {
            List<Product> products = DataLoader.LoadProducts();
            var result = from product in products
                         select new
                         {
                             productName = product.ProductName,
                             productCategory = product.Category
                         };

            string line = " {0,-35} {1,-15} ";
            Console.WriteLine(line, "Product Name", "Category");
            Console.WriteLine("================================================");

            foreach (var product in result)
            {
                Console.WriteLine(line, product.productName.ToUpper(), product.productCategory.ToUpper());
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {

            List<Product> products = DataLoader.LoadProducts();

            var result = from product in products
                         select new
                         {
                             productName = product.ProductName,
                             productPrice = (product.UnitPrice),
                             productStock = product.UnitsInStock,
                             productID = product.ProductID,
                             productCategory = product.Category,
                             reorder = (product.UnitsInStock < 3)

                         };

            string line = "{0,-5} {1,-35} {2,-15} {3,8:c} {4,6} {5,8}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "ReOrder");
            Console.WriteLine("=================================================================================");

            foreach (var product in result)
            {

                Console.WriteLine(line, product.productID, product.productName, product.productCategory,
                    product.productPrice, product.productStock, product.reorder);

            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> products = DataLoader.LoadProducts();

            var result = from product in products
                         select new
                         {
                             productName = product.ProductName,
                             productPrice = (product.UnitPrice),
                             productStock = product.UnitsInStock,
                             productID = product.ProductID,
                             productCategory = product.Category,
                             stockValue = (product.UnitsInStock * product.UnitPrice)

                         };

            string line = "{0,-5} {1,-35} {2,-15} {3,8:c} {4,6} {5,10:c}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Stock Value");
            Console.WriteLine("====================================================================================");

            foreach (var product in result)
            {

                Console.WriteLine(line, product.productID, product.productName, product.productCategory,
                    product.productPrice, product.productStock, product.stockValue);

            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            int[] allNumbers = DataLoader.NumbersA;

            var onlyEvens = from number in allNumbers
                            where number % 2 != 1
                            select number;
            foreach (var even in onlyEvens)
            {
                Console.Write($"{even} ");
            }

        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var customers = DataLoader.LoadCustomers();
            var underfive = from customer in customers
                            where customer.Orders.Count(order => order.Total < 500.00M) > 0
                            select customer;

            PrintCustomerInformation(underfive);
        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            int[] allNumbers = DataLoader.NumbersC;
            var onlyOdds = from number in allNumbers
                           where number % 2 == 1
                           select number;
            for (int i = 0; i < 3; i++)
            {
                int odd = onlyOdds.ElementAt(i);
                Console.Write($"{odd} ");
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            int[] allNumbers = DataLoader.NumbersB;
            var lessthree = allNumbers.Skip(3);
            foreach (var number in lessthree)
            {
                Console.Write($"{number} ");
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var customers = DataLoader.LoadCustomers();
            var waCustomers = from customer in customers
                              where customer.Region == "WA"
                              select customer;
            foreach (var customer in waCustomers)
            {
                Console.Write($"{customer.CompanyName} ");
                Console.WriteLine();
                var last = customer.Orders.Last();
                Console.WriteLine("{0} {1:MM-dd-yyyy} {2,10:c}", last.OrderID, last.OrderDate, last.Total);
                Console.WriteLine();

            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            int[] allNumbers = DataLoader.NumbersC;

            var untilsix = allNumbers.TakeWhile(number => !number.Equals(6));
            foreach (var number in untilsix)
            {
                Console.Write($"{number} ");
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            int[] allNumbers = DataLoader.NumbersC;

            var bythree = allNumbers.TakeWhile(number => number % 3 != 0);
            foreach (var number in bythree)
            {
                Console.Write($"{number} ");
            }
        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts();
            var alphabetical = from product in products
                               orderby product.ProductName
                               select product;

            PrintProductInformation(alphabetical);
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();
            var descending = from product in products
                             orderby product.UnitsInStock descending
                             select product;

            PrintProductInformation(descending);
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();
            var byprice = products.OrderBy(p => p.Category).ThenBy(p => p.UnitPrice);

            PrintProductInformation(byprice);
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            int[] allNumbers = DataLoader.NumbersB;
            var reverse = allNumbers.Reverse();
            foreach (var number in reverse)
            {
                Console.Write($"{number} ");
            }
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> products = DataLoader.LoadProducts();
            var bycategory = products.OrderBy(p => p.ProductName).GroupBy(p => p.Category);

            foreach (var p in bycategory)
            {
                Console.WriteLine(p.Key);

                foreach (var c in p)
                {
                    Console.WriteLine("\t{0}", c.ProductName);
                }
            }
        }

        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            var customers = DataLoader.LoadCustomers();
            foreach (var c in customers)
            {
                Console.WriteLine($"{c.CompanyName}");
                var byyear = c.Orders.GroupBy(o => o.OrderDate.Year);

                foreach (var order in byyear)
                {
                    Console.WriteLine($"{order.Key}");
                    var monthly = order.GroupBy(o => o.OrderDate.Month);
                    foreach (var monthorder in monthly)
                    {
                        Console.WriteLine($"\t{monthorder.First().OrderDate:MMMM}");
                        foreach (var o in monthorder)
                        {
                            Console.WriteLine($"\t\t  {o.Total}");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> products = DataLoader.LoadProducts();
            var bycategory = products.GroupBy(p => p.Category);

            foreach (var p in bycategory)
            {
                Console.WriteLine(p.Key);
            }
        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> products = DataLoader.LoadProducts();
            var locator = products.Find(p => p.ProductID == 789);
            if (locator != null)
            {
                Console.WriteLine($"Product Name: {locator.ProductName}, Product ID: {locator.ProductID}");
            }
            else
            {
                Console.WriteLine($"That product ID does not exist");
            }
        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> products = DataLoader.LoadProducts();
            var outOfStock = products.Where(p => p.UnitsInStock == 0).GroupBy(p => p.Category);

            foreach (var p in outOfStock)
            {
                Console.WriteLine(p.Key);
            }
        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            List<Product> products = DataLoader.LoadProducts();
            
            var bycategory = products.GroupBy(p => p.Category).Where(c => c.All(p => p.UnitsInStock > 0));

            foreach (var p in bycategory)
            {
                Console.WriteLine(p.Key);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int[] allNumbers = DataLoader.NumbersA;
            var oddOnly = allNumbers.Count(n => n % 2 == 1);
            Console.WriteLine($"{oddOnly} ");
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customers = DataLoader.LoadCustomers();
            var result = from customer in customers
                         select new
                         {
                             CustomerID = customer.CustomerID,
                             count = customer.Orders.Count()
                         };
            foreach (var c in result)
            {
                Console.WriteLine($"Customer ID: {c.CustomerID}\tOrder Count: {c.count}");
            }        
        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            List<Product> products = DataLoader.LoadProducts();
            var bycategory = products.GroupBy(p => p.Category);
            foreach (var c in bycategory)
            {
                var count = c.Count();
                Console.WriteLine(c.Key);
                Console.WriteLine($"Product Count: {count}");
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            List<Product> products = DataLoader.LoadProducts();
            var bycategory = products.GroupBy(p => p.Category);
            foreach (var c in bycategory)
            {
                var sum = c.Sum(p => p.UnitsInStock);
                Console.WriteLine(c.Key);
                Console.WriteLine($"Product Count: {sum}");
            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            List<Product> products = DataLoader.LoadProducts();
            var bycategory = products.OrderBy(p => p.UnitPrice).GroupBy(p => p.Category);

            foreach(var c in bycategory)
            {
                Console.WriteLine($"Category: {c.Key}");
                Console.WriteLine($"Lowest Priced Item: {c.First().ProductName}");
            }
        }

        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            List<Product> products = DataLoader.LoadProducts();
            
            var bycategory = products.GroupBy(p => p.Category).OrderByDescending(c => c.Average(p => p.UnitPrice) ).Take(3);
            foreach (var c in bycategory)
            {
                Console.WriteLine(c.Key);
                Console.WriteLine($"Average Unit Price: {c.Average(p => p.UnitPrice):C}");
            }
        }


    }
}
