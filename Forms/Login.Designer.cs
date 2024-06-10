namespace FinalProject.Forms
{
    partial class Login
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

        private void InitializeComponent()
        {
            panel1 = new Panel();
            closeMinimize = new FinalProject.Components.Common.close_minmize(); // Thêm dòng này
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(closeMinimize); // Thêm dòng này
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 40);
            panel1.TabIndex = 0;
            // 
            // closeMinimize
            // 
            closeMinimize.Dock = DockStyle.Right; // Đặt vị trí bên phải
            closeMinimize.SetTargetForm(this); // Truyền form hiện tại vào close_minmize
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("#9Slide03 Cabin Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 7);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 0;
            label1.Text = "RESTRO POS";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("#9Slide03 Cabin Bold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(339, 138);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(113, 48);
            label2.TabIndex = 1;
            label2.Text = "LOGIN";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Font = new Font("#9Slide03 Cabin Bold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(318, 498);
            button1.Name = "button1";
            button1.Size = new Size(166, 42);
            button1.TabIndex = 2;
            button1.TabStop = false;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBox1.Font = new Font("#9Slide03 Cabin", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(211, 277);
            textBox1.Margin = new Padding(10);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(360, 40);
            textBox1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("#9Slide03 Cabin", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(211, 237);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(105, 25);
            label3.TabIndex = 4;
            label3.Text = "Enter your ID:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("#9Slide03 Cabin", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(211, 347);
            label4.Margin = new Padding(0);
            label4.Name = "label4";
            label4.Size = new Size(155, 25);
            label4.TabIndex = 6;
            label4.Text = "Enter your password:";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBox2.Font = new Font("#9Slide03 Cabin", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(211, 387);
            textBox2.Margin = new Padding(10);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(360, 40);
            textBox2.TabIndex = 5;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private FinalProject.Components.Common.close_minmize closeMinimize; // Thêm dòng này
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
    }
}
