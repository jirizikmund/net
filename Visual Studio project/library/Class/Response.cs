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

    public struct UserResponse
    {
        public bool success;
        public String message;
        public User user;

        public UserResponse(bool success = false, String message = "", User user = null)
        {
            this.success = success;
            this.message = message;
            this.user = user;
        }
    }

    public struct GasResponse
    {
        public bool success;
        public String message;
        public List<Gas> gasList;

        public GasResponse(bool success = false, String message = "", List<Gas> gasList = null)
        {
            this.success = success;
            this.message = message;
            this.gasList = gasList;
        }
    }

    public struct ServiceResponse
    {
        public bool success;
        public String message;
        public List<Service> serviceList;

        public ServiceResponse(bool success = false, String message = "", List<Service> serviceList = null)
        {
            this.success = success;
            this.message = message;
            this.serviceList = serviceList;
        }
    }
}
