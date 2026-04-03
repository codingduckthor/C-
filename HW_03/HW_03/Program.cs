using System;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace HW_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a task (1-7): ");
            int task = int.Parse(Console.ReadLine());

            switch (task)
            {
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                case 6: Task6(); break;
                case 7: Task7(); break;
                default: Console.WriteLine("Invalid task"); break;
            }
        }

        static void Task1()
        {
            //Объявить одномерный(5 элементов) массив с именем A и двумерный массив(3 строки, 4 столбца) дробных чисел с именем B
            int[] A = new int[5];
            float[,] B = new float[3, 4];
            Random rand = new Random();

            //Заполнить одномерный массив А числами, введенными с клавиатуры пользователем
            for (int i = 0; i < A.Length; i++)
            {
                int input;
                Console.WriteLine($"Enter digit for {i} index.");
                while (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.Write("Enter correct value for ({0},{1}): ", i);
                }
                A[i] = input;
            }

            //а двумерный массив В случайными числами с помощью циклов
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    B[i, j] = rand.Next(1, 10);
                }
            }

            //Вывести на экран значения массивов: массива А в одну строку
            Console.WriteLine($"created array:\n " + string.Join(", ", A));

            //массива В — в виде матрицы
            Console.WriteLine("Created matrix:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(B[i, j] + ", ");
                }
                Console.WriteLine();
            }

            //Найти в данных массивах общий максимальный элемент, минимальный элемент, общую сумму всех элементов, 
            //общее произведение всех элементов, сумму четных элементов массива А, 
            //сумму нечетных столбцов массива В
            double min = A[0];
            double max = A[0];
            double sumA = 0;
            double sumB = 0;
            double multiplicationOfAll_A = 1;
            double multiplicationOfAll_B = 1;
            double sumOfEvenA = 0;
            double sumOfUnevenColumnsB = 0;

            foreach (int i in A)
            {
                if (i > max) max = i;
                if (i < min) min = i;

                sumA += i;
                multiplicationOfAll_A *= i;

                if (i % 2 == 0)
                    sumOfEvenA += i;
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double x = B[i, j];

                    if (x > max) max = x;
                    if (x < min) min = x;

                    sumB += x;
                    multiplicationOfAll_B *= x;

                    if (j % 2 != 0)
                        sumOfUnevenColumnsB += x;
                }
            }

            Console.WriteLine($"Max: {max}");
            Console.WriteLine($"Min: {min}");
            Console.WriteLine($"Sum of elements in A: {sumA}");
            Console.WriteLine($"Sum of elements in B: {sumB}");
            Console.WriteLine($"Product of elements in A: {multiplicationOfAll_A}");
            Console.WriteLine($"Product of elements in B: {multiplicationOfAll_B}");
            Console.WriteLine($"Sum of even elements in A: {sumOfEvenA}");
            Console.WriteLine($"Sum of odd columns(index 1 and 3) in B: {sumOfUnevenColumnsB}");
        }

        static void Task2()
        {
            //Дан двумерный массив размерностью 5×5, заполненный случайными числами из диапазона от –100 до 100.
            //Определить сумму элементов массива, расположенных между минимальным и максимальным элементами

            int[,] array = new int[5, 5];
            Random rand = new Random();
            double min = array[0, 0];
            double max = array[0, 0];
            int minRow = 0;
            int minCol = 0;
            int maxRow = 0;
            int maxCol = 0;

            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    array[i, j] = rand.Next(-100, 100);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        minRow = i;
                        minCol = j;
                    }
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        maxRow = i;
                        maxCol = j;
                    }
                }
            }

            bool counting = false;
            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if ((i == minRow && j == minCol) || (i == maxRow && j == maxCol))
                    {
                        if (!counting)
                        {
                            counting = true;
                            continue;
                        }
                        else
                        {
                            counting = false;
                            break;
                        }
                    }

                    if (counting)
                    {
                        sum += array[i, j];
                    }
                }
            }

            Console.WriteLine("Matrix:");
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Console.Write(array[i, j] + "\t");
                Console.WriteLine();
            }

            Console.WriteLine($"Min: {min}, Max: {max}");
            Console.WriteLine($"Sum of elements between min and max: {sum}");
        }

        static void Task3()
        {
            Console.WriteLine("Enter a sentence: ");
            string input = Console.ReadLine();

            int key;
            Console.WriteLine("Enter a key: ");
            while (!int.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Enter a valid integer key:");
            }
            Console.WriteLine("Which side? left (l) or right (r)?");

            string side = Console.ReadLine();
            side = side.ToLower();

            char[] array = input.ToCharArray();

            for(int i = 0; i < array.Length; i++)
            {
                char c = array[i];

                if (char.IsLetter(c))
                {
                    char offset = char.IsUpper(c) ? 'A' : 'a';

                    if (side == "r")
                        array[i] = (char)((c - offset + key) % 26 + offset);
                    else if (side == "l")
                        array[i] = (char)((c - offset - key + 26) % 26 + offset);
                }
            }

            Console.WriteLine("Encrypted text: " + new string(array));
        }

        static void Task4()
        {
            int[,] newMatrix = createMatrix(3, 3);
            printMatrix(newMatrix);

            Console.Write("Enter the multiplicator: ");
            int multiplicator = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            matrixMultiplication(newMatrix, multiplicator);
            Console.WriteLine();

            
            int[,] matrix1 = createMatrix(3, 3);
            int[,] matrix2 = createMatrix(3, 3);
            Console.WriteLine("First matrix:");
            printMatrix(matrix1);
            Console.WriteLine("Second matrix:");
            printMatrix(matrix2);

            matrixAddition(matrix1, matrix2);
            Console.WriteLine();
            matrixProduct(matrix1, matrix2);
        }

        // функции для Task4()
        // создание матрицы
        static Random rand = new Random();
        static int[,] createMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = rand.Next(1, 11);
                }
            }

            return matrix;
        }

        // функция для вывода матрицы
        static void printMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        // функция перемножения на число
        static void matrixMultiplication(int[,] matrix, int multiplicator)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            Console.WriteLine("Matrix after multiplication by " + multiplicator);
            for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] *= multiplicator;
                        Console.Write(matrix[i, j] + "   ");
                    }
                    Console.WriteLine();
                }
        }

        // функция сложения 2х матриц
        static void matrixAddition(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);
            int[,] result = new int[rows, cols];

            Console.WriteLine("Both matrix after addition to each other:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                    Console.Write(result[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }

        // функция перемножения 2х матриц
        static void matrixProduct(int[,] matrix1, int[,] matrix2)
        {
            int rows = matrix1.GetLength(0);
            int cols = matrix1.GetLength(1);
            int[,] result = new int[rows, cols];

            Console.WriteLine("Product of both matrix:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] * matrix2[i, j];
                    Console.Write(result[i, j] + "   ");
                }
                Console.WriteLine();
            }
        }

        static void Task5()
        {
            Console.Write("Enter expression (+ and - only): ");
            string input = Console.ReadLine();
            input = input.Replace(" ", "");

            int result = 0;
            int currentNumber = 0;
            char operation = '+';

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsDigit(c))
                {
                    currentNumber = currentNumber * 10 + (c - '0');
                }

                if (!char.IsDigit(c) || i == input.Length - 1)
                {
                    if (operation == '+')
                        result += currentNumber;
                    else if (operation == '-')
                        result -= currentNumber;

                    operation = c;
                    currentNumber = 0;
                }
            }

            Console.WriteLine("Result: " + result);
        }

        static void Task6()
        {
            Console.Write("Enter text with '.', '?', '!': ");
            string input = Console.ReadLine();

            char[] arr = input.ToCharArray();

            bool newSentence = true;

            for (int i = 0; i < arr.Length; i++)
            {
                if (newSentence && char.IsLetter(arr[i]))
                {
                    arr[i] = char.ToUpper(arr[i]);
                    newSentence = false;
                }

                if (arr[i] == '.' || arr[i] == '!' || arr[i] == '?')
                {
                    newSentence = true;
                }
            }

            string result = new string(arr);
            Console.WriteLine("Now every first word in a sentence starts with a capital letter:");
            Console.WriteLine(result);
        }

        static void Task7()
        {
            Console.Write("Enter text to redact: ");
            string input = Console.ReadLine();

            Console.WriteLine("Which word to censor?");
            string censor = Console.ReadLine().ToLower();

            char[] arr = input.ToCharArray();

            char[] arr2 = censor.ToCharArray();

            string[] words = input.Split(' ');

            int count = 0;

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];

                string cleanWord = word.Trim(',', '.', '!', '?', ':', ';', '\'').ToLower();

                if (cleanWord == censor)
                {
                    count++;

                    int start = 0;
                    int end = word.Length - 1;

                    while (start < word.Length && !char.IsLetter(word[start]))
                        start++;

                    while (end >= 0 && !char.IsLetter(word[end]))
                        end--;

                    string prefix = word.Substring(0, start);
                    string suffix = word.Substring(end + 1);

                    words[i] = prefix + "***" + suffix;
                }
            }

            string result = string.Join(" ", words);

            Console.WriteLine("\nResult:");
            Console.WriteLine(result);

            Console.WriteLine($"\nStatistics: {count} replacements.");
        }
    }
}



