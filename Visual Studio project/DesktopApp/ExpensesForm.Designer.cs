namespace DesktopApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpensesForm));
            this.btnLogout = new System.Windows.Forms.Button();
            this.comboSelectCar = new System.Windows.Forms.ComboBox();
            this.btnAddNewCar = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnAddGas = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableGas = new System.Windows.Forms.DataGridView();
            this.tableService = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblGasLiters = new System.Windows.Forms.Label();
            this.lblGasCost = new System.Windows.Forms.Label();
            this.lblGasCost_ = new System.Windows.Forms.Label();
            this.lblGasCount_ = new System.Windows.Forms.Label();
            this.lblGasLiters_ = new System.Windows.Forms.Label();
            this.lblGasCount = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblServiceCost = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblServiceCount = new System.Windows.Forms.Label();
            this.lblServiceCost_ = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblOtherCost = new System.Windows.Forms.Label();
            this.lblOtherCount_ = new System.Windows.Forms.Label();
            this.lblOtherCount = new System.Windows.Forms.Label();
            this.lblOtherCost_ = new System.Windows.Forms.Label();
            this.tableOtherExpense = new System.Windows.Forms.DataGridView();
            this.btnAddOtherExpense = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.lblCarName = new System.Windows.Forms.Label();
            this.lblCarYear_ = new System.Windows.Forms.Label();
            this.lblCarPrice_ = new System.Windows.Forms.Label();
            this.lblCarYear = new System.Windows.Forms.Label();
            this.lblCarPrice = new System.Windows.Forms.Label();
            this.lblCarTotal_ = new System.Windows.Forms.Label();
            this.lblCarCosts_ = new System.Windows.Forms.Label();
            this.lblCarTotal = new System.Windows.Forms.Label();
            this.lblCarCosts = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableGas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableService)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableOtherExpense)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(16, 253);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(121, 23);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // comboSelectCar
            // 
            this.comboSelectCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSelectCar.Location = new System.Drawing.Point(16, 23);
            this.comboSelectCar.Name = "comboSelectCar";
            this.comboSelectCar.Size = new System.Drawing.Size(121, 24);
            this.comboSelectCar.TabIndex = 1;
            this.comboSelectCar.SelectionChangeCommitted += new System.EventHandler(this.comboSelectCar_SelectionChangeCommitted);
            // 
            // btnAddNewCar
            // 
            this.btnAddNewCar.Location = new System.Drawing.Point(16, 209);
            this.btnAddNewCar.Name = "btnAddNewCar";
            this.btnAddNewCar.Size = new System.Drawing.Size(121, 24);
            this.btnAddNewCar.TabIndex = 2;
            this.btnAddNewCar.Text = "Add new car";
            this.btnAddNewCar.UseVisualStyleBackColor = true;
            this.btnAddNewCar.Click += new System.EventHandler(this.btnAddNewCar_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(16, 296);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(121, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAddService
            // 
            this.btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddService.Location = new System.Drawing.Point(224, 230);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(90, 24);
            this.btnAddService.TabIndex = 2;
            this.btnAddService.Text = "Add service";
            this.btnAddService.UseVisualStyleBackColor = true;
            // 
            // btnAddGas
            // 
            this.btnAddGas.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddGas.Location = new System.Drawing.Point(3, 230);
            this.btnAddGas.Name = "btnAddGas";
            this.btnAddGas.Size = new System.Drawing.Size(90, 24);
            this.btnAddGas.TabIndex = 2;
            this.btnAddGas.Text = "Add gas";
            this.btnAddGas.UseVisualStyleBackColor = true;
            this.btnAddGas.Click += new System.EventHandler(this.btnAddGas_Click);
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
            this.tableLayoutPanel1.Controls.Add(this.btnAddService, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableGas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableService, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAddGas, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableOtherExpense, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAddOtherExpense, 2, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(155, 136);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(665, 257);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableGas
            // 
            this.tableGas.AllowUserToAddRows = false;
            this.tableGas.AllowUserToDeleteRows = false;
            this.tableGas.AllowUserToOrderColumns = true;
            this.tableGas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableGas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tableGas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableGas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableGas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableGas.Location = new System.Drawing.Point(3, 73);
            this.tableGas.Name = "tableGas";
            this.tableGas.ReadOnly = true;
            this.tableGas.RowHeadersVisible = false;
            this.tableGas.RowHeadersWidth = 20;
            this.tableGas.RowTemplate.Height = 24;
            this.tableGas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableGas.Size = new System.Drawing.Size(215, 151);
            this.tableGas.TabIndex = 4;
            // 
            // tableService
            // 
            this.tableService.AllowUserToAddRows = false;
            this.tableService.AllowUserToDeleteRows = false;
            this.tableService.AllowUserToOrderColumns = true;
            this.tableService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tableService.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableService.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableService.Location = new System.Drawing.Point(224, 73);
            this.tableService.Name = "tableService";
            this.tableService.ReadOnly = true;
            this.tableService.RowHeadersVisible = false;
            this.tableService.RowHeadersWidth = 20;
            this.tableService.RowTemplate.Height = 24;
            this.tableService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableService.Size = new System.Drawing.Size(215, 151);
            this.tableService.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lblGasLiters);
            this.panel1.Controls.Add(this.lblGasCost);
            this.panel1.Controls.Add(this.lblGasCost_);
            this.panel1.Controls.Add(this.lblGasCount_);
            this.panel1.Controls.Add(this.lblGasLiters_);
            this.panel1.Controls.Add(this.lblGasCount);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 64);
            this.panel1.TabIndex = 5;
            // 
            // lblGasLiters
            // 
            this.lblGasLiters.AutoSize = true;
            this.lblGasLiters.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGasLiters.Location = new System.Drawing.Point(110, 24);
            this.lblGasLiters.Name = "lblGasLiters";
            this.lblGasLiters.Size = new System.Drawing.Size(49, 17);
            this.lblGasLiters.TabIndex = 8;
            this.lblGasLiters.Text = "1.342";
            // 
            // lblGasCost
            // 
            this.lblGasCost.AutoSize = true;
            this.lblGasCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGasCost.Location = new System.Drawing.Point(110, 41);
            this.lblGasCost.Name = "lblGasCost";
            this.lblGasCost.Size = new System.Drawing.Size(78, 17);
            this.lblGasCost.TabIndex = 8;
            this.lblGasCost.Text = "132.234,-";
            // 
            // lblGasCost_
            // 
            this.lblGasCost_.Location = new System.Drawing.Point(-3, 41);
            this.lblGasCost_.Name = "lblGasCost_";
            this.lblGasCost_.Size = new System.Drawing.Size(107, 17);
            this.lblGasCost_.TabIndex = 7;
            this.lblGasCost_.Text = "Selected cost:";
            // 
            // lblGasCount_
            // 
            this.lblGasCount_.Location = new System.Drawing.Point(-3, 7);
            this.lblGasCount_.Name = "lblGasCount_";
            this.lblGasCount_.Size = new System.Drawing.Size(107, 17);
            this.lblGasCount_.TabIndex = 7;
            this.lblGasCount_.Text = "Selected:";
            // 
            // lblGasLiters_
            // 
            this.lblGasLiters_.Location = new System.Drawing.Point(-3, 24);
            this.lblGasLiters_.Name = "lblGasLiters_";
            this.lblGasLiters_.Size = new System.Drawing.Size(107, 17);
            this.lblGasLiters_.TabIndex = 7;
            this.lblGasLiters_.Text = "Selected liters:";
            // 
            // lblGasCount
            // 
            this.lblGasCount.AutoSize = true;
            this.lblGasCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGasCount.Location = new System.Drawing.Point(110, 7);
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
            this.panel2.Controls.Add(this.lblServiceCost);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lblServiceCount);
            this.panel2.Controls.Add(this.lblServiceCost_);
            this.panel2.Location = new System.Drawing.Point(224, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 64);
            this.panel2.TabIndex = 5;
            // 
            // lblServiceCost
            // 
            this.lblServiceCost.AutoSize = true;
            this.lblServiceCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblServiceCost.Location = new System.Drawing.Point(110, 41);
            this.lblServiceCost.Name = "lblServiceCost";
            this.lblServiceCost.Size = new System.Drawing.Size(78, 17);
            this.lblServiceCost.TabIndex = 8;
            this.lblServiceCost.Text = "132.234,-";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(-3, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 17);
            this.label11.TabIndex = 7;
            this.label11.Text = "Selected:";
            // 
            // lblServiceCount
            // 
            this.lblServiceCount.AutoSize = true;
            this.lblServiceCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblServiceCount.Location = new System.Drawing.Point(110, 24);
            this.lblServiceCount.Name = "lblServiceCount";
            this.lblServiceCount.Size = new System.Drawing.Size(26, 17);
            this.lblServiceCount.TabIndex = 8;
            this.lblServiceCount.Text = "43";
            // 
            // lblServiceCost_
            // 
            this.lblServiceCost_.Location = new System.Drawing.Point(-3, 41);
            this.lblServiceCost_.Name = "lblServiceCost_";
            this.lblServiceCost_.Size = new System.Drawing.Size(107, 17);
            this.lblServiceCost_.TabIndex = 7;
            this.lblServiceCost_.Text = "Selected cost:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.lblOtherCost);
            this.panel3.Controls.Add(this.lblOtherCount_);
            this.panel3.Controls.Add(this.lblOtherCount);
            this.panel3.Controls.Add(this.lblOtherCost_);
            this.panel3.Location = new System.Drawing.Point(445, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(217, 64);
            this.panel3.TabIndex = 5;
            // 
            // lblOtherCost
            // 
            this.lblOtherCost.AutoSize = true;
            this.lblOtherCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOtherCost.Location = new System.Drawing.Point(110, 41);
            this.lblOtherCost.Name = "lblOtherCost";
            this.lblOtherCost.Size = new System.Drawing.Size(78, 17);
            this.lblOtherCost.TabIndex = 8;
            this.lblOtherCost.Text = "132.234,-";
            // 
            // lblOtherCount_
            // 
            this.lblOtherCount_.Location = new System.Drawing.Point(-3, 24);
            this.lblOtherCount_.Name = "lblOtherCount_";
            this.lblOtherCount_.Size = new System.Drawing.Size(107, 17);
            this.lblOtherCount_.TabIndex = 7;
            this.lblOtherCount_.Text = "Selected:";
            // 
            // lblOtherCount
            // 
            this.lblOtherCount.AutoSize = true;
            this.lblOtherCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblOtherCount.Location = new System.Drawing.Point(110, 24);
            this.lblOtherCount.Name = "lblOtherCount";
            this.lblOtherCount.Size = new System.Drawing.Size(26, 17);
            this.lblOtherCount.TabIndex = 8;
            this.lblOtherCount.Text = "43";
            // 
            // lblOtherCost_
            // 
            this.lblOtherCost_.Location = new System.Drawing.Point(-3, 41);
            this.lblOtherCost_.Name = "lblOtherCost_";
            this.lblOtherCost_.Size = new System.Drawing.Size(107, 17);
            this.lblOtherCost_.TabIndex = 7;
            this.lblOtherCost_.Text = "Selected cost:";
            // 
            // tableOtherExpense
            // 
            this.tableOtherExpense.AllowUserToAddRows = false;
            this.tableOtherExpense.AllowUserToDeleteRows = false;
            this.tableOtherExpense.AllowUserToOrderColumns = true;
            this.tableOtherExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableOtherExpense.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tableOtherExpense.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableOtherExpense.BackgroundColor = System.Drawing.SystemColors.Control;
            this.tableOtherExpense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tableOtherExpense.Location = new System.Drawing.Point(445, 73);
            this.tableOtherExpense.Name = "tableOtherExpense";
            this.tableOtherExpense.ReadOnly = true;
            this.tableOtherExpense.RowHeadersVisible = false;
            this.tableOtherExpense.RowHeadersWidth = 20;
            this.tableOtherExpense.RowTemplate.Height = 24;
            this.tableOtherExpense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableOtherExpense.Size = new System.Drawing.Size(217, 151);
            this.tableOtherExpense.TabIndex = 4;
            // 
            // btnAddOtherExpense
            // 
            this.btnAddOtherExpense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddOtherExpense.Location = new System.Drawing.Point(445, 230);
            this.btnAddOtherExpense.Name = "btnAddOtherExpense";
            this.btnAddOtherExpense.Size = new System.Drawing.Size(90, 24);
            this.btnAddOtherExpense.TabIndex = 2;
            this.btnAddOtherExpense.Text = "Add other";
            this.btnAddOtherExpense.UseVisualStyleBackColor = true;
            // 
            // lblCarName
            // 
            this.lblCarName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCarName.AutoEllipsis = true;
            this.lblCarName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCarName.Location = new System.Drawing.Point(153, 20);
            this.lblCarName.Name = "lblCarName";
            this.lblCarName.Size = new System.Drawing.Size(662, 29);
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
            this.lblCarTotal_.Location = new System.Drawing.Point(376, 66);
            this.lblCarTotal_.Name = "lblCarTotal_";
            this.lblCarTotal_.Size = new System.Drawing.Size(107, 17);
            this.lblCarTotal_.TabIndex = 7;
            this.lblCarTotal_.Text = "Total:";
            // 
            // lblCarCosts_
            // 
            this.lblCarCosts_.Location = new System.Drawing.Point(376, 49);
            this.lblCarCosts_.Name = "lblCarCosts_";
            this.lblCarCosts_.Size = new System.Drawing.Size(107, 17);
            this.lblCarCosts_.TabIndex = 7;
            this.lblCarCosts_.Text = "Costs:";
            // 
            // lblCarTotal
            // 
            this.lblCarTotal.AutoSize = true;
            this.lblCarTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCarTotal.ForeColor = System.Drawing.Color.Crimson;
            this.lblCarTotal.Location = new System.Drawing.Point(489, 66);
            this.lblCarTotal.Name = "lblCarTotal";
            this.lblCarTotal.Size = new System.Drawing.Size(92, 17);
            this.lblCarTotal.TabIndex = 8;
            this.lblCarTotal.Text = "1.233.322,-";
            // 
            // lblCarCosts
            // 
            this.lblCarCosts.AutoSize = true;
            this.lblCarCosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCarCosts.Location = new System.Drawing.Point(489, 49);
            this.lblCarCosts.Name = "lblCarCosts";
            this.lblCarCosts.Size = new System.Drawing.Size(78, 17);
            this.lblCarCosts.TabIndex = 8;
            this.lblCarCosts.Text = "135.500,-";
            // 
            // ExpensesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 405);
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
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 450);
            this.Name = "ExpensesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Car Expenses";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExpensesForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tableGas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableService)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableOtherExpense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox comboSelectCar;
        private System.Windows.Forms.Button btnAddNewCar;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnAddGas;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.HelpProvider helpProvider1;
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
        private System.Windows.Forms.Label label11;
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
    }
}