using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static UI.UIProperties;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>Handles the MouseLeftButtonDown event of the Grid control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="MouseButtonEventArgs"/> instance containing the event data.</param>
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        /// <summary>Handles the Click event of the CloseButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //Shuts down the Application
            Application.Current.Shutdown();
        }

        /// <summary>Handles the Click event of the EventButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void EventButton_Click(object sender, RoutedEventArgs e)
        {
            if (!MainBody.Children.Contains(eventView))
            {
                //Removes all elements
                MainBody.Children.Clear();

                //Adds the user control
                MainBody.Children.Add(eventView);
            }

            //Sets the button toggle
            SetCurrentButtonToggle(EventButton);
        }

        /// <summary>Handles the Click event of the ReminderButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ReminderButton_Click(object sender, RoutedEventArgs e)
        {
            if (!MainBody.Children.Contains(reminderView))
            {
                //Removes all elements
                MainBody.Children.Clear();

                //Adds the user control
                MainBody.Children.Add(reminderView);
            }

            //Sets the button toggle
            SetCurrentButtonToggle(ReminderButton);
        }

        /// <summary>Handles the Click event of the TaskButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void TaskButton_Click(object sender, RoutedEventArgs e)
        {
            if (!MainBody.Children.Contains(taskView))
            {
                //Removes all elements
                MainBody.Children.Clear();

                //Adds the user control
                MainBody.Children.Add(taskView);
            }

            //Sets the button toggle
            SetCurrentButtonToggle(TaskButton);
        }

        /// <summary>Sets the current button toggle.</summary>
        /// <param name="currentButton">The current button.</param>
        private void SetCurrentButtonToggle(Button currentButton)
        {
            string buttonName = currentButton.Name;

            switch (buttonName)
            {
                case "EventButton":
                    SetButtonToggle(EventButton);

                    RemoveButtonToggle(ReminderButton);
                    RemoveButtonToggle(TaskButton);
                    break;
                case "ReminderButton":
                    SetButtonToggle(ReminderButton);

                    RemoveButtonToggle(EventButton);
                    RemoveButtonToggle(TaskButton);
                    break;
                case "TaskButton":
                    SetButtonToggle(TaskButton);

                    RemoveButtonToggle(EventButton);
                    RemoveButtonToggle(ReminderButton);
                    break;
            }
        }
    }
}
