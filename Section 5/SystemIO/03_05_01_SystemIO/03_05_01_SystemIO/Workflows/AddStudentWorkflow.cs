﻿using _03_05_01_SystemIO.Data;
using _03_05_01_SystemIO.Helpers;
using _03_05_01_SystemIO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_05_01_SystemIO.Workflows
{
    public class AddStudentWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("Add Student");
            Console.WriteLine(ConsoleIO.SeparatorBar);
            Console.WriteLine();

            Student newStudent = new Student();

            newStudent.FirstName = ConsoleIO.GetRequiredStringFromUser("First Name: ");
            newStudent.LastName = ConsoleIO.GetRequiredStringFromUser("Last Name: ");
            newStudent.Major = ConsoleIO.GetRequiredStringFromUser("Major: ");
            newStudent.GPA = ConsoleIO.GetRequiredDecimalFromUser("GPA: ");
            newStudent.CreditHours = ConsoleIO.GetRequiredIntFromUser("Credit Hours: ");

            Console.WriteLine();
            ConsoleIO.PrintStudentListHeader();
            Console.WriteLine(ConsoleIO.StudentLineFormat, newStudent.LastName + ", " + newStudent.FirstName, newStudent.Major, newStudent.GPA, newStudent.CreditHours);

            Console.WriteLine();
            if(ConsoleIO.GetYesNoAnswerFromUser("Add the following information") == "Y")
            {
                StudentRepository repo = new StudentRepository(Settings.FilePath);
                repo.Add(newStudent);
                Console.WriteLine("Student Added!");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Add Cancelled");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
