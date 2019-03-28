using System.Windows;
using System.Windows.Controls;
using UI.UserControls.ReminderControls;
using static UI.UIProperties;

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

            //Sets the button toggle
            SetCurrentButtonToggle(AddButton);
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

            //Sets the button toggle
            SetCurrentButtonToggle(RemoveButton);
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

            //Sets the button toggle
            SetCurrentButtonToggle(ModifyButton);
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

            //Sets the button toggle
            SetCurrentButtonToggle(ListAllButton);
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
