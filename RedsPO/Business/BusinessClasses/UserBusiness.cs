using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Business
{
    public class UserBusiness
    {
        private PODbContext _poDbContext;

        public PODbContext GetPODbContext => _poDbContext;

        public UserBusiness(PODbContext poDbContext)
        {
            _poDbContext = poDbContext;
        }

        /// <summary>Fetches the user.</summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="passwordHash">The password hash.</param>
        public User FetchUser(string userName, string passwordHash)
        {
            //Returns the user
            return _poDbContext.Users.FirstOrDefault(x => x.UserName == userName && x.PasswordHash == passwordHash.ToString());
        }

        /// <summary>Registers the specified user.</summary>
        /// <param name="user">The user.</param>
        public void Register(User user)
        {
            if (user == null || user.UserName == null || user.PasswordHash == null)
                throw new InvalidOperationException("User should not be null!");

            //Registers the user
            _poDbContext.Users.Add(user);
            _poDbContext.SaveChanges();
        }

        /// <summary>Hashes the password with SHA256 Hash.</summary>
        /// <param name="password">The password.</param>
        public static string HashPassword(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] hash = sha256.ComputeHash(bytes);

            //Gets string from Hash's Byte Array
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
