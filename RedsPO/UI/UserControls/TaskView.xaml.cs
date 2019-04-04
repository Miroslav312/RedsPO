using System.Windows;
using System.Windows.Controls;
using UI.UserControls.TaskControls;
using static UI.UIProperties;

namespace UI.UserControls
{
    /// <summary>
    /// Interaction logic for TaskView.xaml
    /// </summary>
    public partial class TaskView : UserControl
    {

        /// <summary>The add task</summary>
        private AddTask _addTask = new AddTask();
        
        /// <summary>The remove task</summary>
        private RemoveTask _removeTask = new RemoveTask();
        
        /// <summary>The modify task</summary>
        private ModifyTask _modifyTask = new ModifyTask();
        
        /// <summary>The list all tasks</summary>
        private ListAllTasks _listAllTasks = new ListAllTasks();

        /// <summary>The list all tasks by date</summary>
        private ListAllTasksByDate _listAllTasksByDate = new ListAllTasksByDate();

        /// <summary>The list all tasks by completion</summary>
        private ListAllTasksByCompletion _listAllTasksByCompletion = new ListAllTasksByCompletion();

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskView"/> class.
        /// </summary>
        public TaskView()
        {
            InitializeComponent();
        }

        /// <summary>Handles the Click task of the AddButton control.</summary>
        /// <param name="sender">The source of the task.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the task data.</param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TaskFunction.Children.Contains(_addTask))
            {
                //Removes all elements
                TaskFunction.Children.Clear();

                //Adds the user control
                TaskFunction.Children.Add(_addTask);
            }

            //Sets the button toggle
            SetCurrentButtonToggle(AddButton);
        }

        /// <summary>Handles the Click task of the RemoveButton control.</summary>
        /// <param name="sender">The source of the task.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the task data.</param>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TaskFunction.Children.Contains(_removeTask))
            {
                //Removes all elements
                TaskFunction.Children.Clear();

                //Adds the user control
                TaskFunction.Children.Add(_removeTask);

                //Loads the Task List Box
                _removeTask.LoadTaskListBox();
            }

            //Sets the button toggle
            SetCurrentButtonToggle(RemoveButton);
        }

        /// <summary>Handles the Click task of the ModifyButton control.</summary>
        /// <param name="sender">The source of the task.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the task data.</param>
        private void ModifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TaskFunction.Children.Contains(_modifyTask))
            {
                //Removes all elements
                TaskFunction.Children.Clear();

                //Adds the user control
                TaskFunction.Children.Add(_modifyTask);

                //Loads the Task List Box
                _modifyTask.LoadTaskListBox();
            }

            //Sets the button toggle
            SetCurrentButtonToggle(ModifyButton);
        }

        /// <summary>Handles the Click task of the ListAllButton control.</summary>
        /// <param name="sender">The source of the task.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the task data.</param>
        private void ListAllButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TaskFunction.Children.Contains(_listAllTasks))
            {
                //Removes all elements
                TaskFunction.Children.Clear();

                //Adds the user control
                TaskFunction.Children.Add(_listAllTasks);

                //Loads the Task List View
                _listAllTasks.LoadTaskListView();
            }

            //Sets the button toggle
            SetCurrentButtonToggle(ListAllButton);
        }

        /// <summary>Handles the Click task of the ListByDateButton control.</summary>
        /// <param name="sender">The source of the task.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the task data.</param>
        private void ListByDateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!TaskFunction.Children.Contains(_listAllTasksByDate))
            {
                //Removes all elements
                TaskFunction.Children.Clear();

                //Adds the user control
                TaskFunction.Children.Add(_listAllTasksByDate);
            }

            //Sets the button toggle
            SetCurrentButtonToggle(ListByDateButton);
        }

        /// <summary>Handles the Click event of the ListByCompletionButton control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ListByCompletionButton_Click(object sender, RoutedEventArgs e)
        {
            //Loads the ListView
            _listAllTasksByCompletion.LoadTaskListViewByCompletion((bool)_listAllTasksByCompletion.CompletedCheckBox.IsChecked);

            if (!TaskFunction.Children.Contains(_listAllTasksByCompletion))
            {
                //Removes all elements
                TaskFunction.Children.Clear();

                //Adds the user control
                TaskFunction.Children.Add(_listAllTasksByCompletion);
            }

            //Sets the button toggle
            SetCurrentButtonToggle(ListByCompletionButton);
        }

        /// <summary>Sets the current button toggle.</summary>
        /// <param name="currentButton">The current button.</param>
        private void SetCurrentButtonToggle(Button currentButton)
        {
            string buttonName = currentButton.Name;

            switch (buttonName)
            {
                case "AddButton":
                    SetButtonToggle(AddButton);

                    RemoveButtonToggle(ListByCompletionButton);
                    RemoveButtonToggle(RemoveButton);
                    RemoveButtonToggle(ModifyButton);
                    RemoveButtonToggle(ListAllButton);
                    RemoveButtonToggle(ListByDateButton);
                    break;
                case "RemoveButton":
                    SetButtonToggle(RemoveButton);

                    RemoveButtonToggle(ListByCompletionButton);
                    RemoveButtonToggle(AddButton);
                    RemoveButtonToggle(ModifyButton);
                    RemoveButtonToggle(ListAllButton);
                    RemoveButtonToggle(ListByDateButton);
                    break;
                case "ModifyButton":
                    SetButtonToggle(ModifyButton);

                    RemoveButtonToggle(ListByCompletionButton);
                    RemoveButtonToggle(RemoveButton);
                    RemoveButtonToggle(AddButton);
                    RemoveButtonToggle(ListAllButton);
                    RemoveButtonToggle(ListByDateButton);
                    break;
                case "ListAllButton":
                    SetButtonToggle(ListAllButton);

                    RemoveButtonToggle(ListByCompletionButton);
                    RemoveButtonToggle(RemoveButton);
                    RemoveButtonToggle(ModifyButton);
                    RemoveButtonToggle(AddButton);
                    RemoveButtonToggle(ListByDateButton);
                    break;
                case "ListByDateButton":
                    SetButtonToggle(ListByDateButton);

                    RemoveButtonToggle(ListByCompletionButton);
                    RemoveButtonToggle(RemoveButton);
                    RemoveButtonToggle(ModifyButton);
                    RemoveButtonToggle(ListAllButton);
                    RemoveButtonToggle(AddButton);
                    break;
                case "ListByCompletionButton":
                    SetButtonToggle(ListByCompletionButton);

                    RemoveButtonToggle(ListByDateButton);
                    RemoveButtonToggle(RemoveButton);
                    RemoveButtonToggle(ModifyButton);
                    RemoveButtonToggle(ListAllButton);
                    RemoveButtonToggle(AddButton);
                    break;
            }
        }
    }
}
