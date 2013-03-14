using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarExpenses
{
    public class CarExpensesException : Exception
    {
        public CarExpensesException(string message)
            : base(message)
        { }
    }

    public class CarExpensesDatabaseException : Exception
    {
        public CarExpensesDatabaseException(string message)
            : base(message)
        { }
    }
}
