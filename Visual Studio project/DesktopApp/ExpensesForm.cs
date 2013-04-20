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
            if (MessageBox.Show("Do you really want to exit Car Expenses?", "Exit Car Expenses", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                carExpensesApp.logout();
                Application.Exit();
            }
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
                foreach (Car car in carResponse.carList)
                {
                    comboSelectCar.Items.Add(car);
                }
            }
        }

        private void disableElements()
        {
            lblCarName.Text = "<< select car";
            lblCarYear.Text = "";
            lblCarPrice.Text = "";
            lblCarCosts.Text = "";
            lblCarTotal.Text = "";

            lblGasCount.Text = "";
            lblGasCost.Text = "";
            lblGasLiters.Text = "";

            lblServiceCount.Text = "";
            lblServiceCost.Text = "";

            lblOtherCount.Text = "";
            lblOtherCost.Text = "";

            btnAddGas.Enabled = false;
            btnAddService.Enabled = false;
            btnAddOther.Enabled = false;
        }

        private void enableElements()
        {
            btnAddGas.Enabled = true;
            btnAddService.Enabled = true;
            btnAddOther.Enabled = true;
        }

        private void reloadCarInfo()
        {
            if (this.selectedCar == null)
            {
                MessageBox.Show("No car selected, gas info can't be loaded.");
                return;
            }
            lblCarName.Text = this.selectedCar.name;
            lblCarPrice.Text = this.selectedCar.cost.ToString();
            lblCarTotal.Text = "TODO !!!";
            lblCarCosts.Text = "TODO !!!";
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

            DataColumn colKm = new DataColumn("Km");
            DataColumn colLiters = new DataColumn("Liters");
            DataColumn colCost = new DataColumn("Cost");
            DataColumn colDate = new DataColumn("Date");

            colKm.DataType = System.Type.GetType("System.Int32");
            colLiters.DataType = System.Type.GetType("System.Double");
            colCost.DataType = System.Type.GetType("System.Int32");
            colDate.DataType = System.Type.GetType("System.DateTime");

            table.Columns.Add(colKm);
            table.Columns.Add(colLiters);
            table.Columns.Add(colCost);
            table.Columns.Add(colDate);
                
            foreach (Gas gas in gasResponse.gasList)
            {
                DataRow row = table.NewRow();

                row[colKm] = gas.km;
                row[colLiters] = gas.mililiters / 1000;
                row[colCost] = gas.cost;
                row[colDate] = gas.date;

                table.Rows.Add(row);
            }
            tableGas.DataSource = table;
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

            DataColumn colKm = new DataColumn("Km");
            DataColumn colCost = new DataColumn("Cost");
            DataColumn colDate = new DataColumn("Date");
            DataColumn colDescription = new DataColumn("Description");

            colKm.DataType = System.Type.GetType("System.Int32");
            colCost.DataType = System.Type.GetType("System.Int32");
            colDate.DataType = System.Type.GetType("System.DateTime");
            colDescription.DataType = System.Type.GetType("System.String");

            table.Columns.Add(colKm);
            table.Columns.Add(colCost);
            table.Columns.Add(colDate);
            table.Columns.Add(colDescription);

            foreach (Service service in serviceResponse.serviceList)
            {
                DataRow row = table.NewRow();

                row[colKm] = service.km;
                row[colCost] = service.cost;
                row[colDate] = service.date;
                row[colDescription] = service.description;

                table.Rows.Add(row);
            }
            tableService.DataSource = table;
        }

        private void btnAddNewCar_Click(object sender, EventArgs e)
        {

        }

        private void comboSelectCar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedCar = (Car)comboSelectCar.SelectedItem;
            reloadCarInfo();
            reloadGas();
            reloadService();
            enableElements();
        }
    }
}
