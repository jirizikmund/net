using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zikmundj.CarExpenses
{
    /// <summary>
    /// Třída reprezentující jeden jiný výdaj za auto
    /// </summary>
    public class OtherExpense
    {
        /// <summary>Interní identifikátor jiného výdaje (generován databází)</summary>
        public int id { get; set; }

        /// <summary>Identifikátor auta, kterého se jiný výdaj týká</summary>
        public int carId { get; set; }

        /// <summary>Stav tachometru při jiném výdaji</summary>
        public int km { get; set; }

        /// <summary>Cena jiného výdaje</summary>
        public int cost { get; set; }

        /// <summary>Slovní popis jiného výdaje</summary>
        public string description { get; set; }

        /// <summary>Datum jiného výdaje</summary>
        public DateTime date { get; set; }

        /// <summary>Časový otisk (generován databází)</summary>
        public int timestamp { get; set; }

        /// <summary>
        /// Konstruktor, nastavuje nulové hodnoty všem atributům
        /// </summary>
        public OtherExpense() {
            id = 0;
            carId = 0;
            km = 0;
            cost = 0;
            description = "";
            date = new DateTime(0);
            timestamp = 0;
        }

        /// <summary>
        /// Převod objektu na řetězec
        /// </summary>
        /// <returns>Krátký popis jiného výdaje</returns>
        public override string ToString()
        {
            return getShortDescription(20);
        }

        /// <summary>
        /// Krátký popis jiného výdaje
        /// </summary>
        /// <param name="maxLegth">Maximální délka popisu</param>
        /// <returns>Popis jiného výdaje o maximální délce podle zadaného parametru length</returns>
        public string getShortDescription(int maxLength = 20)
        {
            string shortDescription = description;
            if (shortDescription.Length > maxLength)
                shortDescription = description.Substring(0, maxLength-3) + "...";

            return shortDescription;
        }

        /// <summary>
        /// Přetížení oprerátoru, slouží ke sčítání jiného výdaje
        /// </summary>
        /// <returns>Nový objekt jiného výdaje se sečtenýmy hodnotami ceny</returns> 
        public static OtherExpense operator +(OtherExpense oe1, OtherExpense oe2)
        {
            OtherExpense result = new OtherExpense();
            result.cost = oe1.cost + oe2.cost;
            result.description = "Total cost of other expenses";
            return result;
        }
    }
}
