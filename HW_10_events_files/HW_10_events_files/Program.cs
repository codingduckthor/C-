using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HW_10_events_files
{
    // ================================================= задание 1

    class TemperatureSensor
    {
        public event Action<int> onTemperatureTooHigh;

        public void setTemperature(int temp)
        {
            if (temp > 30)
            {
                onTemperatureTooHigh?.Invoke(temp);
            }
            else
            {
                Console.WriteLine("All good.");
            }
        }

        public void over30deg(int temp)
        {
            Console.WriteLine($"Current temperature ({temp}) is over 30 degrees");
        }

        public void Meltdown(int temp)
        {
            Console.WriteLine($"{temp} too high! Reactor meltdown");
        }

        public void writeToLog(int temp)
        {
            string path = "log.txt";
            string message = $"Temperature too high: {temp}\n";
            File.AppendAllText(path, message);
        }
    }

    // ================================================= задание 4

    class Order
    {
        public event Action<int, string> onOrderCreated;

        protected int Id;
        protected string Name;

        public Order(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public void CreateOrder()
        {
            onOrderCreated?.Invoke(Id, Name);
        }
        public static void ShowOrder(int id, string name)
        {
            Console.WriteLine($"Order created: {id} - {name}");
        }

        public static void SaveOrder(int id, string name)
        {
            string path = "orders.txt";
            string text = $"Order #{id} - {name}{Environment.NewLine}";
            File.AppendAllText(path, text);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //================================================= задание 1
            //TemperatureSensor sensor = new TemperatureSensor();

            //sensor.onTemperatureTooHigh += sensor.over30deg;
            //sensor.onTemperatureTooHigh += sensor.Meltdown;
            //sensor.onTemperatureTooHigh += sensor.writeToLog;

            //sensor.setTemperature(25);
            //sensor.setTemperature(35);

            //================================================= задание 2 и 3
            //string path = "names.txt";
            ////string path = "d:\\popo<>\\names.txt";
            //string path2 = "errors.txt";

            //bool running = true;

            //while (running)
            //{
            //    Console.WriteLine("\n--- MENU ---");
            //    Console.WriteLine("1. Add new name to a file");
            //    Console.WriteLine("2. Show saved names from the file");
            //    Console.WriteLine("3. Show errors log");
            //    Console.WriteLine("0. Exit");

            //    Console.Write("Choose option: ");
            //    string input = Console.ReadLine();

            //    switch (input)
            //    {
            //        case "1":
            //            Console.Write("Enter new name: ");
            //            string name = Console.ReadLine();

            //            try
            //            {
            //                File.AppendAllText(path, name + Environment.NewLine);
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine("Error");
            //                File.AppendAllText(path2, ex.Message + Environment.NewLine);
            //            }
            //            break;

            //        case "2":
            //            try
            //            {
            //                if (File.Exists(path))
            //                {
            //                    string[] names = File.ReadAllLines(path);
            //                    foreach (var n in names)
            //                    {
            //                        Console.WriteLine(n);
            //                    }
            //                }
            //                else
            //                {
            //                    Console.WriteLine("File not found.");
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine("Error");
            //                File.AppendAllText(path2, ex.Message + Environment.NewLine);
            //            }
            //            break;

            //        case "3":
            //            try
            //            {
            //                if (File.Exists(path2))
            //                {
            //                    string text = File.ReadAllText(path2);
            //                    Console.WriteLine("\n--- ERRORS ---");
            //                    Console.WriteLine(text);
            //                }
            //                else
            //                {
            //                    Console.WriteLine("No errors logged yet.");
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                Console.WriteLine("Error");
            //                File.AppendAllText(path2,
            //                    $"[{DateTime.Now}] {ex.Message}{Environment.NewLine}");
            //            }
            //            break;
            //        case "0":
            //            running = false;
            //            break;

            //        default:
            //            Console.WriteLine("Invalid choice");
            //            break;
            //    }
            //}

            // ================================================= задание 4
            //Order order = new Order(0, "");

            //order.onOrderCreated += Order.ShowOrder;
            //order.onOrderCreated += Order.SaveOrder;
            //order.CreateOrder();

            //order = new Order(1, "Laptop");
            //order.onOrderCreated += Order.ShowOrder;
            //order.onOrderCreated += Order.SaveOrder;
            //order.CreateOrder();

            //order = new Order(2, "Phone");
            //order.onOrderCreated += Order.ShowOrder;
            //order.onOrderCreated += Order.SaveOrder;
            //order.CreateOrder();

            // ================================================= задание 5
            string path = "task5.txt";

            try
            { 
                if (!File.Exists(path))
                {
                    Console.WriteLine("File not found. Creating a new one");
                    File.Create(path).Close();
                }

                string text = File.ReadAllText(path);

                Console.WriteLine("\n--- File ---");
                Console.WriteLine(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error");
                File.AppendAllText("errors2.txt",
                    $"[{DateTime.Now}] {ex.Message}{Environment.NewLine}");
            }        
        }
    }
}
