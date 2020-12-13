using Core.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Core.WebAPI.Extensions
{
    public static partial class Extension
    {
        public static IServiceCollection SetDependencies(this IServiceCollection services) =>
            services
            .AddScoped<ISmtpRepository, SmtpRepository>()
            .AddScoped<IActivityLogger, ActivityLogger>()
            .AddScoped<ITokenHandler  , TokenHandler  >()
            .AddScoped(typeof(IModelRepository<>), typeof(ModelRepository<>));
    }
}