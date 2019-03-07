using System;
using Business;
using static System.Console;
using static UI.ConsoleUI;

namespace UI
{
    class TaskUI
    {


        // USEFUL FOR TASK IMPLEMENTATION

        /*
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
        */
        /*
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
            if(events.Count > 0)
            { 
                foreach (Event @event in events)
                {
                    WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime.ToString("dd'/'MM'/'yyyy")} {@event.Importance}");
                }
            }
            else
            {
                WriteLine("No events found!");
            }

            MenuOrExit();
        }
        */

        /*
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
            if(events.Count > 0) { 
            foreach (Event @event in events)
            {
                WriteLine($"{@event.EventId} {@event.Title} {@event.DueTime.ToString("dd'/'MM'/'yyyy")} {@event.Importance}");
            }
            }
            else
            {
                WriteLine("No events found!");
            }

            MenuOrExit();
        }
        */
        /*
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
        */

    }
}
