using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TaskBusiness
    {
        private PODbContext poDbContext;

        /// <summary>Adds the task.</summary>
        /// <param name="userTask">The user task.</param>
        public void AddTask(Task userTask)
        {
            using (poDbContext = new PODbContext())
            {
                poDbContext.Tasks.Add(userTask);
                poDbContext.SaveChanges();
            }
        }

        /// <summary>Modifies the task.</summary>
        /// <param name="userTask">The user task.</param>
        /// <param name="user">The user.</param>
        public void ModifyTask(Task userTask, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Task @task = poDbContext.Tasks.Find(userTask.TaskId);
                if (@task == null && @task.UserId != user.UserId)
                {
                    throw new InvalidOperationException("Task either does not exist or is in another user!");
                    //Warning: Task either does not exist or is in another user
                }
                else
                {
                    poDbContext.Entry(@task).CurrentValues.SetValues(userTask);
                    poDbContext.SaveChanges();
                }
            }
        }

        /// <summary>Deletes the Task.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public void DeleteTask(int id, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Task @task = poDbContext.Tasks.Find(id);
                if (@task == null && @task.UserId != user.UserId)
                {
                    throw new InvalidOperationException("Task either does not exist or is in another user!");
                    //Warning: Task either does not exist or is in another user
                }
                else
                {
                    poDbContext.Tasks.Remove(@task);
                    poDbContext.SaveChanges();
                }
            }
        }

        /// <summary>Completes the Task.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public void CompleteTask(int id, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Task @task = poDbContext.Tasks.Find(id);
                if (@task == null && @task.UserId != user.UserId)
                {
                    throw new InvalidOperationException("Task either does not exist or is in another user!");
                    //Warning: Task either does not exist or is in another user
                }
                else
                {
                    @task.IsDone = true;
                    poDbContext.SaveChanges();
                }
            }
        }

        /// <summary>Fetches the Task by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public Task FetchTaskById(int id, User user)
        {
            using (poDbContext = new PODbContext())
            {
                Task @task = poDbContext.Tasks.Find(id);
                if (@task == null && @task.UserId != user.UserId)
                {
                    throw new InvalidOperationException("Task either does not exist or is in another user!");
                }
                else
                {
                    return @task;
                }
            }
        }

        /// <summary>Lists all Tasks.</summary>
        /// <param name="user">The user.</param>
        public List<Task> ListAllTasks(User user)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Tasks.Where(r => r.UserId == user.UserId).ToList();
            }
        }

        /// <summary>Lists all Tasks by date.</summary>
        /// <param name="date">The date.</param>
        /// <param name="user">The user.</param>
        public List<Task> ListAllTasksByDate(DateTime date, User user)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Tasks.Where(r => DbFunctions.TruncateTime(r.Date) == date.Date && r.UserId == user.UserId).ToList();
            }
        }
        
        /// <summary>Lists all completed Tasks.</summary>
        /// <param name="user">The user.</param>
        public List<Task> ListAllCompletedTasks(User user)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Tasks.Where(r => r.IsDone == true && r.UserId == user.UserId).ToList();
            }
        }

        /// <summary>Lists all uncompleted Tasks.</summary>
        /// <param name="user">The user.</param>
        public List<Task> ListAllUncompletedTasks(User user)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Tasks.Where(r => r.IsDone == false && r.UserId == user.UserId).ToList();
            }
        }

        /// <summary>Removes all completed Tasks.</summary>
        /// <param name="user">The user.</param>
        public void RemoveAllCompletedTasks(User user)
        {
            using (poDbContext = new PODbContext())
            {
                foreach (Task @task in poDbContext.Tasks)
                {
                    if (@task.IsDone == true && @task.UserId == user.UserId)
                    {
                        poDbContext.Tasks.Remove(@task);
                    }
                }

                poDbContext.SaveChanges();
            }
        }

        /// <summary>Removes all Tasks.</summary>
        /// <param name="user">The user.</param>
        public void RemoveAllTasks(User user)
        {
            using (poDbContext = new PODbContext())
            {
                foreach (Task @task in poDbContext.Tasks)
                {
                    if (task.UserId == user.UserId)
                    {
                        poDbContext.Tasks.Remove(task);
                    }
                }

                poDbContext.SaveChanges();
            }
        }
    }
}
