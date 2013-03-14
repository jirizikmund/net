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
        public int code;
        public Object obj;

        public Response(bool success, String message = "", int code = 0, Object obj = null)
        {
            this.success = success;
            this.message = message;
            this.code = code;
            this.obj = obj;
        }
    }
}
