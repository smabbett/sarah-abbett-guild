using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.ViewModels
{
    public class StateVM
    {
        [Required(ErrorMessage = "State Abbreviation is required.")]
        [MaxLength(2, ErrorMessage = "State Abbreviation max length is 2.")]
        public string StateAbbreviation { get; set; }
        [Required(ErrorMessage = "State Name is required.")]
        public string StateName { get; set; }
    }
}