
using EComApplication.Services;
using FertiVueWebapi.Data;
using FertiVueWebapi.Models;
using FertiVueWebapi.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FertiVueWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbcontext _dbContext;

        public UserController(UserDbcontext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/User
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _dbContext.Users.ToList();
            return Ok(users);
        }

        // POST: api/User
        [HttpPost]
        public IActionResult SaveUser(AddUserDetailsdto user)
        {
            // Map DTO to Entity
            var userDetails = new UserDetails
            {
                UserName = user.UserName,
                email = user.email,
                clinicName = user.clinicName,
                country = user.country,
                platform = user.platform,
                massage = user.massage,
                ipaddress = user.ipaddress
            };

            // Save to Database
            _dbContext.Users.Add(userDetails);
            _dbContext.SaveChanges();

            // Send Email if email exists
            if (!string.IsNullOrEmpty(user.email))
            {
                SendmailService mail = new SendmailService(user.email, user.UserName);
                mail.SendMail();
            }

            return Ok("User saved successfully!");
        }
    }
}
