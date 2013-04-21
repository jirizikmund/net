using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zikmundj.CarExpenses;

namespace DesktopApp
{
    public partial class ExpensesForm : Form
    {
        private CarExpensesApp carExpensesApp;
        private User user;
        private Car selectedCar;

        private int totalGasCost = 0;
        private int totalServiceCost = 0;
        private int totalOtherCost = 0;

        //public const String currencyFormat = "#,##0.00 $;#,##0.00'-  $';0 $";
        //public const String currencyFormat = "N2";
        public const String currencyFormat = "C";

        public ExpensesForm(CarExpensesApp carExpensesApp, User user)
        {
            InitializeComponent();

            this.carExpensesApp = carExpensesApp;
            this.user = user;
            this.selectedCar = null;

            disableElements();
            reloadUserCars();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            carExpensesApp.logout();
            this.DialogResult = DialogResult.Abort;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void ExpensesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            carExpensesApp.logout();
            this.DialogResult = DialogResult.Abort;
        }

        private void reloadUserCars()
        {
            CarResponse carResponse = carExpensesApp.getUserCars();
            if (carResponse.success)
            {
                comboSelectCar.Items.Clear();
                foreach (Car car in carResponse.carList)
                {
                    comboSelectCar.Items.Add(car);
                }
            }
            btnExport.Enabled = carResponse.carList.Count > 1;
        }

        private void disableElements()
        {
            lblCarName.Text = "";
            lblCarYear.Text = "";
            lblCarPrice.Text = "";
            lblCarCosts.Text = "";
            lblCarTotal.Text = "";

            lblCarName.Visible = false;
            lblCarYear_.Visible = false;
            lblCarPrice_.Visible = false;
            lblCarCosts_.Visible = false;
            lblCarTotal_.Visible = false;

            lblNoCarSelected.Visible = true;

            lblGasCount_.Visible = false;
            lblGasCost_.Visible = false;
            lblGasLiters_.Visible = false;
            lblServiceCount_.Visible = false;
            lblServiceCost_.Visible = false;
            lblOtherCount_.Visible = false;
            lblOtherCost_.Visible = false;

            lblGasCount.Text = "";
            lblGasCost.Text = "";
            lblGasLiters.Text = "";
            lblServiceCount.Text = "";
            lblServiceCost.Text = "";
            lblOtherCount.Text = "";
            lblOtherCost.Text = "";

            btnAddGas.Visible = false;
            btnAddService.Visible = false;
            btnAddOtherExpense.Visible = false;
            btnCopy.Visible = false;

            tableGas.DataSource = null;
            tableService.DataSource = null;
            tableOtherExpense.DataSource = null;
        }

        private void enableElements()
        {
            lblNoCarSelected.Visible = false;

            lblCarName.Visible = true;
            lblCarYear_.Visible = true;
            lblCarPrice_.Visible = true;
            lblCarCosts_.Visible = true;
            lblCarTotal_.Visible = true;

            lblGasCount_.Visible = true;
            lblGasCost_.Visible = true;
            lblGasLiters_.Visible = true;
            lblServiceCount_.Visible = true;
            lblServiceCost_.Visible = true;
            lblOtherCount_.Visible = true;
            lblOtherCost_.Visible = true;

            btnAddGas.Visible = true;
            btnAddService.Visible = true;
            btnAddOtherExpense.Visible = true;
            btnCopy.Visible = true;
        }

        private void reloadCarInfo()
        {
            if (this.selectedCar == null)
            {
                MessageBox.Show("No car selected, gas info can't be loaded.");
                return;
            }
            lblCarName.Text = this.selectedCar.name;
            lblCarPrice.Text = this.selectedCar.cost.ToString(currencyFormat);
            lblCarYear.Text = this.selectedCar.boughtYear.ToString();
            lblCarTotal.Text = "";
            lblCarCosts.Text = "";
        }

