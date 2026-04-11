using System;

namespace HW_06
{
    abstract class Transport
    {
        public string Name { get; set; }
        public abstract void Move();
    }

    interface IFlyable
    {
        void Fly();
    }

    interface IDrivable
    {
        void Drive();
    }

    class Car : Transport, IDrivable
    {
        public Car(string name)
        {
            Name = name;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name}: is a car and it drives.");
        }

        public void Drive()
        {
            Console.WriteLine($"{Name}: is a car that drives on the road.");
        }
    }

    class Plane : Transport, IFlyable
    {
        public Plane(string name)
        {
            Name = name;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name}: is a plane and it flys.");
        }

        public void Fly()
        {
            Console.WriteLine($"{Name}: is a plane that flys on air.");
        }
    }
    class AmphibiousCar : Transport, IFlyable, IDrivable
    {
        public AmphibiousCar(string name)
        {
            Name = name;
        }

        public override void Move()
        {
            Console.WriteLine($"{Name}: can drive on road and water.");
        }

        public void Drive()
        {
            Console.WriteLine($"{Name}: can drive on the road.");
        }

        public void Fly()
        {
            Console.WriteLine($"{Name}: cant fly.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car("Toyota");
            car.Move();
            car.Drive();
            Console.WriteLine();

            Plane plane = new Plane("Airbus");
            plane.Move();
            plane.Fly();
            Console.WriteLine();

            AmphibiousCar ac = new AmphibiousCar("Vodnik");
            ac.Move();
            ac.Drive();
            ac.Fly();
            Console.WriteLine();

            // доп задание
            Transport[] transports =
            {
                new Car("Toyota"),
                new Plane("Airbus"),
                new AmphibiousCar("Vodnik")
            };

            foreach (var t in transports)
            {
                t.Move();

                if (t is IDrivable d)
                    d.Drive();

                if (t is IFlyable f)
                    f.Fly();

                Console.WriteLine();
            }
        }
    }
}
