using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static UI.UIProperties;

namespace UI.UserControls.TaskControls
{
    /// <summary>
    /// Interaction logic for RemoveTask.xaml
    /// </summary>
    public partial class RemoveTask : UserControl
    {
        /// <summary>Initializes a new instance of the <see cref="RemoveTask"/> class.</summary>
        public RemoveTask()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the RemoveButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TaskListBox.SelectedItem == null)
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");

                else
                {
                    //Gets the Task from the box
                    Task selectedTask = (Task)TaskListBox.SelectedItem;

                    //Gets the TaskId of the selected Task
                    int TaskId = selectedTask.TaskId;

                    //Removes the Task
                    taskBusiness.RemoveTask(TaskId, currentUser);

                    //Loads the new list box
                    LoadTaskListBox();

                    //Shows success info
                    ShowInfo("Task removed successfully!");
                }
            }
            catch(Exception exception)
            {
                //Shows the message of the current exception
                ShowError(exception.Message);
            }
        }

        /// <summary>
        /// Loads the task ListBox.
        /// </summary>
        public void LoadTaskListBox()
        {
            //Gets all user Tasks
            List<Task> Tasks = taskBusiness.ListAllTasks(currentUser);

            //Deletes current items
            TaskListBox.Items.Clear();

            //Adds Tasks to the List Box
            foreach (Task @Task in Tasks)
            {
                TaskListBox.Items.Add(@Task);
            }
        }
    }
}
