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
    public partial class RegisterForm : Form
    {
        private CarExpensesApp app;
        public string message { get; set; }

        public RegisterForm(CarExpensesApp app)
        {
            InitializeComponent();

            this.app = app;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (register())
                this.DialogResult = DialogResult.OK;
            else
                showError(this.message);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private bool register()
        {
            int regionId = 0;
            int bornYear = 0;

            if (txtPassword.Text != txtPassword2.Text)
            {
                this.message = "Passwords must be same.";
                return false;
            }

            if (CarExpensesApp.validateEmail(txtEmail.Text) == false)
            {
                this.message = "Email has an invalid format.";
                return false;
            }

            if (int.TryParse(txtBornYear.Text, out bornYear) == false)
            {
                this.message = "Born year has an invalid format.";
                return false;
            }

            Response response = app.register(txtLogin.Text, txtPassword.Text, txtEmail.Text, bornYear, regionId);
                
            this.message = response.message;
            return response.success;
        }

        private void showError(string error) 
        {
            MessageBox.Show(error);
        }
    }
}
