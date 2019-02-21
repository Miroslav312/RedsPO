using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace UI
{
    public class ConsoleUI
    {
        private static EventBusiness eventBusiness = new EventBusiness();
        private static UserBusiness userBusiness = new UserBusiness();
        private static User user;

        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        public static void Main()
        {
            Input();
        }

        /// <summary>
        /// Determines whether to return Login or Register Menu.
        /// </summary>
        public static void LoginOrRegisterMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. Register an Account");
            Console.WriteLine("2. Sign in your Account");
            Console.WriteLine(new string('-', 40));
            int command = int.Parse(Console.ReadLine());
            switch (command)
            {
                case 1:
                    Register();
                    break;

                case 2:
                    Login();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Determines whether to go to the Main Menu or to Exit the program.
        /// </summary>
        public static void MenuOrExit()
        {
            Console.WriteLine("Do you want to go to the Main Menu or to Exit the Program? [Menu/Exit]");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "menu")
            {
                ShowMenu();
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
        /// Logins the User into his Account.
        /// </summary>
        public static void Login()
        {
            Console.Clear();

            Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            string passwordHash = UserBusiness.HashPassword(ReadPassword());

            user = userBusiness.FetchUser(username, passwordHash);

            if (user == null)
            {
                Console.WriteLine("There was an error logging in the application. Please try again later!");
            }
            else
            {
                ShowMenu();
            }
        }

        /// <summary>
        ///   Registers the User.
        /// </summary>
        public static void Register()
        {
            Console.Clear();
            
            User user = new User();

            Console.WriteLine("Enter Username: ");
            user.UserName = Console.ReadLine();

            Console.WriteLine("Enter Password:");
            user.PasswordHash = UserBusiness.HashPassword(ReadPassword());

            Console.WriteLine("First Name: ");
            user.FirstName = Console.ReadLine();

            Console.WriteLine("Last Name: ");
            user.LastName = Console.ReadLine();

            userBusiness.Register(user);

            Login();
        }

        /// <summary>
        /// Shows the User menu.
        /// </summary>
        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(" 1. Add an event");
            Console.WriteLine(" 2. Modify an event");
            Console.WriteLine(" 3. Delete an event");
            Console.WriteLine(" 4. Complete an event");
            Console.WriteLine(" 5. List all events");
            Console.WriteLine(" 6. Fetch an event for a certain day");
            Console.WriteLine(" 7. List all completed events");
            Console.WriteLine(" 8. List all events on a certain date");
            Console.WriteLine(" 9. List all uncompleted events");
            Console.WriteLine(" 10. Remove all completed events");
            Console.WriteLine(" 11. Remove all events");
            Console.WriteLine(new string('-', 40));
        }


        /// <summary>
        /// Exits the program.
        /// </summary>
        public static void ExitProgram()
        {
            Console.Clear();

            Console.WriteLine("Have a nice day!");
            Environment.Exit(0);
        }

        /// <summary>
        /// Gets the input from the User.
        /// </summary>
        public static void Input()
        {
            LoginOrRegisterMenu();
            while (true)
            {
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        AddEvent();
                        break;

                    case 2:
                        ModifyEvent();
                        break;

                    case 3:
                        DeleteEvent();
                        break;

                    case 4:
                        MarkEventAsDone();
                        break;

                    case 5:
                        ListAllEvents();
                        break;

                    case 6:
                        FetchEvent();
                        break;

                    case 7:
                        ListAllCompletedEvents();
                        break;
                    case 8:
                        break;

                    case 9:
                        ListAllUncompletedEvents();
                        break;

                    case 10:
                        RemoveAllCompletedEvents();
                        break;

                    case 11:
                        RemoveAllEvents();
                        break;

                    default:
                        ExitProgram();
                        break;
                }
            }
        }

        /// <summary>
        /// Adds the event.
        /// </summary>
        public static void AddEvent()
        {
            Console.Clear();

            Event @event = new Event();

            Console.WriteLine("Enter event title: ");
            @event.Title = Console.ReadLine();

            Console.WriteLine("Enter event year: ");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter event month: ");
            int month = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter event day: ");
            int day = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter event hour: ");
            int hour = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter event minute: ");
            int minute = int.Parse(Console.ReadLine());

            @event.DueTime = new DateTime(year, month, day, hour, minute, 0);

            Console.WriteLine("Enter event importance [Low, Medium, High]: ");
            @event.Importance = Console.ReadLine();

            eventBusiness.AddEvent(@event);
            Console.WriteLine("Event successfully added");

            MenuOrExit();
        }

        /// <summary>
        /// Modifies an event by its ID.
        /// </summary>
        public static void ModifyEvent()
        {
            Console.Clear();

            Console.WriteLine("Enter event id: ");
            int id = int.Parse(Console.ReadLine());

            Event @event = eventBusiness.FetchEventById(id, user);

            Console.WriteLine("Enter new title: ");
            @event.Title = Console.ReadLine();

            Console.WriteLine("Enter new due time: ");
            @event.DueTime = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter new importance: ");
            @event.Importance = Console.ReadLine();

            eventBusiness.ModifyEvent(@event, user);
            Console.WriteLine("Event successfully Modified");

            MenuOrExit();
        }

        /// <summary>
        /// Deletes an event by its ID.
        /// </summary>
        public static void DeleteEvent()
        {
            Console.Clear();

            Console.WriteLine("Enter event id: ");
            int id = int.Parse(Console.ReadLine());

            eventBusiness.DeleteEvent(id, user);

            Console.WriteLine("Event successfully deleted");

            MenuOrExit();
        }

        /// <summary>
        /// Marks an event by its ID as done.
        /// </summary>
        public static void MarkEventAsDone()
        {
            Console.Clear();

            Console.WriteLine("Enter event id: ");
            int id = int.Parse(Console.ReadLine());

            Event @event = eventBusiness.FetchEventById(id, user);

            if (@event == null || @event.IsDone == true)
            {
                Console.WriteLine("Event is already completed or does not exist");
            }
            else
            {
                eventBusiness.CompleteEvent(id, user);
                Console.WriteLine("Event successfully completed");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all events.
        /// </summary>
        public static void ListAllEvents()
        {
            Console.Clear();

            List<Event> events = eventBusiness.ListAllEvents(user);
            foreach (var item in events)
            {
                Console.WriteLine($"{item.EventId} {item.Title} {item.DueTime} {item.Importance}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Fetches an event.
        /// </summary>
        public static void FetchEvent()
        {
            Console.Clear();

            Console.WriteLine("Enter event id: ");
            int id = int.Parse(Console.ReadLine());

            Event @event = eventBusiness.FetchEventById(id, user);
            if (@event == null)
            {
                Console.WriteLine($"There is no event with id {id}");
            }
            else
            {
                Console.WriteLine($"Listing the event with the id {id}...");
                Console.WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime} {@event.Importance}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all completed events.
        /// </summary>
        public static void ListAllCompletedEvents()
        {
            Console.Clear();

            List<Event> events = eventBusiness.ListAllCompletedEvents(user);

            Console.WriteLine("Listing all completed tasks...");
            foreach (Event @event in events)
            {
                Console.WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime} {@event.Importance}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all events on a certain Date.
        /// </summary>
        public static void ListAllEventsByDate()
        {
            Console.Clear();

            Console.WriteLine("Enter your date [e.g '2015-01-01']:");
            DateTime inputDate = DateTime.Parse(Console.ReadLine());

            List<Event> events = eventBusiness.ListAllEventsByDate(inputDate, user);

            Console.WriteLine($"Listing all events on {inputDate.Date}...");
            foreach (Event @event in events)
            {
                Console.WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime} {@event.Importance}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all uncompleted events.
        /// </summary>
        public static void ListAllUncompletedEvents()
        {
            Console.Clear();

            List<Event> events = eventBusiness.ListAllUncompletedEvents(user);
            
            Console.WriteLine("Listing all uncompleted events...");
            foreach (Event @event in events)
            {
                Console.WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime} {@event.Importance}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Removes all completed events.
        /// </summary>
        public static void RemoveAllCompletedEvents()
        {
            Console.Clear();

            eventBusiness.RemoveAllCompletedEvents(user);
            Console.WriteLine("All completed events have successfully been removed");

            MenuOrExit();
        }

        /// <summary>
        /// Removes all events.
        /// </summary>
        public static void RemoveAllEvents()
        {
            Console.Clear();

            eventBusiness.RemoveAllEvents(user);
            Console.WriteLine("All events have successfully been removed");

            MenuOrExit();
        }

        /// <summary>
        /// Reads the password, hiding the input.
        /// </summary>
        public static string ReadPassword()
        {
            string inputPassword = "";
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                if (keyInfo.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    inputPassword += keyInfo.KeyChar;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(inputPassword))
                    {
                        // Remove one character from the list of password characters
                        inputPassword = inputPassword.Substring(0, inputPassword.Length - 1);
                        // Get the location of the cursor
                        int cursorPosition = Console.CursorLeft;
                        // Move the cursor to the left by one character
                        Console.SetCursorPosition(cursorPosition - 1, Console.CursorTop);
                        // Replace it with space
                        Console.Write(" ");
                        // Move the cursor to the left by one character again
                        Console.SetCursorPosition(cursorPosition - 1, Console.CursorTop);
                    }
                }

                keyInfo = Console.ReadKey(true);
            }

            Console.WriteLine();

            return inputPassword;
        }
    }
}
