using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace FinalProject.Components.Common
{
    public partial class Search : TextBox
    {
        public delegate void SearchHandler(string searchText);
        public event SearchHandler OnSearch;

        public Search(SearchHandler handler, string hintText)
        {
            InitializeComponent();
            this.KeyPress += Search_KeyPress;
            SetSearchHandler(handler);
            SetHintText(hintText);
        }

        public Search(IContainer container, SearchHandler handler, string hintText)
        {
            container.Add(this);
            InitializeComponent();
            this.KeyPress += Search_KeyPress;
            SetSearchHandler(handler);
            SetHintText(hintText);
        }

        private void Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Ngăn không cho Enter thêm ký tự mới vào textbox
                OnSearch?.Invoke(this.Text.Trim());
                this.Text = string.Empty; // Xóa văn bản đã nhập
            }
        }

        public void SetSearchHandler(SearchHandler handler)
        {
            OnSearch = handler;
        }

        public void SetHintText(string hintText)
        {
            this.PlaceholderText = hintText;
        }
    }
}
