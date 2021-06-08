using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContextLib.Entites;
using AutoMapper;
using ContextLib.DTOs;
using WebService.AutoMapper;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserServicesController : ControllerBase
    {
        private readonly ContextWeb _context;
        private readonly IMapper mapper;

        public UserServicesController(ContextWeb context , IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: api/UserServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserService>>> GetUserServices()
        {
            return await _context.UserServices.Include(x=>x.Service).ToListAsync();
        }

        // GET: api/UserServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserService>> GetUserService(int id)
        {
            var userService = await _context.UserServices.FindAsync(id);

            if (userService == null)
            {
                return NotFound();
            }

            return userService;
        }

        // PUT: api/UserServices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserService(int id, UserService userService)
        {
            if (id != userService.Id)
            {
                return BadRequest();
            }

            _context.Entry(userService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserServiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserServices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        
        
        [HttpPost]
        public async Task<object> PostUserServiceAsync(ServiceModel serviceModel)
        {
            
            var serviceDTO = mapper.Map<UserService>(serviceModel);

             // var x = mapper.Map(serviceModel,  userService);
            /* UserService userService1 = new UserService();
              userService1.ServiceId = serviceModel.ServiceId;
              userService1.UserName = serviceModel.UserName;
              userService1.Id = serviceModel.Id;*/
              _context.UserServices.Add(serviceDTO);
              await _context.SaveChangesAsync();

            
            return Ok();
        }

        // DELETE: api/UserServices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserService>> DeleteUserService(int id)
        {
            var userService = await _context.UserServices.FindAsync(id);
            if (userService == null)
            {
                return NotFound();
            }

            _context.UserServices.Remove(userService);
            await _context.SaveChangesAsync();

            return userService;
        }

        private bool UserServiceExists(int id)
        {
            return _context.UserServices.Any(e => e.Id == id);
        }
    }
}
