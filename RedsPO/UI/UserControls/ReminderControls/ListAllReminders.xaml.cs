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
    /// Interaction logic for ListAllReminders.xaml
    /// </summary>
    public partial class ListAllReminders : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAllReminders"/> class.
        /// </summary>
        public ListAllReminders()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the reminder ListView.
        /// </summary>
        public void LoadReminderListView()
        {
            //Gets all user Reminders
            List<Reminder> Reminders = reminderBusiness.ListAllReminders(currentUser);

            //Deletes current items
            ReminderListView.Items.Clear();

            //Adds Reminders to the List View
            foreach (Reminder @Reminder in Reminders)
            {
                ReminderListView.Items.Add(@Reminder);
            }
        }
    }
}
