using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using static UI.UIProperties;

namespace UI.UserControls.TaskControls
{
    /// <summary>
    /// Interaction logic for ModifyTask.xaml
    /// </summary>
    public partial class ModifyTask : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModifyTask"/> class.
        /// </summary>
        public ModifyTask()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the ModifyButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TaskListBox.SelectedItem == null || string.IsNullOrEmpty(NewNameBox.Text) || string.IsNullOrEmpty(NewDatePicker.Text))
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");

                else
                {
                    //Gets the Task from the box
                    Task selectedTask = (Task)TaskListBox.SelectedItem;

                    //Make changes to the Task
                    selectedTask.Name = NewNameBox.Text;
                    selectedTask.Date = DateTime.Parse(NewDatePicker.Text);
                    selectedTask.IsDone = (bool)CompletedCheckBox.IsChecked ? true : false;

                    //Modifies the Task
                    taskBusiness.ModifyTask(selectedTask, currentUser);

                    //Loads the new list box
                    LoadTaskListBox();

                    //Shows success info
                    ShowInfo("Task modified successfully!");
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
