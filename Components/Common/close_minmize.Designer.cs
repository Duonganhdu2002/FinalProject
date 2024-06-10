namespace FinalProject.Components.Common
{
    partial class close_minmize
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(close_minmize));
            panel1 = new Panel();
            panelButton2 = new Panel();
            button2 = new Button();
            panelButton1 = new Panel();
            button1 = new Button();
            panel1.SuspendLayout();
            panelButton2.SuspendLayout();
            panelButton1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panelButton2);
            panel1.Controls.Add(panelButton1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(100, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(70, 30);
            panel1.TabIndex = 0;
            // 
            // panelButton2
            // 
            panelButton2.Controls.Add(button2);
            panelButton2.Location = new Point(36, 3);
            panelButton2.Name = "panelButton2";
            panelButton2.Size = new Size(30, 30);
            panelButton2.TabIndex = 2;
            // 
            // button2
            // 
            button2.ForeColor = SystemColors.ControlText;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(-2, -6);
            button2.Name = "button2";
            button2.Size = new Size(35, 38);
            button2.TabIndex = 1;
            button2.UseVisualStyleBackColor = true;
            button2.Click += CloseButton_Click;
            // 
            // panelButton1
            // 
            panelButton1.Controls.Add(button1);
            panelButton1.Location = new Point(3, 3);
            panelButton1.Name = "panelButton1";
            panelButton1.Size = new Size(30, 30);
            panelButton1.TabIndex = 1;
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ControlText;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(-4, -8);
            button1.Name = "button1";
            button1.Size = new Size(40, 43);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += MinimizeButton_Click;
            // 
            // close_minmize
            // 
            Controls.Add(panel1);
            Name = "close_minmize";
            Size = new Size(170, 30);
            panel1.ResumeLayout(false);
            panelButton2.ResumeLayout(false);
            panelButton1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelButton1;
        private System.Windows.Forms.Panel panelButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}
