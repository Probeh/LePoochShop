using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Shared.Models.DTOs;
using Core.Shared.Models.Identity;
using Core.WebAPI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.WebAPI.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("auth")]
    public class AccountController : ControllerBase
    {
        // ======================================= //
        private readonly UserManager<User> _user;
        private readonly SignInManager<User> _signIn;
        // ======================================= //
        private readonly IConfiguration _config;
        // ======================================= //
        public AccountController(UserManager<User> user, SignInManager<User> signIn, IConfiguration config)
        {
            this._config = config;
            this._signIn = signIn;
            this._user = user;
        }
        // ======================================= //
        [HttpPut]
        public async Task<IActionResult> UserRegister([FromBody] RegisterDTO dto)
        {
            if (await _user.Users.AnyAsync(x => x.UserName == dto.UserName))
                ModelState.AddModelError("Username", "Username already exists");
            if (await _user.Users.AnyAsync(x => x.Email == dto.Email))
                ModelState.AddModelError("Email", "Email already exists");

            if (ModelState.IsValid)
            {
                var account = new User { UserName = dto.UserName, Email = dto.Email };

                var register = await _user.CreateAsync(account, dto.Password);
                if (!register.Succeeded)
                    return BadRequest(register.Errors);
                return Ok();
            }
            else return BadRequest(ModelState as IEnumerable<KeyValuePair<string, ModelStateEntry>>);
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin([FromBody] LoginDTO dto)
        {
            try
            {
                User userResult = await _user.FindByNameAsync(dto.UserName);
                var signIn = await this._signIn
                    .CheckPasswordSignInAsync(userResult, dto.Password, false);

                if (userResult == null)
                    ModelState.AddModelError("Username", "Invalid username");
                if (!signIn.Succeeded)
                    ModelState.AddModelError("Password", "Invalid password");

                if (!ModelState.IsValid)
                    return Unauthorized(ModelState as IEnumerable<KeyValuePair<string, ModelStateEntry>>);

                Response.CreateToken(_config);
                return Ok(userResult);

            }
            catch (Exception) { return Unauthorized("Invalid username or password"); }
        }
    }
}