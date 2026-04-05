using System;
using System.Runtime.Remoting.Channels;


namespace HW_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a task (1-4): ");
            int task = int.Parse(Console.ReadLine());

            switch (task)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                default: Console.WriteLine("Invalid task"); break;
            }
        }

        //#1 Создайте приложение калькулятор для перевода числа из одной системы исчисления в другую.
        //Пользователь с помощью меню выбирает направление перевода. Например, из десятичной в двоичную. После выбора направления,
        //пользователь вводит число в исходной системе исчисления. Приложение должно перевести число в требуемую систему.Предусмотреть
        //случай выхода за границы диапазона, определяемого типом int, неправильный ввод.

        class Converter
        {
            public static string DecToBin(int number)
            {
                if (number == 0) return "0";

                string result = "";

                while (number > 0)
                {
                    result = (number % 2) + result;
                    number /= 2;
                }

                return result;
            }

            public static int BinToDec(string bin)
            {
                int result = 0;

                foreach (char c in bin)
                {
                    if (c != '0' && c != '1')
                        throw new Exception("Invalid binary number");

                    result = result * 2 + (c - '0');
                }

                return result;
            }

            public static string DecToHex(int number)
            {
                if (number == 0) return "0";

                string hex = "0123456789ABCDEF";
                string result = "";

                while (number > 0)
                {
                    result = hex[number % 16] + result;
                    number /= 16;
                }

                return result;
            }

            public static int HexToDec(string hex)
            {
                int result = 0;

                foreach (char c in hex.ToUpper())
                {
                    int value;

                    if (c >= '0' && c <= '9')
                        value = c - '0';
                    else if (c >= 'A' && c <= 'F')
                        value = c - 'A' + 10;
                    else
                        throw new Exception("Invalid hex number");

                    result = result * 16 + value;
                }

                return result;
            }
        }

        static void Task1()
        {
            Console.WriteLine("1 - Dec into Bin");
            Console.WriteLine("2 - Bin into Dec");
            Console.WriteLine("3 - Dec into Hex");
            Console.WriteLine("4 - Hex into Dec");

            string choice = Console.ReadLine();

            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        int dec = int.Parse(input);
                        Console.WriteLine(Converter.DecToBin(dec));
                        break;

                    case "2":
                        Console.WriteLine(Converter.BinToDec(input));
                        break;

                    case "3":
                        int input_INT = int.Parse(input);
                        Console.WriteLine(Converter.DecToHex(input_INT));
                        break;

                    case "4":
                        Console.WriteLine(Converter.HexToDec(input));
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        //#2 Пользователь вводит словами цифру от 0 до 9. Приложение должно перевести слово в цифру.Например, если
        //пользователь ввёл five, приложение должно вывести на экран 5.

        class NumberConverter
        {
            public static int WordToNumber(string word)
            {
                switch (word.ToLower())
                {
                    case "zero": return 0;
                    case "one": return 1;
                    case "two": return 2;
                    case "three": return 3;
                    case "four": return 4;
                    case "five": return 5;
                    case "six": return 6;
                    case "seven": return 7;
                    case "eight": return 8;
                    case "nine": return 9;
                    default: return -1;
                }
            }
        }
        static void Task2()
        {
            Console.WriteLine("Enter a word for a number ('one', 'two', 'three', 'nine' etc): ");
            string input = Console.ReadLine();

            int result = NumberConverter.WordToNumber(input);

            if (result == -1)
                Console.WriteLine("Error: invalid entry.");
            else
                Console.WriteLine(result);
        }

        //#3 Создайте класс «Заграничный паспорт». Вам необходимо хранить информацию о номере паспорта, ФИО владельца,
        //дате выдачи и т.д.Предусмотреть механизмы для инициализации полей класса.Если значение для инициализации
        //неверное, генерируйте исключение.

        class Passport
        {
            int ID;
            string owner;
            string issueDate;

            public Passport(int ID, string owner, string issueDate)
            {
                if (ID <= 0)
                    throw new ArgumentException("Invalid passport ID");

                if (string.IsNullOrWhiteSpace(owner))
                    throw new ArgumentException("Owner name cannot be empty");

                if (!DateTime.TryParse(issueDate, out DateTime date))
                    throw new ArgumentException("Invalid date format");

                this.ID = ID;
                this.owner = owner;
                this.issueDate = issueDate;
            }
        }
        static void Task3()
        {
            try
            {
                Passport passport = new Passport(123456, "John Smith", "12.05.2020");

                Console.WriteLine("Passport created successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        //#4 Пользователь вводит в строку с клавиатуры логическое выражение.Например, 3>2 или 7<3. Программа должна
        //посчитать результат введенного выражения и дать результат true или false. В строке могут быть только целые числа
        //и операторы: <, >, <=, >=, ==, !=. Для обработки ошибок ввода используйте механизм исключений.

        class XmoreThanY
        {
            public bool Check(int num1, char c, int num2)
            {
                if (c == '>')
                    return num1 > num2;

                if (c == '<')
                    return num1 < num2;

                if (c == '=')
                    return num1 == num2;

                throw new ArgumentException("Invalid operator");
            }
        }

        static void Task4()
        {
            Console.Write("Enter expression (e.g. 3>5): ");
            string input = Console.ReadLine();

            int num1 = 0;
            int num2 = 0;
            char op = ' ';

            int i = 0;

            while (i < input.Length && char.IsDigit(input[i]))
            {
                num1 = num1 * 10 + (input[i] - '0');
                i++;
            }

            op = input[i];
            i++;

            while (i < input.Length && char.IsDigit(input[i]))
            {
                num2 = num2 * 10 + (input[i] - '0');
                i++;
            }

            XmoreThanY checker = new XmoreThanY();
            bool result = checker.Check(num1, op, num2);

            Console.WriteLine(result);
        }
    }
}