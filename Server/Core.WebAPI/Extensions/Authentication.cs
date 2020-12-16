using System.Text;
using Core.Shared.Context;
using Core.Shared.Models.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Core.WebAPI.Extensions
{
    public static partial class Extension
    {
        public static IServiceCollection SetAuthentication(this IServiceCollection services, IConfiguration config)
        {
            return services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey         = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(config.GetSection("AppSettings:Secret").Value)),
                        ValidateAudience         = false,
                        ValidateIssuer           = false,
                        ValidateIssuerSigningKey = true
                    };
                }).Services
                .AddIdentityCore<User>(options =>
                {
                    options.Password.RequireDigit            = false;
                    options.Password.RequiredLength          = 6    ;
                    options.Password.RequireLowercase        = false;
                    options.Password.RequireNonAlphanumeric  = false;
                    options.Password.RequireUppercase        = false;
                    options.SignIn  .RequireConfirmedAccount = false;
                })
                .AddRoles<Role>()
                .AddRoleManager<RoleManager<Role>>()
                .AddSignInManager<SignInManager<User>>()
                .AddRoleValidator<RoleValidator<Role>>()
                .AddEntityFrameworkStores<ApplicationData>().Services;
        }
    }
}