using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static UI.UIProperties;

namespace UI.UserControls.TaskControls
{
    /// <summary>
    /// Interaction logic for ListAllTasksByDate.xaml
    /// </summary>
    public partial class ListAllTasksByDate : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAllTasksByDate"/> class.
        /// </summary>
        public ListAllTasksByDate()
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
                if (string.IsNullOrEmpty(DatePicker.Text))
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");

                else
                {
                    //Loads the View
                    LoadTaskListViewByDate(DateTime.Parse(DatePicker.Text));
                }
            }
            catch(Exception exception)
            {
                //Shows the message of the current exception
                ShowError(exception.Message);
            }
        }

        /// <summary>Loads the task ListView by date.</summary>
        /// <param name="date">The date.</param>
        public void LoadTaskListViewByDate(DateTime date)
        {
            //Gets all user task
            List<Task> tasks = taskBusiness.ListAllTasksByDate(date, currentUser);

            //Deletes current items
            TaskListView.Items.Clear();

            if (tasks.Count == 0)
            {
                //Shows NoItemsBox
                NoItemsBox.Visibility = Visibility.Visible;
            }
            else
            {
                //Hides NoItemsBox
                NoItemsBox.Visibility = Visibility.Collapsed;

                //Adds tasks to the List View
                foreach (Task @task in tasks)
                {
                    TaskListView.Items.Add(@task);
                }
            }
        }
    }
}
