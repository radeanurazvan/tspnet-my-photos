using Microsoft.Extensions.DependencyInjection;
using MyPhotos.Gui.WindowsForms.Factory;
using MyPhotos.Gui.WindowsForms.Forms;

namespace MyPhotos.Gui.WindowsForms
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            return services.AddScoped<IComponentFactory, ComponentFactory>()
                .AddScoped<AttributesForm>()
                .AddScoped<MainForm>();
        }
    }
}