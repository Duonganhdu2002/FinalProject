using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class OrderDetailController
    {
        private List<OrderDetail> orderDetails;
        private DatabaseConnection dbConnection;

        public OrderDetailController()
        {
            dbConnection = new DatabaseConnection();
            orderDetails = FetchOrderDetailsFromDatabase();
        }

        private List<OrderDetail> FetchOrderDetailsFromDatabase()
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();

            try
            {
                using (SqlConnection connection = dbConnection.GetConnection())
                {
                    string query = "SELECT * FROM [OrderDetail]";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    dbConnection.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail
                        {
                            OrderDetailID = reader.GetInt32(0),
                            OrderID = reader.GetInt32(1),
                            ProductID = reader.GetInt32(2),
                            Quantity = reader.GetInt32(3),
                            UnitPrice = reader.GetDecimal(4)
                        };
                        orderDetails.Add(orderDetail);
                    }
                    reader.Close();
                    dbConnection.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching order details: {ex.Message}");
                throw;
            }

            return orderDetails;
        }

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
            try
            {
                using (SqlConnection connection = dbConnection.GetConnection())
                {
                    string query = "INSERT INTO [OrderDetail] (OrderID, ProductID, Quantity, UnitPrice) " +
                                   "VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice); " +
                                   "SELECT SCOPE_IDENTITY();";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@OrderID", orderDetail.OrderID);
                    cmd.Parameters.AddWithValue("@ProductID", orderDetail.ProductID);
                    cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                    cmd.Parameters.AddWithValue("@UnitPrice", orderDetail.UnitPrice);

                    dbConnection.OpenConnection();
                    orderDetail.OrderDetailID = Convert.ToInt32(cmd.ExecuteScalar());
                    dbConnection.CloseConnection();
                }
                orderDetails.Add(orderDetail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding order detail: {ex.Message}");
                throw;
            }
        }

        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            var existingOrderDetail = GetOrderDetailById(orderDetail.OrderDetailID);
            if (existingOrderDetail != null)
            {
                try
                {
                    using (SqlConnection connection = dbConnection.GetConnection())
                    {
                        string query = "UPDATE [OrderDetail] SET OrderID = @OrderID, ProductID = @ProductID, " +
                                       "Quantity = @Quantity, UnitPrice = @UnitPrice " +
                                       "WHERE OrderDetailID = @OrderDetailID";
                        SqlCommand cmd = new SqlCommand(query, connection);

                        cmd.Parameters.AddWithValue("@OrderID", orderDetail.OrderID);
                        cmd.Parameters.AddWithValue("@ProductID", orderDetail.ProductID);
                        cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                        cmd.Parameters.AddWithValue("@UnitPrice", orderDetail.UnitPrice);
                        cmd.Parameters.AddWithValue("@OrderDetailID", orderDetail.OrderDetailID);

                        dbConnection.OpenConnection();
                        cmd.ExecuteNonQuery();
                        dbConnection.CloseConnection();
                    }

                    // Update the in-memory list
                    existingOrderDetail.OrderID = orderDetail.OrderID;
                    existingOrderDetail.ProductID = orderDetail.ProductID;
                    existingOrderDetail.Quantity = orderDetail.Quantity;
                    existingOrderDetail.UnitPrice = orderDetail.UnitPrice;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating order detail: {ex.Message}");
                    throw;
                }
            }
        }

        public void DeleteOrderDetail(int id)
        {
            var orderDetail = GetOrderDetailById(id);
            if (orderDetail != null)
            {
                try
                {
                    using (SqlConnection connection = dbConnection.GetConnection())
                    {
                        string query = "DELETE FROM [OrderDetail] WHERE OrderDetailID = @OrderDetailID";
                        SqlCommand cmd = new SqlCommand(query, connection);

                        cmd.Parameters.AddWithValue("@OrderDetailID", id);

                        dbConnection.OpenConnection();
                        cmd.ExecuteNonQuery();
                        dbConnection.CloseConnection();
                    }

                    orderDetails.Remove(orderDetail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting order detail: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
