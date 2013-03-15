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

        private string oradb = "Data Source=(DESCRIPTION="
            + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=students.kiv.zcu.cz)(PORT=1521)))"
            + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=students)));"
            + "User Id=zikmundj;Password=A12N0103P;";
        
        private CarExpensesApp()
        {
            user = null;
            connection = null;
            userDAO = new UserDAO(getConnection());
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

        public Response login(string login, string password)
        {
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
    }
}