﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.Models
{
    public class Tax
    {
        public string StateAbbreviation { get; set; }
        public string StateName { get; set; }
        public decimal TaxRate { get; set; }
    }
}
