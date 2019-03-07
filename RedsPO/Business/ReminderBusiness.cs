using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ReminderBusiness
    {
        private PODbContext poDbContext;

        /// <summary>Adds the reminder.</summary>
        /// <param name="userReminder">The user reminder.</param>
        public void AddReminder(Reminder userReminder)
        {
            using (poDbContext = new PODbContext())
            {
                poDbContext.Reminders.Add(userReminder);
                poDbContext.SaveChanges();
            }
        }

        /// <summary>Modifies the reminder.</summary>
        /// <param name="userReminder">The user reminder.</param>
        /// <param name="user">The user.</param>
        public void ModifyReminder(Reminder userReminder, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Reminder @reminder = poDbContext.Reminders.Find(userReminder.ReminderId);
                if (@reminder == null && @reminder.UserId != user.UserId)
                {
                    throw new InvalidOperationException("Reminder either does not exist or is in another user!");
                    //Warning: Reminder either does not exist or is in another user
                }
                else
                {
                    poDbContext.Entry(@reminder).CurrentValues.SetValues(userReminder);
                    poDbContext.SaveChanges();
                }
            }
        }

        /// <summary>Deletes the reminder.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public void DeleteReminder(int id, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Reminder @reminder = poDbContext.Reminders.Find(id);
                if (reminder == null && reminder.UserId != user.UserId)
                {
                    throw new InvalidOperationException("Reminder either does not exist or is in another user!");
                    //Warning: Reminder either does not exist or is in another user
                }
                else
                {
                    poDbContext.Reminders.Remove(@reminder);
                    poDbContext.SaveChanges();
                }
            }
        }

        /// <summary>Fetches the reminder by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public Reminder FetchReminderById(int id, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Reminder @reminder = poDbContext.Reminders.Find(id);
                if (@reminder == null && @reminder.UserId != user.UserId)
                {
                    throw new InvalidOperationException("Reminder either does not exist or is in another user!");
                    //Warning: Reminder either does not exist or is in another user
                }
                else
                {
                    return @reminder;
                }
            }
        }

        /// <summary>Lists all reminders.</summary>
        /// <param name="user">The user.</param>
        public List<Reminder> ListAllReminders(User user)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Reminders.Where(r => r.UserId == user.UserId).ToList();
            }
        }

        /// <summary>Lists all reminders by date.</summary>
        /// <param name="date">The date.</param>
        /// <param name="user">The user.</param>
        public List<Reminder> ListAllRemindersByDate(DateTime date, User user)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Reminders.Where(r => r.DueTime == date && r.UserId == user.UserId).ToList();
            }
        }

        /// <summary>Removes all reminders.</summary>
        /// <param name="user">The user.</param>
        public void RemoveAllReminders(User user)
        {
            using (poDbContext = new PODbContext())
            {
                foreach (Reminder @reminder in poDbContext.Reminders)
                {
                    if (@reminder.UserId == user.UserId)
                    {
                        poDbContext.Reminders.Remove(@reminder);
                    }
                }

                poDbContext.SaveChanges();
            }
        }
    }
}
