using FinalProject.Controllers;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FinalProject.Components
{
    public partial class ProductContent : UserControl
    {
        private ProductController productController;
        private CategoryController categoryController;
        private List<Category> categories;

        public ProductContent()
        {
            InitializeComponent();
            productController = new ProductController();
            categoryController = new CategoryController();
            LoadProductData();
            LoadCategories();
        }

        private void LoadProductData()
        {
            List<Product> products = productController.GetAllProducts();
            gridViewProducts.DataSource = products;
            gridViewProducts.CellClick += GridViewProducts_CellClick;
        }

        private void LoadCategories()
        {
            categories = categoryController.GetAllCategories();
            comboBoxCategory.DataSource = new List<Category>(categories);
            comboBoxCategory.DisplayMember = "Name";
            comboBoxCategory.ValueMember = "CategoryID";
            comboBoxEditCategory.DataSource = new List<Category>(categories);
            comboBoxEditCategory.DisplayMember = "Name";
            comboBoxEditCategory.ValueMember = "CategoryID";
        }

        private void GridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedProductId = Convert.ToInt32(gridViewProducts.Rows[e.RowIndex].Cells[0].Value);
                Product selectedProduct = productController.GetProductById(selectedProductId);
                if (selectedProduct != null)
                {
                    textBoxEditName.Text = selectedProduct.Name;
                    textBoxEditDescription.Text = selectedProduct.Description;
                    textBoxEditPrice.Text = selectedProduct.Price.ToString();
                    textBoxEditStockQuantity.Text = selectedProduct.StockQuantity.ToString();
                    comboBoxEditCategory.SelectedValue = selectedProduct.CategoryID;
                    panelEdit.Tag = selectedProduct.ProductID; // Store the product ID in the panel's tag
                }
            }
        }

        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxDescription.Text) ||
                string.IsNullOrWhiteSpace(textBoxPrice.Text) || string.IsNullOrWhiteSpace(textBoxStockQuantity.Text) ||
                comboBoxCategory.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields correctly.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBoxPrice.Text, out decimal price) || !int.TryParse(textBoxStockQuantity.Text, out int stockQuantity))
            {
                MessageBox.Show("Please enter valid numeric values for Price and Stock Quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Category selectedCategory = (Category)comboBoxCategory.SelectedItem;

            Product newProduct = new Product
            {
                Name = textBoxName.Text,
                Description = textBoxDescription.Text,
                Price = price,
                StockQuantity = stockQuantity,
                CategoryID = selectedCategory.CategoryID
            };

            // Handle image path selection
            if (pictureBoxSelectedImage.Image != null)
            {
                // Assuming you have a way to store the image path in newProduct.ImagePath
                // For example, you could store the path to where the image is saved.
                // Replace "path_to_image_folder" with your actual path logic.
                string imagePath = "C://Users//Duong//Source//Repos//POS-window//Images//"; // Replace with your logic to save image

                // Set newProduct.ImagePath to imagePath
                newProduct.ImagePath = imagePath;
            }

            productController.AddProduct(newProduct);
            LoadProductData();

            MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void ButtonSaveEdit_Click(object sender, EventArgs e)
        {
            if (panelEdit.Tag != null)
            {
                if (string.IsNullOrWhiteSpace(textBoxEditName.Text) || string.IsNullOrWhiteSpace(textBoxEditDescription.Text) ||
                    string.IsNullOrWhiteSpace(textBoxEditPrice.Text) || string.IsNullOrWhiteSpace(textBoxEditStockQuantity.Text) ||
                    comboBoxEditCategory.SelectedItem == null)
                {
                    MessageBox.Show("Please fill in all fields correctly.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBoxEditPrice.Text, out decimal price) || !int.TryParse(textBoxEditStockQuantity.Text, out int stockQuantity))
                {
                    MessageBox.Show("Please enter valid numeric values for Price and Stock Quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int productId = (int)panelEdit.Tag;
                Category selectedCategory = (Category)comboBoxEditCategory.SelectedItem;

                Product updatedProduct = new Product
                {
                    ProductID = productId,
                    Name = textBoxEditName.Text,
                    Description = textBoxEditDescription.Text,
                    Price = price,
                    StockQuantity = stockQuantity,
                    CategoryID = selectedCategory.CategoryID
                };

                productController.UpdateProduct(updatedProduct);
                LoadProductData();
            }
        }

        private void ButtonSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select a Product Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    pictureBoxSelectedImage.Image = Image.FromFile(selectedImagePath);
                }
            }
        }
    }
}
