using Exercises.Models.Data;
using Exercises.Models.ViewModels;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new MajorVM());
        }

        [HttpPost]
        public ActionResult AddMajor(MajorVM majorVM)
        {
            if (ModelState.IsValid)
            {
                var major = new Major();
                major.MajorName = majorVM.MajorName;
                MajorRepository.Add(major.MajorName);
                return RedirectToAction("Majors");
            }
            else
            {
                return View("AddMajor", majorVM);
            }
                
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var majorVM = new MajorVM();
            var major = MajorRepository.Get(id);
            majorVM.MajorId = major.MajorId;
            majorVM.MajorName = major.MajorName;
            return View(majorVM);
        }

        [HttpPost]
        public ActionResult EditMajor(MajorVM majorVM)
        {
            if (ModelState.IsValid)
            {
                var major = new Major();
                major.MajorName = majorVM.MajorName;
                major.MajorId = majorVM.MajorId;
                MajorRepository.Edit(major);
                return RedirectToAction("Majors");
            }
            else
            {
                return View("EditMajor", majorVM);
            }
            
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddState()
        {
            return View(new StateVM());
        }

        [HttpPost]
        public ActionResult AddState(StateVM stateVM)
        {
            if (ModelState.IsValid)
            {
                var state = new State();
                state.StateName = stateVM.StateName;
                state.StateAbbreviation = stateVM.StateAbbreviation;
                StateRepository.Add(state);
                return RedirectToAction("States");
            }
            else
            {
                return View("AddState", stateVM);
            }
                
        }

        [HttpGet]
        public ActionResult EditState(string stateAbbreviation)
        {
            var stateVM = new StateVM();
            var state = StateRepository.Get(stateAbbreviation);
            stateVM.StateAbbreviation = state.StateAbbreviation;
            stateVM.StateName = state.StateName;
            return View(stateVM);
        }

        [HttpPost]
        public ActionResult EditState(StateVM stateVM)
        {
            if (ModelState.IsValid)
            {
                var state = new State();
                state.StateName = stateVM.StateName;
                state.StateAbbreviation = stateVM.StateAbbreviation;
                StateRepository.Edit(state);
                return RedirectToAction("States");
            }
            else
            {
                return View("EditState", stateVM);
            }
            
        }

        [HttpGet]
        public ActionResult DeleteState(string id)
        {
            var state = StateRepository.Get(id);
            return View(state);
        }

        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }

        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();          
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new CourseVM());
        }

        [HttpPost]
        public ActionResult AddCourse(CourseVM courseVM)
        {
            if (ModelState.IsValid)
            {
                var course = new Course();
                course.CourseName = courseVM.CourseName;
                CourseRepository.Add(course.CourseName);
                return RedirectToAction("Courses");
            }
            else
            {
                return View("AddCourse", courseVM);
            }
            
        }

        [HttpGet]
        public ActionResult EditCourse(int id)
        {
            var courseVM = new CourseVM();
            var course = CourseRepository.Get(id);
            courseVM.CourseId = course.CourseId;
            courseVM.CourseName = course.CourseName;
            return View(courseVM);
        }

        [HttpPost]
        public ActionResult EditCourse(CourseVM courseVM)
        {
            if (ModelState.IsValid)
            {
                var course = new Course();
                course.CourseName = courseVM.CourseName;
                course.CourseId = courseVM.CourseId;
                CourseRepository.Edit(course);
                return RedirectToAction("Courses");
            }
            else
            {
                return View("EditCourse", courseVM);
            }
            
        }

        [HttpGet]
        public ActionResult DeleteCourse(int id)
        {
            var course = CourseRepository.Get(id);
            return View(course);
        }

        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }
    }
}