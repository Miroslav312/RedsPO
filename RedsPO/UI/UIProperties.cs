using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Business;
using UI.UserControls;

namespace UI
{
    static class UIProperties
    {
        public static User currentUser;

        public static UserBusiness userBusiness = new UserBusiness(new PODbContext());
        public static EventBusiness eventBusiness = new EventBusiness(new PODbContext());
        public static TaskBusiness taskBusiness = new TaskBusiness(new PODbContext());
        public static ReminderBusiness reminderBusiness = new ReminderBusiness(new PODbContext());

        public static EventView eventView = new EventView();
        public static ReminderView reminderView = new ReminderView();

        /// <summary>Shows the error.</summary>
        /// <param name="errorMessage">The error message.</param>
        public static void ShowError(string errorMessage)
        {
            //Shows a message box with a warning
            MessageBox.Show(errorMessage, "Critical Error", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.OK);

            //Shuts down the Application
            Application.Current.Shutdown();
        }

        /// <summary>Shows the warning.</summary>
        /// <param name="warningMessage">The warning message.</param>
        public static void ShowWarning(string warningMessage)
        {
            //Shows a message box with a warning
            MessageBox.Show(warningMessage, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
        }

        /// <summary>Shows the information.</summary>
        /// <param name="warningMessage">The warning message.</param>
        public static void ShowInfo(string warningMessage)
        {
            //Shows a message box with info
            MessageBox.Show(warningMessage, "Info", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }

        /// <summary>Sets the button toggle.</summary>
        /// <param name="button">The button.</param>
        public static void SetButtonToggle(Button button)
        {
            button.BorderBrush = new SolidColorBrush(Color.FromRgb(255, 255, 255));
        }

        /// <summary>Removes the button toggle.</summary>
        /// <param name="button">The button.</param>
        public static void RemoveButtonToggle(Button button)
        {
            button.BorderBrush = null;
        }
    }
}
