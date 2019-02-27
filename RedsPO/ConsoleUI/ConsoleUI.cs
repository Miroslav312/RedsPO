using System;
using static System.Console;
using System.Collections.Generic;
using Business;

namespace UI
{
    public class I
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
                    break;
            }
        }

        /// <summary>
        /// Determines whether to go to the Main Menu or to Exit the program.
        /// </summary>
        public static void MenuOrExit()
        {
            WriteLine("Do you want to go to the Main Menu or to Exit the Program? [Menu/Exit]");
            string answer = ReadLine();
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
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 17) + "LOGIN" + new string(' ', 18));
            WriteLine(new string('-', 40));

            WriteLine("Enter Username:");
            string username = ReadLine();

            WriteLine("Enter Password:");
            string passwordHash = UserBusiness.HashPassword(ReadPassword());

            user = userBusiness.FetchUser(username, passwordHash);

            if (user == null)
            {
                WriteLine("There was an error logging in the application. Please try again later!");
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
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 16) + "REGISTER" + new string(' ', 16));
            WriteLine(new string('-', 40));

            User user = new User();

            WriteLine("Enter Username: ");
            user.UserName = ReadLine();

            WriteLine("Enter Password:");
            user.PasswordHash = UserBusiness.HashPassword(ReadPassword());

            WriteLine("First Name: ");
            user.FirstName = ReadLine();

            WriteLine("Last Name: ");
            user.LastName = ReadLine();

            userBusiness.Register(user);

            Login();
        }

        /// <summary>
        /// Shows the User menu.
        /// </summary>
        public static void ShowMenu()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            WriteLine(new string('-', 40));

            WriteLine(" 1. Add an event");
            WriteLine(" 2. Modify an event");
            WriteLine(" 3. Delete an event");
            WriteLine(" 4. Complete an event");
            WriteLine(" 5. List all events");
            WriteLine(" 6. Fetch an event for a certain day");
            WriteLine(" 7. List all completed events");
            WriteLine(" 8. List all events on a certain date");
            WriteLine(" 9. List all uncompleted events");
            WriteLine(" 10. Remove all completed events");
            WriteLine(" 11. Remove all events");
            WriteLine(new string('-', 40));
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

        /// <summary>
        /// Gets the input from the User.
        /// </summary>
        public static void Input()
        {
            LoginOrRegisterMenu();
            while (true)
            {
                int command = int.Parse(ReadLine());
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
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 15) + "ADD EVENT" + new string(' ', 16));
            WriteLine(new string('-', 40));

            Event @event = new Event();

            WriteLine("Enter event title: ");
            @event.Title = ReadLine();

            WriteLine("Enter event year: ");
            int year = int.Parse(ReadLine());

            WriteLine("Enter event month: ");
            int month = int.Parse(ReadLine());

            WriteLine("Enter event day: ");
            int day = int.Parse(ReadLine());

            WriteLine("Enter event hour: ");
            int hour = int.Parse(ReadLine());

            WriteLine("Enter event minute: ");
            int minute = int.Parse(ReadLine());

            @event.DueTime = new DateTime(year, month, day, hour, minute, 0);

            WriteLine("Enter event importance [Low, Medium, High]: ");
            @event.Importance = ReadLine();

            eventBusiness.AddEvent(@event);
            WriteLine("Event successfully added");

            MenuOrExit();
        }

        /// <summary>
        /// Modifies an event by its ID.
        /// </summary>
        public static void ModifyEvent()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 17) + "MODIFY" + new string(' ', 17));
            WriteLine(new string('-', 40));

            WriteLine("Enter event id: ");
            int id = int.Parse(ReadLine());

            Event @event = eventBusiness.FetchEventById(id, user);

            WriteLine("Enter new title: ");
            @event.Title = ReadLine();

            WriteLine("Enter new due time: ");
            @event.DueTime = DateTime.Parse(ReadLine());

            WriteLine("Enter new importance: ");
            @event.Importance = ReadLine();

            eventBusiness.ModifyEvent(@event, user);
            WriteLine("Event successfully Modified");

            MenuOrExit();
        }

        /// <summary>
        /// Deletes an event by its ID.
        /// </summary>
        public static void DeleteEvent()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 17) + "DELETE" + new string(' ', 17));
            WriteLine(new string('-', 40));

            WriteLine("Enter event id: ");
            int id = int.Parse(ReadLine());

            eventBusiness.DeleteEvent(id, user);

            WriteLine("Event successfully deleted");

            MenuOrExit();
        }

        /// <summary>
        /// Marks an event by its ID as done.
        /// </summary>
        public static void MarkEventAsDone()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 11) + "MARK EVENT AS DONE" + new string(' ', 11));
            WriteLine(new string('-', 40));

            WriteLine("Enter event id: ");
            int id = int.Parse(ReadLine());

            Event @event = eventBusiness.FetchEventById(id, user);

            if (@event == null || @event.IsDone == true)
            {
                WriteLine("Event is already completed or does not exist");
            }
            else
            {
                eventBusiness.CompleteEvent(id, user);
                WriteLine("Event successfully completed");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all events.
        /// </summary>
        public static void ListAllEvents()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 12) + "LIST ALL EVENTS" + new string(' ', 13));
            WriteLine(new string('-', 40));

            List<Event> events = eventBusiness.ListAllEvents(user);
            foreach (Event @event in events)
            {
                WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime} {@event.Importance}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Fetches an event.
        /// </summary>
        public static void FetchEvent()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 14) + "FETCH EVENT" + new string(' ', 15));
            WriteLine(new string('-', 40));

            WriteLine("Enter event id: ");
            int id = int.Parse(ReadLine());

            Event @event = eventBusiness.FetchEventById(id, user);
            if (@event == null)
            {
                WriteLine($"There is no event with id {id}");
            }
            else
            {
                WriteLine($"Listing the event with the id {id}...");
                WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime} {@event.Importance}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all completed events.
        /// </summary>
        public static void ListAllCompletedEvents()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 12) + "COMPLETED EVENTS" + new string(' ', 12));
            WriteLine(new string('-', 40));

            List<Event> events = eventBusiness.ListAllCompletedEvents(user);

            WriteLine("Listing all completed tasks...");
            foreach (Event @event in events)
            {
                WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime} {@event.Importance}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all events on a certain Date.
        /// </summary>
        public static void ListAllEventsByDate()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 13) + "EVENTS BY DATE" + new string(' ', 13));
            WriteLine(new string('-', 40));

            WriteLine("Enter your date [e.g '2015-01-01']:");
            DateTime inputDate = DateTime.Parse(ReadLine());

            List<Event> events = eventBusiness.ListAllEventsByDate(inputDate, user);

            WriteLine($"Listing all events on {inputDate.Date}...");
            foreach (Event @event in events)
            {
                WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime} {@event.Importance}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all uncompleted events.
        /// </summary>
        public static void ListAllUncompletedEvents()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 11) + "UNCOMPLETED EVENTS" + new string(' ', 11));
            WriteLine(new string('-', 40));

            List<Event> events = eventBusiness.ListAllUncompletedEvents(user);
            
            WriteLine("Listing all uncompleted events...");
            foreach (Event @event in events)
            {
                WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime} {@event.Importance}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Removes all completed events.
        /// </summary>
        public static void RemoveAllCompletedEvents()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 8) + "REMOVE COMPLETED EVENTS" + new string(' ', 8));
            WriteLine(new string('-', 40));

            eventBusiness.RemoveAllCompletedEvents(user);
            WriteLine("All completed events have successfully been removed");

            MenuOrExit();
        }

        /// <summary>
        /// Removes all events.
        /// </summary>
        public static void RemoveAllEvents()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 11) + "REMOVE ALL EVENTS" + new string(' ', 12));
            WriteLine(new string('-', 40));

            eventBusiness.RemoveAllEvents(user);
            WriteLine("All events have successfully been removed");

            MenuOrExit();
        }

        /// <summary>
        /// Reads the password, hiding the input.
        /// </summary>
        public static string ReadPassword()
        {
            string inputPassword = "";
            ConsoleKeyInfo keyInfo = ReadKey(true);

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                if (keyInfo.Key != ConsoleKey.Backspace)
                {
                    Write("*");
                    inputPassword += keyInfo.KeyChar;
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(inputPassword))
                    {
                        // Remove one character from the list of password characters
                        inputPassword = inputPassword.Substring(0, inputPassword.Length - 1);
                        // Get the location of the cursor
                        int cursorPosition = CursorLeft;
                        // Move the cursor to the left by one character
                        SetCursorPosition(cursorPosition - 1, CursorTop);
                        // Replace it with space
                        Write(" ");
                        // Move the cursor to the left by one character again
                        SetCursorPosition(cursorPosition - 1, CursorTop);
                    }
                }

                keyInfo = ReadKey(true);
            }

            WriteLine();

            return inputPassword;
        }
    }
}
