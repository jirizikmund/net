using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zikmundj.DesktopApp
{
    /// <summary>
    /// Zobrazuje dialogová okna s hláškami
    /// </summary>
    static class CarExpenseMessage
    {
        /// <summary>
        /// Zobrazuje chybovou hlášku
        /// </summary>
        /// <param name="message">Hláška k zobrazení</param>
        /// <param name="caption">Titulek dialogového okan</param>
        public static void ShowError(string message, string caption = null)
        {
            MessageBox.Show(message,
                            caption,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.None,
                            MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Zobrazuje hlášku fatální chyby
        /// </summary>
        /// <param name="message">Hláška k zobrazení</param>
        public static void ShowFatalError(string message)
        {
            MessageBox.Show(message,
                            "Car Expenses Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Zobrazuje informační hlášku
        /// </summary>
        /// <param name="message">Hláška k zobrazení</param>
        public static void ShowInfo(string message)
        {
            MessageBox.Show(message,
                            "Car Expenses",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Zobrazuje otázku
        /// </summary>
        /// <param name="message">Otázka k zobrazení</param>
        /// /// <returns>Odpověď ano/ne (true/false)</returns>
        public static bool ShowQuestion(string message, string caption = "Car Expenses")
        {
            if (MessageBox.Show(message,
                                caption,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }
            else return false;
        }
    }
}
