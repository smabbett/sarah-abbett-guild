using _03_05_01_SystemIO.Helpers;
using _03_05_01_SystemIO.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_05_01_SystemIO
{
    public class MainMenu
    {
        

        private static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Management System");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("1. List Students");
            Console.WriteLine("2. Add Student");
            Console.WriteLine("3. Remove Student");
            Console.WriteLine("4. Edit Student GPA");
            Console.WriteLine("5. Edit Student Credit Hours");
            Console.WriteLine("");
            Console.WriteLine("Q - Quit");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine("");
            Console.Write("Enter choice: ");
        }

        private static bool ProcessChoice()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ListStudentWorkflow listWorkflow = new ListStudentWorkflow();
                    listWorkflow.Execute();
                    break;
                case "2":
                    AddStudentWorkflow addWorkflow = new AddStudentWorkflow();
                    addWorkflow.Execute();
                    break;
                case "3":
                    RemoveStudentWorkflow removeWorkflow = new RemoveStudentWorkflow();
                    removeWorkflow.Execute();
                    break;
                case "4":
                    EditGPAWorkflow editWorkflow = new EditGPAWorkflow();
                    editWorkflow.Execute();
                    break;
                case "5":
                    EditCreditHoursWorkflow editCreditHours = new EditCreditHoursWorkflow();
                    editCreditHours.Execute();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("That is not a valid choice.  Press any key to continue...");
                    Console.ReadKey();
                    break;
            }

            return true;
        }

        public static void Show()
        {
            bool continueRunning = true;
            while(continueRunning)
            {
                DisplayMenu();
                continueRunning = ProcessChoice();
            }
        }
    }
}
