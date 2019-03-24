using System;
using System.Windows;
using System.Windows.Controls;
using static UI.UIProperties;

namespace UI.UserControls.EventControls
{
    /// <summary>
    /// Interaction logic for AddEvent.xaml
    /// </summary>
    public partial class AddEvent : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddEvent"/> class.
        /// </summary>
        public AddEvent()
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
                    //Creates new instance of event
                    Event @event = new Event
                    {
                        //Sets properties for the event
                        Name = NameBox.Text,
                        DueTime = DateTime.Parse(DatePicker.Text),
                        UserId = currentUser.UserId
                    };

                    //Adds the event
                    eventBusiness.AddEvent(@event);

                    //Shows success info
                    ShowInfo("Event added successfully!");
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
