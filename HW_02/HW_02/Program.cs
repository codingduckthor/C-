using System;
using System.Linq;
using System.Security.Policy;

namespace HW_02
{

    class Task1
    {
        public void Square(char _symbol, int _size)
        {
            for (int row = 1; row <= _size; row++)
            {
                for (int col = 1; col < _size; col++)
                {
                    Console.Write(_symbol);
                }
                Console.WriteLine(_symbol);
            }
        }
    }

    class Task2
    {
        public bool PalindromCheck(int number)
        {
            if (number < 0) return false;

            int original = number;
            int reversed = 0;

            while (number != 0)
            {
                int digit = number % 10;
                reversed = reversed * 10 + digit;
                number /= 10;
            }

            return original == reversed;
        }
    }

    class Task3
    {
        public static void FilterArray(int[] originalArr, int[] exclude)
        {
            var result = originalArr.Except(exclude);

            foreach (var num in result)
            {
                Console.Write(num + ", ");
            }
        }
    }

    class WebSite
    {
        private string siteName;
        private string sitePath;
        private string siteDescription;
        private string siteIP;

        public void inputData()
        {
            Console.Write("Enter site name: ");
            siteName = Console.ReadLine();

            Console.Write("Enter site path: ");
            sitePath = Console.ReadLine();

            Console.Write("Enter description: ");
            siteDescription = Console.ReadLine();

            Console.Write("Enter IP address: ");
            siteIP = Console.ReadLine();
        }

        public void outputData()
        {
            Console.WriteLine("\nSite info:");
            Console.WriteLine($"Name: {siteName}");
            Console.WriteLine($"Path: {sitePath}");
            Console.WriteLine($"Description: {siteDescription}");
            Console.WriteLine($"IP: {siteIP}");
        }


        public void SetName(string name)
        {
            siteName = name;
        }

        public string GetName()
        {
            return siteName;
        }

        public void SetPath(string path)
        {
            sitePath = path;
        }

        public string GetPath()
        {
            return sitePath;
        }

        public void SetDescription(string description)
        {
            siteDescription = description;
        }

        public string GetDescription()
        {
            return siteDescription;
        }

        public void SetIP(string ip)
        {
            siteIP = ip;
        }

        public string GetIP()
        {
            return siteIP;
        }
    }


//    Создайте класс «Журнал». Необходимо хранить в полях класса: название журнала, год основания, описание журнала, контактный телефон, контактный e-mail.
//Реализуйте методы класса для ввода данных, вывода данных, реализуйте доступ к отдельным полям через методы класса.

    class Journal
    {
        private string name;
        private int year;
        private string description;
        private string contactNumber;
        private string email;

        public void InputData()
        {
            Console.Write("Enter journal name: ");
            name = Console.ReadLine();

            Console.Write("Enter year of establishment: ");
            int.TryParse(Console.ReadLine(), out year);

            Console.Write("Enter description: ");
            description = Console.ReadLine();

            Console.Write("Enter contact number: ");
            contactNumber = Console.ReadLine();

            Console.Write("Enter email address: ");
            email = Console.ReadLine();
        }

        public void OutputData()
        {
            Console.WriteLine("\nJournal info:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Founding year: {year}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Contact number: {contactNumber}");
            Console.WriteLine($"E-mail: {email}");
        }


        public void SetName(string value) => name = value;
        public string GetName() => name;

        public void SetYear(int value) => year = value;
        public int GetYear() => year;

        public void SetDescription(string value) => description = value;
        public string GetDescription() => description;

        public void SetContactNumber(string value) => contactNumber = value;
        public string GetContactNumber() => contactNumber;

        public void SetEmail(string value) => email = value;
        public string GetEmail() => email;
    }

//    Cоздайте класс «Магазин». Необходимо хранить в
//полях класса: название магазина, адрес, описание профиля магазина, контактный телефон, контактный e-mail.
//Реализуйте методы класса для ввода данных, вывода
//данных, реализуйте доступ к отдельным полям через
//методы класса.
    class Shop
    {
        private string name;
        private string address;
        private string description;
        private string contactNumber;
        private string email;

        public void InputData()
        {
            Console.Write("Enter shop name: ");
            name = Console.ReadLine();

            Console.Write("Enter address: ");
            address = Console.ReadLine();

            Console.Write("Enter description: ");
            description = Console.ReadLine();

            Console.Write("Enter contact number: ");
            contactNumber = Console.ReadLine();

            Console.Write("Enter email: ");
            email = Console.ReadLine();
        }

        public void OutputData()
        {
            Console.WriteLine("\nShop info:");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Address: {address}");
            Console.WriteLine($"Description: {description}");
            Console.WriteLine($"Contact number: {contactNumber}");
            Console.WriteLine($"E-mail: {email}");
        }


        public void SetName(string value) => name = value;
        public string GetName() => name;

        public void SetAddress(string value) => address = value;
        public string GetAddress() => address;

        public void SetDescription(string value) => description = value;
        public string GetDescription() => description;

        public void SetContactNumber(string value) => contactNumber = value;
        public string GetContactNumber() => contactNumber;

        public void SetEmail(string value) => email = value;
        public string GetEmail() => email;
    }
    internal class Program
    {
        static void Main()
        {
            //Task1 figure = new Task1();
            //figure.Square('o', 5);

            //Task2 palindrome = new Task2();
            //Console.WriteLine(palindrome.PalindromCheck(1223221));

            //int[] arr = { 1, 2, 6, -1, 88, 7, 6 };
            //int[] remove = { 6, 88, 7 };

            //Task3.FilterArray(arr, remove);

            //WebSite site = new WebSite();

            //site.inputData();

            //site.outputData();

            //Console.WriteLine("\nOnly name: " + site.GetName());

            //site.SetName("Google");
            //Console.WriteLine("Updated name: " + site.GetName());

            //Journal journal = new Journal();

            //journal.InputData();
            //journal.OutputData();

            //Console.WriteLine("\nOnly name: " + journal.GetName());

            //journal.SetName("New Journal");
            //Console.WriteLine("Updated name: " + journal.GetName());

            Shop shop = new Shop();

            shop.InputData();
            shop.OutputData();
            Console.WriteLine("\nShop name: " + shop.GetName());

            shop.SetName("MegaStore");
            Console.WriteLine("Updated name: " + shop.GetName());
        }
    }
}
