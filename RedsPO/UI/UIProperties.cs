using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Business;
using UI.UserControls;

namespace UI
{
    static class UIProperties
    {
        static public User currentUser;

        static public UserBusiness userBusiness = new UserBusiness(new PODbContext());
        static public EventBusiness eventBusiness = new EventBusiness(new PODbContext());
        static public TaskBusiness taskBusiness = new TaskBusiness(new PODbContext());
        static public ReminderBusiness reminderBusiness = new ReminderBusiness(new PODbContext());

        static public EventView eventView = new EventView();

        public static void ShowError(string errorMessage)
        {
            //Shows a message box with a warning
            MessageBox.Show(errorMessage, "Critical Error", MessageBoxButton.OK);

            //Shuts down the Application
            Application.Current.Shutdown();
        }

        public static void ShowWarning(string warningMessage)
        {
            //Shows a message box with a warning
            MessageBox.Show(warningMessage, "Warning", MessageBoxButton.OK);
        }

        public static void ShowInfo(string warningMessage)
        {
            //Shows a message box with info
            MessageBox.Show(warningMessage, "Info", MessageBoxButton.OK);
        }
    }
}
