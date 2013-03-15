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
        static string startText =
            "****************************************************************\n" +
            "*                                                              *\n" +
            "*                         CAR EXPENSES                         *\n" +
            "*                                                              *\n" +
            "*                  Semestral work for KIV/NET                  *\n" +
            "*                                                              *\n" +
            "*          @ Jiri Zikmund <zikmundj@students.zcu.cz>           *\n" +
            "*                                                              *\n" +
            "****************************************************************\n";
        
        static string mainMenuText =
            "****************************************************************\n" +
            "*                                                              *\n" +
            "*                          MAIN MENU                           *\n" +
            "*                                                              *\n" +
            "****************************************************************\n";

        static CarExpensesApp application = null;

        static void Main(string[] args)
        {
            Console.Write(startText);
            bool started = false;
            try
            {
                initApp();

            Start:
                if (started == true)
                {
                    Console.Clear();
                    Console.Write(startText);
                }
                started = true;
                
                switch( menu( new string[] {"Login","Register","Exit"} ) ) 
                {
                    case 1: // Login
                        if (login())
                            goto MainMenu;
                        else
                            goto Start;
                    case 2: // Register
                        register();
                        goto Start;
                    case 3: // Exit
                        exit(0);
                        break;
                }
            
            MainMenu:
                Console.Clear();
                Console.Write(mainMenuText);
                switch ( menu(new string[] { "Select car", "Add new car", "Remove car", "Logout", "Exit" }) )
                {
                    case 1: // Select car
                        
                        goto MainMenu;
                    case 2: // Add new car

                        goto MainMenu;
                    case 3: // Remove car
                        
                        goto MainMenu;
                    case 4: // Logout
                        application.logout();
                        goto Start;
                    case 5: // Exit
                        exit(0);
                        break;
                }

                exit(0);
            }
            catch (CarExpensesException ex)
            {
                Console.WriteLine(ex.Message);
                exit(1);
            }
        }

        static void initApp()
        {
            Console.WriteLine();
            Console.Write("Initializing application... ");
            application = CarExpensesApp.init;
            Console.WriteLine("OK");
        }

        static bool login()
        {
            Console.Write("login: ");
            string login = Console.ReadLine();
            Console.Write("password: ");
            string password = readPassword();

            Response response = application.login(login, password);
            Console.WriteLine(response.message);

            if (response.success == false)
            {
                keyToContinue();
            }

            return response.success;
        }

        static void keyToContinue()
        {
            Console.WriteLine();
            Console.Write("--press any key to continue--");
            Console.ReadKey();
        }

        static bool register()
        {
            Console.Write("New login: ");
            string login = Console.ReadLine();
            Console.Write("New email: ");
            string email = Console.ReadLine();
            Console.Write("New password: ");
            string password = readPassword();

            Console.Write("New born year: ");
            int bornYear;
            while ( int.TryParse(Console.ReadLine(), out bornYear) == false)
            {
                Console.WriteLine(" must be a number!");
                Console.Write("New born year: ");
            }

            Console.Write("New region ID: ");
            int regionId;
            while (int.TryParse(Console.ReadLine(), out regionId) == false)
            {
                Console.WriteLine(" must be a number!");
                Console.Write("New region ID: ");
            }

            Console.Write("Registering... ");
            Response response = application.register(login, password, email, bornYear, regionId);
            Console.WriteLine(response.message);

            keyToContinue();

            return response.success;
        }

        static string readPassword()
        {
            string pass = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return pass;
        }

        static int menu(string[] items)
        {
            Console.WriteLine();
            for (int i = 0; i < items.Length; i++)
            {
                Console.WriteLine( (char)(i+49) + ": " + items[i] );
            }
            Console.WriteLine("------------");
            Console.Write(    "Your choise: ");

            int result;
            do
            {
                result = Console.ReadKey(true).KeyChar - 48;
            }
            while (result < 1 || result > items.Length);

            Console.WriteLine(result);
            Console.WriteLine();

            return result;
        }

        static void exit(int code = 0)
        {
            Console.WriteLine();
            Console.Write("--press any key to exit--");
            Console.ReadKey();
            Environment.Exit(code);
        }
        
    }
}
