using System;
using System.Windows;
using System.Windows.Controls;
using static UI.UIProperties;

namespace UI.UserControls.TaskControls
{
    /// <summary>
    /// Interaction logic for AddTask.xaml
    /// </summary>
    public partial class AddTask : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddTask"/> class.
        /// </summary>
        public AddTask()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click event of the SubmitButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(NameBox.Text) || string.IsNullOrEmpty(DatePicker.Text))
                    //Shows a message box with a warning
                    ShowWarning("All fields should be full!");

                else
                {
                    //Creates new instance of task
                    Task @task = new Task
                    {
                        //Sets properties for the task
                        Name = NameBox.Text,
                        Date = DateTime.Parse(DatePicker.Text),
                        IsDone = (bool)CompletedCheckBox.IsChecked,
                        UserId = currentUser.UserId
                    };

                    //Adds the task
                    taskBusiness.AddTask(@task);

                    //Shows success info
                    ShowInfo("Task added successfully!");
                }
            }
            catch(Exception exception)
            {
                //Shows the message of the current exception
                ShowError(exception.Message);
            }
        }
    }
}
