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
                    cmbxSelectCar.Items.Add(car);
                }
            }
        }

        private void disableElements()
        {

        }

        private void reloadCarGas()
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

                //Create columns for DataTable
            DataColumn colId = new DataColumn("Id");
            DataColumn colKm = new DataColumn("Km");
            DataColumn colLiters = new DataColumn("Liters");
            DataColumn colCost = new DataColumn("Cost");
            DataColumn colDate = new DataColumn("Date");
                //Define DataType of the Columns
            colId.DataType = System.Type.GetType("System.Int32");
            colKm.DataType = System.Type.GetType("System.Int32");
            colLiters.DataType = System.Type.GetType("System.Double");
            colCost.DataType = System.Type.GetType("System.Int32");
            colDate.DataType = System.Type.GetType("System.DateTime");
                //Add All These Columns into DataTable table
            table.Columns.Add(colId);
            table.Columns.Add(colKm);
            table.Columns.Add(colLiters);
            table.Columns.Add(colCost);
            table.Columns.Add(colDate);
                
            foreach (Gas gas in gasResponse.gasList)
            {
                    //Create a Row in the DataTable table
                DataRow row = table.NewRow();
                    //Fill All Columns with Data
                row[colId] = gas.id;
                row[colKm] = gas.km;
                row[colLiters] = gas.mililiters / 1000;
                row[colCost] = gas.cost;
                row[colDate] = gas.date;
                    //Add the Row into DataTable
                table.Rows.Add(row);
            }
                //Bind DataTable to a GridView
            tableGas.DataSource = table;
        }

        private void btnAddNewCar_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbxSelectCar_SelectionChangeCommitted(object sender, EventArgs e)
        {
            selectedCar = (Car)cmbxSelectCar.SelectedItem;
            reloadCarGas();
        }

        private void ExpensesForm_Load(object sender, EventArgs e)
        {

        }
    }
}
