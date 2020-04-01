using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MyPhotos.Business.Contracts
{
    [ServiceContract]
    public interface IPhotosService
    {
        [OperationContract]
        Task<IEnumerable<FileDto>> GetPhotos();

        [OperationContract]
        Task<ApiResult> CreatePhoto(string path);

        [OperationContract]
        Task<ApiResult> DeletePhoto(Guid id);
    }
}