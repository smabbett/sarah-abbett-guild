using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.ViewModels
{
    public class CourseVM
    {
        public int CourseId { get; set; }
        [Required(ErrorMessage = "Course Name is required.")]
        public string CourseName { get; set; }
    }
}