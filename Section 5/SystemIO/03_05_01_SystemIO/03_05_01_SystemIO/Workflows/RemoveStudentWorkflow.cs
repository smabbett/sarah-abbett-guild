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
    public class RemoveStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Remove Student");

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
            int index = ConsoleIO.GetStudentIndexFromUser("Which student would you like to delete? ", students.Count());
            index--;

            string answer = ConsoleIO.GetYesNoAnswerFromUser($"Are you sure you want to remove {students[index].FirstName} {students[index].LastName}");

                if (answer == "Y")
                {
                    repo.Delete(index);
                    Console.WriteLine("Student Removed!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Remove cancelled.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
            }
        }
    }
}
