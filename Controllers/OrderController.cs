using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class OrderController
    {
        private List<Order> orders;
        private DatabaseConnection dbConnection;

        public OrderController()
        {
            dbConnection = new DatabaseConnection();
            orders = FetchOrdersFromDatabase();
        }

        private List<Order> FetchOrdersFromDatabase()
        {
            List<Order> orders = new List<Order>();

            try
            {
                using (SqlConnection connection = dbConnection.GetConnection())
                {
                    string query = "SELECT * FROM [Order]";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    dbConnection.OpenConnection();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Order order = new Order
                        {
                            OrderID = reader.GetInt32(0),
                            EmployeeID = reader.GetInt32(1),
                            OrderDate = reader.GetDateTime(2),
                            CustomerID = reader.GetInt32(3),
                            TotalAmount = reader.GetDecimal(4)
                        };
                        orders.Add(order);
                    }
                    reader.Close();
                    dbConnection.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching orders: {ex.Message}");
                throw;
            }

            return orders;
        }

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
            try
            {
                using (SqlConnection connection = dbConnection.GetConnection())
                {
                    string query = "INSERT INTO [Order] (EmployeeID, OrderDate, CustomerID, TotalAmount) " +
                                 "VALUES (@EmployeeID, @OrderDate, @CustomerID, @TotalAmount); " +
                                 "SELECT CAST(scope_identity() AS int)";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);
                    cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                    cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                    cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

                    dbConnection.OpenConnection();
                    order.OrderID = Convert.ToInt32(cmd.ExecuteScalar());
                    dbConnection.CloseConnection();
                }
                orders.Add(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding order: {ex.Message}");
                throw;
            }
        }

        public void UpdateOrder(Order order)
        {
            var existingOrder = GetOrderById(order.OrderID);
            if (existingOrder != null)
            {
                try
                {
                    using (SqlConnection connection = dbConnection.GetConnection())
                    {
                        string query = "UPDATE [Order] SET EmployeeID = @EmployeeID, OrderDate = @OrderDate, " +
                                       "CustomerID = @CustomerID, TotalAmount = @TotalAmount " +
                                       "WHERE OrderID = @OrderID";
                        SqlCommand cmd = new SqlCommand(query, connection);

                        cmd.Parameters.AddWithValue("@EmployeeID", order.EmployeeID);
                        cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                        cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                        cmd.Parameters.AddWithValue("@OrderID", order.OrderID);

                        dbConnection.OpenConnection();
                        cmd.ExecuteNonQuery();
                        dbConnection.CloseConnection();
                    }

                    // Update the in-memory list
                    existingOrder.EmployeeID = order.EmployeeID;
                    existingOrder.OrderDate = order.OrderDate;
                    existingOrder.CustomerID = order.CustomerID;
                    existingOrder.TotalAmount = order.TotalAmount;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error updating order: {ex.Message}");
                    throw;
                }
            }
        }

        public void DeleteOrder(int id)
        {
            var order = GetOrderById(id);
            if (order != null)
            {
                try
                {
                    using (SqlConnection connection = dbConnection.GetConnection())
                    {
                        string query = "DELETE FROM [Order] WHERE OrderID = @OrderID";
                        SqlCommand cmd = new SqlCommand(query, connection);

                        cmd.Parameters.AddWithValue("@OrderID", id);

                        dbConnection.OpenConnection();
                        cmd.ExecuteNonQuery();
                        dbConnection.CloseConnection();
                    }

                    orders.Remove(order);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting order: {ex.Message}");
                    throw;
                }
            }
        }
    }
}
