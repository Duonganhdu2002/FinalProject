using System;
using System.Windows.Forms;
using FinalProject.Models;

namespace FinalProject.Forms
{
    public partial class Home : Form
    {
        private Employee loggedInEmployee;

        public Home(Employee employee)
        {
            InitializeComponent();
            loggedInEmployee = employee;
            DisplayEmployeeInfo();
        }

        private void DisplayEmployeeInfo()
        {
            // Hiển thị thông tin nhân viên đã đăng nhập
            labelEmployeeName.Text = $"Welcome, {loggedInEmployee.FirstName} {loggedInEmployee.LastName}";
            // Thêm các thông tin khác nếu cần
        }
    }
}
