using System;
using System.Windows.Forms;
using FinalProject.Components; // Thêm namespace cho Components

namespace FinalProject.Forms
{
    public partial class Home : Form
    {
        private HomeContent homeContent;

        public Home()
        {
            InitializeComponent();
            homeContent = new HomeContent();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn không cho Enter thêm ký tự mới vào textbox
                string searchText = textBox1.Text.Trim();
                homeContent.SearchProducts(searchText);
                textBox1.Text = string.Empty; // Xóa văn bản đã nhập
            }
        }

        private void ShowContent(UserControl content)
        {
            // Clear the current content
            panelContent.Controls.Clear();

            // Add the new content
            content.Dock = DockStyle.Fill;
            panelContent.Controls.Add(content);
        }

        private void Home_Load(object sender, EventArgs e)
        {
            // Initial content display
            ShowContent(homeContent);

            // Add event handler for textBox1 KeyPress event
            textBox1.KeyPress += TextBox1_KeyPress;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowContent(new HomeContent());
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
