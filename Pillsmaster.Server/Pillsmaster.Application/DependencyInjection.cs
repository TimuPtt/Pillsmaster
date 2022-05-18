using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Pillsmaster.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicator(
            this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
