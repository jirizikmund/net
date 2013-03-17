using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zikmundj.CarExpenses
{
    /// <summary>
    /// Struktura používaná k předání odpovědí událostí aplikace.
    /// Kromě stavu úspěhu obsahuje i zprávu.
    /// </summary>
    public struct Response
    {
        /// <summary>Stav úspěchu (true/false)</summary>
        public bool success;

        /// <summary>Upřesňující informační zpráva odpovědi</summary>
        public String message;

        /// <summary>
        /// Konstruktor struktury
        /// </summary>
        public Response(bool success = false, String message = "")
        {
            this.success = success;
            this.message = message;
        }
    }

    /// <summary>
    /// Struktura používaná k předání odpovědí událostí aplikace.
    /// Kromě stavu úspěhu obsahuje i zprávu a seznam aut.
    /// </summary>
    public struct CarResponse
    {
        /// <summary>Stav úspěchu (true/false)</summary>
        public bool success;

        /// <summary>Upřesňující informační zpráva odpovědi</summary>
        public String message;

        /// <summary>Seznam aut</summary>
        public List<Car> carList;

        /// <summary>
        /// Konstruktor struktury
        /// </summary>
        public CarResponse(bool success = false, String message = "", List<Car> carList = null)
        {
            this.success = success;
            this.message = message;
            this.carList = carList;
        }
    }

    /// <summary>
    /// Struktura používaná k předání odpovědí událostí aplikace.
    /// Kromě stavu úspěhu obsahuje i zprávu a objekt uživatele.
    /// </summary>
    public struct UserResponse
    {
        /// <summary>Stav úspěchu (true/false)</summary>
        public bool success;

        /// <summary>Upřesňující informační zpráva odpovědi</summary>
        public String message;

        /// <summary>Objekt uživatele</summary>
        public User user;

        /// <summary>
        /// Konstruktor struktury
        /// </summary>
        public UserResponse(bool success = false, String message = "", User user = null)
        {
            this.success = success;
            this.message = message;
            this.user = user;
        }
    }

    /// <summary>
    /// Struktura používaná k předání odpovědí událostí aplikace.
    /// Kromě stavu úspěhu obsahuje i zprávu a seznam tankování.
    /// </summary>
    public struct GasResponse
    {
        /// <summary>Stav úspěchu (true/false)</summary>
        public bool success;

        /// <summary>Upřesňující informační zpráva odpovědi</summary>
        public String message;

        /// <summary>Seznam tankování</summary>
        public List<Gas> gasList;

        /// <summary>
        /// Konstruktor struktury
        /// </summary>
        public GasResponse(bool success = false, String message = "", List<Gas> gasList = null)
        {
            this.success = success;
            this.message = message;
            this.gasList = gasList;
        }
    }

    /// <summary>
    /// Struktura používaná k předání odpovědí událostí aplikace.
    /// Kromě stavu úspěhu obsahuje i zprávu a seznam oprav.
    /// </summary>
    public struct ServiceResponse
    {
        /// <summary>Stav úspěchu (true/false)</summary>
        public bool success;

        /// <summary>Upřesňující informační zpráva odpovědi</summary>
        public String message;

        /// <summary>Seznam oprav</summary>
        public List<Service> serviceList;

        /// <summary>
        /// Konstruktor struktury
        /// </summary>
        public ServiceResponse(bool success = false, String message = "", List<Service> serviceList = null)
        {
            this.success = success;
            this.message = message;
            this.serviceList = serviceList;
        }
    }
}
