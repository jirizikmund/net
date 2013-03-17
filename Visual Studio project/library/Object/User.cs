using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zikmundj.CarExpenses
{
    /// <summary>
    /// Třída reprezentující jednoho uživatele
    /// </summary>
    public class User
    {
        /// <summary>Interní identifikátor uživatele (generován databází)</summary>
        public int id { get; set; }

        /// <summary>Login pro přihlášení</summary>
        public String login { get; set; }

        /// <summary>Heslo uživatele</summary>
        public String password { get; set; }

        /// <summary>Email uživatele</summary>
        public String email { get; set; }

        /// <summary>Rok narození uživatele</summary>
        public int bornYear { get; set; }

        /// <summary>Identifikátor regionu, ve kterém uživatel bydlí</summary>
        public int regionId { get; set; }

        /// <summary>Název regionu, kde uživatel bydlí</summary>
        public String region { get; set; }

        /// <summary>Konstruktor, nastavuje nulové hodnoty všem atributům</summary>
        public User() {
            id = 0;
            login = "";
            bornYear = 0;
            regionId = 0;
            region = "";
        }
    }
}