        private void reloadGas()
        {
            if (this.selectedCar == null)
            {
                MessageBox.Show("No car selected, gas info can't be loaded.");
                return;
            }
            GasResponse gasResponse = carExpensesApp.getCarGasses(this.selectedCar.id);

            if (gasResponse.success == false) 
            {
                MessageBox.Show(gasResponse.message);
                return;
            }

            DataTable table = new DataTable();

            DataColumn colID = new DataColumn("ID");
            DataColumn colKm = new DataColumn("Km");
            DataColumn colLiters = new DataColumn("Liters");
            DataColumn colCost = new DataColumn("Cost");
            DataColumn colDate = new DataColumn("Date");

            colID.DataType = System.Type.GetType("System.Int32");
            colKm.DataType = System.Type.GetType("System.Int32");
            colLiters.DataType = System.Type.GetType("System.Double");
            colCost.DataType = System.Type.GetType("System.Int32");
            colDate.DataType = System.Type.GetType("System.DateTime");

            table.Columns.Add(colID);
            table.Columns.Add(colKm);
            table.Columns.Add(colLiters);
            table.Columns.Add(colCost);
            table.Columns.Add(colDate);

            this.totalGasCost = 0;
            foreach (Gas gas in gasResponse.gasList)
            {
                this.totalGasCost += gas.cost;

                DataRow row = table.NewRow();

                row[colID] = gas.id;
                row[colKm] = gas.km;
                row[colLiters] = gas.mililiters / 1000;
                row[colCost] = gas.cost;
                row[colDate] = gas.date;

                table.Rows.Add(row);
            }
            tableGas.DataSource = table;
            tableGas.Columns["ID"].Visible = false;
            selectAllRows(tableGas);

            reloadTotalCarCost();
        }

        private void reloadService()
        {
            if (this.selectedCar == null)
            {
                MessageBox.Show("No car selected, service info can't be loaded.");
                return;
            }
            ServiceResponse serviceResponse = carExpensesApp.getCarServices(this.selectedCar.id);

            if (serviceResponse.success == false)
            {
                MessageBox.Show(serviceResponse.message);
                return;
            }

            DataTable table = new DataTable();

            DataColumn colID = new DataColumn("ID");
            DataColumn colKm = new DataColumn("Km");
            DataColumn colCost = new DataColumn("Cost");
            DataColumn colDate = new DataColumn("Date");
            DataColumn colDescription = new DataColumn("Description");

            colID.DataType = System.Type.GetType("System.Int32");
            colKm.DataType = System.Type.GetType("System.Int32");
            colCost.DataType = System.Type.GetType("System.Int32");
            colDate.DataType = System.Type.GetType("System.DateTime");
            colDescription.DataType = System.Type.GetType("System.String");

            table.Columns.Add(colID);
            table.Columns.Add(colKm);
            table.Columns.Add(colCost);
            table.Columns.Add(colDate);
            table.Columns.Add(colDescription);

            this.totalServiceCost = 0;
            foreach (Service service in serviceResponse.serviceList)
            {
                this.totalServiceCost += service.cost;

                DataRow row = table.NewRow();

                row[colID] = service.id;
                row[colKm] = service.km;
                row[colCost] = service.cost;
                row[colDate] = service.date;
                row[colDescription] = service.description;

                table.Rows.Add(row);
            }
            tableService.DataSource = table;
            tableService.Columns["ID"].Visible = false;
            selectAllRows(tableService);

            reloadTotalCarCost();
        }

        private void reloadOtherExpense()
        {
            if (this.selectedCar == null)
            {
                MessageBox.Show("No car selected, other expense info can't be loaded.");
                return;
            }
            OtherExpenseResponse otherExpenseResponse = carExpensesApp.getCarOtherExpenses(this.selectedCar.id);

            if (otherExpenseResponse.success == false)
            {
                MessageBox.Show(otherExpenseResponse.message);
                return;
            }

            DataTable table = new DataTable();

            DataColumn colID = new DataColumn("ID");
            DataColumn colKm = new DataColumn("Km");
            DataColumn colCost = new DataColumn("Cost");
            DataColumn colDate = new DataColumn("Date");
            DataColumn colDescription = new DataColumn("Description");

            colID.DataType = System.Type.GetType("System.Int32");
            colKm.DataType = System.Type.GetType("System.Int32");
            colCost.DataType = System.Type.GetType("System.Int32");
            colDate.DataType = System.Type.GetType("System.DateTime");
            colDescription.DataType = System.Type.GetType("System.String");

            table.Columns.Add(colID);
            table.Columns.Add(colKm);
            table.Columns.Add(colCost);
            table.Columns.Add(colDate);
            table.Columns.Add(colDescription);

            this.totalOtherCost = 0;
            foreach (OtherExpense otherExpense in otherExpenseResponse.otherExpenseList)
            {
                this.totalOtherCost += otherExpense.cost;

                DataRow row = table.NewRow();

                row[colID] = otherExpense.id;
                row[colKm] = otherExpense.km;
                row[colCost] = otherExpense.cost;
                row[colDate] = otherExpense.date;
                row[colDescription] = otherExpense.description;

                table.Rows.Add(row);
            }
            tableOtherExpense.DataSource = table;
            tableOtherExpense.Columns["ID"].Visible = false;
            selectAllRows(tableService);
            reloadTotalCarCost();

        }

        private void btnAddNewCar_Click(object sender, EventArgs e)
        {
            using (AddNewCarForm addNewCarForm = new AddNewCarForm(carExpensesApp))
            {
                DialogResult dr = addNewCarForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    reloadUserCars();
                }
            }
        }

