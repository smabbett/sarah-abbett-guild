﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using _03_05_01_SystemIO.Data;
using _03_05_01_SystemIO.Models;
using System.IO;

namespace SystemIO.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private const string _filePath = @"C:\Data\SystemIO\StudentTest.txt";
        private const string _originalData = @"C:\Data\SystemIO\StudentTestSeed.txt";

        [SetUp]
        public void Setup()
        {
            if(File.Exists(_filePath))
            {
                File.Delete(_filePath);
            }

            File.Copy(_originalData, _filePath);
        }

        [Test]
        public void CanReadDataFromFile()
        {
            StudentRepository repo = new StudentRepository(_filePath);

            List<Student> students = repo.List();

            Assert.AreEqual(4, students.Count());

            Student check = students[2];

            Assert.AreEqual("Jane", check.FirstName);
            Assert.AreEqual("Doe", check.LastName);
            Assert.AreEqual("Computer Science", check.Major);
            Assert.AreEqual(4.0M, check.GPA);
            Assert.AreEqual(400, check.CreditHours);
        }

        [Test]
        public void CanAddStudentToFile()
        {
            StudentRepository repo = new StudentRepository(_filePath);

            Student newStudent = new Student();
            newStudent.FirstName = "Testy";
            newStudent.LastName = "Tester";
            newStudent.Major = "Research";
            newStudent.GPA = 3.2M;
            newStudent.CreditHours = 800;

            repo.Add(newStudent);

            List<Student> students = repo.List();

            Assert.AreEqual(5, students.Count());

            Student check = students[4];

            Assert.AreEqual("Testy", check.FirstName);
            Assert.AreEqual("Tester", check.LastName);
            Assert.AreEqual("Research", check.Major);
            Assert.AreEqual(3.2M, check.GPA);
            Assert.AreEqual(800, check.CreditHours);
        }

        [Test]
        public void CanDeleteStudent()
        {
            StudentRepository repo = new StudentRepository(_filePath);
            repo.Delete(0);

            List<Student> students = repo.List();

            Assert.AreEqual(3, students.Count);

            Student check = students[0];

            Assert.AreEqual("Mary", check.FirstName);
            Assert.AreEqual("Jone", check.LastName);
            Assert.AreEqual("Business", check.Major);
            Assert.AreEqual(3.0M, check.GPA);
            Assert.AreEqual(350, check.CreditHours);
        }

        [Test]
        public void CanEditStudentGPA()
        {
            StudentRepository repo = new StudentRepository(_filePath);
            List<Student> students = repo.List();

            Student editedStudent = students[0];
            editedStudent.GPA = 3.0M;

            repo.Edit(editedStudent, 0);

            Assert.AreEqual(4, students.Count);

            students = repo.List();
            Student check = students[0];

            Assert.AreEqual("Joe", check.FirstName);
            Assert.AreEqual("Smith", check.LastName);
            Assert.AreEqual("Computer Science", check.Major);
            Assert.AreEqual(3.0M, check.GPA);
            Assert.AreEqual(300, check.CreditHours);
        }

        [Test]
        public void CanEditStudentCreditHours()
        {
            StudentRepository repo = new StudentRepository(_filePath);
            List<Student> students = repo.List();

            Student editedStudent = students[0];
            editedStudent.CreditHours = 800;

            repo.Edit(editedStudent, 0);

            Assert.AreEqual(4, students.Count);

            students = repo.List();
            Student check = students[0];

            Assert.AreEqual("Joe", check.FirstName);
            Assert.AreEqual("Smith", check.LastName);
            Assert.AreEqual("Computer Science", check.Major);
            Assert.AreEqual(3.5M, check.GPA);
            Assert.AreEqual(800, check.CreditHours);
        }
    }
}
