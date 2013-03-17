using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace zikmundj.CarExpensesDAO
{
    /// <summary>
    /// Bázová třída všech datových modelů
    /// </summary>
    class BaseDAO
    {
        protected OracleConnection connection;

        /// <summary>
        /// Konstruktor datového modelu.
        /// </summary>
        /// <param name="connection">Instance připojení k databázi</param>
        public BaseDAO(OracleConnection connection)
        {
            this.connection = connection;
        }
    }
}
