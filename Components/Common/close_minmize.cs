using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FinalProject.Components.Common
{
    public partial class close_minmize : UserControl
    {
        private Form targetForm; // Form mục tiêu

        public close_minmize()
        {
            InitializeComponent();
            InitializeButtons();
        }

        public close_minmize(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            InitializeButtons();
        }

        // Đặt form mục tiêu để tác động
        public void SetTargetForm(Form form)
        {
            targetForm = form;
        }

        private void InitializeButtons()
        {
            // Gán sự kiện cho nút Close
            button2.Click += CloseButton_Click;
            // Gán sự kiện cho nút Minimize
            button1.Click += MinimizeButton_Click;
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            if (targetForm != null)
            {
                targetForm.WindowState = FormWindowState.Minimized;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (targetForm != null)
            {
                targetForm.Close();
            }
        }
    }
}
