namespace FinalProject.Components
{
    partial class HomeContent
    {
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            panel8 = new Panel();
            totalPrice = new Label();
            label1 = new Label();
            panel9 = new Panel();
            processBtn = new Button();
            orderListPanel = new FlowLayoutPanel();
            panel4 = new Panel();
            panel6 = new Panel();
            button1 = new Button();
            panel7 = new Panel();
            numberOfProductOrdered = new Label();
            panel3 = new Panel();
            panel5 = new FlowLayoutPanel();
            panelProducts = new FlowLayoutPanel();
            nameOfProductOrdered = new Label();
            priceOfProductOrdered = new Label();
            deleteOrderedProductFromOrderListBtn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel8.SuspendLayout();
            panel9.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(568, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(580, 616);
            panel1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.White;
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(orderListPanel);
            panel2.Location = new Point(0, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(580, 551);
            panel2.TabIndex = 5;
            // 
            // panel8
            // 
            panel8.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel8.BackColor = SystemColors.Control;
            panel8.Controls.Add(totalPrice);
            panel8.Controls.Add(label1);
            panel8.Controls.Add(panel9);
            panel8.Location = new Point(13, 423);
            panel8.Name = "panel8";
            panel8.Size = new Size(552, 117);
            panel8.TabIndex = 1;
            // 
            // totalPrice
            // 
            totalPrice.AutoSize = true;
            totalPrice.BackColor = SystemColors.Control;
            totalPrice.Location = new Point(80, 24);
            totalPrice.Name = "totalPrice";
            totalPrice.Size = new Size(25, 15);
            totalPrice.TabIndex = 3;
            totalPrice.Text = "40$";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Location = new Point(18, 24);
            label1.Name = "label1";
            label1.Size = new Size(32, 15);
            label1.TabIndex = 2;
            label1.Text = "Total";
            // 
            // panel9
            // 
            panel9.Controls.Add(processBtn);
            panel9.Location = new Point(18, 61);
            panel9.Name = "panel9";
            panel9.Size = new Size(515, 42);
            panel9.TabIndex = 0;
            // 
            // processBtn
            // 
            processBtn.Location = new Point(-7, -12);
            processBtn.Name = "processBtn";
            processBtn.Size = new Size(530, 69);
            processBtn.TabIndex = 0;
            processBtn.Text = "Process";
            processBtn.UseVisualStyleBackColor = true;
            // 
            // orderListPanel
            // 
            orderListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            orderListPanel.AutoScroll = true;
            orderListPanel.Location = new Point(13, 14);
            orderListPanel.Name = "orderListPanel";
            orderListPanel.Size = new Size(552, 394);
            orderListPanel.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.White;
            panel4.Controls.Add(panel6);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(580, 59);
            panel4.TabIndex = 4;
            // 
            // panel6
            // 
            panel6.Controls.Add(button1);
            panel6.Location = new Point(12, 11);
            panel6.Name = "panel6";
            panel6.Size = new Size(189, 37);
            panel6.TabIndex = 0;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.Font = new Font("#9Slide03 Cabin Condensed", 11.249999F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(-11, -12);
            button1.Name = "button1";
            button1.Size = new Size(207, 61);
            button1.TabIndex = 1;
            button1.Text = "Add customer";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel7
            // 
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(200, 100);
            panel7.TabIndex = 0;
            // 
            // numberOfProductOrdered
            // 
            numberOfProductOrdered.Location = new Point(0, 0);
            numberOfProductOrdered.Name = "numberOfProductOrdered";
            numberOfProductOrdered.Size = new Size(100, 23);
            numberOfProductOrdered.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panelProducts);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(568, 616);
            panel3.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel5.AutoScroll = true;
            panel5.BackColor = Color.White;
            panel5.Location = new Point(16, 12);
            panel5.Name = "panel5";
            panel5.Size = new Size(537, 47);
            panel5.TabIndex = 2;
            panel5.WrapContents = false;
            // 
            // panelProducts
            // 
            panelProducts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelProducts.AutoScroll = true;
            panelProducts.Location = new Point(16, 65);
            panelProducts.Name = "panelProducts";
            panelProducts.Size = new Size(537, 540);
            panelProducts.TabIndex = 3;
            // 
            // nameOfProductOrdered
            // 
            nameOfProductOrdered.Location = new Point(0, 0);
            nameOfProductOrdered.Name = "nameOfProductOrdered";
            nameOfProductOrdered.Size = new Size(100, 23);
            nameOfProductOrdered.TabIndex = 0;
            // 
            // priceOfProductOrdered
            // 
            priceOfProductOrdered.Location = new Point(0, 0);
            priceOfProductOrdered.Name = "priceOfProductOrdered";
            priceOfProductOrdered.Size = new Size(100, 23);
            priceOfProductOrdered.TabIndex = 0;
            // 
            // deleteOrderedProductFromOrderListBtn
            // 
            deleteOrderedProductFromOrderListBtn.Location = new Point(0, 0);
            deleteOrderedProductFromOrderListBtn.Name = "deleteOrderedProductFromOrderListBtn";
            deleteOrderedProductFromOrderListBtn.Size = new Size(75, 23);
            deleteOrderedProductFromOrderListBtn.TabIndex = 0;
            // 
            // HomeContent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "HomeContent";
            Size = new Size(1148, 616);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel9.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private FlowLayoutPanel panel5; // Changed to FlowLayoutPanel
        private FlowLayoutPanel panelProducts; // Panel to display products
        private FlowLayoutPanel orderListPanel; // Panel to display order list
        private Button button1;
        private Panel panel6;
        private Panel panel7;
        private Label numberOfProductOrdered;
        private Button deleteOrderedProductFromOrderListBtn;
        private Label priceOfProductOrdered;
        private Label nameOfProductOrdered;
        private Panel panel8;
        private Label totalPrice;
        private Label label1;
        private Panel panel9;
        private Button processBtn;
    }
}
