using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static UI.UIProperties;

namespace UI.UserControls.TaskControls
{
    /// <summary>
    /// Interaction logic for ListAllTasksByCompletion.xaml
    /// </summary>
    public partial class ListAllTasksByCompletion : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAllTasksByCompletion"/> class.
        /// </summary>
        public ListAllTasksByCompletion()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the SearchButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Loads the View
                LoadTaskListViewByCompletion((bool)CompletedCheckBox.IsChecked);
            }
            catch(Exception exception)
            {
                //Shows the message of the current exception
                ShowError(exception.Message);
            }
        }

        /// <summary>Loads the task ListView by date.</summary>
        /// <param name="date">The date.</param>
        public void LoadTaskListViewByCompletion(bool completed)
        {
            //List with tasks
            List<Task> tasks = new List<Task>();

            if (completed)
            {
                //Gets all user task
                tasks = taskBusiness.ListAllCompletedTasks(currentUser);
            }
            else
            {
                //Gets all user task
                tasks = taskBusiness.ListAllUncompletedTasks(currentUser);
            }

            //Deletes current items
            TaskListView.Items.Clear();

            //Adds tasks to the List View
            foreach (Task @task in tasks)
            {
                TaskListView.Items.Add(@task);
            }
        }
    }
}
