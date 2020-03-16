using System.Data.Entity;
using Microsoft.Extensions.DependencyInjection;

namespace MyPhotos.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services.AddScoped<DbContext>(_ => new FileModelContainer());
        }
    }
}