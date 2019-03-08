using System;
using System.Collections.Generic;
using static System.Console;
using static UI.ConsoleUI;

namespace UI
{
    class ReminderUI
    {
        /// <summary>
        /// Shows the Reminder menu.
        /// </summary>
        public static void ShowReminderMenu()
        {
            if (CurrentUser == null) throw new InvalidOperationException("Not logged into an Account!");

            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            WriteLine(new string('-', 40));

            WriteLine(" 1. Add a reminder");
            WriteLine(" 2. Modify a reminder");
            WriteLine(" 3. Delete a reminder");
            WriteLine(" 4. List all reminders");
            WriteLine(" 5. Fetch a reminder");
            WriteLine(" 6. List all reminders on a certain date");
            WriteLine(" 7. Remove all reminders");
            WriteLine(" 8. Exit the program");

            WriteLine(new string('-', 40));
        }


        /// <summary>
        /// Gets the input from the User.
        /// </summary>
        public static void TakeReminderInput()
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
                            AddReminder();
                            break;

                        case 2:
                            ModifyReminder();
                            break;

                        case 3:
                            DeleteReminder();
                            break;

                        case 4:
                            ListAllReminders();
                            break;

                        case 5:
                            FetchReminder();
                            break;

                        case 6:
                            ListAllRemindersByDate();
                            break;

                        case 7:
                            RemoveAllReminders();
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
                WriteLine("An unexpected ERROR occured! Please try again later.");
                WriteLine($"[{currentException.Message}]");
                MenuOrExit();
            }
        }


        /// <summary>
        /// Adds the reminder.
        /// </summary>
        public static void AddReminder()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 15) + "ADD REMINDER" + new string(' ', 16));
            WriteLine(new string('-', 40));

            Reminder @reminder= new Reminder();

            WriteLine("Enter reminder title: ");
            @reminder.Name = ReadLine();

            WriteLine("Enter reminder due time (e.g 2009/02/26 18:37:58): ");
            @reminder.DueTime = DateTime.Parse(ReadLine());

            @reminder.UserId = CurrentUser.UserId;

            RBusiness.AddReminder(@reminder);
            WriteLine("Reminder successfully added");

            MenuOrExit();
        }

        /// <summary>
        /// Modifies a reminder by its ID.
        /// </summary>
        public static void ModifyReminder()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 17) + "MODIFY" + new string(' ', 17));
            WriteLine(new string('-', 40));

            WriteLine("Enter reminder id: ");
            int id = int.Parse(ReadLine());

            Reminder @reminder = RBusiness.FetchReminderById(id, CurrentUser);

            WriteLine("Enter new title: ");
            @reminder.Name = ReadLine();

            WriteLine("Enter new due time (e.g : 2009/02/26 18:37:58): ");
            @reminder.DueTime = DateTime.Parse(ReadLine());

            RBusiness.ModifyReminder(@reminder, CurrentUser);
            WriteLine("Reminder successfully Modified");

            MenuOrExit();
        }

        /// <summary>
        /// Delete a reminder bu its ID.
        /// </summary>
        public static void DeleteReminder()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 17) + "DELETE" + new string(' ', 17));
            WriteLine(new string('-', 40));

            WriteLine("Enter reminder id: ");
            int id = int.Parse(ReadLine());

            RBusiness.DeleteReminder(id, CurrentUser);
            WriteLine("Reminder successfully deleted");

            MenuOrExit();
        }


        /// <summary>
        /// Fetches a reminder.
        /// </summary>
        public static void FetchReminder()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 14) + "FETCH REMINDER" + new string(' ', 15));
            WriteLine(new string('-', 40));

            WriteLine("Enter reminder id: ");
            int id = int.Parse(ReadLine());

            Reminder @reminder = RBusiness.FetchReminderById(id, CurrentUser);
            if (@reminder == null)
            {
                WriteLine($"There is no reminder with id {id}");
            }
            else
            {
                WriteLine($"Listing the reminder with the id {id}...");
                WriteLine($"{@reminder.ReminderId} {@reminder.Name} {@reminder.DueTime.ToString("g")}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all reminders.
        /// </summary>
        public static void ListAllReminders()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 12) + "LIST ALL REMINDERS" + new string(' ', 13));
            WriteLine(new string('-', 40));

            List<Reminder> reminders = RBusiness.ListAllReminders(CurrentUser);
            if (reminders.Count > 0)
            {
                foreach (Reminder @reminder in reminders)
                {
                    WriteLine($"{@reminder.ReminderId} {@reminder.Name} {@reminder.DueTime.ToString("g")}");
                }
            }
            else
            {
                WriteLine("No reminders found!");
            }

            MenuOrExit();
        }

        /// <summary>
        /// List all reminder on a certain date.
        /// </summary>
        public static void ListAllRemindersByDate()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 13) + "REMINDERS BY DATE" + new string(' ', 13));
            WriteLine(new string('-', 40));

            WriteLine("Enter your due time (e.g 2009/02/26):");
            DateTime inputDate = DateTime.Parse(ReadLine());

            List<Reminder> reminders = RBusiness.ListAllRemindersByDate(inputDate, CurrentUser);

            WriteLine($"Listing all reminders on {inputDate.ToString("d")}...");
            if (reminders.Count > 0)
            {
                foreach (Reminder @reminder in reminders)
                {
                    WriteLine($"{@reminder.ReminderId} {@reminder.Name} {@reminder.DueTime.ToString("g")}");
                }
            }
            else
            {
                WriteLine("No reminders found!");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Removes all reminders.
        /// </summary>
        public static void RemoveAllReminders()
        {
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 8) + "REMOVE ALL REMINDERS" + new string(' ', 8));
            WriteLine(new string('-', 40));

            RBusiness.RemoveAllReminders(CurrentUser);
            WriteLine("All reminders have successfully been removed");

            MenuOrExit();
        }
    }
}
