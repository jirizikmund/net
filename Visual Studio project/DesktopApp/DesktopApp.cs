using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using zikmundj.CarExpenses;
using System.Threading;

namespace zikmundj.DesktopApp
{
    /// <summary>
    /// Desktopový klient aplikace CarExpenses
    /// </summary>
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

            InitForm initForm = new InitForm("Initialization application...");
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
                    CarExpenseMessage.ShowFatalError(ex.Message);
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
                CarExpenseMessage.ShowFatalError(ex.Message);
                success = false;
            }
        }
    }
}
