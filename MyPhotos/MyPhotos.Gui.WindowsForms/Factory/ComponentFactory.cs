using System;
using Microsoft.Extensions.DependencyInjection;

namespace MyPhotos.Gui.WindowsForms.Factory
{
    internal sealed class ComponentFactory : IComponentFactory
    {
        private readonly IServiceProvider provider;

        public ComponentFactory(IServiceProvider provider)
        {
            this.provider = provider;
        }

        public T Resolve<T>() => provider.GetRequiredService<T>();
    }
}