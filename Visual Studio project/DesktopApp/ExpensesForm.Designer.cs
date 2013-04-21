namespace zikmundj.DesktopApp
{
    partial class ExpensesForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpensesForm));
            this.comboSelectCar = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddGas = new System.Windows.Forms.Button();
            this.tableGas = new System.Windows.Forms.DataGridView();
            this.tableService = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGasLiters = new System.Windows.Forms.Label();
            this.lblGasCost = new System.Windows.Forms.Label();
            this.lblGasLiters_ = new System.Windows.Forms.Label();
            this.lblGasCost_ = new System.Windows.Forms.Label();
            this.lblGasCount_ = new System.Windows.Forms.Label();
            this.lblGasCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblServiceCost = new System.Windows.Forms.Label();
            this.lblServiceCount_ = new System.Windows.Forms.Label();
            this.lblServiceCount = new System.Windows.Forms.Label();
            this.lblServiceCost_ = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblOtherCost = new System.Windows.Forms.Label();
            this.lblOtherCount_ = new System.Windows.Forms.Label();
            this.lblOtherCount = new System.Windows.Forms.Label();
            this.lblOtherCost_ = new System.Windows.Forms.Label();
            this.tableOtherExpense = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnAddService = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddOtherExpense = new System.Windows.Forms.Button();
            this.lblCarName = new System.Windows.Forms.Label();
            this.lblCarYear_ = new System.Windows.Forms.Label();
            this.lblCarPrice_ = new System.Windows.Forms.Label();
            this.lblCarYear = new System.Windows.Forms.Label();
            this.lblCarPrice = new System.Windows.Forms.Label();
            this.lblCarTotal_ = new System.Windows.Forms.Label();
            this.lblCarCosts_ = new System.Windows.Forms.Label();
            this.lblCarTotal = new System.Windows.Forms.Label();
            this.lblCarCosts = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnAddNewCar = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblNoCarSelected = new System.Windows.Forms.Label();
            this.btnExit = new zikmundj.CustomComponents.ColorButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableService)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableOtherExpense)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboSelectCar
            // 
            this.comboSelectCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelectCar.Location = new System.Drawing.Point(16, 22);
            this.comboSelectCar.Name = "comboSelectCar";
            this.comboSelectCar.Size = new System.Drawing.Size(121, 24);
            this.comboSelectCar.TabIndex = 0;
            this.comboSelectCar.SelectionChangeCommitted += new System.EventHandler(this.comboSelectCar_SelectionChangeCommitted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.30999F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.35001F));
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableGas, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableService, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableOtherExpense, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(155, 106);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(815, 287);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.btnAddGas);
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(265, 24);
            this.panel4.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(30, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "GAS";
            // 
            // btnAddGas
            // 
            this.btnAddGas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddGas.Image = global::zikmundj.DesktopApp.Properties.Resources.plus_16;
            this.btnAddGas.Location = new System.Drawing.Point(0, 0);
            this.btnAddGas.Name = "btnAddGas";
            this.btnAddGas.Size = new System.Drawing.Size(24, 24);
            this.btnAddGas.TabIndex = 6;
            this.btnAddGas.Text = " ";
            this.toolTip.SetToolTip(this.btnAddGas, "Add new gas for current car");
            this.btnAddGas.UseVisualStyleBackColor = true;
            this.btnAddGas.Click += new System.EventHandler(this.btnAddGas_Click);
            // 
            // tableGas
            // 
            this.tableGas.AllowUserToAddRows = false;
            this.tableGas.AllowUserToDeleteRows = false;
            this.tableGas.AllowUserToOrderColumns = true;
            this.tableGas.AllowUserToResizeRows = false;
            this.tableGas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableGas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableGas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableGas.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tableGas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableGas.DefaultCellStyle = dataGridViewCellStyle1;
            this.tableGas.GridColor = System.Drawing.SystemColors.Control;
            this.tableGas.Location = new System.Drawing.Point(3, 78);
            this.tableGas.Name = "tableGas";
            this.tableGas.ReadOnly = true;
            this.tableGas.RowHeadersVisible = false;
            this.tableGas.RowHeadersWidth = 20;
            this.tableGas.RowTemplate.Height = 24;
            this.tableGas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGas.Size = new System.Drawing.Size(265, 206);
            this.tableGas.TabIndex = 4;
            this.tableGas.SelectionChanged += new System.EventHandler(this.tableGas_SelectionChanged);
            // 
            // tableService
            // 
            this.tableService.AllowUserToAddRows = false;
            this.tableService.AllowUserToDeleteRows = false;
            this.tableService.AllowUserToOrderColumns = true;
            this.tableService.AllowUserToResizeRows = false;
            this.tableService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableService.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableService.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tableService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableService.DefaultCellStyle = dataGridViewCellStyle2;
            this.tableService.GridColor = System.Drawing.SystemColors.Control;
            this.tableService.Location = new System.Drawing.Point(274, 78);
            this.tableService.Name = "tableService";
            this.tableService.ReadOnly = true;
            this.tableService.RowHeadersVisible = false;
            this.tableService.RowHeadersWidth = 20;
            this.tableService.RowTemplate.Height = 24;
            this.tableService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableService.Size = new System.Drawing.Size(265, 206);
            this.tableService.TabIndex = 4;
            this.tableService.SelectionChanged += new System.EventHandler(this.tableService_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblGasLiters);
            this.panel1.Controls.Add(this.lblGasCost);
            this.panel1.Controls.Add(this.lblGasLiters_);
            this.panel1.Controls.Add(this.lblGasCost_);
            this.panel1.Controls.Add(this.lblGasCount_);
            this.panel1.Controls.Add(this.lblGasCount);
            this.panel1.Location = new System.Drawing.Point(3, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 39);
            this.panel1.TabIndex = 5;
            // 
            // lblGasLiters
            // 
            this.lblGasLiters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGasLiters.AutoSize = true;
            this.lblGasLiters.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGasLiters.Location = new System.Drawing.Point(202, 20);
            this.lblGasLiters.Name = "lblGasLiters";
            this.lblGasLiters.Size = new System.Drawing.Size(49, 17);
            this.lblGasLiters.TabIndex = 8;
            this.lblGasLiters.Text = "1.342";
            // 
            // lblGasCost
            // 
            this.lblGasCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGasCost.AutoSize = true;
            this.lblGasCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGasCost.Location = new System.Drawing.Point(79, 20);
            this.lblGasCost.Name = "lblGasCost";
            this.lblGasCost.Size = new System.Drawing.Size(78, 17);
            this.lblGasCost.TabIndex = 8;
            this.lblGasCost.Text = "132.234,-";
            // 
            // lblGasLiters_
            // 
            this.lblGasLiters_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGasLiters_.AutoSize = true;
            this.lblGasLiters_.Location = new System.Drawing.Point(202, 3);
            this.lblGasLiters_.Name = "lblGasLiters_";
            this.lblGasLiters_.Size = new System.Drawing.Size(47, 17);
            this.lblGasLiters_.TabIndex = 7;
            this.lblGasLiters_.Text = "Liters:";
            // 
            // lblGasCost_
            // 
            this.lblGasCost_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGasCost_.Location = new System.Drawing.Point(3, 20);
            this.lblGasCost_.Name = "lblGasCost_";
            this.lblGasCost_.Size = new System.Drawing.Size(50, 17);
            this.lblGasCost_.TabIndex = 7;
            this.lblGasCost_.Text = "Cost:";
            // 
            // lblGasCount_
            // 
            this.lblGasCount_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGasCount_.Location = new System.Drawing.Point(3, 3);
            this.lblGasCount_.Name = "lblGasCount_";
            this.lblGasCount_.Size = new System.Drawing.Size(70, 17);
            this.lblGasCount_.TabIndex = 7;
            this.lblGasCount_.Text = "Selected:";
            // 
            // lblGasCount
            // 
            this.lblGasCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGasCount.AutoSize = true;
            this.lblGasCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGasCount.Location = new System.Drawing.Point(79, 3);
            this.lblGasCount.Name = "lblGasCount";
            this.lblGasCount.Size = new System.Drawing.Size(26, 17);
            this.lblGasCount.TabIndex = 8;
            this.lblGasCount.Text = "43";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblServiceCost);
            this.panel2.Controls.Add(this.lblServiceCount_);
            this.panel2.Controls.Add(this.lblServiceCount);
            this.panel2.Controls.Add(this.lblServiceCost_);
            this.panel2.Location = new System.Drawing.Point(274, 33);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 39);
            this.panel2.TabIndex = 5;
            // 
            // lblServiceCost
            // 
            this.lblServiceCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServiceCost.AutoSize = true;
            this.lblServiceCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblServiceCost.Location = new System.Drawing.Point(79, 20);
            this.lblServiceCost.Name = "lblServiceCost";
            this.lblServiceCost.Size = new System.Drawing.Size(78, 17);
            this.lblServiceCost.TabIndex = 8;
            this.lblServiceCost.Text = "132.234,-";
            // 
            // lblServiceCount_
            // 
            this.lblServiceCount_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServiceCount_.Location = new System.Drawing.Point(3, 3);
            this.lblServiceCount_.Name = "lblServiceCount_";
            this.lblServiceCount_.Size = new System.Drawing.Size(70, 17);
            this.lblServiceCount_.TabIndex = 7;
            this.lblServiceCount_.Text = "Selected:";
            // 
            // lblServiceCount
            // 
            this.lblServiceCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServiceCount.AutoSize = true;
            this.lblServiceCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblServiceCount.Location = new System.Drawing.Point(79, 3);
            this.lblServiceCount.Name = "lblServiceCount";
            this.lblServiceCount.Size = new System.Drawing.Size(26, 17);
            this.lblServiceCount.TabIndex = 8;
            this.lblServiceCount.Text = "43";
            // 
            // lblServiceCost_
            // 
            this.lblServiceCost_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblServiceCost_.Location = new System.Drawing.Point(3, 20);
            this.lblServiceCost_.Name = "lblServiceCost_";
            this.lblServiceCost_.Size = new System.Drawing.Size(70, 17);
            this.lblServiceCost_.TabIndex = 7;
            this.lblServiceCost_.Text = "Cost:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lblOtherCost);
            this.panel3.Controls.Add(this.lblOtherCount_);
            this.panel3.Controls.Add(this.lblOtherCount);
            this.panel3.Controls.Add(this.lblOtherCost_);
            this.panel3.Location = new System.Drawing.Point(545, 33);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 39);
            this.panel3.TabIndex = 5;
            // 
            // lblOtherCost
            // 
            this.lblOtherCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOtherCost.AutoSize = true;
            this.lblOtherCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOtherCost.Location = new System.Drawing.Point(79, 20);
            this.lblOtherCost.Name = "lblOtherCost";
            this.lblOtherCost.Size = new System.Drawing.Size(78, 17);
            this.lblOtherCost.TabIndex = 8;
            this.lblOtherCost.Text = "132.234,-";
            // 
            // lblOtherCount_
            // 
            this.lblOtherCount_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOtherCount_.Location = new System.Drawing.Point(3, 3);
            this.lblOtherCount_.Name = "lblOtherCount_";
            this.lblOtherCount_.Size = new System.Drawing.Size(70, 17);
            this.lblOtherCount_.TabIndex = 7;
            this.lblOtherCount_.Text = "Selected:";
            // 
            // lblOtherCount
            // 
            this.lblOtherCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOtherCount.AutoSize = true;
            this.lblOtherCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOtherCount.Location = new System.Drawing.Point(79, 3);
            this.lblOtherCount.Name = "lblOtherCount";
            this.lblOtherCount.Size = new System.Drawing.Size(26, 17);
            this.lblOtherCount.TabIndex = 8;
            this.lblOtherCount.Text = "43";
            // 
            // lblOtherCost_
            // 
            this.lblOtherCost_.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOtherCost_.Location = new System.Drawing.Point(3, 20);
            this.lblOtherCost_.Name = "lblOtherCost_";
            this.lblOtherCost_.Size = new System.Drawing.Size(70, 17);
            this.lblOtherCost_.TabIndex = 7;
            this.lblOtherCost_.Text = "Cost:";
            // 
            // tableOtherExpense
            // 
            this.tableOtherExpense.AllowUserToAddRows = false;
            this.tableOtherExpense.AllowUserToDeleteRows = false;
            this.tableOtherExpense.AllowUserToOrderColumns = true;
            this.tableOtherExpense.AllowUserToResizeRows = false;
            this.tableOtherExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableOtherExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableOtherExpense.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableOtherExpense.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.tableOtherExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tableOtherExpense.DefaultCellStyle = dataGridViewCellStyle3;
            this.tableOtherExpense.GridColor = System.Drawing.SystemColors.Control;
            this.tableOtherExpense.Location = new System.Drawing.Point(545, 78);
            this.tableOtherExpense.Name = "tableOtherExpense";
            this.tableOtherExpense.ReadOnly = true;
            this.tableOtherExpense.RowHeadersVisible = false;
            this.tableOtherExpense.RowHeadersWidth = 20;
            this.tableOtherExpense.RowTemplate.Height = 24;
            this.tableOtherExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableOtherExpense.Size = new System.Drawing.Size(267, 206);
            this.tableOtherExpense.TabIndex = 4;
            this.tableOtherExpense.SelectionChanged += new System.EventHandler(this.tableOtherExpense_SelectionChanged);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.btnAddService);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(274, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(265, 24);
            this.panel5.TabIndex = 11;
            // 
            // btnAddService
            // 
            this.btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddService.Image = global::zikmundj.DesktopApp.Properties.Resources.plus_16;
            this.btnAddService.Location = new System.Drawing.Point(0, 0);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(24, 24);
            this.btnAddService.TabIndex = 7;
            this.toolTip.SetToolTip(this.btnAddService, "Add new service for current car");
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(30, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "SERVICE";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.btnAddOtherExpense);
            this.panel6.Location = new System.Drawing.Point(545, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(267, 24);
            this.panel6.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(30, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "OTHER";
            // 
            // btnAddOtherExpense
            // 
            this.btnAddOtherExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddOtherExpense.Image = global::zikmundj.DesktopApp.Properties.Resources.plus_16;
            this.btnAddOtherExpense.Location = new System.Drawing.Point(0, 0);
            this.btnAddOtherExpense.Name = "btnAddOtherExpense";
            this.btnAddOtherExpense.Size = new System.Drawing.Size(24, 24);
            this.btnAddOtherExpense.TabIndex = 8;
            this.toolTip.SetToolTip(this.btnAddOtherExpense, "Add other expense for current car");
            this.btnAddOtherExpense.UseVisualStyleBackColor = true;
            this.btnAddOtherExpense.Click += new System.EventHandler(this.btnAddOtherExpense_Click);
            // 
            // lblCarName
            // 
            this.lblCarName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarName.AutoEllipsis = true;
            this.lblCarName.AutoSize = true;
            this.lblCarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCarName.Location = new System.Drawing.Point(183, 20);
            this.lblCarName.Name = "lblCarName";
            this.lblCarName.Size = new System.Drawing.Size(272, 29);
            this.lblCarName.TabIndex = 7;
            this.lblCarName.Text = "Škoda Octavia 1.9 TDI";
            // 
            // lblCarYear_
            // 
            this.lblCarYear_.Location = new System.Drawing.Point(155, 49);
            this.lblCarYear_.Name = "lblCarYear_";
            this.lblCarYear_.Size = new System.Drawing.Size(107, 17);
            this.lblCarYear_.TabIndex = 7;
            this.lblCarYear_.Text = "Bought year:";
            // 
            // lblCarPrice_
            // 
            this.lblCarPrice_.Location = new System.Drawing.Point(155, 66);
            this.lblCarPrice_.Name = "lblCarPrice_";
            this.lblCarPrice_.Size = new System.Drawing.Size(107, 17);
            this.lblCarPrice_.TabIndex = 7;
            this.lblCarPrice_.Text = "Price:";
            // 
            // lblCarYear
            // 
            this.lblCarYear.AutoSize = true;
            this.lblCarYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCarYear.Location = new System.Drawing.Point(268, 49);
            this.lblCarYear.Name = "lblCarYear";
            this.lblCarYear.Size = new System.Drawing.Size(44, 17);
            this.lblCarYear.TabIndex = 8;
            this.lblCarYear.Text = "2008";
            // 
            // lblCarPrice
            // 
            this.lblCarPrice.AutoSize = true;
            this.lblCarPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCarPrice.Location = new System.Drawing.Point(268, 66);
            this.lblCarPrice.Name = "lblCarPrice";
            this.lblCarPrice.Size = new System.Drawing.Size(78, 17);
            this.lblCarPrice.TabIndex = 8;
            this.lblCarPrice.Text = "135.500,-";
            // 
            // lblCarTotal_
            // 
            this.lblCarTotal_.Location = new System.Drawing.Point(433, 66);
            this.lblCarTotal_.Name = "lblCarTotal_";
            this.lblCarTotal_.Size = new System.Drawing.Size(70, 17);
            this.lblCarTotal_.TabIndex = 7;
            this.lblCarTotal_.Text = "Total:";
            // 
            // lblCarCosts_
            // 
            this.lblCarCosts_.Location = new System.Drawing.Point(433, 49);
            this.lblCarCosts_.Name = "lblCarCosts_";
            this.lblCarCosts_.Size = new System.Drawing.Size(70, 17);
            this.lblCarCosts_.TabIndex = 7;
            this.lblCarCosts_.Text = "Costs:";
            // 
            // lblCarTotal
            // 
            this.lblCarTotal.AutoSize = true;
            this.lblCarTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCarTotal.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblCarTotal.Location = new System.Drawing.Point(509, 66);
            this.lblCarTotal.Name = "lblCarTotal";
            this.lblCarTotal.Size = new System.Drawing.Size(92, 17);
            this.lblCarTotal.TabIndex = 8;
            this.lblCarTotal.Text = "1.233.322,-";
            // 
            // lblCarCosts
            // 
            this.lblCarCosts.AutoSize = true;
            this.lblCarCosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCarCosts.Location = new System.Drawing.Point(509, 49);
            this.lblCarCosts.Name = "lblCarCosts";
            this.lblCarCosts.Size = new System.Drawing.Size(78, 17);
            this.lblCarCosts.TabIndex = 8;
            this.lblCarCosts.Text = "135.500,-";
            // 
            // btnCopy
            // 
            this.btnCopy.Image = global::zikmundj.DesktopApp.Properties.Resources.clipboard_16_bw;
            this.btnCopy.Location = new System.Drawing.Point(158, 22);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(24, 24);
            this.btnCopy.TabIndex = 5;
            this.toolTip.SetToolTip(this.btnCopy, "Copy info about selected car into clipboard");
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::zikmundj.DesktopApp.Properties.Resources.table_export_16_bw;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(16, 184);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(121, 26);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = " Export";
            this.toolTip.SetToolTip(this.btnExport, "Export all your user data into XML file");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExportGas_Click);
            // 
            // btnAddNewCar
            // 
            this.btnAddNewCar.Image = global::zikmundj.DesktopApp.Properties.Resources.plus_16_bw;
            this.btnAddNewCar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddNewCar.Location = new System.Drawing.Point(16, 229);
            this.btnAddNewCar.Name = "btnAddNewCar";
            this.btnAddNewCar.Size = new System.Drawing.Size(121, 26);
            this.btnAddNewCar.TabIndex = 2;
            this.btnAddNewCar.Text = "New car";
            this.toolTip.SetToolTip(this.btnAddNewCar, "Add new car");
            this.btnAddNewCar.UseVisualStyleBackColor = true;
            this.btnAddNewCar.Click += new System.EventHandler(this.btnAddNewCar_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Image = global::zikmundj.DesktopApp.Properties.Resources.logout_16_bw;
            this.btnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogout.Location = new System.Drawing.Point(16, 274);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(121, 26);
            this.btnLogout.TabIndex = 3;
            this.btnLogout.Text = "Logout";
            this.toolTip.SetToolTip(this.btnLogout, "Logout and go to welcome screen");
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // lblNoCarSelected
            // 
            this.lblNoCarSelected.AutoSize = true;
            this.lblNoCarSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNoCarSelected.Location = new System.Drawing.Point(158, 26);
            this.lblNoCarSelected.Name = "lblNoCarSelected";
            this.lblNoCarSelected.Size = new System.Drawing.Size(471, 17);
            this.lblNoCarSelected.TabIndex = 11;
            this.lblNoCarSelected.Text = "<<   No car is selected. Please select the car or add a new one.";
            this.lblNoCarSelected.Visible = false;
            // 
            // btnExit
            // 
            this.btnExit.ColorLeft = System.Drawing.SystemColors.Control;
            this.btnExit.ColorLeftTransparency = 50;
            this.btnExit.ColorRight = System.Drawing.Color.OrangeRed;
            this.btnExit.ColorRightTransparency = 20;
            this.btnExit.Image = global::zikmundj.DesktopApp.Properties.Resources.exit_16;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(16, 319);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(121, 26);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click_1);
            // 
            // ExpensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 405);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblCarCosts);
            this.Controls.Add(this.lblCarTotal);
            this.Controls.Add(this.lblCarPrice);
            this.Controls.Add(this.lblCarCosts_);
            this.Controls.Add(this.lblCarYear);
            this.Controls.Add(this.lblCarTotal_);
            this.Controls.Add(this.lblCarPrice_);
            this.Controls.Add(this.lblCarYear_);
            this.Controls.Add(this.lblCarName);
            this.Controls.Add(this.comboSelectCar);
            this.Controls.Add(this.btnAddNewCar);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblNoCarSelected);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1000, 450);
            this.Name = "ExpensesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Expenses";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExpensesForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableService)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableOtherExpense)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox comboSelectCar;
        private System.Windows.Forms.Button btnAddNewCar;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnAddGas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView tableGas;
        private System.Windows.Forms.DataGridView tableService;
        private System.Windows.Forms.Label lblCarName;
        private System.Windows.Forms.Label lblCarYear_;
        private System.Windows.Forms.Label lblCarPrice_;
        private System.Windows.Forms.Label lblCarYear;
        private System.Windows.Forms.Label lblCarPrice;
        private System.Windows.Forms.Label lblGasCost_;
        private System.Windows.Forms.Label lblGasCost;
        private System.Windows.Forms.Label lblServiceCost_;
        private System.Windows.Forms.Label lblGasLiters_;
        private System.Windows.Forms.Label lblServiceCost;
        private System.Windows.Forms.Label lblGasLiters;
        private System.Windows.Forms.Label lblGasCount_;
        private System.Windows.Forms.Label lblGasCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblServiceCount_;
        private System.Windows.Forms.Label lblServiceCount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblCarTotal_;
        private System.Windows.Forms.Label lblCarCosts_;
        private System.Windows.Forms.Label lblCarTotal;
        private System.Windows.Forms.Label lblCarCosts;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblOtherCost;
        private System.Windows.Forms.Label lblOtherCount_;
        private System.Windows.Forms.Label lblOtherCount;
        private System.Windows.Forms.Label lblOtherCost_;
        private System.Windows.Forms.DataGridView tableOtherExpense;
        private System.Windows.Forms.Button btnAddOtherExpense;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblNoCarSelected;
        private zikmundj.CustomComponents.ColorButton btnExit;
    }
}