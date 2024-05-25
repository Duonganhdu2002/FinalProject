using System;
using System.Drawing;
using System.Windows.Forms;
using FinalProject.Components;

namespace FinalProject.Forms
{
    partial class Home : Form
    {
        private System.ComponentModel.IContainer components = null;
        private CustomTitleBar customTitleBar;

        private void InitializeComponent()
        {
            this.customTitleBar = new CustomTitleBar("Home Title"); // Create an instance of CustomTitleBar
            SuspendLayout();
            // 
            // customTitleBar
            // 
            customTitleBar.BackColor = Color.FromArgb(255, 140, 0);
            customTitleBar.Location = new Point(0, 0);
            customTitleBar.Name = "customTitleBar";
            customTitleBar.Size = new Size(this.ClientSize.Width, 30);
            customTitleBar.TabIndex = 0;
            customTitleBar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right; // Ensure it resizes with the form
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            Controls.Add(customTitleBar);
            Name = "Home";
            Padding = new Padding(0, 30, 0, 0);
            Text = "Home";
            ResumeLayout(false);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
