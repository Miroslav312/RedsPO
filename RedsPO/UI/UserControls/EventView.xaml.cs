using System.Windows;
using System.Windows.Controls;
using UI.UserControls.EventControls;
using static UI.UIProperties;

namespace UI.UserControls
{
    /// <summary>
    /// Interaction logic for EventView.xaml
    /// </summary>
    public partial class EventView : UserControl
    {

        /// <summary>The add event</summary>
        private AddEvent _addEvent = new AddEvent();
        
        /// <summary>The remove event</summary>
        private RemoveEvent _removeEvent = new RemoveEvent();
        
        /// <summary>The modify event</summary>
        private ModifyEvent _modifyEvent = new ModifyEvent();
        
        /// <summary>The list all events</summary>
        private ListAllEvents _listAllEvents = new ListAllEvents();

        /// <summary>The list all events by date</summary>
        private ListAllEventsByDate _listAllEventsByDate = new ListAllEventsByDate();

        /// <summary>
        /// Initializes a new instance of the <see cref="EventView"/> class.
        /// </summary>
        public EventView()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the AddButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!EventFunction.Children.Contains(_addEvent))
            {
                //Removes all elements
                EventFunction.Children.Clear();

                //Adds the user control
                EventFunction.Children.Add(_addEvent);
            }

            //Sets the button toggle
            SetCurrentButtonToggle(AddButton);
        }

        /// <summary>Handles the Click event of the RemoveButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!EventFunction.Children.Contains(_removeEvent))
            {
                //Removes all elements
                EventFunction.Children.Clear();

                //Adds the user control
                EventFunction.Children.Add(_removeEvent);

                //Loads the Event List Box
                _removeEvent.LoadEventListBox();
            }

            //Sets the button toggle
            SetCurrentButtonToggle(RemoveButton);
        }

        /// <summary>Handles the Click event of the ModifyButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!EventFunction.Children.Contains(_modifyEvent))
            {
                //Removes all elements
                EventFunction.Children.Clear();

                //Adds the user control
                EventFunction.Children.Add(_modifyEvent);

                //Loads the Event List Box
                _modifyEvent.LoadEventListBox();
            }

            //Sets the button toggle
            SetCurrentButtonToggle(ModifyButton);
        }

        /// <summary>Handles the Click event of the ListAllButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ListAllButton_Click(object sender, RoutedEventArgs e)
        {
            if (!EventFunction.Children.Contains(_listAllEvents))
            {
                //Removes all elements
                EventFunction.Children.Clear();

                //Adds the user control
                EventFunction.Children.Add(_listAllEvents);

                //Loads the Event List View
                _listAllEvents.LoadEventListView();
            }

            //Sets the button toggle
            SetCurrentButtonToggle(ListAllButton);
        }

        /// <summary>Handles the Click event of the ListByDateButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ListByDateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!EventFunction.Children.Contains(_listAllEventsByDate))
            {
                //Removes all elements
                EventFunction.Children.Clear();

                //Adds the user control
                EventFunction.Children.Add(_listAllEventsByDate);
            }

            //Sets the button toggle
            SetCurrentButtonToggle(ListByDateButton);
        }

        /// <summary>Sets the current button toggle.</summary>
        /// <param name="currentButton">The current button.</param>
        private void SetCurrentButtonToggle(Button currentButton)
        {
            string buttonName = currentButton.Name;

            switch (buttonName)
            {
                case "AddButton":
                    SetButtonToggle(AddButton);

                    RemoveButtonToggle(RemoveButton);
                    RemoveButtonToggle(ModifyButton);
                    RemoveButtonToggle(ListAllButton);
                    RemoveButtonToggle(ListByDateButton);
                    break;
                case "RemoveButton":
                    SetButtonToggle(RemoveButton);

                    RemoveButtonToggle(AddButton);
                    RemoveButtonToggle(ModifyButton);
                    RemoveButtonToggle(ListAllButton);
                    RemoveButtonToggle(ListByDateButton);
                    break;
                case "ModifyButton":
                    SetButtonToggle(ModifyButton);

                    RemoveButtonToggle(RemoveButton);
                    RemoveButtonToggle(AddButton);
                    RemoveButtonToggle(ListAllButton);
                    RemoveButtonToggle(ListByDateButton);
                    break;
                case "ListAllButton":
                    SetButtonToggle(ListAllButton);

                    RemoveButtonToggle(RemoveButton);
                    RemoveButtonToggle(ModifyButton);
                    RemoveButtonToggle(AddButton);
                    RemoveButtonToggle(ListByDateButton);
                    break;
                case "ListByDateButton":
                    SetButtonToggle(ListByDateButton);

                    RemoveButtonToggle(RemoveButton);
                    RemoveButtonToggle(ModifyButton);
                    RemoveButtonToggle(ListAllButton);
                    RemoveButtonToggle(AddButton);
                    break;
            }
        }
    }
}
