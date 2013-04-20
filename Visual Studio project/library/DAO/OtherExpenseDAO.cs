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
    /// Datový model pracující s ostatními výdaji za auto
    /// </summary>
    class OtherExpenseDAO : BaseDAO
    {
        /// <summary>
        /// Konstruktor datového modelu.
        /// </summary>
        /// <param name="connection">Instance připojení k databázi</param>
        public OtherExpenseDAO(OracleConnection connection) : base(connection)
        { }

        /// <summary>
        /// Získává všechny informace o ostatních výdajích vztahující se k autu danému parametrem <paramref name="carId">carId</paramref>
        /// </summary>
        /// <param name="carId">ID auta</param>
        /// <returns>Seznam informací o ostatních výdajích pro dané auto</returns>
        /// <exception cref="CarExpensesDatabaseException">Při chybě práce s databází</exception>
        public List<OtherExpense> getCarOtherExpenses(int carId)
        {
            List<OtherExpense> otherExpenseList = new List<OtherExpense>();

            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM \"other_expense\" WHERE \"car_id\" = :p_car_id ORDER BY \"date\" DESC";
                    cmd.CommandType = System.Data.CommandType.Text;

                    OracleParameter pCarId = new OracleParameter();
                    pCarId.OracleDbType = OracleDbType.Decimal;
                    pCarId.Value = carId;
                    pCarId.ParameterName = "p_car_id";

                    cmd.Parameters.Add(pCarId);

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                OtherExpense otherExpense = new OtherExpense();
                                otherExpense.id = Convert.ToInt32(dr["id"].ToString());
                                otherExpense.carId = Convert.ToInt32(dr["car_id"].ToString());
                                otherExpense.km = Convert.ToInt32(dr["km"].ToString());
                                otherExpense.cost = Convert.ToInt32(dr["cost"].ToString());
                                otherExpense.date = Convert.ToDateTime(dr["date"].ToString());
                                otherExpense.description = dr["description"].ToString();
                                otherExpenseList.Add(otherExpense);
                            }
                        }

                        return otherExpenseList;
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
                catch (Exception ex)
                {
                    throw new CarExpensesDatabaseException("Unexpected error: " + ex.Message.ToString());
                }
            }
        }

        /// <summary>
        /// Vkládá informaci o novém jiném výdaji do databáze.
        /// Vše je potřebné se nachází v objektu jiného výdaje (parametr <paramref name="otherExpense">otherExpense</paramref>),
        /// včetné ID auta, ke kterému se vztahuje.
        /// </summary>
        /// <param name="otherExpense">Nová informace o jiném výdaji pro vložení do databáze</param>
        /// <returns>True při úspěchu vložení</returns>
        /// <exception cref="CarExpensesDatabaseException">Při chybě práce s databází</exception>
        public bool addOtherExpense(OtherExpense otherExpense)
        {
            using (OracleCommand cmdInsert = new OracleCommand())
            {
                try
                {
                    string sqlInsert = "INSERT INTO \"other_expense\" (\"car_id\", \"km\", \"cost\", \"description\", \"date\") ";
                    sqlInsert += "values (:p_car_id, :p_km, :p_cost, :p_description, to_date(:p_date, 'yyyy/mm/dd'))";

                    cmdInsert.CommandText = sqlInsert;
                    cmdInsert.Connection = connection;

                    OracleParameter pCarId = new OracleParameter();
                    pCarId.OracleDbType = OracleDbType.Decimal;
                    pCarId.Value = otherExpense.carId;
                    pCarId.ParameterName = "p_car_id";

                    OracleParameter pKm = new OracleParameter();
                    pKm.OracleDbType = OracleDbType.Decimal;
                    pKm.Value = otherExpense.km;
                    pKm.ParameterName = "p_km";

                    OracleParameter pCost = new OracleParameter();
                    pCost.OracleDbType = OracleDbType.Decimal;
                    pCost.Value = otherExpense.cost;
                    pCost.ParameterName = "p_cost";

                    OracleParameter pDescription = new OracleParameter();
                    pDescription.Value = otherExpense.description;
                    pDescription.ParameterName = "p_description";

                    OracleParameter pDate = new OracleParameter();
                    //pDate.OracleDbType = OracleDbType.Date;
                    pDate.Value = otherExpense.date.ToString("yyyy/MM/dd");
                    pDate.ParameterName = "p_date";

                    cmdInsert.Parameters.Add(pCarId);
                    cmdInsert.Parameters.Add(pKm);
                    cmdInsert.Parameters.Add(pCost);
                    cmdInsert.Parameters.Add(pDescription);
                    cmdInsert.Parameters.Add(pDate);

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
                            throw new CarExpensesDatabaseException("OtherExpense ID " + otherExpense.id + " already exists.");
                        //case 2291:
                        //    throw new CarExpensesDatabaseException("Car ID " + gas.carId + " doesn't exist.");
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
                catch (Exception ex)
                {
                    throw new CarExpensesDatabaseException("Unexpected error: " + ex.Message.ToString());
                }
            }
        }
    }
}
