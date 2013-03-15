using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpenses
{
    public class CarModel
    {
        public int id { get; set; }
        public string manufacturer { get; set; }
        public string type { get; set; }
        public string engine { get; set; }
        public int year { get; set; }
        public int mililitersPer100 { get; set; }
        
        public CarModel() {
            id = 0;
            manufacturer = "";
            type = "";
            engine = "";
            year = 0;
            mililitersPer100 = 0;
        }
    }
}
