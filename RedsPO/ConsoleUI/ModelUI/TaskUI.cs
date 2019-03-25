using System;
using System.Collections.Generic;
using System.Globalization;
using static System.Console;
using static UI.ConsoleUI;

namespace UI
{
    class TaskUI
    {
        /// <summary>
        /// Shows the Task menu.
        /// </summary>
        public static void ShowTaskMenu()
        {
            if (CurrentUser == null) throw new InvalidOperationException("Not logged into an Account!");

            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            WriteLine(new string('-', 40));

            WriteLine(" 1. Add a task");
            WriteLine(" 2. Modify a task");
            WriteLine(" 3. Delete a task");
            WriteLine(" 4. Complete a task");
            WriteLine(" 5. List all tasks");
            WriteLine(" 6. Fetch a task");
            WriteLine(" 7. List all tasks on a certain date");
            WriteLine(" 8. List all completed tasks");
            WriteLine(" 9. List all uncompleted tasks");
            WriteLine(" 10. Remove all completed tasks");
            WriteLine(" 11. Remove all tasks");
            WriteLine(" 12. Exit the program");

            WriteLine(new string('-', 40));
        }


        /// <summary>
        /// Gets the input from the User.
        /// </summary>
        public static void TakeTaskInput()
        {
            if (CurrentUser == null)
                //Shows the start menu
                StartMenu();

            try
            {
                while (true)
                {
                    //Gets the command input
                    int command = int.Parse(ReadLine());
                    switch (command)
                    {
                        case 1:
                            AddTask();
                            break;

                        case 2:
                            ModifyTask();
                            break;

                        case 3:
                            DeleteTask();
                            break;

                        case 4:
                            MarkTaskAsDone();
                            break;

                        case 5:
                            ListAllTasks();
                            break;

                        case 6:
                            FetchTask();
                            break;

                        case 7:
                            ListAllTasksByDate();
                            break;

                        case 8:
                            ListAllCompletedTasks();
                            break;

                        case 9:
                            ListAllUncompletedTasks();
                            break;

                        case 10:
                            RemoveAllCompletedTasks();
                            break;

                        case 11:
                            RemoveAllTasks();
                            break;

                        case 12:
                            ExitProgram();
                            break;

                        default:
                            throw new InvalidOperationException("Invalid command!");
                    }
                }
            }
            catch (Exception currentException)
            {
                //Shows the current exception message
                WriteLine("An unexpected ERROR occured! Please try again later.");
                WriteLine($"[{currentException.Message}]");
                MenuOrExit();
            }
        }

