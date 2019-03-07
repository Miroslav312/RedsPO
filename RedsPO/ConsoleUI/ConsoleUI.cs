using System;
using Business;
using static System.Console;
using static UI.EventUI;
using static UI.TaskUI;
using static UI.ReminderUI;
using static UI.UserUI;

namespace UI
{
    public static class ConsoleUI
    {
        public static EventBusiness EBusiness = new EventBusiness();
        public static ReminderBusiness RBusiness = new ReminderBusiness();
        public static TaskBusiness TBusiness = new TaskBusiness();
        public static UserBusiness UBusiness = new UserBusiness();
        public static User CurrentUser;

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            InitializeWindow();
            StartMenu();
        }

        /// <summary>
        /// Initialises the window.
        /// </summary>
        private static void InitializeWindow()
        {
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Black;

            Clear();

            Title = "RedsPO";
        }

        /// <summary>
        /// Determines whether to return Login or Register Menu.
        /// </summary>
        public static void StartMenu()
        {
            try
            {
                Clear();

                WriteLine(new string('-', 40));
                WriteLine(new string(' ', 19) + "HI" + new string(' ', 19));
                WriteLine(new string('-', 40));
                WriteLine("1. Register an Account");
                WriteLine("2. Sign in your Account");
                WriteLine(new string('-', 40));

                int command = int.Parse(ReadLine());

                switch (command)
                {
                    case 1:
                        Register();
                        break;

                    case 2:
                        Login();
                        break;

                    default:
                        StartMenu();
                        break;
                }
            }
            catch
            {
                StartMenu();
            }
        }

        /// <summary>
        /// Determines whether to go to the Main Menu or to Exit the program.
        /// </summary>
        public static void MenuOrExit()
        {
            WriteLine(new string('-', 40));
            WriteLine("Do you want to go to the Main Menu or to Exit the Program? [Menu/Exit]");

            string answer = ReadLine();
            if (answer.ToLower() == "menu")
            {
                ShowMenu();
                TakeInput();
            }
            else if (answer.ToLower() == "exit")
            {
                ExitProgram();
            }
            else
            {
                MenuOrExit();
            }
        }

        /// <summary>
        /// Shows the User menu.
        /// </summary>
        public static void ShowMenu()
        {
            if (CurrentUser == null) throw new InvalidOperationException("Not logged into an Account!");

            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            WriteLine(new string('-', 40));

            WriteLine(" 1. Events");
            WriteLine(" 2. Tasks");
            WriteLine(" 3. Reminders");
            
            WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Gets the input from the User.
        /// </summary>
        public static void TakeInput()
        {
            if (CurrentUser == null)
                StartMenu();

            try
            {
                while (true)
                {
                    int command = int.Parse(ReadLine());
                    switch (command)
                    {
                        case 1:
                            ShowEventMenu();
                            TakeEventInput();
                            break;

                        case 2:
                            ShowTaskMenu();
                            TakeTaskInput();
                            break;

                        case 3:
                            ShowReminderMenu();
                            TakeReminderInput();
                            break;

                        default:
                            throw new InvalidOperationException("Invalid command!");
                    }
                }
            }
            catch (Exception currentException)
            {
                WriteLine("An unexpected ERROR occured! Please try again later.");
                WriteLine($"[{currentException.Message}]");
                MenuOrExit();
            }
        }

        /// <summary>
        /// Exits the program.
        /// </summary>
        public static void ExitProgram()
        {
            Clear();

            WriteLine("Have a nice day!");
            Environment.Exit(0);
        }
    }
}
