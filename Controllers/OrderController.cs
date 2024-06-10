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
                        dbConnection.OpenConnection(); // Mở kết nối

                        // Bắt đầu transaction
                        SqlTransaction transaction = connection.BeginTransaction();

                        try
                        {
                            // Xóa các chi tiết đơn hàng liên quan trước
                            string deleteOrderDetailsQuery = "DELETE FROM OrderDetail WHERE OrderID = @OrderID";
                            SqlCommand deleteOrderDetailsCmd = new SqlCommand(deleteOrderDetailsQuery, connection, transaction);
                            deleteOrderDetailsCmd.Parameters.AddWithValue("@OrderID", id);
                            deleteOrderDetailsCmd.ExecuteNonQuery();

                            // Xóa đơn hàng
                            string deleteOrderQuery = "DELETE FROM [Order] WHERE OrderID = @OrderID";
                            SqlCommand deleteOrderCmd = new SqlCommand(deleteOrderQuery, connection, transaction);
                            deleteOrderCmd.Parameters.AddWithValue("@OrderID", id);
                            deleteOrderCmd.ExecuteNonQuery();

                            // Commit transaction
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction trong trường hợp xảy ra lỗi
                            transaction.Rollback();
                            Console.WriteLine($"Error deleting order: {ex.Message}");
                            throw;
                        }
                        finally
                        {
                            dbConnection.CloseConnection(); // Đóng kết nối
                        }
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


        public List<Order> SearchOrders(string searchText)
        {
            if (string.IsNullOrEmpty(searchText))
            {
                return orders;
            }

            int idSearch;
            bool isNumeric = int.TryParse(searchText, out idSearch);

            if (isNumeric)
            {
                return orders.Where(o => o.OrderID == idSearch || o.CustomerID == idSearch || o.EmployeeID == idSearch).ToList();
            }
            else
            {
                return new List<Order>();
            }
        }

        public decimal GetTotalRevenue()
        {
            decimal totalRevenue = 0;

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT SUM(TotalAmount) FROM [Order]";
                SqlCommand command = new SqlCommand(query, connection);
                dbConnection.OpenConnection();

                totalRevenue = (decimal)command.ExecuteScalar();

                dbConnection.CloseConnection();
            }

            return totalRevenue;
        }

        public int GetTotalOrders()
        {
            int totalOrders = 0;

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM [Order]";
                SqlCommand command = new SqlCommand(query, connection);
                dbConnection.OpenConnection();

                totalOrders = (int)command.ExecuteScalar();

                dbConnection.CloseConnection();
            }

            return totalOrders;
        }

        public List<(DateTime Date, decimal Revenue)> GetDailyRevenue()
        {
            List<(DateTime Date, decimal Revenue)> dailyRevenue = new List<(DateTime Date, decimal Revenue)>();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT OrderDate, SUM(TotalAmount) AS Revenue FROM [Order] GROUP BY OrderDate";
                SqlCommand command = new SqlCommand(query, connection);
                dbConnection.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dailyRevenue.Add((reader.GetDateTime(0), reader.GetDecimal(1)));
                    }
                }

                dbConnection.CloseConnection();
            }

            return dailyRevenue;
        }

        public List<(int Month, int Year, decimal Revenue)> GetMonthlyRevenue()
        {
            List<(int Month, int Year, decimal Revenue)> monthlyRevenue = new List<(int Month, int Year, decimal Revenue)>();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT MONTH(OrderDate) AS Month, YEAR(OrderDate) AS Year, SUM(TotalAmount) AS Revenue FROM [Order] GROUP BY MONTH(OrderDate), YEAR(OrderDate)";
                SqlCommand command = new SqlCommand(query, connection);
                dbConnection.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        monthlyRevenue.Add((reader.GetInt32(0), reader.GetInt32(1), reader.GetDecimal(2)));
                    }
                }

                dbConnection.CloseConnection();
            }

            return monthlyRevenue;
        }

        public List<(DateTime Date, int OrderCount)> GetDailyOrderCount()
        {
            List<(DateTime Date, int OrderCount)> dailyOrderCount = new List<(DateTime Date, int OrderCount)>();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT OrderDate, COUNT(*) AS OrderCount FROM [Order] GROUP BY OrderDate";
                SqlCommand command = new SqlCommand(query, connection);
                dbConnection.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dailyOrderCount.Add((reader.GetDateTime(0), reader.GetInt32(1)));
                    }
                }

                dbConnection.CloseConnection();
            }

            return dailyOrderCount;
        }

        public List<(int Month, int Year, int OrderCount)> GetMonthlyOrderCount()
        {
            List<(int Month, int Year, int OrderCount)> monthlyOrderCount = new List<(int Month, int Year, int OrderCount)>();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT MONTH(OrderDate) AS Month, YEAR(OrderDate) AS Year, COUNT(*) AS OrderCount FROM [Order] GROUP BY MONTH(OrderDate), YEAR(OrderDate)";
                SqlCommand command = new SqlCommand(query, connection);
                dbConnection.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        monthlyOrderCount.Add((reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                    }
                }

                dbConnection.CloseConnection();
            }

            return monthlyOrderCount;
        }


    }
}
