using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static UI.UIProperties;

namespace UI.UserControls.EventControls
{
    /// <summary>
    /// Interaction logic for RemoveEvent.xaml
    /// </summary>
    public partial class RemoveEvent : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveEvent"/> class.
        /// </summary>
        public RemoveEvent()
        {
            InitializeComponent();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EventListBox.SelectedItem == null)
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");

                else
                {
                    //Gets the event from the box
                    Event selectedEvent = (Event)EventListBox.SelectedItem;

                    //Gets the eventId of the selected event
                    int eventId = selectedEvent.EventId;

                    //Removes the event
                    eventBusiness.RemoveEvent(eventId, currentUser);

                    //Loads the new list box
                    LoadEventListBox();

                    //Shows success info
                    ShowInfo("Event removed successfully!");
                }
            }
            catch(Exception exception)
            {
                //Shows the message of the current exception
                ShowError(exception.Message);
            }
        }

        public void LoadEventListBox()
        {
            //Gets all user events
            List<Event> events = eventBusiness.ListAllEvents(currentUser);

            //Deletes current items
            EventListBox.Items.Clear();

            //Adds events to the List Box
            foreach (Event @event in events)
            {
                EventListBox.Items.Add(@event);
            }
        }
    }
}
