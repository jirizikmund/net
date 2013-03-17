using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zikmundj.CarExpenses;

namespace zikmundj.ConsoleClient
{
    class ConsoleClient
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

        static string carMenuText =
            "****************************************************************\n" +
            "*                                                              *\n" +
            "*                          YOUR CAR                            *\n" +
            "*                                                              *\n" +
            "****************************************************************\n";

        static CarExpensesApp application = null;

        static User user = null;
        static Car car = null;

        /// <summary>
        /// Vstupní bod aplikace
        /// </summary>
        static void Main(string[] args)
        {
            Console.Write(startText);

            try
            {
                initApp();
                keyToContinue();
            Start:
                Console.Clear();
                Console.Write(startText);

                switch (menu(new string[] { "Login", "Register", "Exit" })) 
                {
                    case 0: // Escape
                        goto Start;
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
                goto Start;
            
            MainMenu:
                Console.Clear();
                Console.Write(mainMenuText);
                switch ( menu(new string[] { "Select car", "Add new car", "Logout", "Exit" }) )
                {
                    case 0: // Escape
                        goto MainMenu;
                    case 1: // Select car
                        if (selectCar())
                            goto CarMenu;
                        else
                            goto MainMenu;
                    case 2: // Add new car
                        addCar();
                        goto MainMenu;
                    case 3: // Logout
                        if (logout())
                            goto Start;
                        else
                            goto MainMenu;
                    case 4: // Exit
                        exit(0);
                        break;
                }
                goto MainMenu;

            CarMenu:
                Console.Clear();
                Console.Write(carMenuText);
                switch (menu(new string[] { "Add gas", "Add service", "History of gas", "History of service", "Logout", "Exit" }))
                {
                    case 0: // Escape
                        car = null;
                        goto MainMenu;
                    case 1: // Add gas
                        addGas();
                        goto CarMenu;
                    case 2: // Add service
                        addService();
                        goto CarMenu;
                    case 3: // History of gas
                        writeGasStats();
                        goto CarMenu;
                    case 4: // History of service
                        writeServiceStats();
                        goto CarMenu;
                    case 5: // Logout
                        if (logout())
                            goto Start;
                        else
                            goto CarMenu;
                    case 6: // Exit
                        exit(0);
                        break;
                }
                goto CarMenu;


                exit(0);
            }
            catch (CarExpensesException ex)
            {
                Console.WriteLine(ex.Message);
                exit(1);
            }
        }

        /// <summary>
        /// Inicializace aplikace
        /// </summary>
        static void initApp()
        {
            Console.WriteLine();
            Console.Write("Initializing application... ");
            application = CarExpensesApp.init;
            Console.WriteLine("OK");
        }

        /// <summary>
        /// Přihlášení uživatele
        /// </summary>
        static bool login()
        {
            Console.Write("login: ");
            string login = Console.ReadLine();
            Console.Write("password: ");
            string password = readPassword();

            UserResponse response = application.login(login, password);
            Console.WriteLine(response.message);

            user = response.user;

            if (response.success == false)
            {
                keyToContinue();
            }

            return response.success;
        }

        /// <summary>
        /// Odhlášení uživatele
        /// </summary>
        static bool logout()
        {
            Response response = application.logout();
            if (response.success == true)
            {
                user = null;
            }
            Console.WriteLine(response.message);
            keyToContinue();
            return response.success;
        }

        /// <summary>
        /// Vynutí stisknutí libovolné klávesy před pokračováním
        /// </summary>
        static void keyToContinue(string message = "--press any key to continue--")
        {
            Console.WriteLine();
            Console.Write(message);
            Console.ReadKey();
        }

        /// <summary>
        /// Registrace uživatele
        /// </summary>
        static bool register()
        {
            Console.WriteLine("==NEW REGISTRATION==");
            Console.Write("Login: ");
            string login = Console.ReadLine();

            Console.Write("Email: ");
            string email;
            while ( CarExpensesApp.validateEmail( email=Console.ReadLine()) == false )
            {
                Console.WriteLine("--Please enter valid email address!");
                Console.Write("Email: ");
            }
            
            string password;
            string password2;
            Console.Write("Password:");
            password = readPassword();
            Console.Write("Password again:");
            password2 = readPassword();
            while ( password != password2 )
            {
                Console.WriteLine("--Passwords must be same!");
                Console.Write("Password:");
                password = readPassword();
                Console.Write("Password again:");
                password2 = readPassword();
            }

            Console.Write("Born year: ");
            int bornYear;
            while ( int.TryParse(Console.ReadLine(), out bornYear) == false)
            {
                Console.WriteLine("--Born year must be a number!");
                Console.Write("New born year: ");
            }

            int regionId = 0;
            /*
            Console.Write("New region ID: ");
            int regionId;
            while (int.TryParse(Console.ReadLine(), out regionId) == false)
            {
                Console.WriteLine("--Region ID must be a number!");
                Console.Write("New region ID: ");
            }
            */

            Console.Write("Registering... ");
            Response response = application.register(login, password, email, bornYear, regionId);
            Console.WriteLine(response.message);

            keyToContinue();

            return response.success;
        }

        /// <summary>
        /// Přidání nového auta
        /// </summary>
        static bool addCar()
        {
            Console.WriteLine("==ADD NEW CAR==");
            int carModelId = 0;
            /*
            Console.Write("New car model ID: ");
            int carModelId;
            while (int.TryParse(Console.ReadLine(), out carModelId) == false)
            {
                Console.WriteLine("--Car model ID must be a number!");
                Console.Write("New car model ID: ");
            }
            */
            Console.Write("New car name: ");
            string name;
            while ( (name = Console.ReadLine()).Length > 64 )
            {
                Console.WriteLine("--Name can't be longer than 64 characters");
                Console.Write("New car name: ");
            }

            Console.Write("New bought year: ");
            int boughtYear;
            while (int.TryParse(Console.ReadLine(), out boughtYear) == false)
            {
                Console.WriteLine("--Bought year must be a number!");
                Console.Write("New bought year: ");
            }

            Console.Write("New cost: ");
            int cost;
            while (int.TryParse(Console.ReadLine(), out cost) == false)
            {
                Console.WriteLine("--Cost must be a number!");
                Console.Write("New cost: ");
            }

            Console.Write("Adding new car... ");
            Response response = application.addCar(carModelId,name,boughtYear,cost);
            Console.WriteLine(response.message);

            keyToContinue();

            return response.success;
        }

        /// <summary>
        /// Přidání tankování
        /// </summary>
        static bool addGas()
        {
            if (car == null)
            {
                Console.WriteLine("No car selected.");
                keyToContinue();
                return false;
            }
            Console.WriteLine("==REFUELING OF GAS==");
            Console.Write("Km: ");
            int km;
            while (int.TryParse(Console.ReadLine(), out km) == false)
            {
                Console.WriteLine("--Km must be whole number!");
                Console.Write("Km: ");
            }

            Console.Write("Liters of gas: ");
            float liters;
            while (float.TryParse(Console.ReadLine(), out liters) == false)
            {
                Console.WriteLine("--Liters must be float number!");
                Console.Write("Liters of gas: ");
            }

            Console.Write("Cost: ");
            int cost;
            while (int.TryParse(Console.ReadLine(), out cost) == false)
            {
                Console.WriteLine("--Cost must be whole number!");
                Console.Write("Cost: ");
            }

            Console.Write("Date: ");
            DateTime date;
            while (DateTime.TryParse(Console.ReadLine(), out date) == false)
            {
                Console.WriteLine("--Date is not in valid format!");
                Console.Write("Date: ");
            }

            Console.Write("Adding new gas... ");
            Response response = application.addGas(car.id,km,liters,cost,date);
            Console.WriteLine(response.message);

            keyToContinue();

            return response.success;
        }

        /// <summary>
        /// Výpis stavu tankování pro aktuální auto
        /// </summary>
        /// <param name="itemsPerPage">Počet vypsaných záznamů na jednu stránku</param>
        static void writeGasStats(int itemsPerPage = 10)
        {
            if (car == null)
            {
                Console.WriteLine("No car selected.");
                keyToContinue();
                return;
            }

            GasResponse response = application.getCarGasses(car.id);

            Console.WriteLine(response.message);
            if (response.success == false || response.gasList == null)
            {
                keyToContinue();
                return;
            }

            Console.WriteLine();

            List<Gas> list = response.gasList;

            Gas totalGas = new Gas();
            foreach (Gas gas in list)
            {
                totalGas += gas;
            }
            Console.WriteLine("Total " + totalGas.mililiters/1000 + " liters of gas for " + totalGas.cost.ToString("c") + "." );

            int i = 0;
            foreach (Gas gas in list)
            {
                i++;
                Console.WriteLine(gas);
                if (i % itemsPerPage == 0)
                    keyToContinue("--press any key to show next 10 items--");
            }
            Console.WriteLine();
            keyToContinue("--END OF LIST, press any key to continue--");
        }

        /// <summary>
        /// Přidání opravy k aktuálnímu autu
        /// </summary>
        static bool addService()
        {
            if (car == null)
            {
                Console.WriteLine("No car selected.");
                keyToContinue();
                return false;
            }
            Console.WriteLine("==ADDING NEW SERVICE==");
            Console.Write("Km: ");
            int km;
            while (int.TryParse(Console.ReadLine(), out km) == false)
            {
                Console.WriteLine("--Km must be whole number!");
                Console.Write("Km: ");
            }
            Console.Write("Cost: ");
            int cost;
            while (int.TryParse(Console.ReadLine(), out cost) == false)
            {
                Console.WriteLine("--Cost must be whole number!");
                Console.Write("Cost: ");
            }

            int serviceTypeId = 0;
            /*
            Console.Write("Service type ID: ");
            int serviceTypeId;
            while (int.TryParse(Console.ReadLine(), out serviceTypeId) == false)
            {
                Console.WriteLine("--Service type ID must be number!");
                Console.Write("Service type ID: ");
            }
            */

            Console.Write("Description: ");
            string description;
            while ((description = Console.ReadLine()).Length > 1024 )
            {
                Console.WriteLine("--Description can't be longer than 1024 characters!");
                Console.Write("Description: ");
            }

            Console.Write("Date: ");
            DateTime date;
            while (DateTime.TryParse(Console.ReadLine(), out date) == false)
            {
                Console.WriteLine("--Date is not in valid format!");
                Console.Write("Date: ");
            }

            Console.Write("Adding new service... ");
            Response response = application.addService(car.id,km,cost,serviceTypeId,description,date);
            Console.WriteLine(response.message);

            keyToContinue();

            return response.success;
        }

        /// <summary>
        /// Výpis stavu oprav pro aktuální auto
        /// </summary>
        /// <param name="itemsPerPage">Počet vypsaných záznamů na jednu stránku</param>
        static void writeServiceStats(int itemsPerPage = 10)
        {
            if (car == null)
            {
                Console.WriteLine("No car selected.");
                keyToContinue();
                return;
            }

            ServiceResponse response = application.getCarServices(car.id);

            Console.WriteLine(response.message);
            if (response.success == false || response.serviceList.Count == 0)
            {
                keyToContinue();
                return;
            }

            Console.WriteLine();

            List<Service> list = response.serviceList;

            Service totalService = new Service();
            foreach (Service service in list)
            {
                totalService += service;
            }
            Console.WriteLine("Total cost of services: " + totalService.cost);
            Console.WriteLine();

            int i = 0;
            foreach (Service service in list)
            {
                i++;
                Console.WriteLine(service);
                if (i % itemsPerPage == 0)
                    keyToContinue("--press any key to show next 10 items--");
            }
            Console.WriteLine();
            keyToContinue("--END OF LIST, press any key to continue--");
        }

        /// <summary>
        /// Načtení hesla od uživatele, znaky jsou nahrazovány hvězdičkou
        /// </summary>
        /// <returns>Načtené heslo</returns>
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

        /// <summary>
        /// Výpis menu pro výbě položek - položky jsou vybírány šipkami nahoru a dolu, entrem vybírá, escape ruší nabídku
        /// </summary>
        /// <param name="items">Pole řetězců, jednotlivé položky nabídky</param>
        /// <returns>Číslo byrané položky. 0 = escape, 1 = první položka, 2 = druhá....</returns>
        static int menu(string[] items)
        {
            Console.WriteLine();
            ConsoleKeyInfo key;

            int currentLineCursor = Console.CursorTop;
            int selected = 0;
            do
            {
                Console.SetCursorPosition(0, currentLineCursor);
                for (int i = 0; i < items.Length; i++)
                {
                    if (i == selected)
                        Console.Write("> ");
                    else
                        Console.Write("  ");
                    Console.WriteLine(items[i] + "  ");
                }
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (selected > 0)
                        selected--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (selected < items.Length - 1)
                        selected++;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return selected+1;
        }

        /// <summary>
        /// Výpis všech aut přihlášeného uživatele - uživatel vybírá šipkami nahoru a dolu, entrem potvrzuje, escape ruší nabídku
        /// </summary>
        /// <returns>Stav, zda se výběr podařil (true/false)</returns>
        static bool selectCar()
        {
            CarResponse response = application.getUserCars();
            Console.WriteLine(response.message);
            if (response.success == false || response.carList.Count == 0)
            {
                keyToContinue();
                return false;
            }

            Console.WriteLine();

            List<Car> list = response.carList;

            ConsoleKeyInfo key;

            int selected = 0;
            Car selectedCar = null;
            int currentLineCursor = Console.CursorTop;

            do
            {
                Console.SetCursorPosition(0, currentLineCursor);

                int i = 0;
                foreach(Car _car in list)
                {
                    if (i == selected)
                    {
                        Console.Write("> ");
                        selectedCar = _car;
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine(_car);
                    i++;
                }

                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (selected>0) selected--;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (selected < list.Count-1) selected++;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    return false;
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            
            car = selectedCar;
            return true;
        }

        /// <summary>
        /// Ukončí aplikaci, v případě potřeby odhásí uživatele
        /// </summary>
        /// <param name="code">Exit code returned to system</param>
        static void exit(int code = 0)
        {
            if (user != null)
                application.logout();
            
            Console.WriteLine();
            Console.Write("--press any key to exit--");
            Console.ReadKey();

            Environment.Exit(code);
        }
        
    }
}
