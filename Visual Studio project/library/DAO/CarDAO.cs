using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

using CarExpenses;

namespace CarExpensesTools
{
    class CarDAO : BaseDAO
    {
        public CarDAO(OracleConnection connection) : base(connection)
        { }

        public List<Car> getUserCars(int userId)
        {
            List<Car> carList = new List<Car>();

            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM \"car\" WHERE \"user_id\" = :p_user_id";
                    cmd.CommandType = System.Data.CommandType.Text;

                    OracleParameter pUserId = new OracleParameter();
                    pUserId.OracleDbType = OracleDbType.Decimal;
                    pUserId.Value = userId;
                    pUserId.ParameterName = "p_user_id";

                    cmd.Parameters.Add(pUserId);

                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Car car = new Car();
                                car.id = Convert.ToInt32(dr["id"].ToString());
                                car.userId = Convert.ToInt32(dr["user_id"].ToString());
                                car.carModelId = Convert.ToInt32(dr["car_model_id"].ToString());
                                car.boughtYear = Convert.ToInt32(dr["bought_year"].ToString());
                                car.cost = Convert.ToInt32(dr["cost"].ToString());
                                carList.Add(car);
                            }
                        }

                        return carList;
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


        public bool addCar(Car car)
        {
            using (OracleCommand cmdInsert = new OracleCommand())
            {
                try
                {
                    string sqlInsert = "INSERT INTO \"car\" (\"user_id\", \"car_model_id\", \"bought_year\", \"cost\") ";
                    sqlInsert += "values (:p_user_id, :p_car_model_id, :p_bought_year, :p_cost)";

                    cmdInsert.CommandText = sqlInsert;
                    cmdInsert.Connection = connection;

                    OracleParameter pUserId = new OracleParameter();
                    pUserId.OracleDbType = OracleDbType.Decimal;
                    pUserId.Value = car.userId;
                    pUserId.ParameterName = "p_user_id";

                    OracleParameter pCarModelId = new OracleParameter();
                    pCarModelId.OracleDbType = OracleDbType.Decimal;
                    pCarModelId.Value = car.carModelId;
                    pCarModelId.ParameterName = "p_car_model_id";

                    OracleParameter pBoughtYear = new OracleParameter();
                    pBoughtYear.OracleDbType = OracleDbType.Decimal;
                    pBoughtYear.Value = car.boughtYear;
                    pBoughtYear.ParameterName = "p_bought_year";

                    OracleParameter pCost = new OracleParameter();
                    pCost.OracleDbType = OracleDbType.Decimal;
                    pCost.Value = car.cost;
                    pCost.ParameterName = "p_cost";

                    cmdInsert.Parameters.Add(pUserId);
                    cmdInsert.Parameters.Add(pCarModelId);
                    cmdInsert.Parameters.Add(pBoughtYear);
                    cmdInsert.Parameters.Add(pCost);

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
                            throw new CarExpensesDatabaseException("Car ID " + car.id + " already exists.");
                        case 2291:
                            throw new CarExpensesDatabaseException("Car Model ID " + car.carModelId + " doesn't exist.");
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
