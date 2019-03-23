using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static UI.UIProperties;

namespace UI.UserControls.EventControls
{
    /// <summary>
    /// Interaction logic for RemoveEvent.xaml
    /// </summary>
    public partial class ModifyEvent : UserControl
    {
        public ModifyEvent()
        {
            InitializeComponent();
        }

        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (EventListBox.SelectedItem == null || string.IsNullOrEmpty(NewNameBox.Text) || string.IsNullOrEmpty(NewDatePicker.Text))
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");
                else
                {
                    //Gets the event from the box
                    Event selectedEvent = (Event)EventListBox.SelectedItem;

                    //Make changes to the event
                    selectedEvent.Name = NewNameBox.Text;
                    selectedEvent.DueTime = DateTime.Parse(NewDatePicker.Text);

                    //Modifies the event
                    eventBusiness.ModifyEvent(selectedEvent, currentUser);

                    //Loads the new list box
                    LoadEventListBox();

                    //Shows success info
                    ShowInfo("Event modified successfully!");
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
