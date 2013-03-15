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


        public bool register(User user)
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    string sqlInsert = "INSERT INTO \"users\" (\"login\", \"email\", \"password\", \"region_id\", \"born_year\") ";
                    sqlInsert += "values (:p_login, :p_email, :p_password, :p_region_id, :p_born_year)";

                    OracleCommand cmdInsert = new OracleCommand();
                    cmdInsert.CommandText = sqlInsert;
                    cmdInsert.Connection = connection;

                    OracleParameter pLogin = new OracleParameter();
                    pLogin.Value = user.login;
                    pLogin.ParameterName = "p_login";

                    OracleParameter pEmail = new OracleParameter();
                    pEmail.Value = user.email;
                    pEmail.ParameterName = "p_email";

                    OracleParameter pPassword = new OracleParameter();
                    pPassword.Value = user.password;
                    pPassword.ParameterName = "p_password";

                    OracleParameter pRegionId = new OracleParameter();
                    pRegionId.OracleDbType = OracleDbType.Decimal;
                    pRegionId.Value = user.regionId;
                    pRegionId.ParameterName = "p_region_id";

                    OracleParameter pBornYear = new OracleParameter();
                    pBornYear.OracleDbType = OracleDbType.Decimal;
                    pBornYear.Value = user.bornYear;
                    pBornYear.ParameterName = "p_born_year";

                    cmdInsert.Parameters.Add(pLogin);
                    cmdInsert.Parameters.Add(pEmail);
                    cmdInsert.Parameters.Add(pPassword);
                    cmdInsert.Parameters.Add(pRegionId);
                    cmdInsert.Parameters.Add(pBornYear);

                    if ( cmdInsert.ExecuteNonQuery() > 0 )
                    {
                        return true;
                    }
                    else return false;
                }
                catch (OracleException ex)
                {
                    switch (ex.Number)
                    {
                        case 1:
                            throw new CarExpensesDatabaseException("User " + user.login + " already exists.");
                        case 2291:
                            throw new CarExpensesDatabaseException("Region ID " + user.regionId + " doesn't exist.");
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
        }
    }
}
