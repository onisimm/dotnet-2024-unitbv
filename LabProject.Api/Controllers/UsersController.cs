using LabProject.Core.Services;
using LabProject.Database.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabProject.Api.Controllers
{
    public class UsersController : BaseController
    {
        private UsersService usersService { get; set; }


        public UsersController(UsersService usersService)
        {
            this.usersService = usersService;
        }

        [HttpPost("/register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterRequest payload)
        {
            usersService.Register(payload);
            return Ok("Registration successful");
        }

        [HttpPost("/login")]
        [AllowAnonymous]
        public IActionResult Login(LoginRequest payload)
        {
            var jwtToken = usersService.Login(payload);

            return Ok(new { token = jwtToken });
        }
    }
}
