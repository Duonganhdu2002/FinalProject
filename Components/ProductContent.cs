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
        private string selectedImageName; // Hidden field to store the image name

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

            // Configure DataGridView columns
            gridViewProducts.AutoGenerateColumns = false;
            gridViewProducts.Columns.Clear();

            // Add necessary columns
            gridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "ID", DataPropertyName = "ProductID" });
            gridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Name", DataPropertyName = "Name" });
            gridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Description", DataPropertyName = "Description" });
            gridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Price", DataPropertyName = "Price" });
            gridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Stock Quantity", DataPropertyName = "StockQuantity" });
            gridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Category", DataPropertyName = "CategoryID" });
            gridViewProducts.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Image", DataPropertyName = "ImagePath" });

            // Add delete button column
            var deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Actions",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            gridViewProducts.Columns.Add(deleteButtonColumn);

            gridViewProducts.CellClick += GridViewProducts_CellClick;
            gridViewProducts.CellContentClick += GridViewProducts_CellContentClick;
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
            if (e.RowIndex >= 0 && e.ColumnIndex != gridViewProducts.Columns["Actions"].Index)
            {
                int selectedProductId = Convert.ToInt32(gridViewProducts.Rows[e.RowIndex].Cells["ProductID"].Value);
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

        private void GridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == gridViewProducts.Columns["Actions"].Index)
            {
                int selectedProductId = Convert.ToInt32(gridViewProducts.Rows[e.RowIndex].Cells["ProductID"].Value);
                productController.DeleteProduct(selectedProductId);
                LoadProductData(); // Reload data to update DataGridView
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
                CategoryID = selectedCategory.CategoryID,
                ImagePath = selectedImageName // Set the image name from the hidden field
            };

            productController.AddProduct(newProduct);
            LoadProductData(); // Reload data to update DataGridView

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
                    CategoryID = selectedCategory.CategoryID,
                    ImagePath = selectedImageName // Set the image name from the hidden field
                };

                productController.UpdateProduct(updatedProduct);
                LoadProductData(); // Reload data to update DataGridView
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

                    // Set the image name in the hidden field
                    selectedImageName = System.IO.Path.GetFileName(selectedImagePath);
                }
            }
        }
    }
}
