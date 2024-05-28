using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FinalProject.Controllers;
using FinalProject.Models;

namespace FinalProject.Components
{
    public partial class HomeContent : UserControl
    {
        private CategoryController categoryController;
        private ProductController productController;

        public HomeContent()
        {
            InitializeComponent();
            categoryController = new CategoryController();
            productController = new ProductController();
            LoadCategories();
        }

        private void LoadCategories()
        {
            List<Category> categories = categoryController.GetAllCategories();
            int buttonHeight = 50;
            int buttonWidth = 110; // Adjust width to fit all buttons in a row
            int panelWidth = 120; // Width of the child panel
            int panelHeight = 47; // Height of the child panel

            panel5.Controls.Clear(); // Clear any existing buttons

            foreach (var category in categories)
            {
                Panel childPanel = new Panel
                {
                    Size = new Size(panelWidth, panelHeight),
                    Margin = new Padding() // Add some spacing between panels
                };

                Button categoryButton = new Button
                {
                    Text = category.Name,
                    Size = new Size(buttonWidth, buttonHeight),
                    Location = new Point((panelWidth - buttonWidth) / 2, (panelHeight - buttonHeight) / 2), // Center button in the panel
                    Tag = category,
                    Margin = new Padding(0), // Add some spacing around button
                    FlatStyle = FlatStyle.Flat, // Set FlatStyle to Flat
                };
                categoryButton.FlatAppearance.BorderSize = 0; // Remove the border
                categoryButton.Click += CategoryButton_Click;
                childPanel.Controls.Add(categoryButton);
                panel5.Controls.Add(childPanel);
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is Category category)
            {
                LoadProductsByCategory(category.CategoryID);
            }
        }

        private void LoadProductsByCategory(int categoryId)
        {
            List<Product> products = productController.GetProductsByCategoryId(categoryId);
            int panelWidth = 163; // Width of the child panel for products
            int panelHeight = 252; // Height of the child panel for products

            panelProducts.Controls.Clear(); // Clear any existing buttons

            foreach (var product in products)
            {
                Panel productPanel = new Panel
                {
                    Size = new Size(panelWidth, panelHeight),
                    Margin = new Padding(0, 5, 10, 5), // Add some spacing between panels
                    BackColor = Color.White
                };

                PictureBox productPicture = new PictureBox
                {
                    Location = new Point(16, 14),
                    Size = new Size(130, 130),
                    ImageLocation = product.ImagePath, // Assuming the image path is valid
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                Label productName = new Label
                {
                    AutoSize = true,
                    Location = new Point(16, 171),
                    Text = product.Name
                };

                Label productPrice = new Label
                {
                    AutoSize = true,
                    Location = new Point(16, 210),
                    Text = $"Price: {product.Price:C}"
                };

                productPanel.Controls.Add(productPicture);
                productPanel.Controls.Add(productName);
                productPanel.Controls.Add(productPrice);

                panelProducts.Controls.Add(productPanel);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
