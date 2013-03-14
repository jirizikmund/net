using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpensesTools
{
    public class User
    {
        public int id { get; set; }
        public String login { get; set; }
        public String email { get; set; }
        public int bornYear { get; set; }
        public int regionId { get; set; }
        public String region { get; set; }
        
        public User() {
            id = 0;
            login = "";
            bornYear = 0;
            regionId = 0;
            region = "";
        }
    }
}
