using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using NUnit.Framework;
using Moq;
using Business;
using static UnitTesting.UnitTestMethods;

namespace UnitTesting.BusinessTests
{
    [TestFixture]
    public class TaskBusinessTests
    {
        private Mock<DbSet<Event>> _mockEvents;
        private Mock<DbSet<Reminder>> _mockReminders;
        private Mock<DbSet<Task>> _mockTasks;
        private Mock<DbSet<User>> _mockUsers;

        private Mock<PODbContext> _mockContext;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            List<User> users = new List<User>()
            {
                new User() { UserId = 1, UserName = "userName1", PasswordHash = "passwordHash", FirstName = "firstName", LastName = "lastName" },
                new User() { UserId = 2, UserName = "userName2", PasswordHash = "passwordHash", FirstName = "firstName", LastName = "lastName" }
            };

            List<Event> events = new List<Event>()
            {
                new Event() { EventId = 1, Name = "name", DueTime = DateTime.Now, UserId = 1},
                new Event() { EventId = 2, Name = "name", DueTime = DateTime.Now, UserId = 2}
            };

            List<Reminder> reminders = new List<Reminder>()
            {
                new Reminder() { ReminderId = 1, Name = "name", DueTime = DateTime.Now, UserId = 1},
                new Reminder() { ReminderId = 2, Name = "name", DueTime = DateTime.Now, UserId = 1}
            };

            List<Task> tasks = new List<Task>()
            {
                new Task() { TaskId = 1, Name = "name", Date = DateTime.Now, IsDone = false, UserId = 1},
                new Task() { TaskId = 2, Name = "name", Date = DateTime.Now, IsDone = false, UserId = 1},
            };

            _mockEvents = GetQueryableMockDbSet(events);

            _mockEvents.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => events.AsQueryable().FirstOrDefault(d => d.EventId == (int)ids[0]));

            _mockReminders = GetQueryableMockDbSet(reminders);

