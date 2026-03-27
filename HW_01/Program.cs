using System;

namespace HW_01
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Choose task (1-7): ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input");
                return;
            }

            switch (choice)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
                case 7: Task7(); break;
                default: Console.WriteLine("No such task"); break;
            }
        }

        static void Task1()
        {
            Console.Write("Enter a number from 1 to 100: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Error: input is not a number.");
                return;
            }

            if (number < 1 || number > 100)
            {
                Console.WriteLine("Error: number must be in a range between 1 and 100.");
                return;
            }

            if (number % 3 == 0 && number % 5 == 0)
                Console.WriteLine("Fizz Buzz");
            else if (number % 3 == 0)
                Console.WriteLine("Fizz");
            else if (number % 5 == 0)
                Console.WriteLine("Buzz");
            else
                Console.WriteLine(number);
        }

        static void Task2()
        {
            Console.Write("Enter the number: ");
            if (!int.TryParse(Console.ReadLine(), out int number))
            {
                Console.WriteLine("Error");
                return;
            }

            Console.Write("Enter the percent: ");
            if (!int.TryParse(Console.ReadLine(), out int percent))
            {
                Console.WriteLine("Error");
                return;
            }

            double result = number * (percent / 100.0);
            Console.WriteLine(result);
        }

        static void Task3()
        {
            Console.Write("Enter 4 digits: ");
            Console.WriteLine("~~~~~~~~~~~~");

            if (!int.TryParse(Console.ReadLine(), out int n1) ||
                !int.TryParse(Console.ReadLine(), out int n2) ||
                !int.TryParse(Console.ReadLine(), out int n3) ||
                !int.TryParse(Console.ReadLine(), out int n4))
            {
                Console.WriteLine("Error");
                return;
            }

            int result = int.Parse($"{n1}{n2}{n3}{n4}");
            Console.WriteLine(result);
        }

        static void Task4()
        {
            Console.Write("Enter a 6-digit number: ");
            string input = Console.ReadLine();

            if (input.Length != 6 || !int.TryParse(input, out _))
            {
                Console.WriteLine("Error: number must be 6 digits.");
                return;
            }

            Console.Write("Enter places to swap (e.g., 2,5): ");
            string[] positions = Console.ReadLine().Split(',');

            if (positions.Length != 2 ||
                !int.TryParse(positions[0], out int pos1) ||
                !int.TryParse(positions[1], out int pos2))
            {
                Console.WriteLine("Error");
                return;
            }

            if (pos1 < 1 || pos1 > 6 || pos2 < 1 || pos2 > 6)
            {
                Console.WriteLine("Error: positions must be 1-6.");
                return;
            }

            char[] digits = input.ToCharArray();

            char temp = digits[pos1 - 1];
            digits[pos1 - 1] = digits[pos2 - 1];
            digits[pos2 - 1] = temp;

            Console.WriteLine("Result: " + new string(digits));
        }

        static void Task5()
        {
            Console.Write("Enter date (dd.MM.yyyy): ");
            string input = Console.ReadLine();

            if (!DateTime.TryParse(input, out DateTime date))
            {
                Console.WriteLine("Error: invalid date.");
                return;
            }

            string season;

            int month = date.Month;

            if (month == 12 || month == 1 || month == 2)
                season = "Winter";
            else if (month <= 5)
                season = "Spring";
            else if (month <= 8)
                season = "Summer";
            else
                season = "Autumn";

            Console.WriteLine($"{season} {date.DayOfWeek}");
        }

        static void Task6()
        {
            Console.Write("Enter temperature: ");
            if (!double.TryParse(Console.ReadLine(), out double temp))
            {
                Console.WriteLine("Error");
                return;
            }

            Console.Write("Convert to (C/F): ");
            string choice = Console.ReadLine().ToUpper();

            if (choice == "C")
            {
                double result = (temp - 32) * 5 / 9;
                Console.WriteLine($"{result:F2} °C");
            }
            else if (choice == "F")
            {
                double result = temp * 9 / 5 + 32;
                Console.WriteLine($"{result:F2} °F");
            }
            else
            {
                Console.WriteLine("Error");
            }
        }

        static void Task7()
        {
            Console.Write("Enter starting number: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
            {
                Console.WriteLine("Error");
                return;
            }

            Console.Write("Enter ending number: ");
            if (!int.TryParse(Console.ReadLine(), out int b))
            {
                Console.WriteLine("Error");
                return;
            }

            int start = Math.Min(a, b);
            int end = Math.Max(a, b);

            Console.WriteLine("Even numbers:");

            for (int i = start; i <= end; i++)
            {
                if (i % 2 == 0)
                    Console.Write(i + " ");
            }
        }
    }
}