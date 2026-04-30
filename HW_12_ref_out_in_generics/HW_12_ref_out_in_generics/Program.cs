using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12_ref_out_in_generics
{
    class Utils
    {
        public void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        public static bool TryDivide(double a, double b, out double result)
        {
            if (b == 0)
            {
                result = 0;
                return false;
            }

            result = a / b;
            return true;
        }

        public static void PrintArray<T>(ref T[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(i);
            }
        }

        public static int Sum(in int a, in int b)
        {
            return a + b;
        }

        public static T FindMax<T>(T[] array)
                where T : IComparable<T>
        {
            if (array == null || array.Length == 0)
                throw new Exception("Array is empty");

            T max = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(max) > 0)
                {
                    max = array[i];
                }
            }

            return max;
        }

        public static T FindMin<T>(T[] array)
        where T : IComparable<T>
        {
            if (array == null || array.Length == 0)
                throw new Exception("Array is empty");

            T min = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(min) < 0)
                {
                    min = array[i];
                }
            }

            return min;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // задание 1
            Console.WriteLine("Swap:");
            Utils swap = new Utils();

            int a = 5;
            int b = 10;

            Console.WriteLine($"Before: a = {a}, b = {b}");

            swap.Swap(ref a, ref b);
            Console.WriteLine($"After: a = {a}, b = {b}");

            // задание 2
            Console.WriteLine("Division:");
            double result;

            bool success = Utils.TryDivide(10, 2, out result);
            Console.WriteLine(success);
            Console.WriteLine(result);

            bool failure = Utils.TryDivide(10, 0, out result);
            Console.WriteLine(result);

            // задание 3
            Console.WriteLine("Print array:");
            int[] numbers = { 1, 2, 3 };
            Utils.PrintArray(ref numbers);

            // задание 4
            Console.WriteLine("Sum:");
            result = Utils.Sum(5, 10);
            Console.WriteLine(result);

            // задание 5
            Console.WriteLine("Max in array:");
            int[] numbers2 = { 7, 2, 10, 5 };

            int max = Utils.FindMax(numbers2);
            int min = Utils.FindMin(numbers2);
            Console.WriteLine(max);
            Console.WriteLine(min);
        }
    }
}
