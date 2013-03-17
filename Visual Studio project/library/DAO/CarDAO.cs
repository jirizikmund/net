using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

using CarExpenses;

namespace CarExpensesTools
{
    // <summary>
    // Datový model epracující s autama v databázi
    // </summary>
    class CarDAO : BaseDAO
    {
        // <summary>
        // Konstruktor datového modelu.
        // </summary>
        // <param name="connection">Instance připojení k databázi</param>
        public CarDAO(OracleConnection connection) : base(connection)
        { }

        // <summary>
        // Získává všechny auta patřící uživateli specifikovaného parametrem <paramref name="userId">userId</paramref>
        // </summary>
        // <param name="userId">ID uživatele</param>
        // <returns>Seznam aut daného uživatele</returns>
        // <exception cref="CarExpensesDatabaseException">Při chybě práce s databází</exception>
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
                                car.name = dr["name"].ToString();
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

        // <summary>
        // Vkládá do databáze nové auto.
        // Vše je potřebné se nachází v objektu auta (parametr <paramref name="userId">userId</paramref>),
        // včetné ID uživatele, ke kterému se vztahuje.
        // </summary>
        // <param name="car">Nové auto pro vložení do databáze</param>
        // <returns>Úspěch vložení</returns>
        // <exception cref="CarExpensesDatabaseException">Při chybě práce s databází</exception>
        public bool addCar(Car car)
        {
            using (OracleCommand cmdInsert = new OracleCommand())
            {
                try
                {
                    string sqlInsert = "INSERT INTO \"car\" (\"user_id\", \"car_model_id\", \"bought_year\", \"cost\", \"name\") ";
                    sqlInsert += "values (:p_user_id, :p_car_model_id, :p_bought_year, :p_cost, :p_name)";

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

                    OracleParameter pName = new OracleParameter();
                    pName.Value = car.name;
                    pName.ParameterName = "p_name";

                    cmdInsert.Parameters.Add(pUserId);
                    cmdInsert.Parameters.Add(pCarModelId);
                    cmdInsert.Parameters.Add(pBoughtYear);
                    cmdInsert.Parameters.Add(pCost);
                    cmdInsert.Parameters.Add(pName);

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

        // <summary>
        // Zjišťuje, zda uživatel s ID <paramref name="userId">userId</paramref>
        // je vlastníkem auta s ID <paramref name="userId">carId</paramref>.
        // </summary>
        // <param name="userId">ID uživatele</param>
        // <param name="carId">ID auta</param>
        // <returns>True, pokud uživatel je vlastník auta</returns>
        // <exception cref="CarExpensesDatabaseException">Při chybě práce s databází</exception>
        public bool userHasCar(int userId, int carId)
        {

            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM \"car\" WHERE \"id\" = :p_car_id";
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
                            dr.Read();
                            return ( userId == Convert.ToInt32(dr["user_id"].ToString()) );
                        }
                        else
                        {
                            throw new CarExpensesDatabaseException("Car ID " + carId + " doesn't exist.");
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
                catch (Exception ex)
                {
                    throw new CarExpensesDatabaseException("Unexpected error: " + ex.Message.ToString());
                }
            }
        }
    }
}
