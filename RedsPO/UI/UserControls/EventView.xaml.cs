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
using UI.UserControls.EventControls;

namespace UI.UserControls
{
    /// <summary>
    /// Interaction logic for EventUI.xaml
    /// </summary>
    public partial class EventView : UserControl
    {

        private AddEvent _addEvent = new AddEvent();
        private RemoveEvent _removeEvent = new RemoveEvent();
        private ModifyEvent _modifyEvent = new ModifyEvent();
        private ListAllEvents _listAllEvents = new ListAllEvents();
        private ListAllEventsByDate _listAllEventsByDate = new ListAllEventsByDate();

        public EventView()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!EventFunction.Children.Contains(_addEvent))
            {
                //Removes all elements
                EventFunction.Children.Clear();

                //Adds the user control
                EventFunction.Children.Add(_addEvent);
            }
        }

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
        }

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
        }

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
        }

        private void ListByDateButton_Click(object sender, RoutedEventArgs e)
        {

            if (!EventFunction.Children.Contains(_listAllEventsByDate))
            {
                //Removes all elements
                EventFunction.Children.Clear();

                //Adds the user control
                EventFunction.Children.Add(_listAllEventsByDate);

                //Loads the Event List View
                _listAllEvents.LoadEventListView();
            }
        }
    }
}
