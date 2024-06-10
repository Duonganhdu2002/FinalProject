using FinalProject.Components.Common;
using FinalProject.Controllers;
using FinalProject.Models;
using System.Windows.Forms;

namespace FinalProject.Forms
{
    public partial class Login : Form
    {
        private EmployeeController employeeController;

        public Login()
        {
            InitializeComponent();
            employeeController = new EmployeeController();

            // Khởi tạo close_minmize và truyền form hiện tại
            closeMinimize.SetTargetForm(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string password = textBox2.Text;

            Employee? employee = employeeController.ValidateUser(email, password);
            if (employee != null)
            {
                Home homeForm = new Home(employee.EmployeeID, employee.Position);  // Truyền EmployeeID và Position khi tạo đối tượng Home
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
