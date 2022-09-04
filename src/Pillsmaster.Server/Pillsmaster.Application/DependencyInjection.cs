using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Pillsmaster.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return services.AddMediatR(assembly);
    }
}