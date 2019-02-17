using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        private PODbContext poDbContext;

        public List<User> GetAll()
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Users.ToList();
            }
        }

        public User Get(string userName, string passwordHash)
        {
            using (poDbContext = new PODbContext())
            {
                return poDbContext.Users.FirstOrDefault(x => x.UserName == userName && x.PasswordHash == passwordHash.ToString());
            }
        }

        public void Register(User user)
        {
            using (poDbContext = new PODbContext())
            {
                poDbContext.Users.Add(user);
                poDbContext.SaveChanges();
            }
        }

        public bool IsExisting(User user)
        {
            using(poDbContext = new PODbContext())
            {
                return GetAll().Contains(user); 
            }
        }
    }
}
