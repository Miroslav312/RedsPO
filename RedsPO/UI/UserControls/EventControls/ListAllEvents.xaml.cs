using System.Collections.Generic;
using System.Windows.Controls;
using static UI.UIProperties;

namespace UI.UserControls.EventControls
{
    /// <summary>
    /// Interaction logic for ListAllEvents.xaml
    /// </summary>
    public partial class ListAllEvents : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAllEvents"/> class.
        /// </summary>
        public ListAllEvents()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the event ListView.
        /// </summary>
        public void LoadEventListView()
        {
            //Gets all user events
            List<Event> events = eventBusiness.ListAllEvents(currentUser);

            //Deletes current items
            EventListView.Items.Clear();

            //Adds events to the List View
            foreach (Event @event in events)
            {
                EventListView.Items.Add(@event);
            }
        }
    }
}
