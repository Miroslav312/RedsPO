using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Business
{
    public class TaskBusiness
    {
        private PODbContext _poDbContext;

        public PODbContext GetPODbContext => _poDbContext;

        public TaskBusiness(PODbContext poDbContext)
        {
            _poDbContext = poDbContext;
        }

        /// <summary>Adds the task.</summary>
        /// <param name="userTask">The user task.</param>
        public void AddTask(Task userTask)
        {
            if (userTask == null)
                throw new InvalidOperationException("Task should not be null!");

            //Adds the user task
            _poDbContext.Tasks.Add(userTask);
            _poDbContext.SaveChanges();
        }

        /// <summary>Modifies the task.</summary>
        /// <param name="userTask">The user task.</param>
        /// <param name="user">The user.</param>
        public void ModifyTask(Task userTask, User user)
        {
            Task @task = _poDbContext.Tasks.Find(userTask.TaskId);
            if (@task == null || @task.UserId != user.UserId)
            {
                throw new InvalidOperationException("Task either does not exist or is in another user!");
                //Warning: Task either does not exist or is in another user
            }
            else
            {
                //Modifies the user task
                _poDbContext.Entry(@task).CurrentValues.SetValues(userTask);
                _poDbContext.SaveChanges();
            }
        }

        /// <summary>Removes the Task.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public void RemoveTask(int id, User user)
        {
            Task @task = _poDbContext.Tasks.Find(id);
            if (@task == null || @task.UserId != user.UserId)
            {
                throw new InvalidOperationException("Task either does not exist or is in another user!");
                //Warning: Task either does not exist or is in another user
            }
            else
            {
                //Removes the user task
                _poDbContext.Tasks.Remove(@task);
                _poDbContext.SaveChanges();
            }
        }

        /// <summary>Completes the Task.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public void CompleteTask(int id, User user)
        {
            Task @task = _poDbContext.Tasks.Find(id);
            if (@task == null || @task.UserId != user.UserId)
            {
                throw new InvalidOperationException("Task either does not exist or is in another user!");
                //Warning: Task either does not exist or is in another user
            }
            else
            {
                //Completes the user task
                @task.IsDone = true;
                _poDbContext.SaveChanges();
            }
        }

        /// <summary>Fetches the Task by identifier.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="user">The user.</param>
        public Task FetchTaskById(int id, User user)
        {
            Task @task = _poDbContext.Tasks.Find(id);
            if (@task == null || @task.UserId != user.UserId)
            {
                throw new InvalidOperationException("Task either does not exist or is in another user!");
            }
            else
            {
                //Returns the user task
                return @task;
            }
        }

        /// <summary>Lists all Tasks.</summary>
        /// <param name="user">The user.</param>
        public List<Task> ListAllTasks(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User should not be null!");

            //Returns a List with all user tasks
            return _poDbContext.Tasks.Where(r => r.UserId == user.UserId).ToList();
        }

        /// <summary>Lists all Tasks by date.</summary>
        /// <param name="date">The date.</param>
        /// <param name="user">The user.</param>
        public List<Task> ListAllTasksByDate(DateTime date, User user)
        {
            if (user == null)
                throw new ArgumentNullException("User should not be null!");

            //Returns a List with all user tasks on a certain date
            return _poDbContext.Tasks.Where(r => DbFunctions.TruncateTime(r.Date) == date.Date && r.UserId == user.UserId).ToList();
        }
        
        /// <summary>Lists all completed Tasks.</summary>
        /// <param name="user">The user.</param>
        public List<Task> ListAllCompletedTasks(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User should not be null!");

            //Returns a List with all completed user tasks
            return _poDbContext.Tasks.Where(r => r.IsDone == true && r.UserId == user.UserId).ToList();
        }

        /// <summary>Lists all uncompleted Tasks.</summary>
        /// <param name="user">The user.</param>
        public List<Task> ListAllUncompletedTasks(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User should not be null!");

            //Returns a List with all uncompleted user tasks
            return _poDbContext.Tasks.Where(r => r.IsDone == false && r.UserId == user.UserId).ToList();
        }

        /// <summary>Removes all completed Tasks.</summary>
        /// <param name="user">The user.</param>
        public void RemoveAllCompletedTasks(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User should not be null!");

            //Removes all completed user tasks
            _poDbContext.Tasks.RemoveRange(_poDbContext.Tasks.Where(x => x.UserId == user.UserId && x.IsDone == true));
            _poDbContext.SaveChanges();
        }

        /// <summary>Removes all Tasks.</summary>
        /// <param name="user">The user.</param>
        public void RemoveAllTasks(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User should not be null!");

            //Removes all user tasks
            _poDbContext.Tasks.RemoveRange(_poDbContext.Tasks.Where(x => x.UserId == user.UserId));
            _poDbContext.SaveChanges();
        }
    }
}
