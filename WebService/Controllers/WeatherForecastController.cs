using System;
using System.Collections.Generic;
using System.Linq;
using ContextLib.Entites;
using ContextLib.Repositry;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ContextWeb _context;
        private readonly IUserManager _userManager;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger, 
            ContextWeb context,
            IUserManager userManager)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
        }


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;


        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }



        [HttpGet("All")]
        public IList<User> GetAllUsers()
        {
            var users = _userManager.AllUser();
            return users;
        }

        [HttpGet("Search/{name}")]
        public IList<User> GetUserByName(string name)
        {
            var users = _userManager.SearchUsers(name);
            return users;
        }

        [HttpPost("Add")]
        public IActionResult PostAddUser(User user)
        {
            try
            {
                _userManager.AddUser(user);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("Delete")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                bool user = _userManager.DeleteUser(id);
                if(user){
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut("Update/{id}")]
        public IActionResult UpdateUser(int id, User user)
        {
            try
            {
                bool isUpdated = _userManager.UpdateUser(id, user);
                if (isUpdated)
                {
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
 