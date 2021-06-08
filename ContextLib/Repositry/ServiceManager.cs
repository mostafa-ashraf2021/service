using ContextLib.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
namespace ContextLib.Repositry
{
    public interface IServiceManager
    {
        public IList<Service> AllServices();
        public IList<Service> SearchService(string name);
        public void AddService(Service user);
        public bool DeleteService(int id);
        public bool UpdateService(int id, Service service);
    }
   public class ServiceManager : IServiceManager
    {
        private readonly ContextWeb _context;

        public ServiceManager(ContextWeb context)
        {
            _context = context;
        }
        public IList<Service> AllServices()
        {
            var services = _context.Services.ToList();
            return services;
        }
        public void AddService(Service user)
        {
            _context.Services.Add(user);
            _context.SaveChanges();
        }

       

        public bool DeleteService(int id)
        {
            var service = _context.Services.FirstOrDefault(u => u.Id == id);
            if (service == null)
            {
                return false;
            }
            _context.Remove(service);
            _context.SaveChanges();
            return true;
        }

        public IList<Service> SearchService(string name)
        {
            var services = _context.Services.Where(u => u.Name.Contains(name)).ToList();
            return services;
        }

        public bool UpdateService(int id, Service service)
        {
            var serviceDb = _context.Services.AsNoTracking().FirstOrDefault(u => u.Id == id);
            if (serviceDb == null)
            {
                return false;
            }
            //userDb.Name = user.Name;
            //userDb.DateOfBirth = user.DateOfBirth;
            _context.Update(service);
            _context.SaveChanges();
            return true;
        }
    }
}
