using _03_05_01_SystemIO.Data;
using _03_05_01_SystemIO.Helpers;
using _03_05_01_SystemIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_05_01_SystemIO.Workflows
{
    class EditCreditHoursWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            StudentRepository repo = new StudentRepository(Settings.FilePath);
            List<Student> students = repo.List();

            ConsoleIO.PrintPickListOfStudents(students);
            Console.WriteLine();

            if (students.Count == 0)
            {
                Console.WriteLine("There are no student names stored in the file.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                int index = ConsoleIO.GetStudentIndexFromUser("Which student would you like to edit? ", students.Count());
                index--;

                Console.WriteLine();

                students[index].CreditHours = ConsoleIO.GetRequiredIntFromUser(string.Format("Enter new Credit Hours for {0} {1}: ", students[index].FirstName,
                    students[index].LastName));

                repo.Edit(students[index], index);
                Console.WriteLine("Credit Hours updated!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
