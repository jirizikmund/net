using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using zikmundj.CarExpenses;

namespace zikmundj.DesktopApp
{
    /// <summary>
    /// Slouží pro export uživatelovo dat do XML souboru
    /// </summary>
    class XmlExport
    {
        /// <summary>
        /// Export všech dat přihlášeného uživatele do XML souboru. Soubor je pojmenován export_user_ID-UZOVATELE.xml
        /// </summary>
        /// <param name="carExpensesApp">Instance jádra aplikace</param>
        /// <returns>Název vyexportovaného souboru</returns>
        public static string exportToXml(CarExpensesApp carExpensesApp)
        {
            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;

            string fileName = "export_user_" + carExpensesApp.getUser().id + ".xml";
            XmlWriter writer = XmlWriter.Create(fileName, setting); 
            
            writer.WriteStartDocument();
                writer.WriteStartElement("carExpensesExport");

                    CarResponse carResponse = carExpensesApp.getUserCars();
                    if (carResponse.success)
                    {
                        List<Car> carList = carResponse.carList;
                        foreach (Car car in carList)
                        {
                            writer.WriteStartElement("car");
                            writer.WriteElementString("id", car.id.ToString());
                            writer.WriteElementString("name", car.name);
                            writer.WriteElementString("cost", car.cost.ToString());
                            writer.WriteElementString("boughtYear", car.boughtYear.ToString());

                            writer.WriteStartElement("gasList");
                            List<Gas> gasList = carExpensesApp.getCarGasses(car.id).gasList;
                            foreach (Gas gas in gasList)
                            {
                                writer.WriteStartElement("gas");
                                writer.WriteElementString("id", gas.id.ToString());
                                writer.WriteElementString("km", gas.km.ToString());
                                writer.WriteElementString("liters", (gas.mililiters / 1000).ToString());
                                writer.WriteElementString("cost", gas.cost.ToString());
                                writer.WriteElementString("date", gas.date.ToString());
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();

                            writer.WriteStartElement("serviceList");
                            List<Service> serviceList = carExpensesApp.getCarServices(car.id).serviceList;
                            foreach (Service service in serviceList)
                            {
                                writer.WriteStartElement("service");
                                writer.WriteElementString("id", service.id.ToString());
                                writer.WriteElementString("km", service.km.ToString());
                                writer.WriteElementString("description", service.description);
                                writer.WriteElementString("cost", service.cost.ToString());
                                writer.WriteElementString("date", service.date.ToString());
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();

                            writer.WriteStartElement("otherExpenseList");
                            List<OtherExpense> otherExpenseList = carExpensesApp.getCarOtherExpenses(car.id).otherExpenseList;
                            foreach (OtherExpense otherExpense in otherExpenseList)
                            {
                                writer.WriteStartElement("service");
                                writer.WriteElementString("id", otherExpense.id.ToString());
                                writer.WriteElementString("km", otherExpense.km.ToString());
                                writer.WriteElementString("description", otherExpense.description);
                                writer.WriteElementString("cost", otherExpense.cost.ToString());
                                writer.WriteElementString("date", otherExpense.date.ToString());
                                writer.WriteEndElement();
                            }
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                    }
                writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();

            return fileName;
        }
    }
}
