using SWC_Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWC_Flooring.Models;

namespace SWC_Flooring.Data
{
    public class OrderTestRepository : IOrderRepository
    {
        DateTime _orderDate = new DateTime(2017, 01, 01);

        private static Order _order = new Order
        {
            OrderDate = new DateTime(2017, 01, 01),
            OrderNumber = 1,
            CustomerName = "Bob Vila",
            State = "MN",
            TaxRate = 6.5M,
            ProductType = "Carpet",
            Area = 600M,
            CostPerSquareFoot = 3.5M,
            LaborCostPerSquareFoot = 2.0M,
        };

        private static Order _order2 = new Order
        {
            OrderDate = new DateTime(2017, 01, 01),
            OrderNumber = 2,
            CustomerName = "John Smith",
            State = "TX",
            TaxRate = 7.0M,
            ProductType = "Wood",
            Area = 950M,
            CostPerSquareFoot = 2.5M,
            LaborCostPerSquareFoot = 2.0M,
        };

        public List<Order> LoadOrders(DateTime orderDate)
        {
            List<Order> orders = new List<Order>();
            if (orderDate == _orderDate)
            {
                orders.Add(_order);
                orders.Add(_order2);
                
            }
            return orders;
        }
        public Order LoadOrder(int orderNumber, DateTime orderDate)
        {
            var orders = LoadOrders(orderDate);
            var order = orders.Find(o => o.OrderNumber == orderNumber);
            return order;
        }

        public Order AddOrder(Order order, DateTime orderDate)
        {
            var orders = LoadOrders(orderDate);
            if (orders.Count == 0)
            {
                order.OrderNumber = 1;
            }
            else
            {
                order.OrderNumber = (orders.Max(o => o.OrderNumber) + 1);
            }
            orders.Add(order);
            return order;
            
        }

        public void EditOrder(Order order, DateTime orderDate)
        {
            var orders = LoadOrders(orderDate);
            var index = orders.FindIndex(o => o.OrderNumber == order.OrderNumber);
            orders[index] = order;         
        }

        public void DeleteOrder(int orderNumber, DateTime orderDate)
        {
            var orders = LoadOrders(orderDate);
            var order = orders.Find(o => o.OrderNumber == orderNumber);
            orders.Remove(order);
        }   
    }
}
