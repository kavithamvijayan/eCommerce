using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SantaSecretAspCore.Models;
using SantaSecretAspCore.Utils;

namespace SantaSecretAspCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public LoginController(AppDbContext appDbContext) => this.appDbContext = appDbContext;

        public class LoginData
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class LoginResponse
        {
            public bool Success { get; set; }
        }

        // Log In
        // POST: api/Login
        [HttpPost]
        public async Task<LoginResponse> Login([FromBody] Customer ld)
        {
            var lr = new LoginResponse() { Success = false };

            var user = await appDbContext.Customer.SingleOrDefaultAsync(u => u.email == ld.email);
            if (user != null)
            {
                //if (PasswordHash.VerifyHashedPassword(user.password, ld.Password))
                //{
                    await HttpContext.Session.LoadAsync();
                    HttpContext.Session.SetInt32("userId", user.Id);
                    await HttpContext.Session.CommitAsync();
                    lr.Success = true;
               // }
            }

            return lr;
        }

        public class LogoutResponse
        {
            public bool Success { get; set; }
        }

        // Log Out
        // DELETE: api/Login
        [HttpDelete]
        public async Task<LogoutResponse> Logout()
        {
            var dr = new LogoutResponse() { Success = true };

            await HttpContext.Session.LoadAsync();
            HttpContext.Session.SetInt32("userId", 0);
            await HttpContext.Session.CommitAsync();

            return dr;
        }
    }
}
