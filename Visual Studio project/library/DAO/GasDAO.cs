using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

using CarExpenses;

namespace CarExpensesTools
{
    class GasDAO : BaseDAO
    {
        public GasDAO(OracleConnection connection) : base(connection)
        { }

        // <summary>
        // Získává všechny informace o tankování vztahující se ka autu danému parametrem <paramref name="carId">carId</paramref>
        // </summary>
        // <param name="carId">ID auta</param>
        // <returns>Seznam informací o tankování pro dané auto</returns>
        // <exception cref="CarExpensesDatabaseException">Při chybě práce s databází</exception>
        public List<Gas> getCarGasses(int carId)
        {
            List<Gas> gasList = new List<Gas>();

            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM \"gas\" WHERE \"car_id\" = :p_car_id";
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
                                Gas gas = new Gas();
                                gas.id = Convert.ToInt32(dr["id"].ToString());
                                gas.carId = Convert.ToInt32(dr["car_id"].ToString());
                                gas.km = Convert.ToInt32(dr["km"].ToString());
                                gas.mililiters = Convert.ToInt32(dr["mililiters"].ToString());
                                gas.cost = Convert.ToInt32(dr["cost"].ToString());
                                gas.date = Convert.ToDateTime(dr["date"].ToString());
                                gasList.Add(gas);
                            }
                        }

                        return gasList;
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


        public bool addGas(Gas gas)
        {
            using (OracleCommand cmdInsert = new OracleCommand())
            {
                try
                {
                    string sqlInsert = "INSERT INTO \"gas\" (\"car_id\", \"km\", \"mililiters\", \"cost\", \"date\") ";
                    sqlInsert += "values (:p_car_id, :p_km, :p_mililiters, :p_cost, to_date(:p_date, 'yyyy/mm/dd'))";

                    cmdInsert.CommandText = sqlInsert;
                    cmdInsert.Connection = connection;

                    OracleParameter pCarId = new OracleParameter();
                    pCarId.OracleDbType = OracleDbType.Decimal;
                    pCarId.Value = gas.carId;
                    pCarId.ParameterName = "p_car_id";

                    OracleParameter pKm = new OracleParameter();
                    pKm.OracleDbType = OracleDbType.Decimal;
                    pKm.Value = gas.km;
                    pKm.ParameterName = "p_km";

                    OracleParameter pMililiters = new OracleParameter();
                    pMililiters.OracleDbType = OracleDbType.Decimal;
                    pMililiters.Value = gas.mililiters;
                    pMililiters.ParameterName = "p_mililiters";

                    OracleParameter pCost = new OracleParameter();
                    pCost.OracleDbType = OracleDbType.Decimal;
                    pCost.Value = gas.cost;
                    pCost.ParameterName = "p_cost";

                    OracleParameter pDate = new OracleParameter();
                    pDate.OracleDbType = OracleDbType.Date;
                    pDate.Value = gas.date;
                    pDate.ParameterName = "p_date";

                    cmdInsert.Parameters.Add(pCarId);
                    cmdInsert.Parameters.Add(pKm);
                    cmdInsert.Parameters.Add(pMililiters);
                    cmdInsert.Parameters.Add(pCost);
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
                            throw new CarExpensesDatabaseException("Gas ID " + gas.id + " already exists.");
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
