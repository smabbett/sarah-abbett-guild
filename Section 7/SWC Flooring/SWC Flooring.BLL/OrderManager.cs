using SWC_Flooring.Models;
using SWC_Flooring.Models.Interfaces;
using SWC_Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWC_Flooring.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private ITaxesRepository _taxesRepository;

        public OrderManager(IOrderRepository orderRepository, IProductRepository productRepository, ITaxesRepository taxesRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _taxesRepository = taxesRepository;
        }

        public OrdersResponse LookupOrders(DateTime orderDate)
        {
            OrdersResponse response = new OrdersResponse();
            try
            {
                response.Orders = _orderRepository.LoadOrders(orderDate);
                if (response.Orders.Count == 0)
                {
                    response.Success = false;
                    response.Message = $"No orders were found to match the date given.";
                }
                else
                {
                    response.Success = true;
                }
            }
            catch (Exception E)
            {
                response.Success = false;
                response.Message = $"An error has occured. Cause: {E.Message}";
            }
            return response;
        }

        public TaxesResponse LookupTaxes()
        {
            TaxesResponse response = new TaxesResponse();
            try
            {
                response.Taxes = _taxesRepository.LoadTaxes();

                if (response.Taxes.Count == 0)
                {
                    response.Success = false;
                    response.Message = $"No tax file found.";
                }
                else
                {
                    response.Success = true;
                }
            }
            catch (Exception E)
            {
                response.Success = false;
                response.Message = $"An error has occured. Cause: {E.Message}";
            }
            return response;
        }

        public OrderResponse AddOrder(Order order, DateTime orderDate)
        {
            OrderResponse response = new OrderResponse();
            try
            {
                response.order = _orderRepository.AddOrder(order, orderDate);

                if (response.order == null)
                {
                    response.Success = false;
                    response.Message = $"The order could not be added.";
                }
                else
                {
                    response.Success = true;
                }
            }
            catch (Exception E)
            {
                response.Success = false;
                response.Message = $"An error has occured. Cause: {E.Message}";
            }
            return response;
        }

        public OrderResponse LookupOrder(int orderNumber, DateTime orderDate)
        {
            OrderResponse orderResponse = new OrderResponse();
            try
            {
                orderResponse.order = _orderRepository.LoadOrder(orderNumber, orderDate);

                if (orderResponse.order == null)
                {
                    orderResponse.Success = false;
                    orderResponse.Message = $"No order was found to match the order number given.";
                }
                else if (orderResponse.order.OrderNumber == orderNumber)
                {
                    orderResponse.Success = true;
                }
            }
            catch (Exception E)
            {
                orderResponse.Success = false;
                orderResponse.Message = $"An error has occured. Cause: {E.Message}";
            }
            return orderResponse;
        }
        public ProductsResponse LookupProducts()
        {
            ProductsResponse response = new ProductsResponse();
            try
            {
                response.Products = _productRepository.LoadProducts();

                if (response.Products.Count == 0)
                {
                    response.Success = false;
                    response.Message = $"No product file found.";
                }
                else
                {
                    response.Success = true;
                }
            }
            catch (Exception E)
            {
                response.Success = false;
                response.Message = $"An error has occured. Cause: {E.Message}";
            }
            return response;
        }

        public OrderResponse EditOrder(Order order, DateTime orderDate)
        {
            OrderResponse response = new OrderResponse();

            try
            {
                _orderRepository.EditOrder(order, orderDate);
                response.Success = true;
                response.order = order;
            }
            catch (Exception E)
            {
                response.Success = false;
                response.Message = $"Order # {order.OrderNumber} for {order.OrderDate:MM/dd/yyyy} could not be edited. Cause: {E.Message}";
            }
            return response;
        }

        public Response DeleteOrder(int orderNumber, DateTime orderDate)
        {
            Response response = new Response();

            try
            {
                _orderRepository.DeleteOrder(orderNumber, orderDate);
                response.Success = true;
            }
            catch (Exception E)
            {
                response.Success = false;
                response.Message = $"Order # {orderNumber} for {orderDate:MM/dd/yyyy} could not be deleted. Cause: {E.Message}";
            }
            return response;
        }
    }
}
