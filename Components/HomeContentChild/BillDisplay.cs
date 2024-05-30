using System.Windows.Forms;

namespace FinalProject.Components
{
    public partial class BillDisplay : UserControl
    {
        public BillDisplay()
        {
            InitializeComponent();
        }

        public Button CommitButton => button1;

        public void AddProductToBill(string productName, int quantity, decimal totalPrice)
        {
            Panel productPanel = new Panel
            {
                BackColor = SystemColors.Control,
                Size = new Size(thisPanelDisplayProductDetail.Width, 43),
                Margin = new Padding(0, 0, 0, 10) 
            };

            Label productNameLabel = new Label
            {
                Text = productName,
                Location = new Point(13, 13),
                AutoSize = true
            };

            Label productQuantityLabel = new Label
            {
                Text = quantity.ToString(),
                Location = new Point(350, 13),
                AutoSize = true
            };

            Label x = new Label
            {
                Text = "x",
                Location = new Point(400, 13),
                AutoSize = true
            };

            Label productTotalPriceLabel = new Label
            {
                Text = $"{totalPrice:C}",
                Location = new Point(450, 13),
                AutoSize = true
            };

            productPanel.Controls.Add(productNameLabel);
            productPanel.Controls.Add(x);
            productPanel.Controls.Add(productQuantityLabel);
            productPanel.Controls.Add(productTotalPriceLabel);

            thisPanelDisplayProductDetail.Controls.Add(productPanel);
        }

        public void SetTotalPrice(decimal totalPrice)
        {
            totalPriceOfBill.Text = $"{totalPrice:C}";
        }

        private void BillDisplay_Load(object sender, EventArgs e)
        {
            // Clear previous controls
            thisPanelDisplayProductDetail.Controls.Clear();
        }
    }
}
