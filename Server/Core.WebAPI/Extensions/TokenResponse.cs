using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.WebAPI.Extensions
{
    public static partial class Extension
    {
        public static void GenerateToken(this HttpResponse response, IConfiguration Configuration)
        {
            var security = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Secret").Value));
            var credential = new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);
            var descriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credential
            };
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(descriptor);

            response.Headers.Add("X-Authorization", handler.WriteToken(token));
            response.Headers.Add("Access-Control-Expose-Headers", "X-Authorization");
        }
    }
}