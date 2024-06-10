using System;
using System.Drawing;
using System.Windows.Forms;
using FinalProject.Components;
using FinalProject.Components.Common; // Thêm namespace cho Search

namespace FinalProject.Forms
{
    public partial class Home : Form
    {
        private HomeContent homeContent;
        private EmployeeContent employeeContent;
        private OrderContent orderContent;
        private Search searchComponent; // Khai báo searchComponent ở đây
        private UserControl currentContent; // Khai báo biến currentContent

        public Home()
        {
            InitializeComponent();
            orderContent = new OrderContent(); // Initialize OrderContent first
            homeContent = new HomeContent(orderContent); // Pass orderContent to HomeContent constructor
            employeeContent = new EmployeeContent();

            // Khởi tạo searchComponent với hàm xử lý và hint text
            searchComponent = new Search(HomeContentSearch, "Search products...");

            // Đặt vị trí và kích thước cho searchComponent
            searchComponent.Location = new Point(142, 13);
            searchComponent.Size = new Size(322, 25);

            // Thêm searchComponent vào panel9 nếu HomeContent được hiển thị ban đầu
            panel9.Controls.Add(searchComponent);
            searchComponent.SetSearchHandler(HomeContentSearch);
        }

        private void ShowContent(UserControl content)
        {
            // Clear the current content
            panelContent.Controls.Clear();

            // Add the new content
            content.Dock = DockStyle.Fill;
            panelContent.Controls.Add(content);

            // Update the current content
            currentContent = content;

            // Update the search handler based on the current content
            if (content is HomeContent)
            {
                if (!panel9.Controls.Contains(searchComponent))
                {
                    panel9.Controls.Add(searchComponent);
                }
                searchComponent.SetSearchHandler(HomeContentSearch);
                searchComponent.SetHintText("Search products...");
            }
            else if (content is EmployeeContent)
            {
                if (!panel9.Controls.Contains(searchComponent))
                {
                    panel9.Controls.Add(searchComponent);
                }
                searchComponent.SetSearchHandler(EmployeeContentSearch);
                searchComponent.SetHintText("Search employees...");
            }
            else if (content is OrderContent)
            {
                if (!panel9.Controls.Contains(searchComponent))
                {
                    panel9.Controls.Add(searchComponent);
                }
                searchComponent.SetSearchHandler(OrderContentSearch);
                searchComponent.SetHintText("Search orders...");
            }
            else
            {
                if (panel9.Controls.Contains(searchComponent))
                {
                    panel9.Controls.Remove(searchComponent);
                }
            }
        }

        private void HomeContentSearch(string searchText)
        {
            homeContent.SearchProducts(searchText);
        }

        private void EmployeeContentSearch(string searchText)
        {
            employeeContent.SearchEmployees(searchText);
        }

        private void OrderContentSearch(string searchText)
        {
            orderContent.SearchOrders(searchText);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // Initial content display
            ShowContent(homeContent);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowContent(homeContent);
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ShowContent(employeeContent);
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            ShowContent(orderContent);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ShowContent(new ResportContent());
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
