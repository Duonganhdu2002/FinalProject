using System.Collections.Generic;
using System.Linq;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class OrderDetailController
    {
        private List<OrderDetail> orderDetails = new List<OrderDetail>();

        public List<OrderDetail> GetAllOrderDetails()
        {
            return orderDetails;
        }

        public OrderDetail? GetOrderDetailById(int id)
        {
            return orderDetails.FirstOrDefault(od => od.OrderDetailID == id);
        }

        public void AddOrderDetail(OrderDetail orderDetail)
        {
            orderDetails.Add(orderDetail);
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            var existingOrderDetail = GetOrderDetailById(orderDetail.OrderDetailID);
            if (existingOrderDetail != null)
            {
                existingOrderDetail.OrderID = orderDetail.OrderID;
                existingOrderDetail.ProductID = orderDetail.ProductID;
                existingOrderDetail.Quantity = orderDetail.Quantity;
                existingOrderDetail.UnitPrice = orderDetail.UnitPrice;
            }
        }

        public void DeleteOrderDetail(int id)
        {
            var orderDetail = GetOrderDetailById(id);
            if (orderDetail != null)
            {
                orderDetails.Remove(orderDetail);
            }
        }
    }
}