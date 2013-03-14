using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

using CarExpensesTools;

namespace CarExpenses
{
    public class CoreApp
    {
        public User user;
        private static CoreApp instance;
        private OracleConnection connection;

        private UserDAO userDAO;

        private string oradb = "Data Source=(DESCRIPTION="
            + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=students.kiv.zcu.cz)(PORT=1521)))"
            + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=students)));"
            + "User Id=zikmundj;Password=A12N0103P;";
        
        private CoreApp()
        {
            user = null;
            connection = null;
            userDAO = new UserDAO(getConnection());
        }

        ~CoreApp()
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

        public static CoreApp init
        {
            get 
            {
                if (instance == null)
                {
                    instance = new CoreApp();
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

    }
}