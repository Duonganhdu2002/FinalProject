using System;
using System.Collections.Generic;
using System.Linq;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class OrderController
    {
        private List<Order> orders = new List<Order>();

        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public Order? GetOrderById(int id)
        {
            return orders.FirstOrDefault(o => o.OrderID == id);
        }

        public void AddOrder(Order order)
        {
            orders.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = GetOrderById(order.OrderID);
            if (existingOrder != null)
            {
                existingOrder.EmployeeID = order.EmployeeID;
                existingOrder.OrderDate = order.OrderDate;
                existingOrder.CustomerID = order.CustomerID;
                existingOrder.TotalAmount = order.TotalAmount;
            }
        }

        public void DeleteOrder(int id)
        {
            var order = GetOrderById(id);
            if (order != null)
            {
                orders.Remove(order);
            }
        }
    }
}
