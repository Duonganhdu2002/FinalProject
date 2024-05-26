using System;
using System.Windows.Forms;
using FinalProject.Controllers;
using FinalProject.Models;

namespace FinalProject.Forms
{
    public partial class Login : Form
    {
        private EmployeeController employeeController;

        public Login()
        {
            InitializeComponent();
            employeeController = new EmployeeController();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            Employee? employee = employeeController.ValidateUser(email, password);
            if (employee != null)
            {
                Home homeForm = new Home(employee);
                homeForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Email or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