            _mockReminders.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => reminders.AsQueryable().FirstOrDefault(d => d.ReminderId == (int)ids[0]));

            _mockTasks = GetQueryableMockDbSet(tasks);

            _mockTasks.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => tasks.AsQueryable().FirstOrDefault(d => d.TaskId == (int)ids[0]));

            _mockUsers = GetQueryableMockDbSet(users);

            _mockUsers.Setup(m => m.Find(It.IsAny<object[]>())).Returns<object[]>(ids => users.AsQueryable().FirstOrDefault(d => d.UserId == (int)ids[0]));

            _mockContext = new Mock<PODbContext>();
            _mockContext.Setup(m => m.Events).Returns(_mockEvents.Object);
            _mockContext.Setup(m => m.Reminders).Returns(_mockReminders.Object);
            _mockContext.Setup(m => m.Tasks).Returns(_mockTasks.Object);
            _mockContext.Setup(m => m.Users).Returns(_mockUsers.Object);

        }

        /// <summary>
        /// Test - Add new task to the database.
        /// </summary>
        [Test]
        public void TestAddNewTaskToTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);

            Task mockTask = new Task() { TaskId = 3, Date = DateTime.Now, Name = "name",IsDone = false, UserId = 1 };

            mockTaskBusiness.AddTask(mockTask);

            Assert.Contains(mockTask, mockTaskBusiness.GetPODbContext.Tasks.ToList(), "Task not added properly!");
        }

        /// <summary>
        /// Test - Add null task to the database.
        /// </summary>
        [Test]
        public void TestAddNullTaskToTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);

            Task mockTask = null;

            Assert.Catch(() => mockTaskBusiness.AddTask(mockTask), "Null task added to the database!");
        }

        /// <summary>
        /// Test - Delete task from the database.
        /// </summary>
        [Test]
        public void TestDeleteTaskFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int taskId = 1;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            int oldCount = mockTaskBusiness.GetPODbContext.Tasks.ToList().Count();

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            mockTaskBusiness.DeleteTask(taskId, mockUser);

            Assert.Less(mockTaskBusiness.GetPODbContext.Tasks.ToList().Count(), oldCount, "Task not deleted properly!");
        }

        /// <summary>
        /// Test - Delete non existent task from the database.
        /// </summary>
        [Test]
        public void TestDeleteNonExistentTaskFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int taskId = 3;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Assert.Catch(() => mockTaskBusiness.DeleteTask(taskId, mockUser), "Non existent task was deleted!");
        }

        /// <summary>
        /// Test - Fetch task by id from the database.
        /// </summary>
        [Test]
        public void TestFetchTaskByIdFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int taskId = 2;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Task mockTask = mockTaskBusiness.FetchTaskById(taskId, mockUser);

            Assert.AreEqual(taskId, mockTask.TaskId, "Wrong task was fetched!");
        }

        /// <summary>
        /// Test - Fetch non existent task by id from the database.
        /// </summary>
        [Test]
        public void TestFetchNonExistentTaskByIdFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int taskId = 5;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Assert.Catch(() => mockTaskBusiness.FetchTaskById(taskId, mockUser), "Non existent task was fetched!");
        }

        /// <summary>
        /// Test - Fetch task by id with null user from the database.
        /// </summary>
        [Test]
        public void TestFetchTaskByIdWithNullUserFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);

            int taskId = 5;

            User mockUser = null;

            Assert.Catch(() => mockTaskBusiness.FetchTaskById(taskId, mockUser), "Non existent task was fetched!");
        }

        /// <summary>
        /// Test - List all user tasks from the database.
        /// </summary>
        [Test]
        public void TestListAllUserTasksFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            int count = mockTaskBusiness.ListAllTasks(mockUser).Count();
            int expectedCount = mockTaskBusiness.GetPODbContext.Tasks.Where(x => x.UserId == mockUser.UserId).ToList().Count();

            Assert.AreEqual(expectedCount, count, "Not all tasks were fetched!");
        }

        /// <summary>
        /// Test - List all null user tasks from the database.
        /// </summary>
        [Test]
        public void TestListAllNullUserTasksFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);

            User mockUser = null;

            Assert.Catch(() => mockTaskBusiness.ListAllTasks(mockUser), "Null user tasks were fetched!");
        }

        /// <summary>
        /// Test - Remove all user tasks from the database.
        /// </summary>
        [Test]
        public void TestRemoveAllUserTasksFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            mockTaskBusiness.RemoveAllTasks(mockUser);

            int count = mockTaskBusiness.GetPODbContext.Tasks.Where(x => x.UserId == mockUser.UserId).ToList().Count();
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, count, "Not all user tasks were removed!");
        }

        /// <summary>
        /// Test - Remove all null user tasks from the database.
        /// </summary>
        [Test]
        public void TestRemoveAllNullUserTasksFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);

            User mockUser = null;

            Assert.Catch(() => mockTaskBusiness.RemoveAllTasks(mockUser), "All null user tasks were removed!");
        }

        /// <summary>
        /// Test - Complete from the database.
        /// </summary>
        [Test]
        public void TestCompleteTaskFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);


            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Task mockTask = new Task() { TaskId = 3, Date = DateTime.Now, Name = "name", IsDone = false, UserId = 1 };

            mockTaskBusiness.AddTask(mockTask);

            mockTaskBusiness.CompleteTask(mockTask.TaskId, mockUser);

            mockTask = mockTaskBusiness.FetchTaskById(mockTask.TaskId, mockUser);

            Assert.AreEqual(mockTask.IsDone, true, "Wrong task was fetched!");
        }

        /// <summary>
        /// Test - Complete a non existent task from the database.
        /// </summary>
        [Test]
        public void TestCompleteNonExistentTaskFromDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int taskId = 3;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);
            
            Assert.Catch(() => mockTaskBusiness.CompleteTask(taskId, mockUser), "Non existent task was completed!");
        }
        
        /// <summary>
        /// Test - List all completed user tasks from the database.
        /// </summary>
        [Test]
        public void TestListAllCompletedUserTasksFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Task mockTask1 = new Task() { TaskId = 3, Date = DateTime.Now, Name = "name", IsDone = true, UserId = 1 };
            Task mockTask2 = new Task() { TaskId = 4, Date = DateTime.Now, Name = "name", IsDone = true, UserId = 1 };

            mockTaskBusiness.AddTask(mockTask1);
            mockTaskBusiness.AddTask(mockTask2);

            int count = mockTaskBusiness.ListAllCompletedTasks(mockUser).Count();
            int expectedCount = mockTaskBusiness.GetPODbContext.Tasks.Where(x => x.UserId == mockUser.UserId && x.IsDone == true).ToList().Count();

            Assert.AreEqual(expectedCount, count, "Not all tasks were fetched!");
        }

        /// <summary>
        /// Test - List all completed null user tasks from the database.
        /// </summary>
        [Test]
        public void TestListAllCompletedNullUserTasksFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);

            User mockUser = null;

            Assert.Catch(() => mockTaskBusiness.ListAllCompletedTasks(mockUser), "Null user completed tasks were fetched!");
        }

        /// <summary>
        /// Test - List all uncompleted user tasks from the database.
        /// </summary>
        [Test]
        public void TestListAllUncompletedUserTasksFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            int count = mockTaskBusiness.ListAllUncompletedTasks(mockUser).Count();
            int expectedCount = mockTaskBusiness.GetPODbContext.Tasks.Where(x => x.UserId == mockUser.UserId && x.IsDone == false).ToList().Count();

            Assert.AreEqual(expectedCount, count, "Not all tasks were fetched!");
        }

        /// <summary>
        /// Test - List all uncompleted null user tasks from the database.
        /// </summary>
        [Test]
        public void TestListAllUncompletedNullUserTasksFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);

            User mockUser = null;

            Assert.Catch(() => mockTaskBusiness.ListAllUncompletedTasks(mockUser), "Null user uncompleted tasks were fetched!");
        }

        /// <summary>
        /// Test - Remove all completed user tasks from the database.
        /// </summary>
        [Test]
        public void TestRemoveAllCompletedUserTasksFromTheDatabase()
        {
            TaskBusiness mockTaskBusiness = new TaskBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            mockTaskBusiness.RemoveAllCompletedTasks(mockUser);

            int count = mockTaskBusiness.GetPODbContext.Tasks.Where(x => x.UserId == mockUser.UserId && x.IsDone == true).ToList().Count();
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, count, "Not all completed user tasks were removed!");
        }
    }
}