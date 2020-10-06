using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Exercises.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.ViewModels
{
    public class StudentVM: IValidatableObject
    {
        public Student Student { get; set; }
        public List<SelectListItem> CourseItems { get; set; }
        public List<SelectListItem> MajorItems { get; set; }
        public List<SelectListItem> StateItems { get; set; }
        public List<int> SelectedCourseIds { get; set; }

        public StudentVM()
        {
            CourseItems = new List<SelectListItem>();
            MajorItems = new List<SelectListItem>();
            StateItems = new List<SelectListItem>();
            SelectedCourseIds = new List<int>();
            Student = new Student();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrEmpty(Student.FirstName))
            {
                errors.Add(new ValidationResult("First Name is required.",
                    new[] { "Student.FirstName" }));
            }
            if (string.IsNullOrEmpty(Student.LastName))
            {
                errors.Add(new ValidationResult("Last Name is required.",
                    new[] { "Student.LastName" }));
            }
            if (Student.Major.MajorId == 0)
            {
                errors.Add(new ValidationResult("Major is required.", new[] { "Student.Major.MajorId" }));
            }
            if (SelectedCourseIds.Count == 0)
            {
                errors.Add(new ValidationResult("A minimum of one course must be selected.", new[] { "Student.Courses" }));
            }
            if (Student.Address.Street1 != null)
            {
                if (Student.Address.City == null)
                {
                    errors.Add(new ValidationResult("Address not valid without city.", new[] { "Student.Address.City" }));
                }
                if (Student.Address.State.StateAbbreviation == null)
                {
                    errors.Add(new ValidationResult("Address not valid without state.", new[] { "Student.Address.State.StateAbbreviation" }));
                }
                if ((Student.Address.PostalCode == null) || (Student.Address.PostalCode.Length != 5))
                {
                    errors.Add(new ValidationResult("Address not valid without postal code (5 digits).", new[] { "Student.Address.PostalCode" }));
                }             
            }

            return errors;
        }

        public void SetCourseItems(IEnumerable<Course> courses)
        {
            foreach (var course in courses)
            {
                CourseItems.Add(new SelectListItem()
                {
                    Value = course.CourseId.ToString(),
                    Text = course.CourseName
                });
            }
        }

        public void SetMajorItems(IEnumerable<Major> majors)
        {
            foreach (var major in majors)
            {
                MajorItems.Add(new SelectListItem()
                {
                    Value = major.MajorId.ToString(),
                    Text = major.MajorName
                });
            }
        }

        public void SetStateItems(IEnumerable<State> states)
        {
            foreach (var state in states)
            {
                StateItems.Add(new SelectListItem()
                {
                    Value = state.StateAbbreviation,
                    Text = state.StateName
                });
            }
        }
    }
}