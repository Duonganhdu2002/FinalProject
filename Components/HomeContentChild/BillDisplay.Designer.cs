namespace FinalProject.Components
{
    partial class BillDisplay
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            button1 = new Button();
            panel1 = new Panel();
            thisPanelDisplayProductDetail = new FlowLayoutPanel();
            panel3 = new Panel();
            totalPriceOfBill = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.Green;
            button1.ForeColor = Color.White;
            button1.Location = new Point(-6, -15);
            button1.Name = "button1";
            button1.Size = new Size(435, 75);
            button1.TabIndex = 0;
            button1.Text = "Commit";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(button1);
            panel1.Location = new Point(14, 539);
            panel1.Name = "panel1";
            panel1.Size = new Size(417, 46);
            panel1.TabIndex = 1;
            // 
            // thisPanelDisplayProductDetail
            // 
            thisPanelDisplayProductDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            thisPanelDisplayProductDetail.AutoScroll = true;
            thisPanelDisplayProductDetail.BackColor = Color.White;
            thisPanelDisplayProductDetail.Location = new Point(14, 15);
            thisPanelDisplayProductDetail.Name = "thisPanelDisplayProductDetail";
            thisPanelDisplayProductDetail.Size = new Size(417, 457);
            thisPanelDisplayProductDetail.TabIndex = 2;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = SystemColors.Control;
            panel3.Controls.Add(totalPriceOfBill);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(14, 481);
            panel3.Name = "panel3";
            panel3.Size = new Size(417, 47);
            panel3.TabIndex = 3;
            // 
            // totalPriceOfBill
            // 
            totalPriceOfBill.AutoSize = true;
            totalPriceOfBill.Location = new Point(450, 16);
            totalPriceOfBill.Name = "totalPriceOfBill";
            totalPriceOfBill.Size = new Size(19, 15);
            totalPriceOfBill.TabIndex = 3;
            totalPriceOfBill.Text = "0$";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 16);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 3;
            label1.Text = "Total Price";
            // 
            // BillDisplay
            // 
            BackColor = Color.White;
            Controls.Add(panel3);
            Controls.Add(thisPanelDisplayProductDetail);
            Controls.Add(panel1);
            Name = "BillDisplay";
            Size = new Size(449, 599);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Panel panel1;
        private FlowLayoutPanel thisPanelDisplayProductDetail; // Changed to FlowLayoutPanel
        private Panel panel3;
        private Label totalPriceOfBill;
        private Label label1;
    }
}
