using FinalProject.Controllers;
using FinalProject.Models;

public partial class EmployeeForm : Form
{
    private EmployeeController _controller;

    public EmployeeForm()
    {
        InitializeComponent();
        _controller = new EmployeeController();
        LoadEmployees();
    }

    private void LoadEmployees()
    {
        var employees = _controller.GetAllEmployee();
        dgvEmployees.DataSource = employees;
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        var employee = new Employee
        {
            FirstName = txtFirstName.Text,
            LastName = txtLastName.Text,
            DateOfBirth = dtpDateOfBirth.Value,
            Gender = cbGender.SelectedItem?.ToString() ?? string.Empty, // Sử dụng toán tử null-coalescing
            PhoneNumber = txtPhoneNumber.Text,
            Email = txtEmail.Text,
            HireDate = dtpHireDate.Value,
            Position = cbPosition.SelectedItem?.ToString() ?? string.Empty, // Sử dụng toán tử null-coalescing
            Salary = decimal.Parse(txtSalary.Text)
        };

        _controller.AddEmployee(employee);
        LoadEmployees();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        // Similar to AddEmployee, but call _controller.UpdateEmployee
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (dgvEmployees.SelectedRows.Count > 0)
        {
            var employeeID = (int)dgvEmployees.SelectedRows[0].Cells["EmployeeID"].Value;
            _controller.DeleteEmployee(employeeID);
            LoadEmployees();
        }
    }
}