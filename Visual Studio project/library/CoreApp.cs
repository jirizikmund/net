using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

using CarExpensesTools;

namespace CarExpenses
{
    public class CarExpensesApp
    {
        public User user;
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
        
        private CarExpensesApp()
        {
            user = null;
            connection = null;
            userDAO = new UserDAO(getConnection());
            carDAO = new CarDAO(getConnection());
            gasDAO = new GasDAO(getConnection());
            serviceDAO = new ServiceDAO(getConnection());
        }

        ~CarExpensesApp()
        {
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

        public bool isLogged()
        {
            return user != null ? true : false;
        }

        public bool notLogged()
        {
            return user == null ? true : false;
        }

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

        public Response logout()
        {
            user = null;
            return new Response(true, "You were successfuly logged out.");
        }

        public Response register(string login, string password, string email, int bornYear, int regionId)
        {
            password = MD5(password);
            Response response = new Response(false, "Registration failed.");

            if (bornYear < (DateTime.Today.Year-130) || bornYear > DateTime.Today.Year)
            {
                response.message = "Born year must be between " + (DateTime.Today.Year - 130) + " and " + DateTime.Today.Year + ".";
                response.success = false;
                return response;
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
    }
}