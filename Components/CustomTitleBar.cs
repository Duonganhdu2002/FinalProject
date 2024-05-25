using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FinalProject.Components
{
    public class CustomTitleBar : Control
    {
        private Label titleLabel = new Label();
        private Button btnMinimize = new Button();
        private Button btnMaximize = new Button();
        private Button btnClose = new Button();

        public CustomTitleBar(string title)
        {
            InitializeComponent(title);
        }

        private Image ResizeImage(string imagePath, int width, int height)
        {
            Image img = Image.FromFile(imagePath);
            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(img, 0, 0, width, height);
            }
            return bmp;
        }

        private void InitializeComponent(string title)
        {
            this.SuspendLayout();

            // Custom title bar settings
            this.BackColor = ColorTranslator.FromHtml("#FF8C00");
            this.MouseDown += CustomTitleBar_MouseDown;
            this.SizeChanged += CustomTitleBar_SizeChanged;

            // Initialize title label
            titleLabel.Text = title;
            titleLabel.ForeColor = Color.White;
            titleLabel.Font = new Font("Roboto", 8F, FontStyle.Bold);
            titleLabel.Location = new Point(10, 5);

            // Initialize minimize button
            btnMinimize.Size = new Size(30, 30);
            btnMinimize.Location = new Point(this.Width - 90, 0);
            btnMinimize.Click += BtnMinimize_Click;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.BackColor = ColorTranslator.FromHtml("#FF8C00");
            btnMinimize.ForeColor = Color.White;
            btnMinimize.BackgroundImage = ResizeImage("D://Window Application//FinalProject//Icons//minus.png", 13, 13);
            btnMinimize.BackgroundImageLayout = ImageLayout.Center;

            // Initialize maximize button
            btnMaximize.Size = new Size(30, 30);
            btnMaximize.Location = new Point(this.Width - 60, 0);
            btnMaximize.Click += BtnMaximize_Click;
            btnMaximize.FlatStyle = FlatStyle.Flat;
            btnMaximize.FlatAppearance.BorderSize = 0;
            btnMaximize.BackColor = ColorTranslator.FromHtml("#FF8C00");
            btnMaximize.ForeColor = Color.White;
            btnMaximize.BackgroundImage = ResizeImage("D://Window Application//FinalProject//Icons//stack.png", 13, 13);
            btnMaximize.BackgroundImageLayout = ImageLayout.Center;

            // Initialize close button
            btnClose.Size = new Size(30, 30);
            btnClose.Location = new Point(this.Width - 30, 0);
            btnClose.Click += BtnClose_Click;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.BackColor = ColorTranslator.FromHtml("#FF8C00");
            btnClose.ForeColor = Color.White;
            btnClose.BackgroundImage = ResizeImage("D://Window Application//FinalProject//Icons//close.png", 10, 10);
            btnClose.BackgroundImageLayout = ImageLayout.Center;

            // Add controls to title bar
            this.Controls.Add(titleLabel);
            this.Controls.Add(btnMinimize);
            this.Controls.Add(btnMaximize);
            this.Controls.Add(btnClose);

            this.ResumeLayout(false);
        }

        private void BtnMinimize_Click(object? sender, EventArgs e)
        {
            Form? parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.WindowState = FormWindowState.Minimized;
            }
        }

        private void BtnMaximize_Click(object? sender, EventArgs e)
        {
            Form? parentForm = this.FindForm();
            if (parentForm != null)
            {
                if (parentForm.WindowState == FormWindowState.Maximized)
                {
                    parentForm.WindowState = FormWindowState.Normal;
                }
                else
                {
                    parentForm.WindowState = FormWindowState.Maximized;
                }
            }
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            Form? parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        private void CustomTitleBar_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.FindForm()?.Handle ?? IntPtr.Zero, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CustomTitleBar_SizeChanged(object? sender, EventArgs e)
        {
            btnMinimize.Location = new Point(this.Width - 90, 0);
            btnMaximize.Location = new Point(this.Width - 60, 0);
            btnClose.Location = new Point(this.Width - 30, 0);
        }

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
    }
}
