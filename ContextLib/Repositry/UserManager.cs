using ContextLib.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ContextLib.Repositry
{
    public interface IUserManager
    {
        public IList<User> AllUser();
        public IList<User> SearchUsers(string name);
        public void AddUser(User user);
        public bool DeleteUser(int id);
        public bool UpdateUser(int id, User user);
    }
    public class UserManager : IUserManager
    {
        private readonly ContextWeb _context;

        public UserManager(ContextWeb context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public IList<User> AllUser()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if(user == null)
            {
                return false;
            }
            _context.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public IList<User> SearchUsers(string name)
        {
            var users = _context.Users.Where(u => u.Name.Contains(name)).ToList();
            return users;
        }

        public bool UpdateUser(int id, User user)
        {
            var userDb = _context.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (userDb == null)
            {
                return false;
            }
            //userDb.Name = user.Name;
            //userDb.DateOfBirth = user.DateOfBirth;
            _context.Update(user);
            _context.SaveChanges();
            return true;
        }
    }
}
