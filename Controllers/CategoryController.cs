using System.Collections.Generic;
using System.Linq;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class CategoryController
    {
        private List<Category> categories = new List<Category>();

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
            }
        }

        // Xóa danh mục theo ID
        public void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                categories.Remove(category);
            }
        }
    }
}
