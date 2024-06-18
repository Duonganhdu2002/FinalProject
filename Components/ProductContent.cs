using FinalProject.Controllers;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FinalProject.Components
{
    public partial class ProductContent : UserControl
    {
        private ProductController productController;
        private CategoryController categoryController;
        private List<Category> categories;
        private string selectedImageName;
        private string editSelectedImageName; // Biến cho tên hình ảnh khi chỉnh sửa
        private HomeContent homeContent;

        public ProductContent(HomeContent homeContent)
        {
            InitializeComponent();
            this.homeContent = homeContent;
            productController = new ProductController();
            categoryController = new CategoryController();
            LoadProductData();
            LoadCategories();

            gridViewProducts.DataError += GridViewProducts_DataError;
        }

        private void GridViewProducts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show($"Error: {e.Exception.Message}", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
        }

        private void LoadProductData()
        {
            List<Product> products = productController.GetAllProducts();
            gridViewProducts.DataSource = null; // Reset the DataSource to avoid conflicts
            gridViewProducts.Columns.Clear(); // Clear existing columns

            // Add the ProductID column if it doesn't already exist
            if (!gridViewProducts.Columns.Contains("ProductID"))
            {
                DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn
                {
                    Name = "ProductID",
                    HeaderText = "Product ID",
                    DataPropertyName = "ProductID",
                    Visible = false // Hide the column
                };
                gridViewProducts.Columns.Add(idColumn);
            }

            // Set the DataSource
            gridViewProducts.DataSource = products;

            // Add the delete button column if it doesn't already exist
            if (!gridViewProducts.Columns.Contains("Actions"))
            {
                DataGridViewButtonColumn actionsColumn = new DataGridViewButtonColumn
                {
                    Name = "Actions",
                    HeaderText = "Actions",
                    Text = "Delete",
                    UseColumnTextForButtonValue = true
                };
                gridViewProducts.Columns.Add(actionsColumn);
            }

            // Remove the last two columns (Category and OrderDetails) if they exist
            gridViewProducts.Columns["Category"].Visible = false;
            gridViewProducts.Columns["OrderDetails"].Visible = false;

            gridViewProducts.CellClick += GridViewProducts_CellClick;
            gridViewProducts.CellContentClick += GridViewProducts_CellContentClick;
            gridViewProducts.CellPainting += GridViewProducts_CellPainting;
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
                    panelEdit.Tag = selectedProduct.ProductID;

                    // Load image from the Images directory
                    string imagePath = Path.Combine(@"C:\Users\Duong\source\repos\POS-window\Images\", selectedProduct.ImagePath);
                    if (File.Exists(imagePath))
                    {
                        pictureBoxEditSelectedImage.Image = Image.FromFile(imagePath);
                        editSelectedImageName = selectedProduct.ImagePath; // Lưu trữ tên hình ảnh khi chỉnh sửa
                    }
                    else
                    {
                        pictureBoxEditSelectedImage.Image = null;
                    }
                }
            }
        }

        private void GridViewProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gridViewProducts.Rows.Count && e.ColumnIndex == gridViewProducts.Columns["Actions"].Index)
            {
                if (gridViewProducts.Rows[e.RowIndex].Cells["ProductID"].Value != null)
                {
                    int selectedProductId = Convert.ToInt32(gridViewProducts.Rows[e.RowIndex].Cells["ProductID"].Value);
                    var result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        productController.DeleteProduct(selectedProductId);
                        LoadProductData();
                        homeContent.DisplayProducts(productController.GetAllProducts()); // Refresh HomeContent
                    }
                }
                else
                {
                    MessageBox.Show("Unable to retrieve product ID for deletion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GridViewProducts_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == gridViewProducts.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);
                DataGridViewButtonCell buttonCell = gridViewProducts.Rows[e.RowIndex].Cells["Actions"] as DataGridViewButtonCell;
                if (buttonCell != null)
                {
                    buttonCell.FlatStyle = FlatStyle.Flat;
                    buttonCell.Style.ForeColor = Color.Red;
                }
                e.Handled = true;
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
                ImagePath = selectedImageName
            };

            productController.AddProduct(newProduct);
            LoadProductData();
            homeContent.DisplayProducts(productController.GetAllProducts()); // Refresh HomeContent

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
                    ImagePath = editSelectedImageName // Set the image name from the hidden field
                };

                productController.UpdateProduct(updatedProduct);
                LoadProductData();
                homeContent.DisplayProducts(productController.GetAllProducts()); // Refresh HomeContent
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
                    string imagesDirectory = @"C:\Users\Duong\source\repos\POS-window\Images\";
                    string newImagePath = Path.Combine(imagesDirectory, Path.GetFileName(selectedImagePath));

                    // Copy the selected image to the target directory
                    File.Copy(selectedImagePath, newImagePath, true);

                    pictureBoxSelectedImage.Image = Image.FromFile(newImagePath);

                    selectedImageName = Path.GetFileName(newImagePath); // Store the image name
                }
            }
        }

        private void ButtonEditSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
                openFileDialog.Title = "Select a Product Image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    string imagesDirectory = @"C:\Users\Duong\source\repos\POS-window\Images\";
                    string newImagePath = Path.Combine(imagesDirectory, Path.GetFileName(selectedImagePath));

                    // Copy the selected image to the target directory
                    File.Copy(selectedImagePath, newImagePath, true);

                    pictureBoxEditSelectedImage.Image = Image.FromFile(newImagePath);

                    editSelectedImageName = Path.GetFileName(newImagePath); // Store the image name for editing
                }
            }
        }
    }
}
