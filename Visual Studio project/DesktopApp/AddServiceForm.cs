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
    /// Fomrulář pro přidání opravy
    /// </summary>
    public partial class AddServiceForm : Form
    {
        private CarExpensesApp carExpensesApp;
        private Car car;

        /// <summary>
        /// Konstruktor okna
        /// </summary>
        /// <param name="carExpensesApp">Instance jádra aplikace</param>
        /// <param name="car">Auto, ke kterému se oprava přidává</param>
        public AddServiceForm(CarExpensesApp carExpensesApp, Car car)
        {
            InitializeComponent();
            this.carExpensesApp = carExpensesApp;
            this.car = car;
        }

        /// <summary>
        /// Validace údajů ve formuláři a přidání opravy
        /// </summary>
        private bool addService()
        {
            int km = 0;
            int cost = 0;
            int serviceTypeId = 0;
            DateTime date;

            errorProvider.Clear();

            if (int.TryParse(txtKm.Text, out km) == false)
            {
                errorProvider.SetError(txtKm, "Km must be a number.");
                return false;
            }

            if (txtDescription.Text == String.Empty)
            {
                errorProvider.SetError(txtDescription, "Description can't be empty.");
                return false;
            }

            if (int.TryParse(txtCost.Text, out cost) == false)
            {
                errorProvider.SetError(txtCost, "Cost must be a number.");
                return false;
            }

            if (DateTime.TryParse(txtDate.Text, out date) == false)
            {
                errorProvider.SetError(txtDate, "Date has an invalid format.");
                return false;
            }

            Response response = carExpensesApp.addService(car.id, km, cost, serviceTypeId, txtDescription.Text, date);

            if (response.success == false)
            {
                CarExpenseMessage.ShowError(response.message);
            }

            return response.success;
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            if (addService())
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
