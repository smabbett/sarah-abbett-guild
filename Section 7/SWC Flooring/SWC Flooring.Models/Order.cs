﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.Models
{
    public class Order
    {
        public DateTime OrderDate { get; set; }
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal TaxRate { get; set; }
        public string ProductType { get; set; }
        public decimal Area { get; set; }
        public decimal CostPerSquareFoot { get; set; }
        public decimal LaborCostPerSquareFoot { get; set; }
        public decimal MaterialCost
        {
            get
            {
                return CostPerSquareFoot * Area;
            }
        }
        public decimal LaborCost
        {
            get
            {
                return LaborCostPerSquareFoot * Area;
            }
        }
        public decimal Tax
        {
            get
            {
                return ((MaterialCost + LaborCost) * (TaxRate / 100));
            }
        }
        public decimal Total
        {
            get
            {
                return (MaterialCost + LaborCost + Tax);
            }
        }
    }
}
