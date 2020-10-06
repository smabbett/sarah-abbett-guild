using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.ViewModels
{
    public class MajorVM
    {
        public int MajorId { get; set; }
        [Required(ErrorMessage = "Major Name is required.")]
        public string MajorName { get; set; }
    }
}