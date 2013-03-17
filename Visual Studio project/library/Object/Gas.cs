using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpenses
{
    public class Gas
    {
        public int id { get; set; }
        public int carId { get; set; }
        public int km { get; set; }
        public int mililiters { get; set; }
        public int cost { get; set; }
        public DateTime date { get; set; }
        public int timestamp { get; set; }
        
        public Gas() {
            id = 0;
            carId = 0;
            km = 0;
            mililiters = 0;
            cost = 0;
            date = new DateTime(0);
            timestamp = 0;
        }

        public override string ToString()
        {
            float liters = mililiters / 1000;
            return (date.ToString("dd.MM.yyyy")) + " " + 
                
                    String.Format("{0, 7}", km) + " km " +
                    String.Format("{0, 4}", liters) + " l " +
                    String.Format("{0, 4}", cost.ToString("C"));
        }

        // Součet 
        public static Gas operator +(Gas g1, Gas g2)
        {
            Gas result = new Gas();
            result.cost = g1.cost + g2.cost;
            result.mililiters = g1.mililiters + g2.mililiters;
            return result;
        }
    }
}
