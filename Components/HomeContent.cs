using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FinalProject.Controllers;
using FinalProject.Models;

namespace FinalProject.Components
{
    public partial class HomeContent : UserControl
    {
        private CategoryController categoryController;
        private ProductController productController;
        private Dictionary<int, int> orderedProducts; // ProductID, Quantity

        public HomeContent()
        {
            InitializeComponent();
            categoryController = new CategoryController();
            productController = new ProductController();
            orderedProducts = new Dictionary<int, int>();
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
                    BackColor = Color.White // Use system default control color
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
                productPanel.Tag = product;
                productPanel.Click += ProductPanel_Click;

                panelProducts.Controls.Add(productPanel);
            }
        }

        private void ProductPanel_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag is Product product)
            {
                AddProductToOrder(product);
            }
        }

        private void AddProductToOrder(Product product)
        {
            if (orderedProducts.ContainsKey(product.ProductID))
            {
                orderedProducts[product.ProductID]++;
            }
            else
            {
                orderedProducts[product.ProductID] = 1;
            }
            RefreshOrderList();
        }

        private void RefreshOrderList()
        {
            orderListPanel.Controls.Clear();
            var orderedProductsCopy = new Dictionary<int, int>(orderedProducts); // Create a copy of the dictionary
            decimal total = 0;

            foreach (var entry in orderedProductsCopy)
            {
                var product = productController.GetProductById(entry.Key);
                int quantity = entry.Value;

                if (product != null)
                {
                    Panel orderPanel = new Panel
                    {
                        Size = new Size(orderListPanel.Width, 50),
                        Margin = new Padding(0, 5, 0, 5),
                        BackColor = SystemColors.Control // Use system default control color
                    };

                    Label productQuantity = new Label
                    {
                        AutoSize = true,
                        Location = new Point(10, 15),
                        Text = quantity.ToString()
                    };

                    Label productName = new Label
                    {
                        AutoSize = true,
                        Location = new Point(50, 15),
                        Text = product.Name
                    };

                    Label productPrice = new Label
                    {
                        AutoSize = true,
                        Location = new Point(orderPanel.Width - 130, 15),
                        Text = $"Price: {(product.Price * quantity):C}"
                    };

                    total += product.Price * quantity;

                    Button deleteButton = new Button
                    {
                        Size = new Size(25, 25),
                        Location = new Point(orderPanel.Width - 30, 12),
                        Text = "X",
                        Tag = product
                    };
                    deleteButton.Click += DeleteButton_Click;

                    orderPanel.Controls.Add(productQuantity);
                    orderPanel.Controls.Add(productName);
                    orderPanel.Controls.Add(productPrice);
                    orderPanel.Controls.Add(deleteButton);

                    orderListPanel.Controls.Add(orderPanel);
                }
            }

            totalPrice.Text = $"{total:C}";
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is Product product)
            {
                if (orderedProducts.ContainsKey(product.ProductID))
                {
                    orderedProducts[product.ProductID]--;
                    if (orderedProducts[product.ProductID] <= 0)
                    {
                        orderedProducts.Remove(product.ProductID);
                    }
                }
                RefreshOrderList();
            }
        }

        private void processBtn_Click_1(object sender, EventArgs e)
        {
            DisplayBill();
        }

        private void DisplayBill()
        {
            BillDisplay billDisplay = new BillDisplay();
            billDisplay.Dock = DockStyle.Fill;
            panel2.Controls.Clear();
            panel2.Controls.Add(billDisplay);

            // Populate the bill display with ordered products
            foreach (var entry in orderedProducts)
            {
                var product = productController.GetProductById(entry.Key);
                int quantity = entry.Value;

                if (product != null)
                {
                    billDisplay.AddProductToBill(product.Name, quantity, product.Price * quantity);
                }
            }

            decimal total = orderedProducts.Sum(entry => productController.GetProductById(entry.Key).Price * entry.Value);
            billDisplay.SetTotalPrice(total);

            billDisplay.CommitButton.Click += CommitButton_Click;
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Order committed successfully!", "Order Confirmation");
            orderedProducts.Clear();
            RefreshOrderList();
            panel2.Controls.Clear();
            panel2.Controls.Add(orderListPanel);
            panel2.Controls.Add(panel8);
        }
    }
}
