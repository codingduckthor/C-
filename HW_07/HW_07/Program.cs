using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace HW_07
{
    internal class Program
    {
        //                                  задание 1
        delegate int Operations(int a, int b);
        static int Addition(int a, int b)
        {
            return a + b;
        }

        static int Substraction(int a, int b)
        {
            return a - b;
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        static int Division(int a, int b)
        {
            if (b == 0)
            {
                Console.WriteLine("division by zero");
                return 0;
            }
            else
            {
                return (a / b);
            }
        }

        //                              задание 2
        delegate void MsgHandler(string message);

        static void Normalcase(string input)
        {
            Console.WriteLine(input);
        }

        static void Uppercase(string input)
        {
            Console.WriteLine(input.ToUpper());
        }

        static void DatedMsg(string input)
        {
            Console.WriteLine(input + ". created at: " + DateTime.Now);
        }
        static void Print(string message)
        {
            Console.WriteLine(message);
        }

        //                                  задание 3
        static double Square(double x)
        {
            Console.Write($"square of {x} = ");
            return x * x;
        }

        static bool isBiggerThan10(int y)
        {
            return y > 10;
        }

        //                                  задание 4
        static bool evenAndMore5(int x)
        {
            return x % 2 == 0 && x > 5;
        }

        //                                  задание 5

        static int ChangeNum(int x)
        {
            Console.WriteLine("after multiplying by 2: ");
            return x * 2;
        }
        static bool IsEven(int x)
        {
            return x % 2 == 0;
        }

        static void Print(int x)
        {
            Console.WriteLine(x);
        }

        static void Main(string[] args)
        {
            //                              задание 1
            //Console.Write("Enter x: ");
            //int x = int.Parse(Console.ReadLine());
            //Console.Write("Enter y: ");
            //int y = int.Parse(Console.ReadLine());
            //Operations op = null;

            //Console.WriteLine("choose operation");
            //Console.WriteLine("1 - addition (x + y)");
            //Console.WriteLine("2 - substraction (x - y)");
            //Console.WriteLine("3 - multiply (x * y)");
            //Console.WriteLine("4 - division x / y");
            //string choice = Console.ReadLine();

            //switch (choice)
            //{
            //    case "1": op = Addition; break;
            //    case "2": op = Substraction; break;
            //    case "3": op = Multiply; break;
            //    case "4": op = Division; break;
            //    default: Console.WriteLine("wrong input"); break;
            //}
            //Console.WriteLine(op(x, y));

            //                              задание 2

            //Action<string> handler = null;
            //Console.WriteLine("enter msg: ");
            //string msg = Console.ReadLine();

            //Console.WriteLine("how to readact your message: ");
            //Console.WriteLine("1 - Normal case");
            //Console.WriteLine("2 - Upper case");
            //Console.WriteLine("3 - add date to a message");
            //string choice2 = Console.ReadLine();

            //switch (choice2)
            //{
            //    case "1": handler = Normalcase; break;
            //    case "2": handler = Uppercase; break;
            //    case "3": handler = DatedMsg; break;
            //    default: Console.WriteLine("wrong input"); break;
            //}

            //handler(msg);

            //                                  задание 3
            // a
            //Console.Write("Enter x: ");
            //int x = int.Parse(Console.ReadLine());

            //Func<double, double> square = Square;
            //Console.WriteLine(Square(x));

            //// b
            //Console.WriteLine("Enter y: ");
            //int y = int.Parse(Console.ReadLine());

            //Func<int, bool> check = isBiggerThan10;
            //Console.WriteLine(isBiggerThan10(y));

            //// c
            //Console.Write("Enter c: ");
            //int c = int.Parse(Console.ReadLine());

            //if (check(c))
            //{
            //    Console.WriteLine(square(x));
            //} 
            //else
            //{
            //    Console.WriteLine($"{c} is too small.");
            //}

            //                                  задание 4
            //int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //List<int> numbers = new List<int>(array);

            //Predicate<int> check2 = evenAndMore5;

            //List<int> result = numbers.FindAll(check2);
            //Console.WriteLine("Numbers that even and bigger than 5:");
            //foreach(int i in result)
            //{
            //    Console.WriteLine(i);
            //}

            //                                  задание 5
            int[] arr2 = { 1, 10, 2, 15, 3, 20, 4, 25, 5, 30, 6, 35, 7, 40 };

            Predicate<int> filter = IsEven;
            Func<int, int> change = ChangeNum;
            Action<int> print = Print;

            foreach (int num in arr2)
            {
                if (filter(num))
                {
                    int changed = change(num);
                    print(changed);
                }
            }
        }
    }
}
