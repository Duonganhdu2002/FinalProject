using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinalProject.Controllers;
using FinalProject.Models;

namespace FinalProject.Components
{
    public partial class EmployeeContent : UserControl
    {
        private EmployeeController employeeController;

        public EmployeeContent()
        {
            InitializeComponent();
            employeeController = new EmployeeController();
            InitializeDataGridView();
            LoadEmployees();
        }

        private void InitializeDataGridView()
        {
            dataGridViewEmployees.AutoGenerateColumns = false;
            dataGridViewEmployees.AllowUserToAddRows = false; // Prevent adding new rows directly in the DataGridView
            dataGridViewEmployees.AllowUserToDeleteRows = false; // Prevent deleting rows directly in the DataGridView

            // Tăng chiều cao hàng
            dataGridViewEmployees.RowTemplate.Height = 30; // Adjust this value as needed

            // Tăng padding của ô
            dataGridViewEmployees.DefaultCellStyle.Padding = new Padding(5); // Adjust this value as needed

            DataGridViewTextBoxColumn columnEmployeeID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EmployeeID",
                HeaderText = "EmployeeID",
                Name = "EmployeeID", // Ensure the Name property is set
                Visible = false // Hide the EmployeeID column
            };

            DataGridViewTextBoxColumn columnFirstName = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "FirstName",
                HeaderText = "First Name",
                Name = "FirstName" // Ensure the Name property is set
            };

            DataGridViewTextBoxColumn columnLastName = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "LastName",
                HeaderText = "Last Name",
                Name = "LastName" // Ensure the Name property is set
            };

            DataGridViewTextBoxColumn columnEmail = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email",
                Name = "Email" // Ensure the Name property is set
            };

            DataGridViewTextBoxColumn columnPhone = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Phone",
                HeaderText = "Phone",
                Name = "Phone" // Ensure the Name property is set
            };

            DataGridViewTextBoxColumn columnPosition = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Position",
                HeaderText = "Position",
                Name = "Position" // Ensure the Name property is set
            };

            DataGridViewTextBoxColumn columnSalary = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Salary",
                HeaderText = "Salary",
                Name = "Salary" // Ensure the Name property is set
            };

            DataGridViewTextBoxColumn columnPassword = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Password",
                HeaderText = "Password",
                Name = "Password" // Ensure the Name property is set
            };

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Name = "Delete" // Ensure the Name property is set
            };

            dataGridViewEmployees.Columns.AddRange(new DataGridViewColumn[]
            {
                columnEmployeeID, columnFirstName, columnLastName, columnEmail, columnPhone,
                columnPosition, columnSalary, columnPassword, deleteButtonColumn
            });

            dataGridViewEmployees.CellClick += DataGridViewEmployees_CellClick;
            dataGridViewEmployees.CellEndEdit += DataGridViewEmployees_CellEndEdit;
        }

        private void LoadEmployees()
        {
            List<Employee> employees = employeeController.GetAllEmployee();
            DisplayEmployees(employees);
        }

        private void DisplayEmployees(List<Employee> employees)
        {
            dataGridViewEmployees.DataSource = null; // Clear the existing data binding
            dataGridViewEmployees.DataSource = employees;
        }

        private void DataGridViewEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure the column index is valid
            {
                DataGridView dgv = sender as DataGridView;

                if (dgv != null)
                {
                    // Check if the clicked cell is in the "Delete" column
                    if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dgv.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        int employeeId = (int)dgv.Rows[e.RowIndex].Cells["EmployeeID"].Value;
                        employeeController.DeleteEmployee(employeeId);
                        LoadEmployees(); // Refresh the grid
                    }
                }
            }
        }

        private void DataGridViewEmployees_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure the column index is valid
            {
                DataGridView dgv = sender as DataGridView;

                if (dgv != null)
                {
                    int employeeId = (int)dgv.Rows[e.RowIndex].Cells["EmployeeID"].Value;
                    Employee employee = new Employee
                    {
                        EmployeeID = employeeId,
                        FirstName = dgv.Rows[e.RowIndex].Cells["FirstName"].Value.ToString(),
                        LastName = dgv.Rows[e.RowIndex].Cells["LastName"].Value.ToString(),
                        Email = dgv.Rows[e.RowIndex].Cells["Email"].Value.ToString(),
                        Phone = dgv.Rows[e.RowIndex].Cells["Phone"].Value.ToString(),
                        Position = dgv.Rows[e.RowIndex].Cells["Position"].Value.ToString(),
                        Salary = decimal.Parse(dgv.Rows[e.RowIndex].Cells["Salary"].Value.ToString()),
                        Password = dgv.Rows[e.RowIndex].Cells["Password"].Value.ToString()
                    };

                    employeeController.UpdateEmployee(employee);
                    LoadEmployees(); // Refresh the grid
                }
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Employee newEmployee = new Employee
            {
                FirstName = textBoxFirstName.Text,
                LastName = textBoxLastName.Text,
                Email = textBoxEmail.Text,
                Phone = textBoxPhone.Text,
                Position = comboBoxPosition.SelectedItem.ToString(),
                Salary = decimal.Parse(textBoxSalary.Text),
                Password = textBoxPassword.Text
            };

            employeeController.AddEmployee(newEmployee);
            LoadEmployees(); // Refresh the grid

            // Clear input fields
            ClearInputFields();
        }

        private void ClearInputFields()
        {
            textBoxFirstName.Text = string.Empty;
            textBoxLastName.Text = string.Empty;
            textBoxEmail.Text = string.Empty;
            textBoxPhone.Text = string.Empty;
            if (comboBoxPosition.Items.Count > 0)
            {
                comboBoxPosition.SelectedIndex = -1; // Deselect any selection
            }
            textBoxSalary.Text = string.Empty;
            textBoxPassword.Text = string.Empty;
        }

        public void SearchEmployees(string searchText)
        {
            var employees = employeeController.SearchEmployees(searchText);
            DisplayEmployees(employees);
        }
    }
}
