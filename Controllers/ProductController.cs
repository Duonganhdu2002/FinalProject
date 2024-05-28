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
            products.Add(product);
            // Optionally, you can add code to insert this new product into the database
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.ProductID);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
                existingProduct.StockQuantity = product.StockQuantity;
                existingProduct.ImagePath = product.ImagePath;
                existingProduct.CategoryID = product.CategoryID;
                // Optionally, you can add code to update this product in the database
            }
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                products.Remove(product);
                // Optionally, you can add code to delete this product from the database
            }
        }
    }
}
