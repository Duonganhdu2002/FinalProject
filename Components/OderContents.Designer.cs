namespace FinalProject.Components
{
    partial class OrderContent
    {
        private System.ComponentModel.IContainer components = null;

        private Panel rightPanel;
        private Panel panelOrderInfo;
        private DataGridView dataGridViewOrders;
        private DataGridView dataGridViewOrderDetails;

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
            labelOrderDetails = new Label();
            dataGridViewOrderDetails = new DataGridView();
            labelEmployeeID = new Label();
            textBoxEmployeeID = new TextBox();
            labelOrderDate = new Label();
            dateTimePickerOrderDate = new DateTimePicker();
            labelCustomerID = new Label();
            textBoxCustomerID = new TextBox();
            labelTotalAmount = new Label();
            textBoxTotalAmount = new TextBox();
            panelOrderInfo = new Panel();
            dataGridViewOrders = new DataGridView();
            panel2 = new Panel();
            rightPanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderDetails).BeginInit();
            panelOrderInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).BeginInit();
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
            panel1.Controls.Add(labelOrderDetails);
            panel1.Controls.Add(dataGridViewOrderDetails);
            panel1.Controls.Add(labelEmployeeID);
            panel1.Controls.Add(textBoxEmployeeID);
            panel1.Controls.Add(labelOrderDate);
            panel1.Controls.Add(dateTimePickerOrderDate);
            panel1.Controls.Add(labelCustomerID);
            panel1.Controls.Add(textBoxCustomerID);
            panel1.Controls.Add(labelTotalAmount);
            panel1.Controls.Add(textBoxTotalAmount);
            panel1.Location = new Point(18, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(400, 629);
            panel1.TabIndex = 0;
            // 
            // labelOrderDetails
            // 
            labelOrderDetails.AutoSize = true;
            labelOrderDetails.Location = new Point(17, 242);
            labelOrderDetails.Name = "labelOrderDetails";
            labelOrderDetails.Size = new Size(75, 15);
            labelOrderDetails.TabIndex = 11;
            labelOrderDetails.Text = "Order Details";
            // 
            // dataGridViewOrderDetails
            // 
            dataGridViewOrderDetails.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewOrderDetails.BackgroundColor = Color.White;
            dataGridViewOrderDetails.BorderStyle = BorderStyle.None;
            dataGridViewOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrderDetails.Location = new Point(17, 260);
            dataGridViewOrderDetails.Name = "dataGridViewOrderDetails";
            dataGridViewOrderDetails.Size = new Size(368, 349);
            dataGridViewOrderDetails.TabIndex = 10;
            // 
            // labelEmployeeID
            // 
            labelEmployeeID.AutoSize = true;
            labelEmployeeID.Location = new Point(17, 18);
            labelEmployeeID.Name = "labelEmployeeID";
            labelEmployeeID.Size = new Size(73, 15);
            labelEmployeeID.TabIndex = 3;
            labelEmployeeID.Text = "Employee ID";
            // 
            // textBoxEmployeeID
            // 
            textBoxEmployeeID.Location = new Point(17, 36);
            textBoxEmployeeID.Name = "textBoxEmployeeID";
            textBoxEmployeeID.ReadOnly = true;
            textBoxEmployeeID.Size = new Size(368, 23);
            textBoxEmployeeID.TabIndex = 2;
            // 
            // labelOrderDate
            // 
            labelOrderDate.AutoSize = true;
            labelOrderDate.Location = new Point(17, 186);
            labelOrderDate.Name = "labelOrderDate";
            labelOrderDate.Size = new Size(64, 15);
            labelOrderDate.TabIndex = 9;
            labelOrderDate.Text = "Order Date";
            // 
            // dateTimePickerOrderDate
            // 
            dateTimePickerOrderDate.Enabled = false;
            dateTimePickerOrderDate.Location = new Point(17, 204);
            dateTimePickerOrderDate.Name = "dateTimePickerOrderDate";
            dateTimePickerOrderDate.Size = new Size(368, 23);
            dateTimePickerOrderDate.TabIndex = 8;
            // 
            // labelCustomerID
            // 
            labelCustomerID.AutoSize = true;
            labelCustomerID.Location = new Point(17, 74);
            labelCustomerID.Name = "labelCustomerID";
            labelCustomerID.Size = new Size(73, 15);
            labelCustomerID.TabIndex = 5;
            labelCustomerID.Text = "Customer ID";
            // 
            // textBoxCustomerID
            // 
            textBoxCustomerID.Location = new Point(17, 92);
            textBoxCustomerID.Name = "textBoxCustomerID";
            textBoxCustomerID.ReadOnly = true;
            textBoxCustomerID.Size = new Size(368, 23);
            textBoxCustomerID.TabIndex = 4;
            // 
            // labelTotalAmount
            // 
            labelTotalAmount.AutoSize = true;
            labelTotalAmount.Location = new Point(17, 130);
            labelTotalAmount.Name = "labelTotalAmount";
            labelTotalAmount.Size = new Size(79, 15);
            labelTotalAmount.TabIndex = 7;
            labelTotalAmount.Text = "Total Amount";
            // 
            // textBoxTotalAmount
            // 
            textBoxTotalAmount.Location = new Point(17, 148);
            textBoxTotalAmount.Name = "textBoxTotalAmount";
            textBoxTotalAmount.ReadOnly = true;
            textBoxTotalAmount.Size = new Size(368, 23);
            textBoxTotalAmount.TabIndex = 6;
            // 
            // panelOrderInfo
            // 
            panelOrderInfo.BackColor = SystemColors.Control;
            panelOrderInfo.Controls.Add(dataGridViewOrders);
            panelOrderInfo.Dock = DockStyle.Fill;
            panelOrderInfo.Location = new Point(0, 0);
            panelOrderInfo.Name = "panelOrderInfo";
            panelOrderInfo.Size = new Size(683, 671);
            panelOrderInfo.TabIndex = 0;
            // 
            // dataGridViewOrders
            // 
            dataGridViewOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewOrders.BackgroundColor = Color.White;
            dataGridViewOrders.BorderStyle = BorderStyle.None;
            dataGridViewOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewOrders.Location = new Point(15, 16);
            dataGridViewOrders.Name = "dataGridViewOrders";
            dataGridViewOrders.Size = new Size(650, 629);
            dataGridViewOrders.TabIndex = 0;
            dataGridViewOrders.CellClick += DataGridViewOrders_CellClick;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Location = new Point(17, 564);
            panel2.Name = "panel2";
            panel2.Size = new Size(368, 47);
            panel2.TabIndex = 1;
            // 
            // OrderContent
            // 
            Controls.Add(panelOrderInfo);
            Controls.Add(rightPanel);
            Name = "OrderContent";
            Size = new Size(1119, 671);
            rightPanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrderDetails).EndInit();
            panelOrderInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewOrders).EndInit();
            ResumeLayout(false);
        }

        private Panel panel1;
        private Panel panel2;
        private TextBox textBoxEmployeeID;
        private TextBox textBoxCustomerID;
        private TextBox textBoxTotalAmount;
        private DateTimePicker dateTimePickerOrderDate;
        private Label labelEmployeeID;
        private Label labelOrderDate;
        private Label labelCustomerID;
        private Label labelTotalAmount;
        private Label labelOrderDetails;
    }
}
