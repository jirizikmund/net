using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zikmundj.CarExpenses
{
    /// <summary>
    /// Třída reprezentující typ opravy auta
    /// </summary>
    public class ServiceType
    {
        /// <summary>Interní identifikátor typu opravy</summary>
        public int id { get; set; }

        /// <summary>Název typu opravy</summary>
        public string name { get; set; }

        /// <summary>Konstruktor, nastavuje nulové hodnoty všem atributům</summary>
        public ServiceType()
        {
            id = 0;
            name = "";
        }
    }
}
