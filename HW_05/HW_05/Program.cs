using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace HW_05
{
//    Запрограммируйте класс Money(объект класса оперирует одной валютой) для работы с деньгами.
//В классе должны быть предусмотрены поле для хранения целой части денег (доллары, евро, гривны и т.д.) и поле для хранения копеек(центы, евроценты, копейки и т.д.).
//Реализовать методы для вывода суммы на экран, задания значений для частей.
//На базе класса Money создать класс Product для работы с продуктом или товаром. Реализовать метод, позволяющий уменьшить цену на заданное число.
//Для каждого из классов реализовать необходимые методы и поля.

    class Money
    {
        protected int money;
        protected int cents;

        public Money(int money, int cents)
        {
            SetMoney(money, cents);
        }

        public void SetMoney(int money, int cents)
        {
            this.money = money + cents / 100;
            this.cents = cents % 100;

            if (this.cents < 0)
            {
                this.cents += 100;
                this.money--;
            }
        }

        public void Print()
        {
            Console.WriteLine($"{money}.{cents:D2}");
        }

        public double GetAmount()
        {
            return money + cents / 100.0;
        }
    }

    class Product : Money
    {
        private string name;

        public Product(string name, int money, int cents) : base(money, cents)
        {
            this.name = name;
        }

        public void DecreasePrice(int money, int cents)
        {
            int totalCents = this.money * 100 + this.cents;
            int decrease = money * 100 + cents;

            totalCents -= decrease;

            if (totalCents < 0)
                totalCents = 0;

            this.money = totalCents / 100;
            this.cents = totalCents % 100;
        }

        public void PrintProduct()
        {
            Console.Write($"{name}: ");
            Print();
        }        
    }

    //        Задание 2
    //Создать базовый класс «Устройство» и производные классы «Чайник», «Микроволновка», «Автомобиль», «Пароход». С помощью конструктора установить имя каждого устройства и его характеристики.
    //Реализуйте для каждого из классов методы:
    //■ Sound — издает звук устройства (пишем текстом в консоль);
    //■ Show — отображает название устройства; ■ Desc — отображает описание устройства.
    class Device
    {
        protected string name;
        protected string description;

        public Device(string name, string description)
        {
            this.name = name;
            this.description = description;
        }

        public virtual void Sound()
        {
            Console.WriteLine("Device makes a sound");
        }

        public void Show()
        {
            Console.WriteLine($"Name: {name}");
        }

        public void Desc()
        {
            Console.WriteLine($"Description: {description}");
        }
    }
    class Kettle : Device
    {
        public Kettle(string name, string description) : base(name, description) { }

        public override void Sound()
        {
            Console.WriteLine($"{name}: Whistling...");
        }
    }
    class Microwave : Device
    {
        public Microwave(string name, string description) : base(name, description) { }

        public override void Sound()
        {
            Console.WriteLine($"{name}: Beep beep!");
        }
    }
    class Car : Device
    {
        public Car(string name, string description) : base(name, description) { }

        public override void Sound()
        {
            Console.WriteLine($"{name}: Vroom!");
        }
    }
    class Steamboat : Device
    {
        public Steamboat(string name, string description) : base(name, description) { }

        public override void Sound()
        {
            Console.WriteLine($"{name}: Tuuuu!");
        }
    }

    //    Задание 3
    //Создать базовый класс «Музыкальный инструмент» и производные классы «Скрипка», «Тромбон», « Укулеле», «Виолончель». С помощью конструктора установить имя каждого музыкального инструмента и его характеристики.
    //Реализуйте для каждого из классов методы:
    //■ Sound — издает звук музыкального инструмента(пишем текстом в консоль);
    //■ Show — отображает название музыкального инструмента;
    //■ Desc — отображает описание музыкального инструмента;
    //■ History — отображает историю создания музыкального инструмента.

    class Instrument
    {
        protected string name;
        protected string description;
        protected string history;

        public Instrument(string name, string description, string history)
        {
            this.name = name;
            this.description = description;
            this.history = history;
        }

        public virtual void Sound()
        {
            Console.WriteLine("instrument makes a sound");
        }

        public void Show()
        {
            Console.WriteLine($"Name: {name}");
        }

        public void Desc()
        {
            Console.WriteLine($"Description: {description}");
        }

        public void History()
        {
            Console.WriteLine("Instruments history: ");
        }
    }
    class Violin : Instrument
    {
        public Violin(string name, string description, string history) : base(name, description, history) { }

        public override void Sound()
        {
            Console.WriteLine($"{name}: cries...");
        }
    }
    class Trombone : Instrument
    {
        public Trombone(string name, string description, string history) : base(name, description, history) { }

        public override void Sound()
        {
            Console.WriteLine($"{name}: toots...");
        }
    }
    class Ukulele : Instrument
    {
        public Ukulele(string name, string description, string history) : base(name, description, history) { }

        public override void Sound()
        {
            Console.WriteLine($"{name}: adjs...");
        }
    }
    class Cello : Instrument
    {
        public Cello(string name, string description, string history) : base(name, description, history) { }

        public override void Sound()
        {
            Console.WriteLine($"{name}: wasdasd...");
        }
    }

//    Задание 4
//Создать абстрактный базовый класс Worker(работника) с методом Print().Создайте четыре производных класса: President, Security, Manager, Engineer.Переопределите метод
//Print() для вывода информации, соответствующей каждому типу работника.

    abstract class Worker
    {
        protected string name;
        protected string jobDescription;
        public Worker(string name, string jobDescription)
        {
            this.name = name;
            this.jobDescription = jobDescription;
        }
        public abstract void Print();
    }

    class President : Worker
    {
        public President(string name, string jobDescription) : base(name, jobDescription) { }

        public override void Print()
        {
            Console.WriteLine("President of the company");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"What he does: {jobDescription}");
        }
    }
    class Security : Worker
    {
        public Security(string name, string jobDescription) : base(name, jobDescription) { }

        public override void Print()
        {
            Console.WriteLine("Security in the company");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"What he does: {jobDescription}");
        }
    }
    class Manager : Worker
    {
        public Manager(string name, string jobDescription) : base(name, jobDescription) { }

        public override void Print()
        {
            Console.WriteLine("Manager in the company");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"What he does: {jobDescription}");
        }
    }
    class Engineer : Worker
    {
        public Engineer(string name, string jobDescription) : base(name, jobDescription) { }

        public override void Print()
        {
            Console.WriteLine("Engineer in the company");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"What he does: {jobDescription}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====             #1              =====");
            //                                  задание 1
            Product p = new Product("Laptop", 999, 99);
            p.PrintProduct();
            p.DecreasePrice(100, 50);
            p.PrintProduct();

            Console.WriteLine("====             #2              =====");
            //                                  задание 2
            Device kettle = new Kettle("Kettle", "Boils water");
            Device microwave = new Microwave("Microwave", "Heats food");
            Device car = new Car("Car", "Moves on roads");
            Device ship = new Steamboat("Steamboat", "Moves on water");

            Device[] devices = { kettle, microwave, car, ship };

            foreach (var d in devices)
            {
                d.Show();
                d.Desc();
                d.Sound();
                Console.WriteLine();
            }

            Console.WriteLine("====             #3              =====");
            //                                  задание 3
            Instrument violin = new Violin("Violin", "italian instrument", "made sometime in 1400" );
            Instrument trombone = new Trombone("Trombone", "you blow it and it makes the sound", "made with a brass metal" );
            Instrument ukulele = new Ukulele("Ukulele", "hawaian musical instrument", "basically a small guitar" );
            Instrument cello = new Cello("Cello", "same as but biger than violin", "made in 1200" );

            Instrument[] instruments = { violin, trombone, ukulele, cello };

            foreach (var i in instruments)
            {
                i.Show();
                i.Desc();
                i.Sound();
                Console.WriteLine();
            }

            Console.WriteLine("====             #4              =====");
            //                                  задание 4
            Worker[] workers =
            {
            new President("John", "Leads the company"),
            new Security("Mike", "Protects the building"),
            new Manager("Anna", "Manages the team"),
            new Engineer("Alex", "Develops systems")
            };

            foreach (var w in workers)
            {
                w.Print();
                Console.WriteLine();
            }
        }
    }
}
