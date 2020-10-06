using SWC_Flooring.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWC_Flooring.Models;

namespace SWC_Flooring.Data
{
    public class FileOrderRepository : IOrderRepository
    {
        private string _filepathWithoutExtension;
        private string _filepath;
        private string[] _header = new string[]
                {
                    "OrderDate@OrderNumber@CustomerName@State@TaxRate@ProductType@Area@CostPerSquareFoot@LaborCostPerSquareFoot@MaterialCost@LaborCost@Tax@Total"
                };

        public FileOrderRepository(string filepathWithoutExtension)
        {
            _filepathWithoutExtension = filepathWithoutExtension;
        }

        public Order AddOrder(Order order, DateTime orderDate)
        {
            _filepath = CreateFilepath(orderDate);

            if (!File.Exists(_filepath))
            {
                File.AppendAllLines(_filepath, _header);
            }
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
            CreateOrderFile(orders);
            return order;
        }

        public void DeleteOrder(int orderNumber, DateTime orderDate)
        {
            var orders = LoadOrders(orderDate);
            var order = orders.Find(o => o.OrderNumber == orderNumber);
            orders.Remove(order);

            CreateOrderFile(orders);
        }

        public void EditOrder(Order order, DateTime orderDate)
        {
            _filepath = CreateFilepath(orderDate);

            if (!File.Exists(_filepath))
            {
                throw new Exception("Filepath doesn't exist");
            }
            else
            {
                var orders = LoadOrders(orderDate);
                var index = orders.FindIndex(o => o.OrderNumber == order.OrderNumber);
                orders[index] = order;

                CreateOrderFile(orders);
            }
        }

        public Order LoadOrder(int orderNumber, DateTime orderDate)
        {
            Order order = new Order();
            var orders = LoadOrders(orderDate);

            order = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            return order;
        }

        public List<Order> LoadOrders(DateTime orderDate)
        {
            _filepath = CreateFilepath(orderDate);
            List<Order> orders = new List<Order>();

            if (!File.Exists(_filepath))
            {
                return orders;
            }
            else
            {
                using (StreamReader sr = new StreamReader(_filepath))
                {
                    sr.ReadLine();
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] columns = line.Split('@');
                        Order order = new Order()
                        {
                            OrderDate = DateTime.Parse(columns[0]),
                            OrderNumber = int.Parse(columns[1]),
                            CustomerName = columns[2],
                            State = columns[3],
                            TaxRate = decimal.Parse(columns[4]),
                            ProductType = columns[5],
                            Area = decimal.Parse(columns[6]),
                            CostPerSquareFoot = decimal.Parse(columns[7]),
                            LaborCostPerSquareFoot = decimal.Parse(columns[8]),
                        };
                        orders.Add(order);
                    }
                }
                return orders;
            }
        }

        private string CreateFilepath(DateTime orderDate)
        {
            return string.Format("{0}{1:MMddyyyy}.txt", _filepathWithoutExtension, orderDate);
        }

        private void CreateOrderFile(List<Order> orders)
        {
            if (File.Exists(_filepath))
                File.Delete(_filepath);

            using (StreamWriter sr = new StreamWriter(_filepath))
            {
                sr.WriteLine("{0}", _header);
                foreach (var order in orders)
                {
                    sr.WriteLine(CreateCsvForOrder(order));
                }
            }
        }
        private string CreateCsvForOrder(Order order)
        {
            return string.Format("{0:M/d/yyyy}@{1}@{2}@{3}@{4}@{5}@{6}@{7}@{8}@{9:0.00}@{10:0.00}@{11:0.00}@{12:0.00}", order.OrderDate,
                 order.OrderNumber, order.CustomerName.ToString(), order.State.ToString(), order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot, order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
        }
    }
}
