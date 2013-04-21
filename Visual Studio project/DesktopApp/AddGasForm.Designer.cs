namespace DesktopApp
{
    partial class AddGasForm
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
            this.components = new System.ComponentModel.Container();
            this.btnAddGas = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtKm = new System.Windows.Forms.TextBox();
            this.txtLitres = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.lblKm = new System.Windows.Forms.Label();
            this.lblLiters = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddGas
            // 
            this.btnAddGas.Location = new System.Drawing.Point(53, 191);
            this.btnAddGas.Name = "btnAddGas";
            this.btnAddGas.Size = new System.Drawing.Size(75, 23);
            this.btnAddGas.TabIndex = 5;
            this.btnAddGas.Text = "Add gas";
            this.btnAddGas.UseVisualStyleBackColor = true;
            this.btnAddGas.Click += new System.EventHandler(this.btnAddGas_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(168, 191);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtKm
            // 
            this.txtKm.Location = new System.Drawing.Point(143, 39);
            this.txtKm.Name = "txtKm";
            this.txtKm.Size = new System.Drawing.Size(100, 22);
            this.txtKm.TabIndex = 1;
            // 
            // txtLitres
            // 
            this.txtLitres.Location = new System.Drawing.Point(143, 67);
            this.txtLitres.Name = "txtLitres";
            this.txtLitres.Size = new System.Drawing.Size(100, 22);
            this.txtLitres.TabIndex = 2;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(143, 95);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(100, 22);
            this.txtCost.TabIndex = 3;
            // 
            // lblKm
            // 
            this.lblKm.AutoSize = true;
            this.lblKm.Location = new System.Drawing.Point(50, 42);
            this.lblKm.Name = "lblKm";
            this.lblKm.Size = new System.Drawing.Size(28, 17);
            this.lblKm.TabIndex = 2;
            this.lblKm.Text = "Km";
            // 
            // lblLiters
            // 
            this.lblLiters.AutoSize = true;
            this.lblLiters.Location = new System.Drawing.Point(50, 69);
            this.lblLiters.Name = "lblLiters";
            this.lblLiters.Size = new System.Drawing.Size(43, 17);
            this.lblLiters.TabIndex = 2;
            this.lblLiters.Text = "Liters";
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(50, 97);
            this.lblCost.Name = "lblCost";
            this.lblCost.Size = new System.Drawing.Size(36, 17);
            this.lblCost.TabIndex = 2;
            this.lblCost.Text = "Cost";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(50, 125);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(38, 17);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date";
            // 
            // datePicker
            // 
            this.datePicker.CustomFormat = "dd. MM. yyyy";
            this.datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.datePicker.Location = new System.Drawing.Point(143, 125);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(100, 22);
            this.datePicker.TabIndex = 4;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddGasForm
            // 
            this.AcceptButton = this.btnAddGas;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.ControlBox = false;
            this.Controls.Add(this.datePicker);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblLiters);
            this.Controls.Add(this.lblKm);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtLitres);
            this.Controls.Add(this.txtKm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddGas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "AddGasForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add gas";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddGas;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtKm;
        private System.Windows.Forms.TextBox txtLitres;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.Label lblKm;
        private System.Windows.Forms.Label lblLiters;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}