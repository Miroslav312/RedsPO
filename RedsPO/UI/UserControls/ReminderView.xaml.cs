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
using UI.UserControls.ReminderControls;

namespace UI.UserControls
{
    /// <summary>
    /// Interaction logic for ReminderView.xaml
    /// </summary>
    public partial class ReminderView : UserControl
    {

        /// <summary>The add reminder</summary>
        private AddReminder _addReminder = new AddReminder();
        
        /// <summary>The remove reminder</summary>
        private RemoveReminder _removeReminder = new RemoveReminder();
        
        /// <summary>The modify reminder</summary>
        private ModifyReminder _modifyReminder = new ModifyReminder();
        
        /// <summary>The list all reminders</summary>
        private ListAllReminders _listAllReminders = new ListAllReminders();
        
        /// <summary>The list all reminders by date</summary>
        private ListAllRemindersByDate _listAllRemindersByDate = new ListAllRemindersByDate();

        /// <summary>
        /// Initializes a new instance of the <see cref="ReminderView"/> class.
        /// </summary>
        public ReminderView()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the AddButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ReminderFunction.Children.Contains(_addReminder))
            {
                //Removes all elements
                ReminderFunction.Children.Clear();

                //Adds the user control
                ReminderFunction.Children.Add(_addReminder);
            }
        }

        /// <summary>Handles the Click event of the RemoveButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ReminderFunction.Children.Contains(_removeReminder))
            {
                //Removes all elements
                ReminderFunction.Children.Clear();

                //Adds the user control
                ReminderFunction.Children.Add(_removeReminder);

                //Loads the Reminder List Box
                _removeReminder.LoadReminderListBox();
            }
        }

        /// <summary>Handles the Click event of the ModifyButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ReminderFunction.Children.Contains(_modifyReminder))
            {
                //Removes all elements
                ReminderFunction.Children.Clear();

                //Adds the user control
                ReminderFunction.Children.Add(_modifyReminder);

                //Loads the Reminder List Box
                _modifyReminder.LoadReminderListBox();
            }
        }

        /// <summary>Handles the Click event of the ListAllButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ListAllButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ReminderFunction.Children.Contains(_listAllReminders))
            {
                //Removes all elements
                ReminderFunction.Children.Clear();

                //Adds the user control
                ReminderFunction.Children.Add(_listAllReminders);

                //Loads the Reminder List View
                _listAllReminders.LoadReminderListView();
            }
        }

        /// <summary>Handles the Click event of the ListByDateButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ListByDateButton_Click(object sender, RoutedEventArgs e)
        {

            if (!ReminderFunction.Children.Contains(_listAllRemindersByDate))
            {
                //Removes all elements
                ReminderFunction.Children.Clear();

                //Adds the user control
                ReminderFunction.Children.Add(_listAllRemindersByDate);

                //Loads the Reminder List View
                _listAllReminders.LoadReminderListView();
            }
        }
    }
}
