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
