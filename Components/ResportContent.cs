using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using FinalProject.Controllers;

namespace FinalProject.Components
{
    public partial class ResportContent : UserControl
    {
        private OrderController orderController;
        private TableLayoutPanel tableLayoutPanel;

        public ResportContent()
        {
            InitializeComponent();
            orderController = new OrderController();
            InitializeTableLayoutPanel();
            LoadCharts();
        }

        private void InitializeTableLayoutPanel()
        {
            tableLayoutPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
                RowCount = 2,
                AutoSize = true
            };

            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));

            this.Controls.Add(tableLayoutPanel);
        }

        private void LoadCharts()
        {
            LoadDailyRevenueChart();
            LoadMonthlyRevenueChart();
            LoadDailyOrderCountChart();
            LoadMonthlyOrderCountChart();
        }

        private void LoadDailyRevenueChart()
        {
            var dailyRevenue = orderController.GetDailyRevenue();

            Chart dailyRevenueChart = new Chart();
            dailyRevenueChart.Dock = DockStyle.Fill;
            dailyRevenueChart.Titles.Add("Daily Revenue");

            ChartArea chartArea = new ChartArea();
            dailyRevenueChart.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.DateTime;
            dailyRevenueChart.Series.Add(series);

            foreach (var item in dailyRevenue)
            {
                series.Points.AddXY(item.Date, item.Revenue);
            }

            tableLayoutPanel.Controls.Add(dailyRevenueChart, 0, 0);
        }

        private void LoadMonthlyRevenueChart()
        {
            var monthlyRevenue = orderController.GetMonthlyRevenue();

            Chart monthlyRevenueChart = new Chart();
            monthlyRevenueChart.Dock = DockStyle.Fill;
            monthlyRevenueChart.Titles.Add("Monthly Revenue");

            ChartArea chartArea = new ChartArea();
            monthlyRevenueChart.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            series.XValueType = ChartValueType.Int32;
            monthlyRevenueChart.Series.Add(series);

            foreach (var item in monthlyRevenue)
            {
                series.Points.AddXY($"{item.Month}/{item.Year}", item.Revenue);
            }

            tableLayoutPanel.Controls.Add(monthlyRevenueChart, 1, 0);
        }

        private void LoadDailyOrderCountChart()
        {
            var dailyOrderCount = orderController.GetDailyOrderCount();

            Chart dailyOrderCountChart = new Chart();
            dailyOrderCountChart.Dock = DockStyle.Fill;
            dailyOrderCountChart.Titles.Add("Daily Order Count");

            ChartArea chartArea = new ChartArea();
            dailyOrderCountChart.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.ChartType = SeriesChartType.Line;
            series.XValueType = ChartValueType.DateTime;
            dailyOrderCountChart.Series.Add(series);

            foreach (var item in dailyOrderCount)
            {
                series.Points.AddXY(item.Date, item.OrderCount);
            }

            tableLayoutPanel.Controls.Add(dailyOrderCountChart, 0, 1);
        }

        private void LoadMonthlyOrderCountChart()
        {
            var monthlyOrderCount = orderController.GetMonthlyOrderCount();

            Chart monthlyOrderCountChart = new Chart();
            monthlyOrderCountChart.Dock = DockStyle.Fill;
            monthlyOrderCountChart.Titles.Add("Monthly Order Count");

            ChartArea chartArea = new ChartArea();
            monthlyOrderCountChart.ChartAreas.Add(chartArea);

            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            series.XValueType = ChartValueType.Int32;
            monthlyOrderCountChart.Series.Add(series);

            foreach (var item in monthlyOrderCount)
            {
                series.Points.AddXY($"{item.Month}/{item.Year}", item.OrderCount);
            }

            tableLayoutPanel.Controls.Add(monthlyOrderCountChart, 1, 1);
        }
    }
}
