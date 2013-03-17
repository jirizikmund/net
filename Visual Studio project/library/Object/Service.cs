using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zikmundj.CarExpenses
{
    /// <summary>
    /// Třída reprezentující jednu opravu auta
    /// </summary>
    public class Service
    {
        /// <summary>Interní identifikátor opravy (generován databází)</summary>
        public int id { get; set; }

        /// <summary>Identifikátor auta, kterého se oprava týká</summary>
        public int carId { get; set; }

        /// <summary>Stav tachometru při opravě</summary>
        public int km { get; set; }

        /// <summary>Identifikátor typu opravy</summary>
        public int serviceTypeId { get; set; }

        /// <summary>Cena opravy</summary>
        public int cost { get; set; }

        /// <summary>Slovní popis opravy</summary>
        public string description { get; set; }

        /// <summary>Datum opravy</summary>
        public DateTime date { get; set; }

        /// <summary>Časový otisk (generován databází)</summary>
        public int timestamp { get; set; }

        /// <summary>
        /// Konstruktor, nastavuje nulové hodnoty všem atributům
        /// </summary>
        public Service() {
            id = 0;
            carId = 0;
            km = 0;
            serviceTypeId = 0;
            cost = 0;
            description = "";
            date = new DateTime(0);
            timestamp = 0;
        }

        /// <summary>
        /// Převod objektu na řetězec
        /// </summary>
        /// <returns>Řetězec, vhodné pro tabulkový výpis</returns>
        public override string ToString()
        {
            return (date.ToString("dd.MM.yyyy")) + " " +
                    String.Format("{0, 7}", km) + " km " +
                    String.Format("{0, 4}", cost.ToString("C")) +
                    String.Format("{0, 30}", description);
        }

        /// <summary>
        /// Přetížení oprerátoru, slouží ke sčítání ceny servisu
        /// </summary>
        /// <returns>Nový objekt servisu se sečtenýmy hodnotami ceny</returns> 
        public static Service operator +(Service s1, Service s2)
        {
            Service result = new Service();
            result.cost = s1.cost + s2.cost;
            result.description = "Total cost of services";
            return result;
        }
    }
}
