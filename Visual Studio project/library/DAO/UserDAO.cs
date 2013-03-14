using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

using CarExpenses;

namespace CarExpensesTools
{
    class UserDAO : BaseDAO
    {
        public UserDAO(OracleConnection connection) : base(connection)
        { }

        public User login(string login, string password)
        {
            User user = null;

            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM \"users\" WHERE \"login\" = '" + login + "' AND \"password\" = '" + password + "'";
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            dr.Read();
                            user = new User();
                            user.id = Convert.ToInt32(dr["id"].ToString());
                            user.login = dr["login"].ToString();
                            user.email = dr["email"].ToString();
                            user.bornYear = Convert.ToInt32(dr["born_year"].ToString());
                            user.regionId = Convert.ToInt32(dr["region_id"].ToString());
                        }
                        else
                        {
                            throw new CarExpensesDatabaseException("Unknown login or password.");
                        }
                    }
                }
                catch (OracleException ex)
                {
                    switch (ex.Number)
                    {
                        case 12545:
                            throw new CarExpensesDatabaseException("The database is unavailable.");
                        default:
                            throw new CarExpensesDatabaseException("Database error: " + ex.Message.ToString());
                    }
                }
                catch (CarExpensesDatabaseException ex)
                {
                    throw new CarExpensesDatabaseException(ex.Message.ToString());
                }
                catch (Exception ex) // catches any other error
                {
                    throw new CarExpensesDatabaseException("Unexpected error: " + ex.Message.ToString());
                }
            }

            return user;
        }
    }
}
