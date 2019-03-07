using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class EventBusiness
    {
        private PODbContext poDbContext;

        /// <summary>Adds the event.</summary>
        /// <param name="userEvent">The user event.</param>
        public void AddEvent(Event userEvent)
        {
            using (poDbContext = new PODbContext())
            {
                poDbContext.Events.Add(userEvent);
                poDbContext.SaveChanges();
            }
        }

        /// <summary>Modifies the event.</summary>
        /// <param name="userEvent">The user event.</param>
        /// <param name="user">The user.</param>
        public void ModifyEvent(Event userEvent, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Event @event = poDbContext.Events.Find(userEvent.EventId);
                if (@event == null && @event.UserId != user.UserId)
                {
                    throw new InvalidOperationException("Event either does not exist or is in another user!");
                    //Warning: Event either does not exist or is in another user
                }
                else
                {
                    poDbContext.Entry(@event).CurrentValues.SetValues(userEvent);
                    poDbContext.SaveChanges();
                }
            }
        }

        /// <summary>Deletes the event.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public void DeleteEvent(int id, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Event @event = poDbContext.Events.Find(id);
                if (@event == null && @event.UserId != user.UserId)
                {
                    throw new InvalidOperationException("Event either does not exist or is in another user!");
                    //Warning: Event either does not exist or is in another user
                }
                else
                {
                    poDbContext.Events.Remove(@event);
                    poDbContext.SaveChanges();
                }
            }
        }

        /// <summary>Fetches the event by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public Event FetchEventById(int id, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Event @event = poDbContext.Events.Find(id);
                if (@event == null && @event.UserId != user.UserId)
                {
                    throw new InvalidOperationException("Event either does not exist or is in another user!");
                }
                else
                {
                    return @event;
                }
            }
        }

        /// <summary>Lists all events.</summary>
        /// <param name="user">The user.</param>
        public List<Event> ListAllEvents(User user)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Events.Where(r => r.UserId == user.UserId).ToList();
            }
        }

        /// <summary>Lists all events by date.</summary>
        /// <param name="date">The date.</param>
        /// <param name="user">The user.</param>
        public List<Event> ListAllEventsByDate(DateTime date, User user)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Events.Where(r => DbFunctions.TruncateTime(r.DueTime) == date.Date && r.UserId == user.UserId).ToList();
            }
        }

        /// <summary>Removes all events.</summary>
        /// <param name="user">The user.</param>
        public void RemoveAllEvents(User user)
        {
            using (poDbContext = new PODbContext())
            {
                foreach (var item in poDbContext.Events)
                {
                    if (item.UserId == user.UserId)
                    {
                        poDbContext.Events.Remove(item);
                    }
                }

                poDbContext.SaveChanges();
            }
        }
    }
}
