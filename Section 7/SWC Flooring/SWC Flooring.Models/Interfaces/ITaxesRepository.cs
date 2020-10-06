﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.Models.Interfaces
{
    public interface ITaxesRepository
    {
        Tax LoadTax(string stateAbbreviation);
        List<Tax> LoadTaxes();
    }
}
