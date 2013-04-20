using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Text.RegularExpressions;
using zikmundj.CarExpensesDAO;

/// <summary>
/// Třídy aplikace CarExpenses
/// </summary>
namespace zikmundj.CarExpenses
{
    /// <summary>
    /// Jádro aplikace CarExpenses.
    /// </summary>
    public class CarExpensesApp
    {
        private User user;

        private static CarExpensesApp instance;
        private OracleConnection connection;

        private UserDAO userDAO;
        private CarDAO carDAO;
        private GasDAO gasDAO;
        private ServiceDAO serviceDAO;

        private string oradb = "Data Source=(DESCRIPTION="
            + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=students.kiv.zcu.cz)(PORT=1521)))"
            + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=students)));"
            + "User Id=zikmundj;Password=A12N0103P;";

        /// <summary>
        /// Privátní konstruktor aplikace, je volán pouze jednou, inicializuje datové modely
        /// </summary>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        private CarExpensesApp()
        {
            user = null;
            connection = null;
            userDAO = new UserDAO(getConnection());
            carDAO = new CarDAO(getConnection());
            gasDAO = new GasDAO(getConnection());
            serviceDAO = new ServiceDAO(getConnection());
        }

        /// <summary>
        /// Destruktor aplikace, ukončuje spojení s databází, odhlašuje uživatele
        /// </summary>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        ~CarExpensesApp()
        {
            if (user != null)
            {
                user.password = null;
                user.id = 0;
                user.login = null;
                user.region = null;
                user.regionId = 0;
                user = null;
            }

            if (connection != null)
            {
                try
                {
                    connection.Close();
                    connection = null;
                }
                catch (OracleException)
                {
                    throw new CarExpensesException("Error while disconnection from database.");
                }
                catch (Exception ex)
                {
                    throw new CarExpensesException("Unexpected error (1): " + ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Vrací instanci aplikace, pokud žádná není, vytváří novou
        /// </summary>
        /// <returns>Instance aplikace</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public static CarExpensesApp init
        {
            get 
            {
                if (instance == null)
                {
                    instance = new CarExpensesApp();
                }
                return instance;
            }
        }

        /// <summary>
        /// Vrací instanci aplikace, pokud žádná není, vytváří novou
        /// </summary>
        /// <returns>Instance aplikace</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public static CarExpensesApp getInstance()
        {
            return init;
        }

        /// <summary>
        /// Vrací aktuálně přihlášeného uživatele
        /// </summary>
        /// <returns>Přihlášený uživatel, null pokud není přihlášený</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public User getUser()
        {
            return this.user;
        }

        /// <summary>
        /// Vrací instanci spojení s databází, pokud žádné není, náváže nové
        /// </summary>
        /// <returns>Instance spojení s databází</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        private OracleConnection getConnection()
        {
            if (connection == null)
            {
                try
                {
                    connection = new OracleConnection(oradb);
                    connection.Open();
                }
                catch (OracleException)
                {
                    throw new CarExpensesException("Unable to connect to database.");
                }
                catch (Exception ex)
                {
                    throw new CarExpensesException("Unexpected error (2): " + ex.Message.ToString());
                }
            }
            return connection;
        }

        /// <summary>
        /// Zjišťuje, zda je uživatel přihlášen
        /// </summary>
        /// <returns>Zda je uživatel přihlášen (true/false)</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public bool isLogged()
        {
            return user != null ? true : false;
        }

        /// <summary>
        /// Zjišťuje, zda je uživatel odhlášen
        /// </summary>
        /// <returns>Zda je uživatel odhlášen (true/false)</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public bool notLogged()
        {
            return user == null ? true : false;
        }

        /// <summary>
        /// Přihlášení uživatele
        /// </summary>
        /// <param name="login">Přihlašovací jméno uživatele</param>
        /// <param name="password">Heslo uživatele</param>
        /// <returns>Objekt <see cref="UserResponse"/>, kde je uložen stav akce, zpráva a objekt přihlášeného uživatele (při chybě null).</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public UserResponse login(string login, string password)
        {
            password = MD5(password);
            UserResponse response = new UserResponse(false, "You are NOT logged in.");
            try
            {
                user = userDAO.login(login, password);
                if (user != null)
                {
                    User responseUser = new User();
                    responseUser.id = user.id;
                    responseUser.login = user.login;
                    responseUser.region = user.region;
                    responseUser.regionId = user.regionId;

                    response.message = "You were successfuly logged in.";
                    response.success = true;
                    response.user = responseUser;
                }
            }
            catch (CarExpensesDatabaseException ex)
            {
                response.success = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }

        /// <summary>
        /// Odhlášení uživatele
        /// </summary>
        /// <returns>Objekt <see cref="Response"/>, kde je uložen stav akce a zpráva.</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public Response logout()
        {
            user = null;
            return new Response(true, "You were successfuly logged out.");
        }

        /// <summary>
        /// Registrace nového uživatele
        /// </summary>
        /// <param name="login">Přihlašovací jméno uživatele</param>
        /// <param name="password">Heslo uživatele</param>
        /// <param name="email">Email uživatele</param>
        /// <param name="bornYear">Rok narození uživatele</param>
        /// <param name="regionId">Identifikace regionu, kde uživatel žije</param>
        /// <returns>Objekt <see cref="Response"/>, kde je uložen stav akce a zpráva.</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public Response register(string login, string password, string email, int bornYear, int regionId)
        {
            password = MD5(password);
            Response response = new Response(false, "Registration failed.");

            if (bornYear < (DateTime.Today.Year-130) || bornYear > DateTime.Today.Year)
            {
                return new Response(false,"Born year must be between " + (DateTime.Today.Year - 130) + " and " + DateTime.Today.Year + ".");
            }

            if (CarExpensesApp.validateEmail(email) == false)
            {
                return new Response(false, "Email is not in valid format.");
            }
            
            try
            {
                User user = new User();
                user.login = login;
                user.password = password;
                user.email = email;
                user.bornYear = bornYear;
                user.regionId = regionId;

                if (userDAO.register(user) == true)
                {
                    response.message = "User " + user.login + " was successfuly registered.";
                    response.success = true;
                }
            }
            catch (CarExpensesDatabaseException ex)
            {
                response.success = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }

        /// <summary>
        /// Získání uživatelovo aut
        /// </summary>
        /// <returns>Objekt <see cref="CarResponse"/>, kde je uložen stav akce, zpráva a seznam uživatelovo aut (při chybě null).</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public CarResponse getUserCars()
        {
            if ( notLogged() ) return new CarResponse(false, "You are NOT logged in.");
            
            CarResponse response = new CarResponse();
            try
            {
                List<Car> carList = carDAO.getUserCars(user.id);
                response.success = true;
                response.message = "There are " + carList.Count + " cars available.";
                response.carList = carList;
            }
            catch (CarExpensesDatabaseException ex)
            {
                response.success = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }

        /// <summary>
        /// Přidání nového auta k aktuálně přihlášenému uživateli
        /// </summary>
        /// <param name="carModelId">Identifikace typu auta</param>
        /// <param name="name">Jměno auta</param>
        /// <param name="boughtYear">Rok zakoupení auta</param>
        /// <param name="cost">Cena auta</param>
        /// <returns>Objekt <see cref="Response"/>, kde je uložen stav akce a zpráva.</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public Response addCar(int carModelId, string name, int boughtYear, int cost)
        {
            if (notLogged()) return new Response(false, "You are NOT logged in.");

            if (boughtYear < 1900 || boughtYear > DateTime.Today.Year)
                return new Response(false, "Bought year must be between " + 1900 + " and " + DateTime.Today.Year + ".");

            Response response = new Response();
            try
            {
                Car car = new Car();
                car.userId = user.id;
                car.carModelId = carModelId;
                car.boughtYear = boughtYear;
                car.cost = cost;
                car.name = name;

                if (carDAO.addCar(car) == true)
                {
                    response.message = "Car was successfuly added.";
                    response.success = true;
                }
            }
            catch (CarExpensesDatabaseException ex)
            {
                response.success = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }

        /// <summary>
        /// Přidání nového tankování k aktuálně přihlášenému uživateli
        /// </summary>
        /// <param name="carId">Identifikace auta, do kterého bylo tankováno</param>
        /// <param name="km">Stav tachometru při tankování</param>
        /// <param name="cost">Cena za tankování</param>
        /// <param name="liters">Počet natankovaných litrů paliva</param>
        /// <param name="date">Datum tankování</param>
        /// <returns>Objekt <see cref="Response"/>, kde je uložen stav akce a zpráva.</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public Response addGas(int carId, int km, float liters, int cost, DateTime date)
        {
            if (notLogged()) return new Response(false, "You are NOT logged in.");

            if (km < 1 || liters < 1 || cost < 1)
                return new Response(false, "None of values can be smaller than 1.");

            Response response = new Response();
            try
            {
                if (carDAO.userHasCar(user.id, carId) == false)
                {
                    return new Response(false, "User ID " + user.id + " is not owner of car ID " + carId + ".");
                }

                Gas gas = new Gas();
                gas.carId = carId;
                gas.km = km;
                gas.mililiters = (int) Math.Round(liters * 1000);
                gas.cost = cost;
                gas.date = date;

                if (gasDAO.addGas(gas) == true)
                {
                    response.message = "Gas was successfuly added.";
                    response.success = true;
                }
                else
                {
                    response.message = "Gas wasn't added.";
                    response.success = false;
                }
            }
            catch (CarExpensesDatabaseException ex)
            {
                response.success = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }

        /// <summary>
        /// Získání tankování pro dané auto
        /// </summary>
        /// <param name="carId">Identifikace auta, pro které chceme tankování získat</param>
        /// <returns>Objekt <see cref="GasResponse"/>, kde je uložen stav akce, zpráva a seznam tankování (při chybě null).</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public GasResponse getCarGasses(int carId)
        {
            if (notLogged()) return new GasResponse(false, "You are NOT logged in.");

            GasResponse response = new GasResponse();
            try
            {
                List<Gas> gasList = gasDAO.getCarGasses(carId);
                response.success = true;
                response.message = "There are " + gasList.Count + " gasses available.";
                response.gasList = gasList;
            }
            catch (CarExpensesDatabaseException ex)
            {
                response.success = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }

        /// <summary>
        /// Přidání nové opravy k aktuálně přihlášenému uživateli
        /// </summary>
        /// <param name="carId">Identifikace auta, které bylo opravováno</param>
        /// <param name="km">Stav tachometru při opravě</param>
        /// <param name="cost">Cena opravy</param>
        /// <param name="serviceTypeId">Identifikace typu opravy</param>
        /// <param name="description">Slovní popis opravy</param>
        /// <param name="date">Datum opravy</param>
        /// <returns>Objekt <see cref="Response"/>, kde je uložen stav akce a zpráva.</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public Response addService(int carId, int km, int cost, int serviceTypeId, string description, DateTime date)
        {
            if (notLogged()) return new Response(false, "You are NOT logged in.");

            if (km < 1 || cost < 1)
                return new Response(false, "Km and cost can't be smaller than 1.");

            Response response = new Response();
            try
            {
                if (carDAO.userHasCar(user.id, carId) == false)
                {
                    return new Response(false, "User ID " + user.id + " is not owner of car ID " + carId + ".");
                }

                Service service = new Service();
                service.carId = carId;
                service.km = km;
                service.cost = cost;
                service.serviceTypeId = serviceTypeId;
                service.description = description;
                service.date = date;

                if (serviceDAO.addService(service) == true)
                {
                    response.message = "Service was successfuly added.";
                    response.success = true;
                }
                else
                {
                    response.message = "Service wasn't added.";
                    response.success = false;
                }
            }
            catch (CarExpensesDatabaseException ex)
            {
                response.success = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }

        /// <summary>
        /// Získání oprav pro dané auto
        /// </summary>
        /// <param name="carId">Identifikace auta, pro které chceme opravy získat</param>
        /// <returns>Objekt <see cref="ServiceResponse"/>, kde je uložen stav akce, zpráva a seznam oprav (při chybě null).</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public ServiceResponse getCarServices(int carId)
        {
            if (notLogged()) return new ServiceResponse(false, "You are NOT logged in.");

            ServiceResponse response = new ServiceResponse();
            try
            {
                List<Service> serviceList = serviceDAO.getCarServices(carId);
                response.success = true;
                response.message = "There are " + serviceList.Count + " services available.";
                response.serviceList = serviceList;
            }
            catch (CarExpensesDatabaseException ex)
            {
                response.success = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }

        /// <summary>
        /// Získání informace o včech servisech auta
        /// </summary>
        /// <param name="carId">Identifikace auta, o kterém chceme informace získat</param>
        /// <returns>ˇŘetězec s informacemi</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public string getTotalServiceInfo(int carId)
        {
            ServiceResponse response = this.getCarServices(carId);
            if (response.success)
            {
                Service service = new Service();
                int count = 0;
                foreach (Service s in response.serviceList)
                {
                    count++;
                    service += s;
                }
                return "Total " + count + " services for " + service.cost.ToString("C") + "";
            }
            else
            {
                return "Unknown total services stats.";
            }
        }

        /// <summary>
        /// Získání informace o včech tankování auta
        /// </summary>
        /// <param name="carId">Identifikace auta, o kterém chceme informace získat</param>
        /// <returns>ˇŘetězec s informacemi</returns>
        /// <exception cref="CarExpensesException">Při chybě aplikace</exception>
        public string getTotalGasInfo(int carId)
        {
            GasResponse response = this.getCarGasses(carId);
            if (response.success)
            {
                Gas gas = new Gas();
                int count = 0;
                foreach (Gas g in response.gasList)
                {
                    count++;
                    gas += g;
                }
                return "Total " + (float)(gas.mililiters / 100) + " liters for " + gas.cost.ToString("C") + "  (" + count + "x)";
            }
            else
            {
                return "Unknown total services stats.";
            }
        }

        /// <summary>
        /// Hashuje řetězec do MD5
        /// </summary>
        /// <param name="password">Řetězec k hasování</param>
        /// <returns>Zahashovaný řetězec</returns>
        private static string MD5(string password)
        {
            byte[] textBytes = System.Text.Encoding.UTF8.GetBytes(password);
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
                cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash = cryptHandler.ComputeHash(textBytes);
                string ret = "";
                foreach (byte a in hash)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("x");
                    else
                        ret += a.ToString("x");
                }
                return ret;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Validace formátu emailové adresy
        /// </summary>
        /// <param name="email">Emailová adresa pro zvalidování</param>
        /// <returns>Stav, zda je emailová adresa validní (true/false)</returns>
        public static bool validateEmail(string email)
        {
            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return emailRegex.Match(email).Success;
        }
    }
}