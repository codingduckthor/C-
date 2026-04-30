using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11_overload
{
    // задание 1
    class Temperature
    {
        double Value;
        string Scale;

        public Temperature(double Value, string Scale)
        {
            this.Value = Value;
            this.Scale = Scale;
        }

        public double ToCelsius()
        {
            if (Scale == "C") return Value;
            if (Scale == "F") return (Value - 32) * 5 / 9;
            if (Scale == "K") return Value - 273.15;

            throw new Exception("Unknown scale");
        }

        public static Temperature operator +(Temperature t1, Temperature t2)
        {
            double c1 = t1.ToCelsius();
            double c2 = t2.ToCelsius();

            return new Temperature(c1 + c2, "C");
        }

        public static bool operator ==(Temperature t1, Temperature t2)
        {
            return Math.Abs(t1.ToCelsius() - t2.ToCelsius()) < 0.0001;
        }

        public static bool operator !=(Temperature t1, Temperature t2)
        {
            return !(t1 == t2);
        }

        public override string ToString()
        {
            return $"{Value} {Scale}";
        }
    }

    // задание 2
    class ShoppingCart
    {
        List<string> itemsInACart = new List<string>();

        public static ShoppingCart operator +(ShoppingCart cart, string item)
        {
            cart.itemsInACart.Add(item);
            return cart;
        }

        public static ShoppingCart operator -(ShoppingCart cart, string item)
        {
            cart.itemsInACart.Remove(item);
            return cart;
        }

        public static bool operator ==(ShoppingCart cart1, ShoppingCart cart2)
        {
            if (ReferenceEquals(cart1, cart2)) return true;
            if (cart1 is null || cart2 is null) return false;

            return cart1.itemsInACart.OrderBy(x => x).SequenceEqual(cart2.itemsInACart.OrderBy(x => x));
        }

        public static bool operator !=(ShoppingCart cart1, ShoppingCart cart2)
        {
            return !(cart1 == cart2);
        }

        public static bool operator >(ShoppingCart cart1, ShoppingCart cart2)
        {
            return cart1.itemsInACart.Count > cart2.itemsInACart.Count;
        }

        public static bool operator <(ShoppingCart cart1, ShoppingCart cart2)
        {
            return cart1.itemsInACart.Count < cart2.itemsInACart.Count;
        }

        public override bool Equals(object obj)
        {
            if (obj is ShoppingCart other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return itemsInACart.Count;
        }

        public override string ToString()
        {
            return string.Join(", ", itemsInACart);
        }
    }

    class TimeRange
    {
        public int Start;
        public int End;

        public object HashCode { get; private set; }

        public TimeRange(int start, int end)
        {
            if(end < start)
            {
                throw new Exception("Ending range must be bigger than a starting range.");
            }

            Start = start;
            End = end;
        }

        public static TimeRange operator +(TimeRange timeRange1, TimeRange timeRange2)
        {
            int start = Math.Min(timeRange1.Start, timeRange2.Start);
            int end = Math.Max(timeRange1.End, timeRange2.End);

            return new TimeRange(start, end);
        }

        public static bool operator ==(TimeRange timeRange1, TimeRange timeRange2)
        {
            if (ReferenceEquals(timeRange1, timeRange2)) return true;
            if (timeRange1 is null || timeRange2 is null) return false;

            return timeRange1.Start == timeRange2.Start && timeRange1.End == timeRange2.End;
        }

        public static bool operator !=(TimeRange timeRange1, TimeRange timeRange2)
        {
            return !(timeRange1 == timeRange2);
        }

        public static bool operator >(TimeRange timeRange1, TimeRange timeRange2)
        {
            return (timeRange1.End - timeRange1.Start) > (timeRange2.End - timeRange2.Start);
        }

        public static bool operator <(TimeRange timeRange1, TimeRange timeRange2)
        {
            return (timeRange1.End - timeRange1.Start) < (timeRange2.End - timeRange2.Start);
        }

        public override bool Equals(object obj)
        {
            if (obj is TimeRange other)
                return this == other;
            return false;
        }

        public override string ToString()
        {
            return $"[{Start}-{End}]";
        }
    }

    // задание 4
    class FileSize
    {
        public double Size;
        public string Unit;

        public FileSize(double size, string unit)
        {
            Size = size;
            Unit = unit;
        }

        public double ToMB()
        {
            if (Unit == "KB") return Size / 1024;
            if (Unit == "MB") return Size;
            if (Unit == "GB") return Size * 1024;

            throw new Exception("Unknown unit");
        }

        public static FileSize FromMB(double mb)
        {
            if (mb >= 1024)
                return new FileSize(mb / 1024, "GB");
            else if (mb < 1)
                return new FileSize(mb * 1024, "KB");
            else
                return new FileSize(mb, "MB");
        }

        public static FileSize operator +(FileSize file1, FileSize file2)
        {
            double totalMB = file1.ToMB() + file2.ToMB();
            return FromMB(totalMB);
        }

        public static bool operator >(FileSize f1, FileSize f2)
        {
            return f1.ToMB() > f2.ToMB();
        }

        public static bool operator <(FileSize f1, FileSize f2)
        {
            return f1.ToMB() < f2.ToMB();
        }

        public override string ToString()
        {
            return $"{Size} {Unit}";
        }

        public override bool Equals(object obj)
        {
            if (obj is FileSize other)
                return this.ToMB() == other.ToMB();
            return false;
        }

        public override int GetHashCode()
        {
            return ToMB().GetHashCode();
        }
    }

    class Permission
    {
        public bool Read;
        public bool Write;
        public bool Execute;

        public Permission(bool read, bool write, bool execute)
        {
            Read = read;
            Write = write;
            Execute = execute;
        }

        public static Permission operator +(Permission p1, Permission p2)
        {
            return new Permission(
                p1.Read || p2.Read,
                p1.Write || p2.Write,
                p1.Execute || p2.Execute
            );
        }

        public static Permission operator -(Permission p1, Permission p2)
        {
            return new Permission(
                p1.Read && !p2.Read,
                p1.Write && !p2.Write,
                p1.Execute && !p2.Execute
            );
        }

        public static bool operator ==(Permission p1, Permission p2)
        {
            if (ReferenceEquals(p1, p2)) return true;
            if (p1 is null || p2 is null) return false;

            return p1.Read == p2.Read &&
                   p1.Write == p2.Write &&
                   p1.Execute == p2.Execute;
        }

        public static bool operator !=(Permission p1, Permission p2)
        {
            return !(p1 == p2);
        }

        public static bool operator true(Permission p)
        {
            return p.Read || p.Write || p.Execute;
        }

        public static bool operator false(Permission p)
        {
            return !(p.Read || p.Write || p.Execute);
        }

        public override bool Equals(object obj)
        {
            if (obj is Permission other)
                return this == other;
            return false;
        }

        public override string ToString()
        {
            return $"R:{Read} W:{Write} X:{Execute}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // задание 1
            //Temperature t1 = new Temperature(0, "C");
            //Temperature t2 = new Temperature(32, "F");
            //Temperature t3 = new Temperature(143, "K");

            //Console.WriteLine(t1 + t2);
            //Console.WriteLine(t1 == t2);
            //Console.WriteLine(t1 + t2 + t3);

            // задание 2 
            //ShoppingCart cart1 = new ShoppingCart();
            //cart1 += "Milk";
            //cart1 += "Bread";

            //ShoppingCart cart2 = new ShoppingCart();
            //cart2 += "Bread";
            //cart2 += "Milk";

            //Console.WriteLine(cart1 == cart2);
            //cart1 += "Juice";
            //Console.WriteLine(cart1 > cart2);
            //cart1 -= "Milk";
            //Console.WriteLine(cart1 == cart2);

            // задание 3
            //TimeRange t1 = new TimeRange(10, 12);
            //TimeRange t2 = new TimeRange(11, 14);

            //var result = t1 + t2;

            //Console.WriteLine(result);
            //Console.WriteLine(t1 == t2);
            //Console.WriteLine(t1 > t2);

            // задание 4
            //FileSize f1 = new FileSize(500, "MB");
            //FileSize f2 = new FileSize(1, "GB");
            //FileSize f3 = new FileSize(250, "KB");
            //var result = f1 + f2 + f3;
            //Console.WriteLine(result);
            //Console.WriteLine(f1 > f2);
            //Console.WriteLine(f1 < f2);

            // задание 5
            Permission p1 = new Permission(true, false, false);
            Permission p2 = new Permission(false, true, false);

            var p3 = p1 + p2;

            Console.WriteLine(p3);
            if (p3)
                Console.WriteLine("at least one permission exists");
        }
    }
}