        private void comboSelectCar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedCar = (Car)comboSelectCar.SelectedItem;
            reloadCarInfo();
            reloadGas();
            reloadService();
            reloadOtherExpense();
            enableElements();
        }

        private void btnAddGas_Click(object sender, EventArgs e)
        {
            using (AddGasForm addGasForm = new AddGasForm(carExpensesApp, selectedCar))
            {
                DialogResult dr = addGasForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    reloadGas();
                }
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            using (AddServiceForm addServiceForm = new AddServiceForm(carExpensesApp, selectedCar))
            {
                DialogResult dr = addServiceForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    reloadService();
                }
            }
        }

        private void btnAddOtherExpense_Click(object sender, EventArgs e)
        {
            using (AddOtherExpenseForm addOtherExpenseForm = new AddOtherExpenseForm(carExpensesApp, selectedCar))
            {
                DialogResult dr = addOtherExpenseForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    reloadOtherExpense();
                }
            }
        }

        private void tableGas_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRowCount = tableGas.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (tableGas.AreAllCellsSelected(false))
                lblGasCount.Text = "ALL";
            else
                lblGasCount.Text = selectedRowCount.ToString() + " of " + tableGas.RowCount;

            int totalCost = 0;
            int totalLiters = 0;
            for (int i = 0; i < selectedRowCount; i++)
            {
                int pom;
                if (Int32.TryParse(tableGas.SelectedRows[i].Cells["Cost"].Value.ToString(), out pom))
                {
                    totalCost += pom;
                }
                if (Int32.TryParse(tableGas.SelectedRows[i].Cells["Liters"].Value.ToString(), out pom))
                {
                    totalLiters += pom;
                }
            }
            lblGasCost.Text = totalCost.ToString(currencyFormat);
            lblGasLiters.Text = totalLiters.ToString();
        }

        private void selectAllRows(DataGridView table)
        {
            int rowCount = table.RowCount;
            for (int i = 0; i < rowCount; i++)
            {
                table.Rows[i].Selected = true;
            }
        }

        private void reloadTotalCarCost()
        {
            int totalCost = totalGasCost + totalOtherCost + totalServiceCost;
            lblCarCosts.Text = totalCost.ToString(currencyFormat);
            lblCarTotal.Text = (totalCost + selectedCar.cost).ToString(currencyFormat);
        }

        private void tableService_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRowCount = tableService.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (tableService.AreAllCellsSelected(false))
                lblServiceCount.Text = "ALL";
            else
                lblServiceCount.Text = selectedRowCount.ToString() + " of " + tableService.RowCount;

            int totalCost = 0;
            for (int i = 0; i < selectedRowCount; i++)
            {
                int pom;
                if (Int32.TryParse(tableService.SelectedRows[i].Cells["Cost"].Value.ToString(), out pom))
                {
                    totalCost += pom;
                }
            }
            lblServiceCost.Text = totalCost.ToString(currencyFormat);
        }

        private void tableOtherExpense_SelectionChanged(object sender, EventArgs e)
        {
            int selectedRowCount = tableOtherExpense.Rows.GetRowCount(DataGridViewElementStates.Selected);

            if (tableOtherExpense.AreAllCellsSelected(false))
                lblOtherCount.Text = "ALL";
            else
                lblOtherCount.Text = selectedRowCount.ToString() + " of " + tableOtherExpense.RowCount;

            int totalCost = 0;
            for (int i = 0; i < selectedRowCount; i++)
            {
                int pom;
                if (Int32.TryParse(tableOtherExpense.SelectedRows[i].Cells["Cost"].Value.ToString(), out pom))
                {
                    totalCost += pom;
                }
            }
            lblOtherCost.Text = totalCost.ToString(currencyFormat);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (selectedCar == null)
            {
                MyMessage.ShowError("No car selected, info can't be copied to clipboard.");
                return;
            }
            string toClipboard = lblCarName.Text;
            toClipboard += ", bought " + lblCarYear.Text;
            toClipboard += ", price " + lblCarPrice.Text;
            toClipboard += ", cost " + lblCarCosts.Text;
            toClipboard += ", total " + lblCarTotal.Text + ".";
            Clipboard.SetText(toClipboard);

            MyMessage.ShowInfo("Info about car was copied to clipboard");
        }

        private void btnExportGas_Click(object sender, EventArgs e)
        {
            string fileName = XmlExport.exportToXml(carExpensesApp);
            MyMessage.ShowInfo("Your export was saved to file " + fileName);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit Car Expenses?", "Exit Car Expenses", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                carExpensesApp.logout();
                Application.Exit();
            }
        }
    }
}
