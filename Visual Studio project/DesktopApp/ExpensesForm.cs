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

        public ExpensesForm(CarExpensesApp carExpensesApp, User user)
        {
            InitializeComponent();

            this.carExpensesApp = carExpensesApp;
            this.user = user;

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
                cmbxSelectCar.Items.AddRange(carResponse.carList.ToArray());
            }
        }

        private void disableElements()
        {

        }
    }
}
