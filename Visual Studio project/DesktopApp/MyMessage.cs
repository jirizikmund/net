using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    static class MyMessage
    {
        public static void ShowError(string message, string caption = null)
        {
            MessageBox.Show(message,
                            caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);
        }

        public static void ShowFatalError(string message)
        {
            MessageBox.Show(message,
                            "Car Expenses Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
        }

        public static void ShowInfo(string message)
        {
            MessageBox.Show(message,
                            "Car Expenses",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
        }
    }
}
