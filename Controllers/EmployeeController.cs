using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using FinalProject.Models;
using FinalProject.Data;

namespace FinalProject.Controllers
{
    public class EmployeeController
    {
        private DatabaseConnection dbConnection;

        public EmployeeController()
        {
            dbConnection = new DatabaseConnection();
        }

        public List<Employee> GetAllEmployee()
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Employee";
                SqlCommand command = new SqlCommand(query, connection);
                dbConnection.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            EmployeeID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Position = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Salary = reader.GetDecimal(6),
                            Password = reader.GetString(7)
                        };
                        employees.Add(employee);
                    }
                }

                dbConnection.CloseConnection();
            }

            return employees;
        }

        public Employee? GetEmployeeById(int id)
        {
            Employee? employee = null;

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Employee WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", id);
                dbConnection.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            EmployeeID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Position = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Salary = reader.GetDecimal(6),
                            Password = reader.GetString(7)
                        };
                    }
                }

                dbConnection.CloseConnection();
            }

            return employee;
        }

        public Employee? ValidateUser(string email, string password)
        {
            Employee? employee = null;

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Employee WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                dbConnection.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            EmployeeID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Position = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Salary = reader.GetDecimal(6),
                            Password = reader.GetString(7)
                        };
                    }
                }

                dbConnection.CloseConnection();
            }

            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "INSERT INTO Employee (FirstName, LastName, Email, Phone, Position, Salary, Password) VALUES (@FirstName, @LastName, @Email, @Phone, @Position, @Salary, @Password)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Phone", employee.Phone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Position", employee.Position ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@Password", employee.Password);
                dbConnection.OpenConnection();
                command.ExecuteNonQuery();
                dbConnection.CloseConnection();
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "UPDATE Employee SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Position = @Position, Salary = @Salary, Password = @Password WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Phone", employee.Phone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Position", employee.Position ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                command.Parameters.AddWithValue("@Password", employee.Password);
                command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                dbConnection.OpenConnection();
                command.ExecuteNonQuery();
                dbConnection.CloseConnection();
            }
        }

        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeID", id);
                dbConnection.OpenConnection();
                command.ExecuteNonQuery();
                dbConnection.CloseConnection();
            }
        }

        public List<Employee> SearchEmployees(string searchText)
        {
            List<Employee> employees = new List<Employee>();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Employee WHERE FirstName LIKE @SearchText OR LastName LIKE @SearchText";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                dbConnection.OpenConnection();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            EmployeeID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Phone = reader.IsDBNull(4) ? null : reader.GetString(4),
                            Position = reader.IsDBNull(5) ? null : reader.GetString(5),
                            Salary = reader.GetDecimal(6),
                            Password = reader.GetString(7)
                        };
                        employees.Add(employee);
                    }
                }

                dbConnection.CloseConnection();
            }

            return employees;
        }
    }
}
