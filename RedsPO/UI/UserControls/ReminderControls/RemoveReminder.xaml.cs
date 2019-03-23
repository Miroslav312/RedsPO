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

namespace UI.UserControls.ReminderControls
{
    /// <summary>
    /// Interaction logic for RemoveReminder.xaml
    /// </summary>
    public partial class RemoveReminder : UserControl
    {
        /// <summary>Initializes a new instance of the <see cref="RemoveReminder"/> class.</summary>
        public RemoveReminder()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the RemoveButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ReminderListBox.SelectedItem == null)
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");

                else
                {
                    //Gets the Reminder from the box
                    Reminder selectedReminder = (Reminder)ReminderListBox.SelectedItem;

                    //Gets the ReminderId of the selected Reminder
                    int ReminderId = selectedReminder.ReminderId;

                    //Removes the Reminder
                    reminderBusiness.DeleteReminder(ReminderId, currentUser);

                    //Loads the new list box
                    LoadReminderListBox();

                    //Shows success info
                    ShowInfo("Reminder removed successfully!");
                }
            }
            catch(Exception exception)
            {
                //Shows the message of the current exception
                ShowError(exception.Message);
            }
        }

        /// <summary>
        /// Loads the reminder ListBox.
        /// </summary>
        public void LoadReminderListBox()
        {
            //Gets all user Reminders
            List<Reminder> Reminders = reminderBusiness.ListAllReminders(currentUser);

            //Deletes current items
            ReminderListBox.Items.Clear();

            //Adds Reminders to the List Box
            foreach (Reminder @Reminder in Reminders)
            {
                ReminderListBox.Items.Add(@Reminder);
            }
        }
    }
}
