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

        public Response login(string login, string password)
        {
            password = MD5(password);
            Response response = new Response(false, "You are NOT logged in.");
            try
            {
                user = userDAO.login(login, password);
                if (user != null)
                {
                    response.message = "You were successfuly logged in.";
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

        public bool logout()
        {
            user = null;
            return true;
        }

        public Response register(string login, string password, string email, int bornYear, int regionId)
        {
            password = MD5(password);
            Response response = new Response(false, "Registration failed.");

            if (bornYear < (DateTime.Today.Year-130) || bornYear > DateTime.Today.Year)
            {
                response.message = "Born year must be between " + (DateTime.Today.Year - 130) + " and " + DateTime.Today.Year + ".";
                response.success = true;
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
                response.message = "There is " + carList.Count + " cars available.";
                response.carList = carList;
            }
            catch (CarExpensesDatabaseException ex)
            {
                response.success = false;
                response.message = ex.Message.ToString();
            }
            return response;
        }

        public Response addCar(int carModelId, int boughtYear, int cost)
        {
            if (notLogged()) return new Response(false, "You are NOT logged in.");

            Response response = new Response();
            try
            {
                Car car = new Car();
                car.userId = user.id;
                car.carModelId = carModelId;
                car.boughtYear = boughtYear;
                car.cost = cost;

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

        public static string MD5(string password)
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