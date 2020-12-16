using Core.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Core.WebAPI.Extensions
{
    public static partial class Extension
    {
        public static IServiceCollection SetDependencies(this IServiceCollection services) =>
            services
            .AddScoped<ISmtpRepository, SmtpRepository>()
            .AddScoped<ITokenHandler, TokenHandler>()
            .AddScoped<IAppointmentRepository, AppointmentRepository>()
            .AddScoped<IMemberRepository, MemberRepository>()
            .AddScoped<IPoochRepository, PoochRepository>()
            .AddSingleton<IActivityLogger, ActivityLogger>();
    }
}