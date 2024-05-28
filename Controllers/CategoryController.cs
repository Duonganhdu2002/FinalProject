using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class CategoryController
    {
        private List<Category> categories;
        private DatabaseConnection dbConnection;

        public CategoryController()
        {
            dbConnection = new DatabaseConnection();
            categories = FetchCategoriesFromDatabase();
        }

        private List<Category> FetchCategoriesFromDatabase()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection connection = dbConnection.GetConnection())
            {
                string query = "SELECT * FROM Category";
                SqlCommand cmd = new SqlCommand(query, connection);

                dbConnection.OpenConnection();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Category category = new Category
                    {
                        CategoryID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                        IconPath = reader.IsDBNull(3) ? null : reader.GetString(3)
                    };
                    categories.Add(category);
                }
                reader.Close();
                dbConnection.CloseConnection();
            }

            return categories;
        }

        // Lấy tất cả các danh mục
        public List<Category> GetAllCategories()
        {
            return categories;
        }

        // Lấy danh mục theo ID
        public Category? GetCategoryById(int id)
        {
            return categories.FirstOrDefault(c => c.CategoryID == id);
        }

        // Thêm danh mục mới
        public void AddCategory(Category category)
        {
            categories.Add(category);
            // Optionally, you can add code to insert this new category into the database
        }

        // Cập nhật danh mục hiện có
        public void UpdateCategory(Category category)
        {
            var existingCategory = GetCategoryById(category.CategoryID);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                existingCategory.IconPath = category.IconPath;
                // Optionally, you can add code to update this category in the database
            }
        }

        // Xóa danh mục theo ID
        public void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                categories.Remove(category);
                // Optionally, you can add code to delete this category from the database
            }
        }
    }
}
