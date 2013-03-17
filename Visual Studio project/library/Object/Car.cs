using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpenses
{
    public class Car
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int carModelId { get; set; }
        public int boughtYear { get; set; }
        public int cost { get; set; }
        public string name { get; set; }
        
        public Car() {
            id = 0;
            userId = 0;
            carModelId = 0;
            boughtYear = 0;
            cost = 0;
            name = "";
        }

        public override string ToString()
        {
            return String.Format("{0, -15}", name) + "bought " + String.Format("{0, 4}", boughtYear) + ", cost " + cost.ToString("C"); 
        }
    }
}
