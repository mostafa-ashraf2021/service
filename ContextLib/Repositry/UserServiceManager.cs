using ContextLib.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace ContextLib.Repositry
{
    public interface IUserServiceManager
    {
        public IList<UserService> AllUserServices();
        public UserService SearchUserService(int id);
        public void AddUserService(UserService userService);
        public bool DeleteUserService(int id);
        public bool UpdateUserService(int id, UserService userservice);
    }

    class UserServiceManager : IUserServiceManager
    {
        private readonly ContextWeb _context;

        public UserServiceManager(ContextWeb context)
        {
            _context = context;
        }
        public void AddUserService(UserService userService)
        {
            
            _context.Add(userService);
            _context.SaveChanges();
        }

        public IList<UserService> AllUserServices()
        {
            var userservices = _context.UserServices.ToList();
            return userservices;
        }

        public bool DeleteUserService(int id)
        {
            var userservice = _context.UserServices.FirstOrDefault(u => u.Id == id);
            if (userservice == null)
            {
                return false;
            }
            _context.Remove(userservice);
            _context.SaveChanges();
            return true;
        }

        public UserService SearchUserService(int id)
        {
            var userservice = _context.UserServices.FirstOrDefault(u => u.Id == id);
            return userservice;
        }

        public bool UpdateUserService(int id, UserService userservice)
        {
            var userserviceDb = _context.UserServices.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (userserviceDb == null)
            {
                return false;
            }
            
            _context.Update(userservice);
            _context.SaveChanges();
            return true;
        }
    }
}