        /// <summary>
        /// Adds the task.
        /// </summary>
        public static void AddTask()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 15) + "ADD TASK" + new string(' ', 16));
            WriteLine(new string('-', 40));

            //Makes an empty task
            Task @task = new Task();

            //Gets the task data
            WriteLine("Enter task title: ");
            @task.Name = ReadLine();

            WriteLine("Enter task date (e.g 26/02/2009): ");
            @task.Date = DateTime.ParseExact(ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            @task.UserId = CurrentUser.UserId;

            TBusiness.AddTask(@task);
            WriteLine("Task successfully added");

            MenuOrExit();
        }

        /// <summary>
        /// Modifies a task by its ID.
        /// </summary>
        public static void ModifyTask()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 17) + "MODIFY" + new string(' ', 17));
            WriteLine(new string('-', 40));

            //Gets the task id
            WriteLine("Enter task id: ");
            int id = int.Parse(ReadLine());
            
            //Gets the task
            Task @task = TBusiness.FetchTaskById(id, CurrentUser);
            
            //Gets the task data
            WriteLine("Enter new title: ");
            @task.Name = ReadLine();

            WriteLine("Enter new date (e.g : 26/02/2009): ");
            @task.Date = DateTime.ParseExact(ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            TBusiness.ModifyTask(@task, CurrentUser);
            WriteLine("Task successfully Modified");

            MenuOrExit();
        }

        /// <summary>
        /// Deletes a task by its ID.
        /// </summary>
        public static void DeleteTask()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 17) + "DELETE" + new string(' ', 17));
            WriteLine(new string('-', 40));

            //Gets the task id
            WriteLine("Enter task id: ");
            int id = int.Parse(ReadLine());

            TBusiness.RemoveTask(id, CurrentUser);
            WriteLine("Task successfully deleted");

            MenuOrExit();
        }

        /// <summary>
        /// Marks a task by its ID as done.
        /// </summary>
        public static void MarkTaskAsDone()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 11) + "MARK TASK AS DONE" + new string(' ', 11));
            WriteLine(new string('-', 40));

            //Gets the task id
            WriteLine("Enter task id: ");
            int id = int.Parse(ReadLine());

            //Gets the task
            Task @task = TBusiness.FetchTaskById(id, CurrentUser);

            if (@task == null || @task.IsDone == true)
            {
                WriteLine("Task is already completed or does not exist");
            }
            else
            {
                TBusiness.CompleteTask(id, CurrentUser);
                WriteLine("Task successfully completed");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Fetches a task.
        /// </summary>
        public static void FetchTask()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 14) + "FETCH TASK" + new string(' ', 15));
            WriteLine(new string('-', 40));

            //Gets the task id
            WriteLine("Enter task id: ");
            int id = int.Parse(ReadLine());

            //Gets the task
            Task @task = TBusiness.FetchTaskById(id, CurrentUser);
            if (@task == null)
            {
                WriteLine($"There is no task with id {id}");
            }
            else
            {
                WriteLine($"Listing the task with the id {id}...");
                WriteLine($"{@task.TaskId} {@task.Name} {@task.Date.ToString("d")} {(@task.IsDone ? "DONE" : "NOT DONE")}");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all tasks.
        /// </summary>
        public static void ListAllTasks()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 12) + "LIST ALL TASKS" + new string(' ', 13));
            WriteLine(new string('-', 40));

            //Gets all user tasks and lists them
            List<Task> tasks = TBusiness.ListAllTasks(CurrentUser);
            if (tasks.Count > 0)
            {
                foreach (Task @task in tasks)
                {
                    WriteLine($"{@task.TaskId} {@task.Name} {@task.Date.ToString("d")} {(@task.IsDone ? "DONE" : "NOT DONE")}");
                }
            }
            else
            {
                WriteLine("No tasks found!");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all tasks on a certain Date.
        /// </summary>
        public static void ListAllTasksByDate()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 13) + "TASKS BY DATE" + new string(' ', 13));
            WriteLine(new string('-', 40));

            //Gets the task data
            WriteLine("Enter your date (e.g 26/02/2009):");
            DateTime inputDate = DateTime.ParseExact(ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            //Gets all user tasks and lists them
            List<Task> tasks= TBusiness.ListAllTasksByDate(inputDate, CurrentUser);

            WriteLine($"Listing all tasks on {inputDate.ToString("d")}...");
            if (tasks.Count > 0)
            {
                foreach (Task @task in tasks)
                {
                    WriteLine($"{@task.TaskId} {@task.Name} {@task.Date.ToString("d")} {(@task.IsDone ? "DONE" : "NOT DONE")}");
                }
            }
            else
            {
                WriteLine("No tasks found!");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all completed tasks.
        /// </summary>
        public static void ListAllCompletedTasks()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 12) + "COMPLETED TASKS" + new string(' ', 12));
            WriteLine(new string('-', 40));

            //Gets all completed user tasks and lists them
            List<Task> tasks= TBusiness.ListAllCompletedTasks(CurrentUser);

            WriteLine("Listing all completed tasks...");
            if (tasks.Count > 0)
            {
                foreach (Task @task in tasks)
                {
                    WriteLine($"{@task.TaskId} {@task.Name} {@task.Date.ToString("d")} {(@task.IsDone ? "DONE" : "NOT DONE")}");

                }
            }
            else
            {
                WriteLine("No tasks found!");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Lists all uncompleted tasks.
        /// </summary>
        public static void ListAllUncompletedTasks()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 11) + "UNCOMPLETED TASKS" + new string(' ', 11));
            WriteLine(new string('-', 40));

            //Gets all uncompleted user tasks and lists them
            List<Task> tasks= TBusiness.ListAllUncompletedTasks(CurrentUser);

            WriteLine("Listing all uncompleted tasks...");
            if (tasks.Count > 0)
            {
                foreach (Task @task in tasks)
                {
                    WriteLine($"{@task.TaskId} {@task.Name} {@task.Date.ToString("d")} {(@task.IsDone ? "DONE" : "NOT DONE")}");
                }
            }
            else
            {
                WriteLine("No tasks found!");
            }

            MenuOrExit();
        }

        /// <summary>
        /// Removes all completed tasks.
        /// </summary>
        public static void RemoveAllCompletedTasks()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 8) + "REMOVE COMPLETED TASKS" + new string(' ', 8));
            WriteLine(new string('-', 40));

            //Removes all completed user tasks
            TBusiness.RemoveAllCompletedTasks(CurrentUser);
            WriteLine("All completed tasks have successfully been removed");

            MenuOrExit();
        }

        /// <summary>
        /// Removes all tasks.
        /// </summary>
        public static void RemoveAllTasks()
        {
            //Clears the console window
            Clear();

            WriteLine(new string('-', 40));
            WriteLine(new string(' ', 8) + "REMOVE ALL TASKS" + new string(' ', 8));
            WriteLine(new string('-', 40));

            //Removes all user tasks
            TBusiness.RemoveAllTasks(CurrentUser);
            WriteLine("All tasks have successfully been removed");

            MenuOrExit();
        }
    }
}
