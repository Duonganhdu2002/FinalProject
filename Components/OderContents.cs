using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using FinalProject.Controllers;
using FinalProject.Models;

namespace FinalProject.Components
{
    public partial class OrderContent : UserControl
    {
        private OrderController orderController;
        private OrderDetailController orderDetailController;

        public OrderContent()
        {
            InitializeComponent();
            orderController = new OrderController();
            orderDetailController = new OrderDetailController();
            InitializeDataGridView();
            LoadOrders();
        }

        private void InitializeDataGridView()
        {
            dataGridViewOrders.AutoGenerateColumns = false;
            dataGridViewOrders.AllowUserToAddRows = false;
            dataGridViewOrders.AllowUserToDeleteRows = false;

            DataGridViewTextBoxColumn columnOrderID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderID",
                HeaderText = "Order ID",
                Name = "OrderID"
            };

            DataGridViewTextBoxColumn columnEmployeeID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "EmployeeID",
                HeaderText = "Employee ID",
                Name = "EmployeeID"
            };

            DataGridViewTextBoxColumn columnOrderDate = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "OrderDate",
                HeaderText = "Order Date",
                Name = "OrderDate"
            };

            DataGridViewTextBoxColumn columnCustomerID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CustomerID",
                HeaderText = "Customer ID",
                Name = "CustomerID"
            };

            DataGridViewTextBoxColumn columnTotalAmount = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "Total Amount",
                Name = "TotalAmount"
            };

            DataGridViewButtonColumn deleteButtonColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Name = "Delete"
            };

            dataGridViewOrders.Columns.AddRange(new DataGridViewColumn[]
            {
                columnOrderID, columnEmployeeID, columnOrderDate, columnCustomerID, columnTotalAmount, deleteButtonColumn
            });

            dataGridViewOrders.CellClick += DataGridViewOrders_CellClick;
        }

        private void LoadOrders()
        {
            List<Order> orders = orderController.GetAllOrders();
            dataGridViewOrders.DataSource = orders;
        }

        private void DataGridViewOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dgv = sender as DataGridView;

                if (dgv != null)
                {
                    if (dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dgv.Columns[e.ColumnIndex].Name == "Delete")
                    {
                        int orderId = (int)dgv.Rows[e.RowIndex].Cells["OrderID"].Value;
                        orderController.DeleteOrder(orderId);
                        LoadOrders();
                    }
                    else
                    {
                        int orderId = (int)dgv.Rows[e.RowIndex].Cells["OrderID"].Value;
                        DisplayOrderDetails(orderId);
                    }
                }
            }
        }

        private void DisplayOrderDetails(int orderId)
        {
            Order order = orderController.GetOrderById(orderId);
            if (order != null)
            {
                textBoxEmployeeID.Text = order.EmployeeID.ToString();
                textBoxCustomerID.Text = order.CustomerID.ToString();
                textBoxTotalAmount.Text = order.TotalAmount.ToString("C");
                dateTimePickerOrderDate.Value = order.OrderDate;

                List<OrderDetail> orderDetails = orderDetailController.GetAllOrderDetails().Where(od => od.OrderID == orderId).ToList();
                DisplayOrderDetailData(orderDetails);
            }
        }

        private void DisplayOrderDetailData(List<OrderDetail> orderDetails)
        {
            dataGridViewOrderDetails.Columns.Clear();
            dataGridViewOrderDetails.AutoGenerateColumns = false;

            DataGridViewTextBoxColumn columnProductID = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProductID",
                HeaderText = "Product ID",
                Name = "ProductID"
            };

            DataGridViewTextBoxColumn columnQuantity = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantity",
                HeaderText = "Quantity",
                Name = "Quantity"
            };

            DataGridViewTextBoxColumn columnUnitPrice = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "Unit Price",
                Name = "UnitPrice"
            };

            dataGridViewOrderDetails.Columns.AddRange(new DataGridViewColumn[]
            {
                columnProductID, columnQuantity, columnUnitPrice
            });

            dataGridViewOrderDetails.DataSource = orderDetails;
        }

        public void SearchOrders(string searchText)
        {
            List<Order> orders = orderController.SearchOrders(searchText);
            dataGridViewOrders.DataSource = orders;
        }

        public void ReloadOrders()
        {
            LoadOrders();
        }
    }
}
