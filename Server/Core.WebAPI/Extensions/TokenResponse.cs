using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.WebAPI.Extensions
{
    public static partial class Extensions
    {
        public static void CreateToken(this HttpResponse response, IConfiguration config)
        {
            var symmetrics = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("AppSettings:Secret").Value));
            var credential = new SigningCredentials(symmetrics, SecurityAlgorithms.HmacSha512Signature);
            var descriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credential
            };
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(descriptor);

            response.Headers.Add("Authorization", $"Bearer {handler.WriteToken(token)}");
            response.Headers.Add("Access-Control-Expose-Headers", "Authorization"  );
        }
    }
}