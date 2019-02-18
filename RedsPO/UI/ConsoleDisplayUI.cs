using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;

namespace UI
{
    class Display
    {
        private EventBusiness eventBusiness = new EventBusiness();
        private UserBusiness userBusiness = new UserBusiness();
        private User user;

        public Display()
        {
            Input();
        }

        public void LoginOrRegisterMenu()
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

        public void Login()
        {
            //To-do: Add hash commands
            Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();
            user = userBusiness.Get(username, password);
        }

        public void Register()
        {
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
            user = userBusiness.Get(user.UserName, user.PasswordHash);
        }

        public void ShowMenu()
        {
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

        public void Input()
        {
            LoginOrRegisterMenu();
            while (true)
            {
                int command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1:
                        Add();
                        break;

                    case 2:
                        Modify();
                        break;

                    case 3:
                        Delete();
                        break;

                    case 4:
                        Complete();
                        break;

                    case 5:
                        ListAll();
                        break;

                    case 6:
                        Fetch();
                        break;

                    case 7:
                        ListAllCompleted();
                        break;

                    case 8:
                        ListAllUncompleted();
                        break;

                    case 9:
                        RemoveAllCompleted();
                        break;

                    case 10:
                        RemoveAll();
                        break;
                    default:
                        break;
                }
            }
        }

        public void Add()
        {
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

        public void Modify()
        {
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

        public void Delete()
        {
            Console.WriteLine("Enter event id: ");
            int id = int.Parse(Console.ReadLine());
            eventBusiness.DeleteEvent(id, user);
            Console.WriteLine("Event successfully deleted");
        }

        public void Complete()
        {
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

        public void ListAll()
        {
            List<Event> events = eventBusiness.ListAllEvents(user);
            foreach (var item in events)
            {
                Console.WriteLine($"{item.EventId} {item.Title} {item.DueTime} {item.Importance}");
            }
        }

        public void Fetch()
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

        public void ListAllCompleted()
        {
            List<Event> events = eventBusiness.ListAllCompletedEvents(user);
            foreach (var item in events)
            {
                Console.WriteLine($"{item.EventId} {item.Title} {item.DueTime} {item.Importance}");
            }
        }

        public void ListAllUncompleted()
        {
            List<Event> events = eventBusiness.ListAllUncompletedEvents(user);
            foreach (var item in events)
            {
                Console.WriteLine($"{item.EventId} {item.Title} {item.DueTime} {item.Importance}");
            }
        }

        public void RemoveAllCompleted()
        {
            eventBusiness.RemoveAllCompletedEvents(user);
            Console.WriteLine("All completed events have successfully been removed");
        }

        public void RemoveAll()
        {
            eventBusiness.RemoveAllEvents(user);
            Console.WriteLine("All events have successfully been removed");
        }
    }
}
