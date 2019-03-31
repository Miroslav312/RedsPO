using System;
using System.Collections.Generic;
using Notifications.Wpf;
using static UI.UIProperties;
using System.Timers;

namespace UI
{
    class NotificationManager
    {
        private Timer _timer;
        private const int _periodOfDelay = 86400000;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationManager"/> class.
        /// </summary>
        public NotificationManager()
        {
            //Calls the manager methods
            EventManager();
            TaskManager();
            ReminderManager();

            //Set ups the timer
            _timer = new Timer(_periodOfDelay);
            _timer.Elapsed += new ElapsedEventHandler(ElapsedHandler);
            _timer.Enabled = true;

            //Keeps the instance of the timer alive
            GC.KeepAlive(_timer);
        }

        /// <summary>Handler for elapsed time.</summary>
        /// <param name="source">The source.</param>
        /// <param name="e">The <see cref="ElapsedEventArgs"/> instance containing the event data.</param>
        private static void ElapsedHandler(object source, ElapsedEventArgs e)
        {
            EventManager();
            TaskManager();
            ReminderManager();
        }

        /// <summary>
        /// Manages event toasts.
        /// </summary>
        private static void EventManager()
        {
            //Gets current events
            List<Event> currentEvents = eventBusiness.ListAllEventsByDate(DateTime.Now, currentUser);

            foreach (Event @event in currentEvents)
            {
                DisplayToast("Event", @event.Name, @event.DueTime);
            }
        }

        /// <summary>
        /// Manages task toasts.
        /// </summary>
        private static void TaskManager()
        {
            //Gets current tasks
            List<Task> currentTasks = taskBusiness.ListAllTasksByDate(DateTime.Now, currentUser);

            foreach (Task @task in currentTasks)
            {
                DisplayToast("Task", @task.Name, @task.Date);
            }
        }

        /// <summary>
        /// Manages reminder toasts.
        /// </summary>
        private static void ReminderManager()
        {
            //Gets current reminders
            List<Reminder> currentReminders = reminderBusiness.ListAllRemindersByDate(DateTime.Now, currentUser);

            foreach (Reminder @reminder in currentReminders)
            {
                DisplayToast("Reminder", @reminder.Name, @reminder.DueTime);
            }
        }

        /// <summary>Displays the toast.</summary>
        /// <param name="type">The type.</param>
        /// <param name="message">The message.</param>
        /// <param name="date">The date.</param>
        private static void DisplayToast(string type, string message, DateTime date)
        {
            //Creates a new notification manager
            Notifications.Wpf.NotificationManager notificationManager = new Notifications.Wpf.NotificationManager();

            //Shows the notification with the given data
            notificationManager.Show(new NotificationContent
            {
                Title = type,
                Message = message + " " + date.ToString("d"),
                Type = NotificationType.Information
            });
        }
    }
}
