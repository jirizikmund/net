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
    public partial class WelcomeForm : Form
    {
        private CarExpensesApp carExpensesApp;

        public WelcomeForm(CarExpensesApp carExpensesApp)
        {
            InitializeComponent();
            this.carExpensesApp = carExpensesApp;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            using (LoginForm loginForm = new LoginForm(carExpensesApp))
            {
                DialogResult dr = loginForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    MessageBox.Show(loginForm.message);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            carExpensesApp.logout();
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            using (RegisterForm registerForm = new RegisterForm(carExpensesApp))
            {
                DialogResult dr = registerForm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    
                }
            }
        }
    }
}
