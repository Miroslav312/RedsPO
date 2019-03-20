using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using NUnit.Framework;
using Moq;
using Business;
using static UnitTesting.UnitTestMethods;

namespace Tests
{
    [TestFixture]
    public class EventBusinessTests
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
        /// Test - Add new event to the database.
        /// </summary>
        [Test]
        public void TestAddNewEventToTheDatabase()
        {
            EventBusiness mockEventBusiness = new EventBusiness(_mockContext.Object);

            Event mockEvent = new Event() { EventId = 3, DueTime = DateTime.Now, Name = "name", UserId = 1};

            mockEventBusiness.AddEvent(mockEvent);

            Assert.Contains(mockEvent, mockEventBusiness.GetPODbContext.Events.ToList(), "Event not added properly!");
        }

        /// <summary>
        /// Test - Add null event to the database.
        /// </summary>
        [Test]
        public void TestAddNullEventToTheDatabase()
        {
            EventBusiness mockEventBusiness = new EventBusiness(_mockContext.Object);

            Event mockEvent = null;

            Assert.Catch(() => mockEventBusiness.AddEvent(mockEvent), "Null event added to the database!");
        }

        /// <summary>
        /// Test - Delete event from the database.
        /// </summary>
        [Test]
        public void TestDeleteEventFromTheDatabase()
        {
            EventBusiness mockEventBusiness = new EventBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);
            
            int eventId = 1;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            int oldCount = mockEventBusiness.GetPODbContext.Events.ToList().Count();
            
            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            mockEventBusiness.DeleteEvent(eventId, mockUser);

            Assert.Less(mockEventBusiness.GetPODbContext.Events.ToList().Count(), oldCount, "Event not deleted properly!");
        }

        /// <summary>
        /// Test - Delete non existent event from the database.
        /// </summary>
        [Test]
        public void TestDeleteNonExistentEventFromTheDatabase()
        {
            EventBusiness mockEventBusiness = new EventBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int eventId = 3;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Assert.Catch(() => mockEventBusiness.DeleteEvent(eventId, mockUser), "Non existent event was deleted!");
        }

        /// <summary>
        /// Test - Fetch event by id from the database.
        /// </summary>
        [Test]
        public void TestFetchEventByIdFromTheDatabase()
        {
            EventBusiness mockEventBusiness = new EventBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int eventId = 2;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Event mockEvent = mockEventBusiness.FetchEventById(eventId, mockUser);

            Assert.AreEqual(eventId, mockEvent.EventId, "Wrong event was fetched!");
        }

        /// <summary>
        /// Test - Fetch non existent event by id from the database.
        /// </summary>
        [Test]
        public void TestFetchNonExistentEventByIdFromTheDatabase()
        {
            EventBusiness mockEventBusiness = new EventBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            int eventId = 5;
            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);
            
            Assert.Catch(() => mockEventBusiness.FetchEventById(eventId, mockUser), "Non existent event was fetched!");
        }

        /// <summary>
        /// Test - Fetch event by id with null user from the database.
        /// </summary>
        [Test]
        public void TestFetchEventByIdWithNullUserFromTheDatabase()
        {
            EventBusiness mockEventBusiness = new EventBusiness(_mockContext.Object);

            int eventId = 5;

            User mockUser = null;

            Assert.Catch(() => mockEventBusiness.FetchEventById(eventId, mockUser), "Non existent event was fetched!");
        }

        /// <summary>
        /// Test - List all user events from the database.
        /// </summary>
        [Test]
        public void TestListAllUserEventsFromTheDatabase()
        {
            EventBusiness mockEventBusiness = new EventBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            int count = mockEventBusiness.ListAllEvents(mockUser).Count();
            int expectedCount = mockEventBusiness.GetPODbContext.Events.Where(x => x.UserId == mockUser.UserId).ToList().Count();

            Assert.AreEqual(expectedCount, count, "Not all events were fetched!");
        }

        /// <summary>
        /// Test - List all null user events from the database.
        /// </summary>
        [Test]
        public void TestListAllNullUserEventsFromTheDatabase()
        {
            EventBusiness mockEventBusiness = new EventBusiness(_mockContext.Object);

            User mockUser = null;
            
            Assert.Catch(() => mockEventBusiness.ListAllEvents(mockUser), "Null user events were fetched!");
        }

        /// <summary>
        /// Test - Remove all user events from the database.
        /// </summary>
        [Test]
        public void TestRemoveAllUserEventsFromTheDatabase()
        {
            EventBusiness mockEventBusiness = new EventBusiness(_mockContext.Object);
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            string userName = "userName1";
            string passwordHash = "passwordHash";

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            mockEventBusiness.RemoveAllEvents(mockUser);

            int count = mockEventBusiness.GetPODbContext.Events.Where(x => x.UserId == mockUser.UserId).ToList().Count();
            int expectedCount = 0;

            Assert.AreEqual(expectedCount, count, "Not all user events were removed!");
        }

        /// <summary>
        /// Test - Remove all null user events from the database.
        /// </summary>
        [Test]
        public void TestRemoveAllNullUserEventsFromTheDatabase()
        {
            EventBusiness mockEventBusiness = new EventBusiness(_mockContext.Object);

            User mockUser = null;
            
            Assert.Catch(() => mockEventBusiness.RemoveAllEvents(mockUser), "All null user events were removed!");
        }
    }
}