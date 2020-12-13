using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Shared.Models.Enums;
using Core.Shared.Context;

namespace Core.WebAPI.Extensions
{
  public static partial class Extension
  {
    public static IServiceCollection SetEntityFramework(this IServiceCollection services, IConfiguration config) => Environment.GetScope() == Scopes.Development ?
      services.AddDbContext<ApplicationData>(x => x.UseSqlite   (config.GetConnectionString("Application"), c => c.MigrationsAssembly("Core.WebAPI"))) :
      services.AddDbContext<ApplicationData>(x => x.UseSqlServer(config.GetConnectionString("Application"), c => c.MigrationsAssembly("Core.WebAPI")));
  }
}