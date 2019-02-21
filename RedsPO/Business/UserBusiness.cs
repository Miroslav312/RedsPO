using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        private PODbContext poDbContext;

        /// <summary>Fetches all users.</summary>
        public List<User> FetchAllUsers()
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Users.ToList();
            }
        }

        /// <summary>Fetches the user.</summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passwordHash">The password hash.</param>
        public User FetchUser(string userName, string passwordHash)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Users.FirstOrDefault(x => x.UserName == userName && x.PasswordHash == passwordHash.ToString());
            }
        }

        /// <summary>Registers the specified user.</summary>
        /// <param name="user">The user.</param>
        public void Register(User user)
        {
            using (poDbContext = new PODbContext())
            {
                poDbContext.Users.Add(user);
                poDbContext.SaveChanges();
            }
        }

        /// <summary>Determines whether the specified user is existing.</summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///   <c>true</c> if the specified user is existing; otherwise, <c>false</c>.</returns>
        public bool IsExisting(User user)
        {
            using(poDbContext = new PODbContext())
            {
                return FetchAllUsers().Contains(user); 
            }
        }

        /// <summary>Hashes the password with SHA256 Hash.</summary>
        /// <param name="password">The password.</param>
        public static string HashPassword(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);

            return GetStringFromHash(hash);
        }

        /// <summary>Gets string from hash.</summary>
        /// <param name="hash">The hash.</param>
        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }

            return result.ToString();
        }
    }
}
