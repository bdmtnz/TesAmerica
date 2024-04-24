using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TesAmerica.Infrastructure;

namespace TesAmerica.Application
{
    public static class ApplicationDI
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            );
        }
    }
}
