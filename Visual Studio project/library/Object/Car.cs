using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zikmundj.CarExpenses
{
    /// <summary>
    /// Třída reprezentují jedno auto
    /// </summary>
    public class Car
    {
        /// <summary>Interní identifikátor auta (generován databází)</summary>
        public int id { get; set; }

        /// <summary>Identifikátor vlastníka vozidla</summary>
        public int userId { get; set; }

        /// <summary>Identifikátor modelu vozidla</summary>
        public int carModelId { get; set; }

        /// <summary>Rok, kdy vlastník vozidlo zakoupil</summary>
        public int boughtYear { get; set; }

        /// <summary>Cena, za kterou vlastník vozidlo zakoupil</summary>
        public int cost { get; set; }

        /// <summary>Názav vozidla</summary>
        public string name { get; set; }

        /// <summary>
        /// Konstruktor, nastavuje nulové hodnoty všem atributům
        /// </summary>
        public Car() {
            id = 0;
            userId = 0;
            carModelId = 0;
            boughtYear = 0;
            cost = 0;
            name = "";
        }

        /// <summary>
        /// Převod objektu na řetězec
        /// </summary>
        /// <returns>Řetězec, vhodné pro tabulkový výpis</returns>
        public override string ToString()
        {
            string shortName = name;
            if (shortName.Length > 20)
                shortName = name.Substring(0,20);

            return  ""          + String.Format("{0, -20}", shortName) +
                    " bought "  + String.Format("{0, 4}", boughtYear) +
                    ", cost "   + cost.ToString("C"); 
        }

        /// <summary>
        /// Krátký název auta
        /// </summary>
        /// <param name="legth">Maximální délka názvu</param>
        /// <returns>Název o maximální délce podle zadaného parametru length</returns>
        public string getShortName(int maxLength = 20)
        {
            string shortName = name;
            if (shortName.Length > maxLength)
                shortName = name.Substring(0, maxLength);

            return shortName;
        }
    }
}
