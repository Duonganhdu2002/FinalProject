namespace FinalProject.Components
{
    partial class HomeContent
    {
        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            panel5 = new FlowLayoutPanel();
            panelProducts = new FlowLayoutPanel();
            panel1.SuspendLayout();
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
            panel2.Location = new Point(0, 65);
            panel2.Name = "panel2";
            panel2.Size = new Size(580, 551);
            panel2.TabIndex = 5;
            panel2.Paint += panel2_Paint;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.White;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(580, 59);
            panel4.TabIndex = 4;
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
            panel3.Paint += panel3_Paint;
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
            // HomeContent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel3);
            Controls.Add(panel1);
            Name = "HomeContent";
            Size = new Size(1148, 616);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private Panel panel3;
        private FlowLayoutPanel panel5; // Changed to FlowLayoutPanel
        private FlowLayoutPanel panelProducts; // Panel to display products
    }
}
