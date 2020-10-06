using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.Models.Responses
{
    public class OrdersResponse: Response
    {
        public List<Order> Orders { get; set; }
    }
}
