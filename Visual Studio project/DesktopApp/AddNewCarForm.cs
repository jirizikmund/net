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
    /// Fomrulář pro přidání nového auta
    /// </summary>
    public partial class AddNewCarForm : Form
    {
        private CarExpensesApp carExpensesApp;

        /// <summary>
        /// Konstruktor okna
        /// </summary>
        /// <param name="carExpensesApp">Instance jádra aplikace</param>
        public AddNewCarForm(CarExpensesApp carExpensesApp)
        {
            InitializeComponent();
            this.carExpensesApp = carExpensesApp;
        }

        /// <summary>
        /// Validace údajů ve formuláři a přidání nového auta
        /// </summary>
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
                CarExpenseMessage.ShowError(response.message);
            }

            return response.success;
        }


        private void btnAddCar_Click(object sender, EventArgs e)
        {
            if (addNewCar())
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
