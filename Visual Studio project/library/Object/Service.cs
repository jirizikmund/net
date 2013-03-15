using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpenses
{
    public class Service
    {
        public int id { get; set; }
        public int carId { get; set; }
        public int km { get; set; }
        public int serviceTypeId { get; set; }
        public int cost { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public int timestamp { get; set; }
        
        public Service() {
            id = 0;
            carId = 0;
            km = 0;
            serviceTypeId = 0;
            cost = 0;
            description = "";
            date = new DateTime(0);
            timestamp = 0;
        }
    }
}
