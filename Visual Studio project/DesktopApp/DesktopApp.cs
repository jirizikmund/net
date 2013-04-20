using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using zikmundj.CarExpenses;
using System.Threading;

namespace DesktopApp
{
    static class DesktopApp
    {

        private static CarExpensesApp carExpensesApp;
        private static bool success;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitForm initForm = new InitForm();
            initForm.Show();

            Thread aThread = new Thread(new ThreadStart(initCarExpensesApp));
            aThread.Start();
            aThread.Join();

            initForm.Close();

            if (success)
            {
                try
                {
                    Application.Run(new WelcomeForm(carExpensesApp));
                }
                catch (CarExpensesException ex)
                {
                    showErrorDialog(ex.Message);
                }
            }
        }

        private static void initCarExpensesApp()
        {
            try
            {
                carExpensesApp = CarExpensesApp.getInstance();
                success = true;
            }
            catch (CarExpensesException ex)
            {
                showErrorDialog(ex.Message);
                success = false;
            }
        }

        private static void showErrorDialog(string message)
        {
            MessageBox.Show(message,
                            "Car Expenses Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
        }
    }
}
