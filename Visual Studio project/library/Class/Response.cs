using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpenses
{
    public struct Response
    {
        public bool success;
        public String message;

        public Response(bool success = false, String message = "")
        {
            this.success = success;
            this.message = message;
        }
    }

    public struct CarResponse
    {
        public bool success;
        public String message;
        public List<Car> carList;

        public CarResponse(bool success = false, String message = "", List<Car> carList = null)
        {
            this.success = success;
            this.message = message;
            this.carList = carList;
        }
    }
}
