using System.ServiceModel;

namespace MyPhotos.Business.Contracts
{
    [ServiceContract]
    public interface IMyPhotosFacade : IAttributesService, IPhotosService
    {
    }
}