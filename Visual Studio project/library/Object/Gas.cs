using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zikmundj.CarExpenses
{
    /// <summary>
    /// Třída reprezentující jedno tankování benzínu
    /// </summary>
    public class Gas
    {
        /// <summary>Interní identifikátor tankování (generován databází)</summary>
        public int id { get; set; }

        /// <summary>Identifikátor auta, kterého se tankování týká</summary>
        public int carId { get; set; }

        /// <summary>Stav tachometru při tankování</summary>
        public int km { get; set; }

        /// <summary>Objem tankovaného paliva v mililitrech</summary>
        public int mililiters { get; set; }

        /// <summary>Cena tankovaného paliva</summary>
        public int cost { get; set; }

        /// <summary>Datum, ldy tankování proběhlo</summary>
        public DateTime date { get; set; }

        /// <summary>Časový otisk (generován databází)</summary>
        public int timestamp { get; set; }

        /// <summary>
        /// Konstruktor, nastavuje nulové hodnoty všem atributům
        /// </summary>
        public Gas() {
            id = 0;
            carId = 0;
            km = 0;
            mililiters = 0;
            cost = 0;
            date = new DateTime(0);
            timestamp = 0;
        }

        /// <summary>
        /// Převod objektu na řetězec
        /// </summary>
        /// <returns>Řetězec, vhodné pro tabulkový výpis</returns>
        public override string ToString()
        {
            float liters = mililiters / 1000;
            return (date.ToString("dd.MM.yyyy")) + " " + 
                
                    String.Format("{0, 7}", km) + " km " +
                    String.Format("{0, 4}", liters) + " l " +
                    String.Format("{0, 4}", cost.ToString("C"));
        }

        /// <summary>
        /// Přetížení oprerátoru, slouží ke sčítání cen a objemu tankování
        /// </summary>
        /// <returns>Nový objekt tankování se sečtenýmy hodnotami ceny a objemu</returns> 
        public static Gas operator +(Gas g1, Gas g2)
        {
            Gas result = new Gas();
            result.cost = g1.cost + g2.cost;
            result.mililiters = g1.mililiters + g2.mililiters;
            return result;
        }
    }
}
