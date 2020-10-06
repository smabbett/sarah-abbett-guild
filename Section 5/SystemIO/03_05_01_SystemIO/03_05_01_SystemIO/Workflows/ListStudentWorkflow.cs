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
    public class ListStudentWorkflow
    {
        public void Execute()
        {
            StudentRepository repo = new StudentRepository(Settings.FilePath);
            List<Student> students = repo.List();

            Console.Clear();
            Console.WriteLine("Student List");
            ConsoleIO.PrintStudentListHeader();

            if (students.Count == 0)
            {
                Console.WriteLine("There are no student names stored in the file.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {             
                foreach (var student in students)
                {
                    Console.WriteLine(ConsoleIO.StudentLineFormat, student.LastName + ", " + student.FirstName, student.Major, student.GPA, student.CreditHours);
                }

                Console.WriteLine();
                Console.WriteLine(ConsoleIO.SeparatorBar);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
