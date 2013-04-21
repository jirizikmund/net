using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zikmundj.DesktopApp
{
    /// <summary>
    /// Okno zobrazované při načítání aplikace
    /// </summary>
    public partial class InitForm : Form
    {
        /// <summary>
        /// Konstruktor okna
        /// </summary>
        /// <param name="message">Text v okně</param>
        public InitForm(string message = "Initialization...")
        {
            InitializeComponent();
            lblInit.Text = message;
        }
    }
}
