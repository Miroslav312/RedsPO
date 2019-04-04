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
    public class UserBusinessTests
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
        /// Test - Register new user to the database.
        /// </summary>
        [Test]
        public void TestRegisterNewUserToTheDatabase()
        {
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            User mockUser = new User() { UserId = 3, UserName = "userName", FirstName = "firstName", LastName = "lastName", PasswordHash = "passwordHash"};

            mockUserBusiness.Register(mockUser);

            Assert.Contains(mockUser, mockUserBusiness.GetPODbContext.Users.ToList(), "User not registered properly!");
        }

        /// <summary>
        /// Test - Register null userName user to the database.
        /// </summary>
        [Test]
        public void TestRegisterNullUserNameUserToTheDatabase()
        {
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            User mockUser = new User() { UserId = 3, UserName = null, FirstName = "firstName", LastName = "lastName", PasswordHash = "passwordHash" };
            
            Assert.Catch(() => mockUserBusiness.Register(mockUser), "User with null user name was registered properly!");
        }

        /// <summary>
        /// Test - Register null passwordHash user to the database.
        /// </summary>
        [Test]
        public void TestRegisterNullPasswordHashUserToTheDatabase()
        {
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            User mockUser = new User() { UserId = 3, UserName = "userName", FirstName = "firstName", LastName = "lastName", PasswordHash = null };

            Assert.Catch(() => mockUserBusiness.Register(mockUser), "User with null password hash was registered properly!");
        }

        /// <summary>
        /// Test - Register null user to the database.
        /// </summary>
        [Test]
        public void TestRegisterNullUserToTheDatabase()
        {
            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            User mockUser = null;

            Assert.Catch(() => mockUserBusiness.Register(mockUser), "Null user registered to the database!");
        }

        /// <summary>
        /// Test - Fetch user from the database.
        /// </summary>
        [Test]
        public void TestFetchUserFromTheDatabase()
        {
            string userName = "userName1";
            string passwordHash = "passwordHash";

            int expectedId = 1;

            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Assert.AreEqual(expectedId, mockUser.UserId,  "User not fetched correctly!");
        }

        /// <summary>
        /// Test - False fetch user from the database.
        /// </summary>
        [Test]
        public void TestFalseFetchUserFromTheDatabase()
        {
            string userName = "nonExisting";
            string passwordHash = "nonExisting";

            UserBusiness mockUserBusiness = new UserBusiness(_mockContext.Object);

            User mockUser = mockUserBusiness.FetchUser(userName, passwordHash);

            Assert.AreEqual(null, mockUser, "Non existent user fetched!");
        }

        /// <summary>
        /// Test - Hash password.
        /// </summary>
        [Test]
        public void TestHashPassword()
        {
            string text = "testText";

            string expectedHash = "85AC464C2F22837C991C50FDAA5FACC25A09FD7664B5D50427F69B4DF7744BDC";

            string returnedHash = UserBusiness.HashPassword(text);

            Assert.True(expectedHash == returnedHash, "Hashing of passwords is incorrect!");
        }

        /// <summary>
        /// Test - Second Hash password.
        /// </summary>
        [Test]
        public void TestSecondHashPassword()
        {
            string text = "testText1";

            string expectedHash = "D540E00AEB67987568C15923B61F8029BD80C7AB07F644306C6735029CDE17EE";

            string returnedHash = UserBusiness.HashPassword(text);

            Assert.True(expectedHash == returnedHash, "Hashing of passwords is incorrect!");
        }

        /// <summary>
        /// Test - Hash null password.
        /// </summary>
        [Test]
        public void TestHashNullPassword()
        {
            string text = null;

            Assert.Catch(() => UserBusiness.HashPassword(text), "Null password is hashed!");
        }
    }
}