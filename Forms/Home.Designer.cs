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
            customTitleBar.Size = new Size(800, 30);
            customTitleBar.TabIndex = 0;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(customTitleBar);
            FormBorderStyle = FormBorderStyle.None;
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
