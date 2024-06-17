using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class ProductController
    {
        private List<Product> products;
        private DatabaseConnection dbConnection;

        public ProductController()
        {
            dbConnection = new DatabaseConnection();
            products = FetchProductsFromDatabase();
        }

        private List<Product> FetchProductsFromDatabase()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(query, connection);

                dbConnection.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        StockQuantity = reader.GetInt32(4),
                        ImagePath = reader.IsDBNull(5) ? null : reader.GetString(5),
                        CategoryID = reader.GetInt32(6)
                    };
                    products.Add(product);
                }
                reader.Close();
                dbConnection.CloseConnection();
            }

            return products;
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product? GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.ProductID == id);
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return products.Where(p => p.CategoryID == categoryId).ToList();
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "INSERT INTO Product (Name, Description, Price, StockQuantity, ImagePath, CategoryID) " +
                               "VALUES (@Name, @Description, @Price, @StockQuantity, @ImagePath, @CategoryID); " +
                               "SELECT SCOPE_IDENTITY();";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Name", product.Name);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@Price", product.Price);
                cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);

                // Handle ImagePath for possible null value
                if (product.ImagePath != null)
                {
                    cmd.Parameters.AddWithValue("@ImagePath", product.ImagePath);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);

                dbConnection.OpenConnection();
                product.ProductID = Convert.ToInt32(cmd.ExecuteScalar());
                dbConnection.CloseConnection();
            }
            products.Add(product);
        }


        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.ProductID);
            if (existingProduct != null)
            {
                using (SqlConnection connection = dbConnection.GetConnection())
                {
                    string query = "UPDATE Product SET Name = @Name, Description = @Description, Price = @Price, " +
                                   "StockQuantity = @StockQuantity, ImagePath = @ImagePath, CategoryID = @CategoryID " +
                                   "WHERE ProductID = @ProductID";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@Name", product.Name);
                    cmd.Parameters.AddWithValue("@Description", product.Description);
                    cmd.Parameters.AddWithValue("@Price", product.Price);
                    cmd.Parameters.AddWithValue("@StockQuantity", product.StockQuantity);
                    cmd.Parameters.AddWithValue("@ImagePath", product.ImagePath);
                    cmd.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                    cmd.Parameters.AddWithValue("@ProductID", product.ProductID);

                    dbConnection.OpenConnection();
                    cmd.ExecuteNonQuery();
                    dbConnection.CloseConnection();
                }

                // Update the in-memory list
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.StockQuantity = product.StockQuantity;
                existingProduct.ImagePath = product.ImagePath;
                existingProduct.CategoryID = product.CategoryID;
            }
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                using (SqlConnection connection = dbConnection.GetConnection())
                {
                    string query = "DELETE FROM Product WHERE ProductID = @ProductID";
                    SqlCommand cmd = new SqlCommand(query, connection);

                    cmd.Parameters.AddWithValue("@ProductID", id);

                    dbConnection.OpenConnection();
                    cmd.ExecuteNonQuery();
                    dbConnection.CloseConnection();
                }

                products.Remove(product);
            }
        }
    }
}
