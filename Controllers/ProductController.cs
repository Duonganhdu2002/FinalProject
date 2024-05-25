using System.Collections.Generic;
using System.Linq;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class ProductController
    {
        private List<Product> products = new List<Product>();

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public Product? GetProductById(int id)
        {
            return products.FirstOrDefault(p => p.ProductID == id);
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
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
            }
        }

        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                products.Remove(product);
            }
        }
    }
}
