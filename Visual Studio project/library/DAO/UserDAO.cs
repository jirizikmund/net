using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using zikmundj.CarExpenses;

namespace zikmundj.CarExpensesDAO
{
    /// <summary>
    /// Datový model pracující s uživateli
    /// </summary>
    class UserDAO : BaseDAO
    {
        /// <summary>
        /// Konstruktor datového modelu.
        /// </summary>
        /// <param name="connection">Instance připojení k databázi</param>
        public UserDAO(OracleConnection connection) : base(connection)
        { }

        /// <summary>
        /// Přihlášení uživatele pomocí jména a hesla v parametrech <paramref name="login">login</paramref>
        /// a <paramref name="password">password</paramref>. Heslo musí být již zahashované, musí být
        /// obstaráno již business logikou.
        /// </summary>
        /// <param name="login">Přihlašovací jméno uživatele.</param>
        /// <param name="password">Zahashované heslo uživatele</param>
        /// <returns>Objekt přihlášeného uživatele při úspěchu, null při chybě</returns>
        /// <exception cref="CarExpensesDatabaseException">Při chybě práce s databází</exception>
        public User login(string login, string password)
        {
            User user = null;

            using (OracleCommand cmdSelect = new OracleCommand())
            {
                try
                {
                    cmdSelect.Connection = connection;
                    cmdSelect.CommandText = "SELECT * FROM \"users\" WHERE \"login\" = '" + login + "' AND \"password\" = '" + password + "'";
                    cmdSelect.CommandType = System.Data.CommandType.Text;

                    using (OracleDataReader dr = cmdSelect.ExecuteReader())
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

        /// <summary>
        /// Registrace nového uživatele. O neduplicitu loginů se stará integrití omezení databáze
        /// a v případě duplicity je vyvolána výjimka. ID uživatele a časový otisk (timestamp) jsou automaticky
        /// generovány databází a i když jsou v objektu přiřazeny, jsou při vkládání ignorovány.
        /// </summary>
        /// <param name="user">Objekt nového uživatele pro registraci</param>
        /// <returns>True při úspěchu, false při chybě</returns>
        /// <exception cref="CarExpensesDatabaseException">Při chybě práce s databází</exception>
        public bool register(User user)
        {
            using (OracleCommand cmdInsert = new OracleCommand())
            {
                try
                {
                    string sqlInsert = "INSERT INTO \"users\" (\"login\", \"email\", \"password\", \"region_id\", \"born_year\") ";
                    sqlInsert += "values (:p_login, :p_email, :p_password, :p_region_id, :p_born_year)";

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
                catch (Exception ex) //catches any other error
                {
                    throw new CarExpensesDatabaseException("Unexpected error: " + ex.Message.ToString());
                }
            }
        }
    }
}
