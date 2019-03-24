using System.Collections.Generic;
using System.Windows.Controls;
using static UI.UIProperties;

namespace UI.UserControls.TaskControls
{
    /// <summary>
    /// Interaction logic for ListAllTasks.xaml
    /// </summary>
    public partial class ListAllTasks : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAllTasks"/> class.
        /// </summary>
        public ListAllTasks()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the task ListView.
        /// </summary>
        public void LoadTaskListView()
        {
            //Gets all user Tasks
            List<Task> tasks = taskBusiness.ListAllTasks(currentUser);

            //Deletes current items
            TaskListView.Items.Clear();

            //Adds Tasks to the List View
            foreach (Task @task in tasks)
            {
                TaskListView.Items.Add(@task);
            }
        }
    }
}
