using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
            if (studentVM.Student.Address.State.StateAbbreviation != null)
            {
                studentVM.Student.Address.State = StateRepository.Get(studentVM.Student.Address.State.StateAbbreviation);
            }
            

            if (ModelState.IsValid)
            {
                StudentRepository.Add(studentVM.Student);
                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);

                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                studentVM.SetStateItems(StateRepository.GetAll());
                return View("Add", studentVM);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var viewModel = new StudentVM();
            viewModel.Student = StudentRepository.Get(id);
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());
            viewModel.CourseItems = (from c in CourseRepository.GetAll()
                                     select new SelectListItem()
                                     {
                                         Text = c.CourseName,
                                         Value = c.CourseId.ToString(),
                                         Selected = viewModel.Student.Courses.Any(s => s.CourseId == c.CourseId)
                                           }).ToList();
            viewModel.SelectedCourseIds = viewModel.Student.Courses.Select(s => s.CourseId).ToList();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(StudentVM studentVM)
        {
            studentVM.Student.Courses = new List<Course>();

            foreach (var id in studentVM.SelectedCourseIds)
                studentVM.Student.Courses.Add(CourseRepository.Get(id));

            studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);
            if (studentVM.Student.Address.State.StateAbbreviation != null)
            {
                studentVM.Student.Address.State = StateRepository.Get(studentVM.Student.Address.State.StateAbbreviation);
            }
                

            if (ModelState.IsValid)
            {             
                StudentRepository.SaveAddress(studentVM.Student.StudentId, studentVM.Student.Address);
                StudentRepository.Edit(studentVM.Student);
                return RedirectToAction("List");
            }
            else
            {
                studentVM.SetCourseItems(CourseRepository.GetAll());
                studentVM.SetMajorItems(MajorRepository.GetAll());
                studentVM.SetStateItems(StateRepository.GetAll());
                return View("Edit", studentVM);
            }
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var viewModel = new StudentVM();
            viewModel.Student = StudentRepository.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Delete(Student student)
        {
            StudentRepository.Delete(student.StudentId);
            return RedirectToAction("List");
        }
    }
}