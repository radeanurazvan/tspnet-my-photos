namespace MyPhotos.Gui.WindowsForms.Factory
{
    public interface IComponentFactory
    {
        T Resolve<T>();
    }
}