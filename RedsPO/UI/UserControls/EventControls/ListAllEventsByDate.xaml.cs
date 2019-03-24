using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static UI.UIProperties;

namespace UI.UserControls.EventControls
{
    /// <summary>
    /// Interaction logic for ListAllEventsByDate.xaml
    /// </summary>
    public partial class ListAllEventsByDate : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAllEventsByDate"/> class.
        /// </summary>
        public ListAllEventsByDate()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the SearchButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
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

        /// <summary>Loads the event ListView by date.</summary>
        /// <param name="date">The date.</param>
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
