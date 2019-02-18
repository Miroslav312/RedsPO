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
            Console.WriteLine("1. Make an account");
            Console.WriteLine("2. Already have an account");
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
        /// Logins the User into his Account.
        /// </summary>
        public static void Login()
        {
            Console.Clear();
            //To-do: Add hash commands
            Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();
            user = userBusiness.Get(username, password);
            ShowMenu();
        }

        /// <summary>
        ///   Registers the User.
        /// </summary>
        public static void Register()
        {
            Console.Clear();
            //To-do: Add hash commands
            User user = new User();
            Console.WriteLine("Enter Username: ");
            user.UserName = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            user.PasswordHash = Console.ReadLine();
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
            Console.WriteLine(" 8. List all uncompleted events");
            Console.WriteLine(" 9. Remove all completed events");
            Console.WriteLine("10. Remove all events");
            Console.WriteLine(new string('-', 40));
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
                        ListAllIncompletedEvents();
                        break;

                    case 9:
                        RemoveAllCompletedEvents();
                        break;

                    case 10:
                        RemoveAllEvents();
                        break;
                    default:
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
            Console.WriteLine("Enter event importance: ");
            @event.Importance = Console.ReadLine();

            eventBusiness.AddEvent(@event);
            Console.WriteLine("Event successfully added");
        }

        /// <summary>
        /// Modifies an event by its ID.
        /// </summary>
        public static void ModifyEvent()
        {
            Console.Clear();
            Console.WriteLine("Enter event id: ");
            int id = int.Parse(Console.ReadLine());
            Event @event = eventBusiness.FetchEvent(id, user);
            Console.WriteLine("Enter new title: ");
            @event.Title = Console.ReadLine();
            Console.WriteLine("Enter new due time: ");
            Console.WriteLine("Examples: ");
            @event.DueTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter new importance: ");
            @event.Importance = Console.ReadLine();

            eventBusiness.ModifyEvent(@event, user);
            Console.WriteLine("Event successfully Modified");
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
        }

        /// <summary>
        /// Marks an event by its ID as done.
        /// </summary>
        public static void MarkEventAsDone()
        {
            Console.Clear();
            Console.WriteLine("Enter event id: ");
            int id = int.Parse(Console.ReadLine());
            Event @event = eventBusiness.FetchEvent(id, user);
            if (@event == null || @event.IsDone == true)
            {
                Console.WriteLine("Event is already completed or does not exist");
            }
            else
            {
                eventBusiness.CompleteEvent(id, user);
                Console.WriteLine("Event successfully completed");
            }
        }

        /// <summary>
        /// Lists all events.
        /// </summary>
        public static void ListAllEvents()
        {
            List<Event> events = eventBusiness.ListAllEvents(user);
            foreach (var item in events)
            {
                Console.WriteLine($"{item.EventId} {item.Title} {item.DueTime} {item.Importance}");
            }
        }

        /// <summary>
        /// Fetches an event.
        /// </summary>
        public static void FetchEvent()
        {
            int id = int.Parse(Console.ReadLine());
            Event @event = eventBusiness.FetchEvent(id, user);
            if (@event == null)
            {
                Console.WriteLine($"There is no event with id {id}");
            }
            else
            {
                Console.WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime} {@event.Importance}");
            }
        }

        /// <summary>
        /// Lists all completed events.
        /// </summary>
        public static void ListAllCompletedEvents()
        {
            List<Event> events = eventBusiness.ListAllCompletedEvents(user);
            foreach (var item in events)
            {
                Console.WriteLine($"{item.EventId} {item.Title} {item.DueTime} {item.Importance}");
            }
        }

        /// <summary>
        /// Lists all incompleted events.
        /// </summary>
        public static void ListAllIncompletedEvents()
        {
            List<Event> events = eventBusiness.ListAllUncompletedEvents(user);
            foreach (var item in events)
            {
                Console.WriteLine($"{item.EventId} {item.Title} {item.DueTime} {item.Importance}");
            }
        }

        /// <summary>
        /// Removes all completed events.
        /// </summary>
        public static void RemoveAllCompletedEvents()
        {
            eventBusiness.RemoveAllCompletedEvents(user);
            Console.WriteLine("All completed events have successfully been removed");
        }

        /// <summary>
        /// Removes all events.
        /// </summary>
        public static void RemoveAllEvents()
        {
            eventBusiness.RemoveAllEvents(user);
            Console.WriteLine("All events have successfully been removed");
        }
    }
}
