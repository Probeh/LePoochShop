using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Core.Shared.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Shared.Interfaces
{
    public interface ITokenHandler
    {
        Task CreateToken(User user, HttpResponse response);
    }
    public class TokenHandler : ITokenHandler
    {
        // ======================================= //
        private readonly SymmetricSecurityKey _security;
        private readonly UserManager<User> _userManager;
        // ======================================= //
        public TokenHandler(IConfiguration config, UserManager<User> userManager)
        {
            this._security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Secret"]));
            this._userManager = userManager;
        }
        // ======================================= //
        public async Task CreateToken(User user, HttpResponse response)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            };

            claims.AddRange((await _userManager.GetRolesAsync(user)).Select(role => new Claim(ClaimTypes.Role, role)));

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(_security, SecurityAlgorithms.HmacSha512Signature)
            };

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(descriptor);
            var output = handler.WriteToken(token);
            response.Headers.Add("X-Authorization", output);
            response.Headers.Add("Access-Control-Expose-Headers", "X-Authorization");
        }
    }
}