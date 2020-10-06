using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.Models.Interfaces
{
    public interface IOrderRepository
    {
        //display orders
        List<Order> LoadOrders(DateTime orderDate);

        Order LoadOrder(int orderNumber, DateTime orderDate);
        //add
        Order AddOrder(Order order, DateTime orderDate);
        //edit
        void EditOrder(Order order, DateTime orderDate);
        //remove
        void DeleteOrder(int orderNumber, DateTime orderDate);
    }
}
