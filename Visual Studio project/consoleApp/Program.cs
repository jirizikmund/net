using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarExpenses;

namespace CarExpensesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Initializing application... ");
                CoreApp app = CoreApp.init;
                Console.WriteLine("OK");

                Console.Write("Logging in... ");
                Console.WriteLine(app.login("jirka", "heslo").message);

                Console.ReadLine();
            }
            catch (CarExpensesException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to exit.");
                Console.ReadLine();
            }
        }
    }
}
