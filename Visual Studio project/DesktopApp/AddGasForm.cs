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

namespace zikmundj.DesktopApp
{
    /// <summary>
    /// Fomrulář pro přidání benzínu
    /// </summary>
    public partial class AddGasForm : Form
    {
        private CarExpensesApp carExpensesApp;
        private Car car;

        /// <summary>
        /// Konstruktor okna
        /// </summary>
        /// <param name="carExpensesApp">Instance jádra aplikace</param>
        /// <param name="car">Auto, ke kterému se benzín přidává</param>
        public AddGasForm(CarExpensesApp carExpensesApp, Car car)
        {
            InitializeComponent();
            this.carExpensesApp = carExpensesApp;
            this.car = car;
        }

        /// <summary>
        /// Validace údajů ve formuláři a přidání benzínu
        /// </summary>
        private bool addGas()
        {
            int km = 0;
            int liters = 0;
            int cost = 0;
            DateTime date;

            errorProvider.Clear();

            if (int.TryParse(txtKm.Text, out km) == false)
            {
                errorProvider.SetError(txtKm, "Km must be a number.");
                return false;
            }

            if (int.TryParse(txtLitres.Text, out liters) == false)
            {
                errorProvider.SetError(txtLitres, "Liters must be a number.");
                return false;
            }

            if (int.TryParse(txtCost.Text, out cost) == false)
            {
                errorProvider.SetError(txtCost, "Cost must be a number.");
                return false;
            }

            if (DateTime.TryParse(datePicker.Text, out date) == false)
            {
                errorProvider.SetError(datePicker, "Date has an invalid format.");
                return false;
            }

            Response response = carExpensesApp.addGas(car.id,km,liters, cost, date);

            if (response.success == false)
            {
                CarExpenseMessage.ShowError(response.message);
            }

            return response.success;
        }


        private void btnAddGas_Click(object sender, EventArgs e)
        {
            if (addGas())
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
