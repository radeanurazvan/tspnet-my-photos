using Microsoft.Extensions.DependencyInjection;
using MyPhotos.Business.Contracts;
using MyPhotos.Business.Implementations;

namespace MyPhotos.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            return services
                .AddScoped<IAttributesService, MyPhotosService>()
                .AddScoped<IPhotosService, MyPhotosService>()
                .AddScoped<IMyPhotosFacade, MyPhotosService>();
        }
    }
}