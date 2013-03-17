using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zikmundj.CarExpenses
{
    /// <summary>
    /// Třída reprezentující model auta
    /// </summary>
    public class CarModel
    {
        /// <summary>Interní identifikátor modelu auta</summary>
        public int id { get; set; }

        /// <summary>Výrobce auta ('VW',..)</summary>
        public string manufacturer { get; set; }

        /// <summary>Typ auta ('Golf',...)</summary>
        public string type { get; set; }

        /// <summary>Motor auta ('1.6 TDI',...)</summary>
        public string engine { get; set; }

        /// <summary>Rok výroby auta</summary>
        public int year { get; set; }

        /// <summary>Spotřeba auta v mililitrech na 100 km</summary>
        public int mililitersPer100 { get; set; }

        /// <summary>
        /// Konstruktor, nastavuje nulové hodnoty všem atributům
        /// </summary>
        public CarModel() {
            id = 0;
            manufacturer = "";
            type = "";
            engine = "";
            year = 0;
            mililitersPer100 = 0;
        }
    }
}
