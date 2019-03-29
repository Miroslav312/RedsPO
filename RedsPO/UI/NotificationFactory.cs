using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static UI.UIProperties;

namespace UI
{
    class NotificationFactory
    {
        private const int timeInterval = 43200000;

        public Timer EventTimer = new Timer(timerCallback, null, 0, timeInterval);
        
        
        public void EventNotification()
        {
            List<Event> dailyEvents = eventBusiness.ListAllEventsByDate(DateTime.Now, currentUser);
        }
    }
}
