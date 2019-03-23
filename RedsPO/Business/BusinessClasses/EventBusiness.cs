using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Business
{
    public class EventBusiness
    {
        private PODbContext _poDbContext;

        public PODbContext GetPODbContext => _poDbContext;

        public EventBusiness(PODbContext poDbContext)
        {
            _poDbContext = poDbContext;
        }

        /// <summary>Adds the event.</summary>
        /// <param name="userEvent">The user event.</param>
        public void AddEvent(Event userEvent)
        {
            if (userEvent == null)
                throw new InvalidOperationException("Event should not be null!");

            _poDbContext.Events.Add(userEvent);
            _poDbContext.SaveChanges();
        }

        /// <summary>Modifies the event.</summary>
        /// <param name="userEvent">The user event.</param>
        /// <param name="user">The user.</param>
        public void ModifyEvent(Event userEvent, User user)
        {
            Event @event = _poDbContext.Events.Find(userEvent.EventId);
            if (@event == null && @event.UserId != user.UserId)
            {
                throw new InvalidOperationException("Event either does not exist or is in another user!");
                //Warning: Event either does not exist or is in another user
            }
            else
            {
                _poDbContext.Entry(@event).CurrentValues.SetValues(userEvent);
                _poDbContext.SaveChanges();
            }
        }

        /// <summary>Removes the event.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public void RemoveEvent(int id, User user)
        {
            Event @event = _poDbContext.Events.Find(id);
            if (@event == null && @event.UserId != user.UserId)
            {
                throw new InvalidOperationException("Event either does not exist or is in another user!");
                //Warning: Event either does not exist or is in another user
            }
            else
            {
                _poDbContext.Events.Remove(@event);
                _poDbContext.SaveChanges();
            }
        }

        /// <summary>Fetches the event by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public Event FetchEventById(int id, User user)
        {
            Event @event = _poDbContext.Events.Find(id);
            if (@event == null && @event.UserId != user.UserId)
            {
                throw new InvalidOperationException("Event either does not exist or is in another user!");
                //Warning: Event either does not exist or is in another user
            }
            else
            {
                return @event;
            }
        }

        /// <summary>Lists all events.</summary>
        /// <param name="user">The user.</param>
        public List<Event> ListAllEvents(User user)
        {
            return _poDbContext.Events.Where(r => r.UserId == user.UserId).ToList();
        }

        /// <summary>Lists all events by date.</summary>
        /// <param name="date">The date.</param>
        /// <param name="user">The user.</param>
        public List<Event> ListAllEventsByDate(DateTime date, User user)
        {
            return _poDbContext.Events.Where(r => DbFunctions.TruncateTime(r.DueTime) == date.Date && r.UserId == user.UserId).ToList();
        }

        /// <summary>Removes all events.</summary>
        /// <param name="user">The user.</param>
        public void RemoveAllEvents(User user)
        {
            _poDbContext.Events.RemoveRange(_poDbContext.Events.Where(x => x.UserId == user.UserId));
            _poDbContext.SaveChanges();
        }
    }
}
