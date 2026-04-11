using System;
using System.Collections.Generic;

namespace ToDoApp
{
    interface ICompletable
    {
        void Complete();
    }
    class Task : ICompletable
    {
        public string Title;
        public bool IsDone;
        public string Category;

        public Task(string title, string category)
        {
            Title = title;
            Category = category;
            IsDone = false;
        }

        public void Complete()
        {
            IsDone = true;
        }

        public virtual void Show()
        {
            string status = IsDone ? "[+]" : "[ ]";
            Console.WriteLine($"{status} {Title} [{Category}]");
        }
    }

    class TimedTask : Task
    {
        public DateTime Deadline;

        public TimedTask(string title, string category, DateTime deadline)
            : base(title, category)
        {
            Deadline = deadline;
        }

        public override void Show()
        {
            string status;

            if (!IsDone && DateTime.Now > Deadline)
                status = "[-]";
            else
                status = IsDone ? "[+]" : "[ ]";

            Console.WriteLine($"{status} {Title} [{Category}] (due: {Deadline.ToShortDateString()})");
        }
    }

    internal class Program
    {
        static List<Task> tasks = new List<Task>();
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine("1 - Add task.");
                Console.WriteLine("2 - Complete task.");
                Console.WriteLine("3 - Delete task.");
                Console.WriteLine("4 - Show all tasks.");
                Console.WriteLine("5 - Show sorted by deadline.");
                Console.WriteLine("6 - Show by category.");
                Console.WriteLine("7 - Edit task.");
                Console.WriteLine("0 - Exit.\n");

                Console.Write("Select - ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        CompleteTask();
                        break;
                    case "3":
                        DeleteTask();
                        break;
                    case "4":
                        ShowTasks();
                        break;
                    case "5":
                        ShowTasksSorted();
                        break;
                    case "6":
                        ShowByCategory();
                        break;
                    case "7":
                        EditTask();
                        break;
                    case "0":
                        isRunning = false;
                        break;
                }
            }
        }

        static void AddTask()
        {
            Console.Write("Enter a title: ");
            string title = Console.ReadLine();

            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            Console.Write("Is there a deadline(y/n)? ");
            string answer = Console.ReadLine();

            if (answer.ToLower() == "y")
            {
                Console.Write("Enter due date(yyyy-mm-dd): ");
                DateTime date = DateTime.Parse(Console.ReadLine());

                tasks.Add(new TimedTask(title, category, date));
            }
            else
            {
                tasks.Add(new Task(title, category));
            }
        }

        static void ShowTasksSorted()
        {
            List<TimedTask> withDeadline = new List<TimedTask>();
            List<Task> withoutDeadline = new List<Task>();

            foreach (var t in tasks)
            {
                if (t is TimedTask tt)
                    withDeadline.Add(tt);
                else
                    withoutDeadline.Add(t);
            }

            withDeadline.Sort((a, b) => a.Deadline.CompareTo(b.Deadline));

            int index = 0;

            foreach (var t in withDeadline)
            {
                Console.Write($"{index++}. ");
                t.Show();
            }

            foreach (var t in withoutDeadline)
            {
                Console.Write($"{index++}. ");
                t.Show();
            }
        }

        static void CompleteTask()
        {
            Console.WriteLine("Select a task to complete: ");
            int index = int.Parse(Console.ReadLine());

            if(index >= 0 && index < tasks.Count)
            {
                tasks[index].Complete();
            }
        }

        static void DeleteTask()
        {
            Console.WriteLine("Select a task to delete: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < tasks.Count)
            {
                tasks.RemoveAt(index);
            }
        }

        static void ShowTasks()
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.Write($"{i}. ");
                tasks[i].Show();
            }
        }

        static void ShowByCategory()
        {
            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            int index = 0;

            foreach (var t in tasks)
            {
                if (t.Category.ToLower() == category.ToLower())
                {
                    Console.Write($"{index}. ");
                    t.Show();
                }
                index++;
            }
        }
        static void EditTask()
        {
            Console.Write("Select task index: ");
            int index = int.Parse(Console.ReadLine());

            if (index >= 0 && index < tasks.Count)
            {
                Console.Write("New title: ");
                tasks[index].Title = Console.ReadLine();

                Console.Write("New category: ");
                tasks[index].Category = Console.ReadLine();
            }
        }
    }
}
