namespace FinalProject.Components
{
    partial class EmployeeContent
    {
        private System.ComponentModel.IContainer components = null;

        private Panel rightPanel;
        private Panel panelEmployeeInfo;
        private DataGridView dataGridViewEmployees;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            rightPanel = new Panel();
            panel1 = new Panel();
            panelEmployeeInfo = new Panel();
            dataGridViewEmployees = new DataGridView();
            addNewEmployee = new Button();
            panel2 = new Panel();
            textBoxFirstName = new TextBox();
            textBoxLastName = new TextBox();
            textBoxEmail = new TextBox();
            textBoxPhone = new TextBox();
            comboBoxPosition = new ComboBox();
            textBoxSalary = new TextBox();
            textBoxPassword = new TextBox();
            labelFirstName = new Label();
            labelLastName = new Label();
            labelEmail = new Label();
            labelPhone = new Label();
            labelPosition = new Label();
            labelSalary = new Label();
            labelPassword = new Label();
            rightPanel.SuspendLayout();
            panel1.SuspendLayout();
            panelEmployeeInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // rightPanel
            // 
            rightPanel.BackColor = SystemColors.Control;
            rightPanel.Controls.Add(panel1);
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Location = new Point(683, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(436, 671);
            rightPanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.White;
            panel1.Controls.Add(labelFirstName);
            panel1.Controls.Add(textBoxFirstName);
            panel1.Controls.Add(labelLastName);
            panel1.Controls.Add(textBoxLastName);
            panel1.Controls.Add(labelEmail);
            panel1.Controls.Add(textBoxEmail);
            panel1.Controls.Add(labelPhone);
            panel1.Controls.Add(textBoxPhone);
            panel1.Controls.Add(labelPosition);
            panel1.Controls.Add(comboBoxPosition);
            panel1.Controls.Add(labelSalary);
            panel1.Controls.Add(textBoxSalary);
            panel1.Controls.Add(labelPassword);
            panel1.Controls.Add(textBoxPassword);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(18, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 629);
            panel1.TabIndex = 0;
            // 
            // panelEmployeeInfo
            // 
            panelEmployeeInfo.BackColor = SystemColors.Control;
            panelEmployeeInfo.Controls.Add(dataGridViewEmployees);
            panelEmployeeInfo.Dock = DockStyle.Fill;
            panelEmployeeInfo.Location = new Point(0, 0);
            panelEmployeeInfo.Name = "panelEmployeeInfo";
            panelEmployeeInfo.Size = new Size(683, 671);
            panelEmployeeInfo.TabIndex = 0;
            // 
            // dataGridViewEmployees
            // 
            dataGridViewEmployees.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewEmployees.BackgroundColor = Color.White;
            dataGridViewEmployees.BorderStyle = BorderStyle.None;
            dataGridViewEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewEmployees.Location = new Point(15, 16);
            dataGridViewEmployees.Name = "dataGridViewEmployees";
            dataGridViewEmployees.Size = new Size(650, 629);
            dataGridViewEmployees.TabIndex = 0;
            // 
            // addNewEmployee
            // 
            addNewEmployee.BackColor = Color.LightGray;
            addNewEmployee.FlatStyle = FlatStyle.Flat;
            addNewEmployee.Location = new Point(0, 0);
            addNewEmployee.Name = "addNewEmployee";
            addNewEmployee.Size = new Size(368, 47);
            addNewEmployee.TabIndex = 0;
            addNewEmployee.Text = "Add";
            addNewEmployee.UseVisualStyleBackColor = false;
            addNewEmployee.Click += ButtonAdd_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(addNewEmployee);
            panel2.Location = new Point(17, 564);
            panel2.Name = "panel2";
            panel2.Size = new Size(368, 47);
            panel2.TabIndex = 1;
            // 
            // textBoxFirstName
            // 
            textBoxFirstName.Location = new Point(17, 36);
            textBoxFirstName.Name = "textBoxFirstName";
            textBoxFirstName.Size = new Size(368, 23);
            textBoxFirstName.TabIndex = 2;
            // 
            // labelFirstName
            // 
            labelFirstName.AutoSize = true;
            labelFirstName.Location = new Point(17, 18);
            labelFirstName.Name = "labelFirstName";
            labelFirstName.Size = new Size(67, 15);
            labelFirstName.TabIndex = 3;
            labelFirstName.Text = "First Name";
            // 
            // textBoxLastName
            // 
            textBoxLastName.Location = new Point(17, 92);
            textBoxLastName.Name = "textBoxLastName";
            textBoxLastName.Size = new Size(368, 23);
            textBoxLastName.TabIndex = 4;
            // 
            // labelLastName
            // 
            labelLastName.AutoSize = true;
            labelLastName.Location = new Point(17, 74);
            labelLastName.Name = "labelLastName";
            labelLastName.Size = new Size(66, 15);
            labelLastName.TabIndex = 5;
            labelLastName.Text = "Last Name";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(17, 148);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(368, 23);
            textBoxEmail.TabIndex = 6;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(17, 130);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(36, 15);
            labelEmail.TabIndex = 7;
            labelEmail.Text = "Email";
            // 
            // textBoxPhone
            // 
            textBoxPhone.Location = new Point(17, 204);
            textBoxPhone.Name = "textBoxPhone";
            textBoxPhone.Size = new Size(368, 23);
            textBoxPhone.TabIndex = 8;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Location = new Point(17, 186);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(41, 15);
            labelPhone.TabIndex = 9;
            labelPhone.Text = "Phone";
            // 
            // comboBoxPosition
            // 
            comboBoxPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxPosition.FormattingEnabled = true;
            comboBoxPosition.Items.AddRange(new object[] {
            "Manager",
            "Chef",
            "Waiter",
            "Cashier",
            "Dishwasher",
            "Host",
            "Sous Chef",
            "Bartender",
            "Cleaner"});
            comboBoxPosition.Location = new Point(17, 260);
            comboBoxPosition.Name = "comboBoxPosition";
            comboBoxPosition.Size = new Size(368, 23);
            comboBoxPosition.TabIndex = 10;
            // 
            // labelPosition
            // 
            labelPosition.AutoSize = true;
            labelPosition.Location = new Point(17, 242);
            labelPosition.Name = "labelPosition";
            labelPosition.Size = new Size(51, 15);
            labelPosition.TabIndex = 11;
            labelPosition.Text = "Position";
            // 
            // textBoxSalary
            // 
            textBoxSalary.Location = new Point(17, 316);
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.Size = new Size(368, 23);
            textBoxSalary.TabIndex = 12;
            // 
            // labelSalary
            // 
            labelSalary.AutoSize = true;
            labelSalary.Location = new Point(17, 298);
            labelSalary.Name = "labelSalary";
            labelSalary.Size = new Size(38, 15);
            labelSalary.TabIndex = 13;
            labelSalary.Text = "Salary";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(17, 372);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(368, 23);
            textBoxPassword.TabIndex = 14;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(17, 354);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(57, 15);
            labelPassword.TabIndex = 15;
            labelPassword.Text = "Password";
            // 
            // EmployeeContent
            // 
            Controls.Add(panelEmployeeInfo);
            Controls.Add(rightPanel);
            Name = "EmployeeContent";
            Size = new Size(1119, 671);
            rightPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panelEmployeeInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewEmployees).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panel1;
        private Button addNewEmployee;
        private Panel panel2;
        private TextBox textBoxFirstName;
        private TextBox textBoxLastName;
        private TextBox textBoxEmail;
        private TextBox textBoxPhone;
        private ComboBox comboBoxPosition;
        private TextBox textBoxSalary;
        private TextBox textBoxPassword;
        private Label labelFirstName;
        private Label labelLastName;
        private Label labelEmail;
        private Label labelPhone;
        private Label labelPosition;
        private Label labelSalary;
        private Label labelPassword;
    }
}
