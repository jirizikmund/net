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
    /// Fomrulář pro přihlášení
    /// </summary>
    public partial class LoginForm : Form
    {
        /// <summary>Uživatel vrácený po přihlášení</summary>
        public User user { get; set; }

        /// <summary>Zpráva o přihlášení</summary>
        public string message { get; set; }

        private CarExpensesApp app;

        /// <summary>
        /// Konstruktor okna
        /// </summary>
        /// <param name="app">Instance jádra aplikace</param>
        public LoginForm(CarExpensesApp app)
        {
            InitializeComponent();
            this.app = app;
            this.user = null;
            this.message = null;
        }

        /// <summary>
        /// Validace údajů ve formuláři a přihlášení uživatele
        /// </summary>
        private bool login()
        {
            UserResponse response = app.login(txtLogin.Text, txtPassword.Text);
            this.user = response.user;
            this.message = response.message;
            return response.success;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (login())
                this.DialogResult = DialogResult.OK;
            else
                MessageBox.Show(this.message);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }        
    }
}
