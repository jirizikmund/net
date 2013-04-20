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
    public partial class LoginForm : Form
    {
        public User user { get; set; }
        public string message { get; set; }

        private CarExpensesApp app;

        public LoginForm(CarExpensesApp app)
        {
            InitializeComponent();
            this.app = app;
            this.user = null;
            this.message = null;
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

        private bool login()
        {
            UserResponse response = app.login(txtLogin.Text, txtPassword.Text);
            this.user = response.user;
            this.message = response.message;
            return response.success;
        }
    }
}
