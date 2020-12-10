using Microsoft.Extensions.DependencyInjection;
using Core.Shared.Interfaces;

namespace Core.WebAPI.Extensions
{
    public static partial class Extension
    {
        public static IServiceCollection SetDependencies(this IServiceCollection services) =>
            services
            .AddScoped<ISmtpRepository, SmtpRepository>()
            .AddScoped<IActivityLogger, ActivityLogger>()
            .AddScoped(typeof(IModelRepository<>), typeof(ModelRepository<>));
    }
}