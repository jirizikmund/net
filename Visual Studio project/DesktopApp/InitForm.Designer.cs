﻿namespace zikmundj.DesktopApp
{
    partial class InitForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblInit
            // 
            this.lblInit.Location = new System.Drawing.Point(12, 9);
            this.lblInit.Name = "lblInit";
            this.lblInit.Size = new System.Drawing.Size(274, 55);
            this.lblInit.TabIndex = 0;
            this.lblInit.Text = "Initialization application...";
            this.lblInit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // InitForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 73);
            this.ControlBox = false;
            this.Controls.Add(this.lblInit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InitForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblInit;
    }
}