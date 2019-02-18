using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    class EventBusiness
    {
        private PODbContext poDbContext;

        public void AddEvent(Event userEvent)
        {
            using (poDbContext = new PODbContext())
            {
                poDbContext.Events.Add(userEvent);
            }
        }

        public void ModifyEvent(Event userEvent, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Event @event = poDbContext.Events.Find(userEvent.EventId);
                if (@event == null && @event.UserId != user.UserId)
                {
                    //Warning: Event either does not exist or is in another user
                }
                else
                {

                    poDbContext.Entry(@event).CurrentValues.SetValues(userEvent);
                    poDbContext.SaveChanges();
                }
            }
        }

        public void DeleteEvent(int id, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Event @event = poDbContext.Events.Find(id);
                if (@event == null && @event.UserId != user.UserId)
                {
                    //Warning: Event either does not exist or is in another user
                }
                else
                {
                    poDbContext.Events.Remove(@event);
                    poDbContext.SaveChanges();
                }
            }
        }

        public void CompleteEvent(int id, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Event @event = poDbContext.Events.Find(id);
                if (@event == null && @event.UserId != user.UserId)
                {
                    //Warning: Event either does not exist or is in another user
                }
                else
                {
                    @event.IsDone = true;
                    poDbContext.SaveChanges();
                }
            }
        }

        public Event FetchEvent(int id, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Event @event = poDbContext.Events.Find(id);
                if (@event == null && @event.UserId != user.UserId)
                {
                    return null;
                }
                else
                {
                    return @event;
                }
            }
        }

        public List<Event> ListAllEvents(User user)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Events.Where(r => r.UserId == user.UserId).ToList();
            }
        }


        public List<Event> ListAllCompletedEvents(User user)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Events.Where(r => r.IsDone == true && r.UserId == user.UserId).ToList();
            }
        }

        public List<Event> ListAllUncompletedEvents(User user)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Events.Where(r => r.IsDone == false && r.UserId == user.UserId).ToList();
            }
        }

        public void RemoveAllCompletedEvents(User user)
        {
            using (poDbContext = new PODbContext())
            {
                foreach (var item in poDbContext.Events)
                {
                    if (item.IsDone == true && item.UserId == user.UserId)
                    {
                        poDbContext.Events.Remove(item);
                    }
                }
            }
        }

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
            }
        }
    }
}
