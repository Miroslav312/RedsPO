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
    public class ReminderBusinessTests
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
        /// Test - Add new reminder to the database.
        /// </summary>
        [Test]
        public void TestAddNewReminderToTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);

            Reminder mockReminder = new Reminder() { ReminderId = 3, DueTime = DateTime.Now, Name = "name", UserId = 1 };

            mockReminderBusiness.AddReminder(mockReminder);

            Assert.Contains(mockReminder, mockReminderBusiness.GetPODbContext.Reminders.ToList(), "Reminder not added properly!");
        }

        /// <summary>
        /// Test - Add null reminder to the database.
        /// </summary>
        [Test]
        public void TestAddNullReminderToTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);

            Reminder mockReminder = null;

            Assert.Catch(() => mockReminderBusiness.AddReminder(mockReminder), "Null reminder added to the database!");
        }

        /// <summary>
        /// Test - Delete reminder from the database.
        /// </summary>
        [Test]
        public void TestDeleteReminderFromTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int reminderId = 1;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            int oldCount = mockReminderBusiness.GetPODbContext.Reminders.ToList().Count();

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            mockReminderBusiness.DeleteReminder(reminderId, mockUser);

            Assert.Less(mockReminderBusiness.GetPODbContext.Reminders.ToList().Count(), oldCount, "Reminder not deleted properly!");
        }

        /// <summary>
        /// Test - Delete non existent reminder from the database.
        /// </summary>
        [Test]
        public void TestDeleteNonExistentReminderFromTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int reminderId = 3;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Assert.Catch(() => mockReminderBusiness.DeleteReminder(reminderId, mockUser), "Non existent reminder was deleted!");
        }

        /// <summary>
        /// Test - Fetch reminder by id from the database.
        /// </summary>
        [Test]
        public void TestFetchReminderByIdFromTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int reminderId = 2;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Reminder mockReminder = mockReminderBusiness.FetchReminderById(reminderId, mockUser);

            Assert.AreEqual(reminderId, mockReminder.ReminderId, "Wrong reminder was fetched!");
        }

        /// <summary>
        /// Test - Fetch non existent reminder by id from the database.
        /// </summary>
        [Test]
        public void TestFetchNonExistentReminderByIdFromTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int reminderId = 5;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Assert.Catch(() => mockReminderBusiness.FetchReminderById(reminderId, mockUser), "Non existent reminder was fetched!");
        }

        /// <summary>
        /// Test - Fetch reminder by id with null user from the database.
        /// </summary>
        [Test]
        public void TestFetchReminderByIdWithNullUserFromTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);

            int reminderId = 5;

            User mockUser = null;

            Assert.Catch(() => mockReminderBusiness.FetchReminderById(reminderId, mockUser), "Non existent reminder was fetched!");
        }

        /// <summary>
        /// Test - List all user reminders from the database.
        /// </summary>
        [Test]
        public void TestListAllUserRemindersFromTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            int count = mockReminderBusiness.ListAllReminders(mockUser).Count();
            int expectedCount = mockReminderBusiness.GetPODbContext.Reminders.Where(x => x.UserId == mockUser.UserId).ToList().Count();

            Assert.AreEqual(expectedCount, count, "Not all reminders were fetched!");
        }

        /// <summary>
        /// Test - List all null user reminders from the database.
        /// </summary>
        [Test]
        public void TestListAllNullUserRemindersFromTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);

            User mockUser = null;

            Assert.Catch(() => mockReminderBusiness.ListAllReminders(mockUser), "Null user reminders were fetched!");
        }

        /// <summary>
        /// Test - Remove all user reminders from the database.
        /// </summary>
        [Test]
        public void TestRemoveAllUserRemindersFromTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            mockReminderBusiness.RemoveAllReminders(mockUser);

            int count = mockReminderBusiness.GetPODbContext.Reminders.Where(x => x.UserId == mockUser.UserId).ToList().Count();
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, count, "Not all user reminders were removed!");
        }

        /// <summary>
        /// Test - Remove all null user reminders from the database.
        /// </summary>
        [Test]
        public void TestRemoveAllNullUserRemindersFromTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);

            User mockUser = null;

            Assert.Catch(() => mockReminderBusiness.RemoveAllReminders(mockUser), "All null user reminder were removed!");
        }

        /// <summary>
        /// Test - List all user reminders by date from the database.
        /// </summary>
        [Test]
        public void TestListAllUserRemindersByDateFromTheDatabase()
        {
            ReminderBusiness mockReminderBusiness = new ReminderBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            DateTime dueDate = new DateTime(2019, 1, 1);

            Reminder mockReminder1 = new Reminder() { ReminderId = 3, DueTime = dueDate, Name = "name", UserId = 1 };
            Reminder mockReminder2 = new Reminder() { ReminderId = 4, DueTime = dueDate, Name = "name", UserId = 1 };

            mockReminderBusiness.AddReminder(mockReminder1);
            mockReminderBusiness.AddReminder(mockReminder2);

            int count = mockReminderBusiness.ListAllRemindersByDate(dueDate, mockUser).Count();
            int expectedCount = mockReminderBusiness.GetPODbContext.Reminders.Where(x => x.UserId == mockUser.UserId && x.DueTime == dueDate).ToList().Count();

            Assert.AreEqual(expectedCount, count, "Not all reminders were fetched!");
        }
    }
}