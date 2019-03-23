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
    /// Interaction logic for ModifyReminder.xaml
    /// </summary>
    public partial class ModifyReminder : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyReminder"/> class.
        /// </summary>
        public ModifyReminder()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the ModifyButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ReminderListBox.SelectedItem == null || string.IsNullOrEmpty(NewNameBox.Text) || string.IsNullOrEmpty(NewDatePicker.Text))
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");

                else
                {
                    //Gets the Reminder from the box
                    Reminder selectedReminder = (Reminder)ReminderListBox.SelectedItem;

                    //Make changes to the Reminder
                    selectedReminder.Name = NewNameBox.Text;
                    selectedReminder.DueTime = DateTime.Parse(NewDatePicker.Text);

                    //Modifies the Reminder
                    reminderBusiness.ModifyReminder(selectedReminder, currentUser);

                    //Loads the new list box
                    LoadReminderListBox();

                    //Shows success info
                    ShowInfo("Reminder modified successfully!");
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
