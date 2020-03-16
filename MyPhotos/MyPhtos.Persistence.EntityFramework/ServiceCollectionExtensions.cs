using Microsoft.Extensions.DependencyInjection;
using MyPhotos.Domain;
using MyPhotos.Domain.Interfaces;

namespace MyPhotos.Persistence.EntityFramework
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddScoped(typeof(IRepository<>), typeof(EntityFrameworkRepository<>))
                .AddScoped(typeof(IRepository<Photo>), typeof(PhotosRepository));
        }
    }
}