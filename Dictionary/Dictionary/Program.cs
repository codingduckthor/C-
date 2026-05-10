using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Dictionary
{
    class DictionaryExam
    {
        private Dictionary<string, List<string>> engRus;
        private Dictionary<string, List<string>> rusEng;

        public DictionaryExam()
        {
            engRus = new Dictionary<string, List<string>>();
            rusEng = new Dictionary<string, List<string>>();
        }
        public void AddWord(string eng, string rus)
        {
            eng = eng.ToLower().Trim();
            rus = rus.ToLower().Trim();

            if (!engRus.ContainsKey(eng))
                engRus[eng] = new List<string>();

            if (!engRus[eng].Contains(rus))
                engRus[eng].Add(rus);

            if (!rusEng.ContainsKey(rus))
                rusEng[rus] = new List<string>();

            if (!rusEng[rus].Contains(eng))
                rusEng[rus].Add(eng);
        }

        public void TranslateWord(string word)
        {
            word = word.ToLower().Trim();

            if (engRus.ContainsKey(word)) // если введено англ ялово и оно есть в качестве ключа в англ словаре - происходит перевод
            {
                Console.WriteLine("\nENG -> RUS");
                Console.WriteLine(string.Join(", ", engRus[word]));
            }
            else if (rusEng.ContainsKey(word))
            {
                Console.WriteLine("\nRUS -> ENG");
                Console.WriteLine(string.Join(", ", rusEng[word]));
            }
            else
            {
                Console.WriteLine("\nWord not found");
            }
        }

        public void DeleteTranslation(string eng, string rus)
        {
            eng = eng.ToLower().Trim();
            rus = rus.ToLower().Trim();

            if (!engRus.ContainsKey(eng)) // если англ слово в виде ключа не найдено - ошибка
            {
                Console.WriteLine("Word not found");
                return;
            }

            if (!engRus[eng].Contains(rus)) // перевод не найден если по ключу нет значения
            {
                Console.WriteLine("Translation not found");
                return;
            }

            if (engRus[eng].Count == 1) // попытка удаления последнего перевода (если длина значения равна 1)
            {
                Console.WriteLine("Cannot delete last translation");
                return;
            }

            engRus[eng].Remove(rus); // если проверки пройдены - удаляем
            rusEng[rus].Remove(eng);

            if (rusEng[rus].Count == 0) // удаление ключа, если его массив значений пуст
                rusEng.Remove(rus);

            Console.WriteLine("Translation deleted");
        }

        public void DeleteWord(string eng)
        {
            eng = eng.ToLower().Trim();

            if (!engRus.ContainsKey(eng))
            {
                Console.WriteLine("Word not found");
                return;
            }

            foreach (string rus in engRus[eng])
            {
                rusEng[rus].Remove(eng);

                if (rusEng[rus].Count == 0)
                    rusEng.Remove(rus);
            }

            engRus.Remove(eng);

            Console.WriteLine("Word deleted");
        }

        public void EditTranslation(string eng, string oldRus, string newRus)
        {
            eng = eng.ToLower().Trim();
            oldRus = oldRus.ToLower().Trim();
            newRus = newRus.ToLower().Trim();

            if (!engRus.ContainsKey(eng))
            {
                Console.WriteLine("Word not found");
                return;
            }

            if (!engRus[eng].Contains(oldRus))
            {
                Console.WriteLine("Old translation not found");
                return;
            }

            engRus[eng].Remove(oldRus);

            rusEng[oldRus].Remove(eng);

            if (rusEng[oldRus].Count == 0)
                rusEng.Remove(oldRus);

            AddWord(eng, newRus);

            Console.WriteLine("Translation edited");
        }

        public void ShowAllWords()
        {
            Console.WriteLine("\n===== DICTIONARY =====");

            if (engRus.Count == 0)
            {
                Console.WriteLine("Dictionary is empty");
                return;
            }

            foreach (var pair in engRus)
            {
                Console.WriteLine($"{pair.Key} -> {string.Join(", ", pair.Value)}");
            }
        }

        private void AddMenu()
        {
            Console.WriteLine("1 - English word");
            Console.WriteLine("2 - Русское слово");

            string choice = Console.ReadLine();

            Console.Write("Word: ");
            string w1 = Console.ReadLine();

            Console.Write("Word: ");
            string w2 = Console.ReadLine();

            if (choice == "1")
                AddWord(w1, w2);
            else
                AddWord(w2, w1);
        }

        private void DeleteMenu()
        {
            Console.WriteLine("\n1 - Delete whole word");
            Console.WriteLine("2 - Delete translation");
            Console.WriteLine("0 - Back");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("English word: ");
                    string eng = Console.ReadLine();

                    DeleteWord(eng);
                    break;

                case "2":
                    Console.Write("English word: ");
                    string engWord = Console.ReadLine();

                    Console.Write("Russian translation: ");
                    string rusWord = Console.ReadLine();

                    DeleteTranslation(engWord, rusWord);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
        }

        private void EditMenu()
        {
            Console.Write("\nEnglish word: ");
            string eng = Console.ReadLine();

            Console.Write("Old translation: ");
            string oldRus = Console.ReadLine();

            Console.Write("New translation: ");
            string newRus = Console.ReadLine();

            EditTranslation(eng, oldRus, newRus);
        }

        private void TranslateMenu()
        {
            Console.Write("\nEnter word: ");
            string word = Console.ReadLine();

            TranslateWord(word);
        }

        public void SaveToFile(string path)
        {
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                foreach (var pair in engRus)
                {
                    string line = pair.Key + ":" + string.Join(",", pair.Value);

                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Dictionary saved");
        }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("File not found");
                return;
            }

            engRus.Clear();
            rusEng.Clear();

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(':');

                if (parts.Length != 2)
                    continue;

                string eng = parts[0];

                string[] translations = parts[1].Split(',');

                foreach (string rus in translations)
                {
                    AddWord(eng, rus);
                }
            }

            Console.WriteLine("Dictionary loaded");
        }


        public void ShowMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n===== DICTIONARY MENU =====");
                Console.WriteLine("1 - Add word");
                Console.WriteLine("2 - Edit translation");
                Console.WriteLine("3 - Delete");
                Console.WriteLine("4 - Translate");
                Console.WriteLine("5 - Show all words");
                Console.WriteLine("6 - Save dictionary");
                Console.WriteLine("7 - Load dictionary from file");
                Console.WriteLine("0 - Exit");

                Console.Write("\nChoose: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddMenu();
                        break;

                    case "2":
                        EditMenu();
                        break;

                    case "3":
                        DeleteMenu();
                        break;

                    case "4":
                        TranslateMenu();
                        break;

                    case "5":
                        ShowAllWords();
                        break;

                    case "6":
                        SaveToFile("dictionary.txt");
                        break;

                    case "7":
                        LoadFromFile("dictionary.txt");
                        break;

                    case "0":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Wrong choice");
                        break;
                }
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            DictionaryExam dictionary = new DictionaryExam();

            dictionary.ShowMenu();
        }
    }
}