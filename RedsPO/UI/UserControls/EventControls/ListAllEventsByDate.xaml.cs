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
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class ListAllEventsByDate : UserControl
    {
        public ListAllEventsByDate()
        {
            InitializeComponent();
        }
        
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DatePicker.Text))
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");

                else
                {
                    //Loads the View
                    LoadEventListViewByDate(DateTime.Parse(DatePicker.Text));
                }
            }
            catch(Exception exception)
            {
                //Shows the message of the current exception
                ShowError(exception.Message);
            }
        }

        public void LoadEventListViewByDate(DateTime date)
        {
            //Gets all user events
            List<Event> events = eventBusiness.ListAllEventsByDate(date, currentUser);

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
