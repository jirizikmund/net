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
    public partial class AddNewCarForm : Form
    {
        private CarExpensesApp carExpensesApp;

        public AddNewCarForm(CarExpensesApp carExpensesApp)
        {
            InitializeComponent();
            this.carExpensesApp = carExpensesApp;
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            if (addNewCar())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool addNewCar()
        {
            int carModelId = 0;
            int boughtYear = 0;
            int cost = 0;

            errorProvider.Clear();

            if (txtName.Text == String.Empty)
            {
                errorProvider.SetError(txtName, "Name can't be empty.");
                return false;
            }

            if (int.TryParse(txtCost.Text, out cost) == false)
            {
                errorProvider.SetError(txtCost, "Cost must be a number.");
                return false;
            }

            if (int.TryParse(txtYear.Text, out boughtYear) == false)
            {
                errorProvider.SetError(txtYear, "Bought year has an invalid format.");
                return false;
            }

            Response response = carExpensesApp.addCar(carModelId, txtName.Text, boughtYear, cost);

            if (response.success == false)
            {
                MyMessage.ShowError(response.message);
            }

            return response.success;
        }
    }
}
