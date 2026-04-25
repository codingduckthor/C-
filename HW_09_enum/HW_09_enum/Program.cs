using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HW_09_enum
{
    // задание 1
    enum GameState
    {
        Menu,
        Playing,
        Paused,
        GameOver,
    }

    class Game
    {
        public GameState State = GameState.Menu;
        public void StartGame()
        {
            if (State == GameState.GameOver)
            {
                Console.WriteLine("Cant start a finished game.");
                return;
            }

            if (State == GameState.Playing)
            {
                Console.WriteLine("game is running.");
                return;
            }

            State = GameState.Playing;
        }

        public void PauseGame()
        {
            if (State != GameState.Playing)
            {
                Console.WriteLine("only running game can be paused");
                return;
            }

            State = GameState.Paused;
        }

        public void ResumeGame()
        {
            if (State != GameState.Paused)
            {
                Console.WriteLine("only paused game can be resumed.");
                return;
            }

            State = GameState.Playing;
        }

        public void EndGame()
        {
            if (State == GameState.GameOver)
            {
                Console.WriteLine("Game over: game finished.");
                return;
            }

            State = GameState.GameOver;
        }

        public void ShowState()
        {
            Console.WriteLine(State);
        }
    }

    // задание 2
    enum AccessLevel { Guest, User, Moderator, Admin }

    class Account
    {
        public AccessLevel AL;
        public string Name;

        public Account(string name, AccessLevel al)
        {
            this.Name = name;
            this.AL = al;
        }

        public bool CanAccess(string action)
        {
            switch (AL)
            {
                case AccessLevel.Guest:
                    return action == "read";

                case AccessLevel.User:
                    return action == "read" || action == "write";

                case AccessLevel.Moderator:
                    return action == "read" || action == "write" || action == "delete";

                case AccessLevel.Admin:
                    return true;
                default:
                    return false;
            }
        }
    }


    // задание 3 
    enum PaymentStatus { Pending, Completed, Failed, Refunded }

    class Payment
    {
        public int Id;
        public int Amount;
        public PaymentStatus Status = PaymentStatus.Pending;

        public void Pay()
        {
            if (Status == PaymentStatus.Completed)
            {
                Console.WriteLine("Cannot pay second time");
                return;
            }
            Status = PaymentStatus.Completed;
        }

        public void Fail()
        {
            Status = PaymentStatus.Failed;
        }

        public void Refund()
        {
            if (Status != PaymentStatus.Completed)
            {
                Console.WriteLine("Uncompleted payment cannot be refunded");
                return;
            }

            Status = PaymentStatus.Refunded;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // задание 1
            //Game game1 = new Game();
            //game1.ShowState();
            //game1.StartGame();
            //game1.ShowState();
            //game1.PauseGame();
            //game1.ShowState();
            //game1.PauseGame();

            // задание 4

            Game game2 = new Game();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Show state");
                Console.WriteLine("2. Start game");
                Console.WriteLine("3. Pause game");
                Console.WriteLine("4. Resume game");
                Console.WriteLine("5. End game");
                Console.WriteLine("0. Exit");

                Console.Write("Choose option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        game2.ShowState();
                        break;

                    case "2":
                        game2.StartGame();
                        break;

                    case "3":
                        game2.PauseGame();
                        break;

                    case "4":
                        game2.ResumeGame();
                        break;

                    case "5":
                        game2.EndGame();
                        break;

                    case "0":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

            // задание 2
            //Account admin = new Account("John", AccessLevel.Admin);

            //if (admin.CanAccess("delete"))
            //{
            //    Console.WriteLine("access granted");
            //}

            //Account guest = new Account("John", AccessLevel.Guest);

            //if (guest.CanAccess("delete"))
            //{
            //    Console.WriteLine("access granted");
            //}
            //else Console.WriteLine("access denied");

            // задание 3
            //Payment p = new Payment();

            //p.Pay();
            ////p.Pay();
            //p.Refund();
            //p.Fail();
            //p.Pay();
        }
    }
}
