using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.DataAccess.Client;

namespace CarExpensesTools
{
    class BaseDAO
    {
        protected OracleConnection connection;

        public BaseDAO(OracleConnection connection)
        {
            this.connection = connection;
        }
    }
}
