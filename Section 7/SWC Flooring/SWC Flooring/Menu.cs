﻿using SWC_Flooring.UI.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.UI
{
    public class Menu
    {
        public static void Start()
        {
            while (true)
            {
                Console.Clear();               
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine("SWC Flooring Program");
                Console.WriteLine();
                Console.WriteLine("1. Display Orders By Date");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");
                Console.WriteLine("5. Quit");
                Console.WriteLine();
                Console.WriteLine(ConsoleIO.SeparatorBar);

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        OrderLookupWorkflow lookupWorkflow = new OrderLookupWorkflow();
                        lookupWorkflow.Execute();
                        break;
                    case "2":
                        OrderAddWorkflow addWorkflow = new OrderAddWorkflow();
                        addWorkflow.Execute();
                        break;
                    case "3":
                        OrderEditWorkflow editWorkflow = new OrderEditWorkflow();
                        editWorkflow.Execute();
                        break;
                    case "4":
                        OrderDeleteWorkflow deleteWorkflow = new OrderDeleteWorkflow();
                        deleteWorkflow.Execute();
                        break;
                    case "5":
                        return;      
                }


            }
        }
    }
}
