using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zikmundj.CarExpenses
{
    /// <summary>
    /// Třída reprezentující jeden region
    /// </summary>
    public class Region
    {
        /// <summary>Interní identifikátor regionu</summary>
        public int id { get; set; }

        /// <summary>Jméno regionu</summary>
        public string name { get; set; }

        /// <summary>
        /// Konstruktor, nastavuje nulové hodnoty všem atributům
        /// </summary>
        public Region()
        {
            id = 0;
            name = "";
        }
    }
}
