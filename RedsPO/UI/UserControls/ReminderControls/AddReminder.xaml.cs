using System;
using System.Windows;
using System.Windows.Controls;
using static UI.UIProperties;

namespace UI.UserControls.ReminderControls
{
    /// <summary>
    /// Interaction logic for AddReminder.xaml
    /// </summary>
    public partial class AddReminder : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddReminder"/> class.
        /// </summary>
        public AddReminder()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the SubmitButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(NameBox.Text) || string.IsNullOrEmpty(DatePicker.Text))
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");

                else
                {
                    //Creates new instance of reminder
                    Reminder @reminder = new Reminder
                    {
                        //Sets properties for the reminder
                        Name = NameBox.Text,
                        DueTime = DateTime.Parse(DatePicker.Text),
                        UserId = currentUser.UserId
                    };

                    //Adds the reminder
                    reminderBusiness.AddReminder(@reminder);

                    //Shows success info
                    ShowInfo("Reminder added successfully!");
                }
            }
            catch(Exception exception)
            {
                //Shows the message of the current exception
                ShowError(exception.Message);
            }
        }
    }
}
