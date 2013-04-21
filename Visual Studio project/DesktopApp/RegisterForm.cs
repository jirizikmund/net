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
    /// Fomrulář pro registraci nového uživatele
    /// </summary>
    public partial class RegisterForm : Form
    {
        /// <summary>Zpráva vrácená po registraci</summary>
        public string message { get; set; }

        private CarExpensesApp app;

        /// <summary>
        /// Konstruktor okna
        /// </summary>
        /// <param name="app">Instance jádra aplikace</param>
        public RegisterForm(CarExpensesApp app)
        {
            InitializeComponent();

            this.app = app;
        }

        /// <summary>
        /// Validace údajů ve formuláři a registrace uživatele
        /// </summary>
        private bool register()
        {
            int regionId = 0;
            int bornYear = 0;

            errorProvider.Clear();

            if (CarExpensesApp.validateEmail(txtEmail.Text) == false)
            {
                errorProvider.SetError(txtEmail, "Email has an invalid format.");
                return false;
            }

            if (txtPassword.Text == "")
            {
                errorProvider.SetError(txtPassword, "Password can't be empty.");
                return false;
            }

            if (txtPassword.Text != txtPassword2.Text)
            {
                errorProvider.SetError(txtPassword, "Passwords must be same.");
                errorProvider.SetError(txtPassword2, "Passwords must be same.");
                return false;
            }

            if (int.TryParse(txtBornYear.Text, out bornYear) == false)
            {
                errorProvider.SetError(txtBornYear, "Born year has an invalid format.");
                return false;
            }

            Response response = app.register(txtLogin.Text, txtPassword.Text, txtEmail.Text, bornYear, regionId);

            this.message = response.message;

            if (response.success == false)
            {
                CarExpenseMessage.ShowError(response.message);
            }

            return response.success;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (register())
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
