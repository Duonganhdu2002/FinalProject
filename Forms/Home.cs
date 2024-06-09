using System;
using System.Windows.Forms;
using FinalProject.Components;
using FinalProject.Components.Common; // Thêm namespace cho Search

namespace FinalProject.Forms
{
    public partial class Home : Form
    {
        private HomeContent homeContent;
        private Search searchComponent; // Khai báo searchComponent ở đây

        private UserControl currentContent; // Khai báo biến currentContent

        public Home()
        {
            InitializeComponent();
            homeContent = new HomeContent();

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

        private void CustomerContentSearch(string searchText)
        {
            // Implement search logic for CustomerContent
        }

        private void CasherContentSearch(string searchText)
        {
            // Implement search logic for CasherContent
        }

        private void OrderContentsSearch(string searchText)
        {
            // Implement search logic for OderContents
        }

        private void ResportContentSearch(string searchText)
        {
            // Implement search logic for ResportContent
        }

        private void SettingsContentSearch(string searchText)
        {
            // Implement search logic for SettingsContent
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            ShowContent(new CustomerContent());
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            ShowContent(new CasherContent());
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            ShowContent(new OderContents());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            ShowContent(new ResportContent());
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ShowContent(new SettingsContent());
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
