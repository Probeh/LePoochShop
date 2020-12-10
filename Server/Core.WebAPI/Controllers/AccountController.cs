using System;
using System.Threading.Tasks;
using Core.Shared.Models.DTOs;
using Core.Shared.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core.WebAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        // ======================================= //
        private readonly UserManager<User> _user;
        private readonly SignInManager<User> _signIn;
        // ======================================= //
        public AccountController(UserManager<User> user, SignInManager<User> signIn)
        {
            this._signIn = signIn;
            this._user = user;
        }
        // ======================================= //
        [HttpPost("login")]
        public async Task<IActionResult> UserLogin([FromBody] LoginDTO dto)
        {
            var result = await Task.Run(() => "Welcome");
            return Ok(result);
        }

        [HttpPut("register")]
        public async Task<IActionResult> RegisterAccount([FromBody] RegisterDTO dto)
        {
            var result = await Task.Run(() => "Welcome");
            return Ok(result);
        }

        [HttpGet("username")]
        public async Task<IActionResult> CheckUsername([FromRoute] string username)
        {
            var result = await Task.Run(() => username);
            return Ok(result);
        }

        [HttpGet("email")]
        public async Task<IActionResult> ValidateEmail([FromRoute] string password)
        {
            var result = await Task.Run(() => password);
            return Ok(result);
        }
    }
}