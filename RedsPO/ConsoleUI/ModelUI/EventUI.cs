﻿using System;
using System.Collections.Generic;
using static System.Console;
using static UI.ConsoleUI;

namespace UI
{
    class EventUI
    {
        /// <summary>
        /// Shows the Event menu.
        /// </summary>
        public static void ShowEventMenu()
        {
            if (CurrentUser == null) throw new InvalidOperationException("Not logged into an Account!");

            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            WriteLine(new string('-', 40));

            WriteLine(" 1. Add an event");
            WriteLine(" 2. Modify an event");
            WriteLine(" 3. Remove an event");
            WriteLine(" 4. List all events");
            WriteLine(" 5. Fetch an event");
            WriteLine(" 6. List all events on a certain date");
            WriteLine(" 7. Remove all events");
            WriteLine(" 8. Exit the program");

            WriteLine(new string('-', 40));
        }


        /// <summary>
        /// Gets the input from the User.
        /// </summary>
        public static void TakeEventInput()
        {
            if (CurrentUser == null)
                //Shows the start menu
                StartMenu();

            try
            {
                while (true)
                {
                    //Takes the command input
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
                            RemoveEvent();
                            break;

                        case 4:
                            ListAllEvents();
                            break;

                        case 5:
                            FetchEvent();
                            break;

                        case 6:
                            ListAllEventsByDate();
                            break;

                        case 7:
                            RemoveAllEvents();
                            break;

                        case 8:
                            ExitProgram();
                            break;

                        default:
                            throw new InvalidOperationException("Invalid command!");
                    }
                }
            }
            catch (Exception currentException)
            {
                //Shows the current exception message
                WriteLine("An unexpected ERROR occured! Please try again later.");
                WriteLine($"[{currentException.Message}]");
                MenuOrExit();
            }
        }

        /// <summary>
        /// Adds the event.
        /// </summary>
        protected static void AddEvent()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 15) + "ADD EVENT" + new string(' ', 16));
            WriteLine(new string('-', 40));

            //Makes a new empty event
            Event @event = new Event();

            //Gets event data
            WriteLine("Enter event title: ");
            @event.Name = ReadLine();

            WriteLine("Enter event due time (e.g 2009/02/26 18:37:58): ");
            @event.DueTime = DateTime.Parse(ReadLine());

            @event.UserId = CurrentUser.UserId;

            EBusiness.AddEvent(@event);
            WriteLine("Event successfully added");

            MenuOrExit();
        }

        /// <summary>
        /// Modifies an event by its ID.
        /// </summary>
        protected static void ModifyEvent()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 17) + "MODIFY" + new string(' ', 17));
            WriteLine(new string('-', 40));

            //Gets the changed event data
            WriteLine("Enter event id: ");
            int id = int.Parse(ReadLine());

            Event @event = EBusiness.FetchEventById(id, CurrentUser);

            WriteLine("Enter new title: ");
            @event.Name = ReadLine();

            WriteLine("Enter new due time (e.g : 2009/02/26 18:37:58): ");
            @event.DueTime = DateTime.Parse(ReadLine());

            EBusiness.ModifyEvent(@event, CurrentUser);
            WriteLine("Event successfully Modified");

            MenuOrExit();
        }

        /// <summary>
        /// Deletes an event by its ID.
        /// </summary>
        protected static void RemoveEvent()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 17) + "DELETE" + new string(' ', 17));
            WriteLine(new string('-', 40));

            //Gets the event id
            WriteLine("Enter event id: ");
            int id = int.Parse(ReadLine());

            //Removes the event
            EBusiness.RemoveEvent(id, CurrentUser);
            WriteLine("Event successfully deleted");

            MenuOrExit();
        }
        /// <summary>
        /// Lists all events.
        /// </summary>
        protected static void ListAllEvents()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 12) + "LIST ALL EVENTS" + new string(' ', 13));
            WriteLine(new string('-', 40));

            //Gets all user events and lists them
            List<Event> events = EBusiness.ListAllEvents(CurrentUser);
            if (events.Count > 0)
            {
                foreach (Event @event in events)
                {
                    WriteLine($"{@event.EventId} {@event.Name} {@event.DueTime.ToString("g")}");
                }
            }
            else
            {
                WriteLine("No events found!");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Fetches an event.
        /// </summary>
        protected static void FetchEvent()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 14) + "FETCH EVENT" + new string(' ', 15));
            WriteLine(new string('-', 40));

            //Gets the event id
            WriteLine("Enter event id: ");
            int id = int.Parse(ReadLine());

            Event @event = EBusiness.FetchEventById(id, CurrentUser);
            if (@event == null)
            {
                WriteLine($"There is no event with id {id}");
            }
            else
            {
                WriteLine($"Listing the event with the id {id}...");
                WriteLine($"{@event.EventId} {@event.Name} {@event.DueTime.ToString("g")}");
            }

            MenuOrExit();
        }
        /// <summary>
        /// Lists all events on a certain Date.
        /// </summary>
        protected static void ListAllEventsByDate()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 13) + "EVENTS BY DATE" + new string(' ', 13));
            WriteLine(new string('-', 40));

            //Gets event data
            WriteLine("Enter your date (e.g 2009/02/26):");
            DateTime inputDate = DateTime.Parse(ReadLine());

            List<Event> events = EBusiness.ListAllEventsByDate(inputDate, CurrentUser);

            WriteLine($"Listing all events on {inputDate.ToString("d")}...");
            if (events.Count > 0)
            {
                foreach (Event @event in events)
                {
                    WriteLine($"{@event.EventId} {@event.Name} {@event.DueTime.ToString("g")}");
                }
            }
            else
            {
                WriteLine("No events found!");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Removes all events.
        /// </summary>
        protected static void RemoveAllEvents()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 11) + "REMOVE ALL EVENTS" + new string(' ', 12));
            WriteLine(new string('-', 40));

            EBusiness.RemoveAllEvents(CurrentUser);
            WriteLine("All events have successfully been removed");

            MenuOrExit();
        }
    }
}
