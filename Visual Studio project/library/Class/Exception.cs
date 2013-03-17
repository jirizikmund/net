using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zikmundj.CarExpenses
{
    /// <summary>
    /// Uživatelská výjimka používaná při chybě při běhu aplikace
    /// </summary>
    public class CarExpensesException : Exception
    {
        /// <summary>
        /// Konstruktor výjimky
        /// </summary>
        public CarExpensesException(string message)
            : base(message)
        { }
    }

    /// <summary>
    /// Uživatelská výjimka používaná při chybě při práci s databází
    /// </summary>
    public class CarExpensesDatabaseException : Exception
    {
        /// <summary>
        /// Konstruktor výjimky
        /// </summary>
        public CarExpensesDatabaseException(string message)
            : base(message)
        { }
    }
}
