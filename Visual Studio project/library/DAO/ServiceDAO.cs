using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

using CarExpenses;

namespace CarExpensesTools
{
    class ServiceDAO : BaseDAO
    {
        public ServiceDAO(OracleConnection connection) : base(connection)
        { }

        public List<Service> getCarServices(int carId)
        {
            List<Service> serviceList = new List<Service>();

            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    cmd.Connection = connection;
                    cmd.CommandText = "SELECT * FROM \"service\" WHERE \"car_id\" = :p_car_id";
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
                                Service service = new Service();
                                service.id = Convert.ToInt32(dr["id"].ToString());
                                service.carId = Convert.ToInt32(dr["car_id"].ToString());
                                service.km = Convert.ToInt32(dr["km"].ToString());
                                service.serviceTypeId = Convert.ToInt32(dr["service_type_id"].ToString());
                                service.cost = Convert.ToInt32(dr["cost"].ToString());
                                service.date = Convert.ToDateTime(dr["date"].ToString());
                                service.description = dr["description"].ToString();
                                serviceList.Add(service);
                            }
                        }

                        return serviceList;
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


        public bool addService(Service service)
        {
            using (OracleCommand cmdInsert = new OracleCommand())
            {
                try
                {
                    string sqlInsert = "INSERT INTO \"service\" (\"car_id\", \"km\", \"cost\", \"service_type_id\", \"description\", \"date\") ";
                    sqlInsert += "values (:p_car_id, :p_km, :p_cost, :p_service_type_id, :p_description, to_date(:p_date, 'yyyy/mm/dd'))";

                    cmdInsert.CommandText = sqlInsert;
                    cmdInsert.Connection = connection;

                    OracleParameter pCarId = new OracleParameter();
                    pCarId.OracleDbType = OracleDbType.Decimal;
                    pCarId.Value = service.carId;
                    pCarId.ParameterName = "p_car_id";

                    OracleParameter pKm = new OracleParameter();
                    pKm.OracleDbType = OracleDbType.Decimal;
                    pKm.Value = service.km;
                    pKm.ParameterName = "p_km";

                    OracleParameter pCost = new OracleParameter();
                    pCost.OracleDbType = OracleDbType.Decimal;
                    pCost.Value = service.cost;
                    pCost.ParameterName = "p_cost";

                    OracleParameter pServiceTypeId = new OracleParameter();
                    pServiceTypeId.OracleDbType = OracleDbType.Decimal;
                    pServiceTypeId.Value = service.serviceTypeId;
                    pServiceTypeId.ParameterName = "p_service_type_id";

                    OracleParameter pDescription = new OracleParameter();
                    pDescription.Value = service.description;
                    pDescription.ParameterName = "p_description";

                    OracleParameter pDate = new OracleParameter();
                    pDate.OracleDbType = OracleDbType.Date;
                    pDate.Value = service.date;
                    pDate.ParameterName = "p_date";

                    cmdInsert.Parameters.Add(pCarId);
                    cmdInsert.Parameters.Add(pKm);
                    cmdInsert.Parameters.Add(pCost);
                    cmdInsert.Parameters.Add(pServiceTypeId);
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
                            throw new CarExpensesDatabaseException("Service ID " + service.id + " already exists.");
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
