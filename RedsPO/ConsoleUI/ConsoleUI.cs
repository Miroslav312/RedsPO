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
        public static EventBusiness EBusiness = new EventBusiness(new PODbContext());
        public static ReminderBusiness RBusiness = new ReminderBusiness(new PODbContext());
        public static TaskBusiness TBusiness = new TaskBusiness(new PODbContext());
        public static UserBusiness UBusiness = new UserBusiness(new PODbContext());
        public static User CurrentUser;

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            //Initializes the window
            InitializeWindow();
            //Shows the start menu
            StartMenu();
        }

        /// <summary>
        /// Initializes the window.
        /// </summary>
        private static void InitializeWindow()
        {
            //Changes console colors
            BackgroundColor = ConsoleColor.White;
            ForegroundColor = ConsoleColor.Black;

            //Clears the console window
            Clear();

            //Changes the console title
            Title = "RedsPO";
        }

        /// <summary>
        /// Determines whether to return Login or Register Menu.
        /// </summary>
        public static void StartMenu()
        {
            try
            {
                //Clears the console
                Clear();

                //Shows the menu
                WriteLine(new string('-', 40));
                WriteLine(new string(' ', 19) + "HI" + new string(' ', 19));
                WriteLine(new string('-', 40));
                WriteLine("1. Register an Account");
                WriteLine("2. Sign in your Account");
                WriteLine(new string('-', 40));

                //Takes command input
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
                //Returns to the start menu
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
                //Shows the menu
                ShowMenu();
                //Takes input
                TakeInput();
            }
            else if (answer.ToLower() == "exit")
            {
                //Exits the program
                ExitProgram();
            }
            else
            {
                //Relaunches this method
                MenuOrExit();
            }
        }

        /// <summary>
        /// Shows the User menu.
        /// </summary>
        public static void ShowMenu()
        {
            if (CurrentUser == null) throw new InvalidOperationException("Not logged into an Account!");

            //Clears the console window
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
                //Shows the start menu
                StartMenu();

            try
            {
                while (true)
                {
                    //Takes command input
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
                //Shows current exception message
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
            //Clears the console window
            Clear();

            WriteLine("Have a nice day!");
            //Exits the environment with ExitCode = 0
            Environment.Exit(0);
        }
    }
}
