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
        Task<IEnumerable<FileDto>> FindByKeyword(string keyword);

        [OperationContract]
        Task<ApiResult<FileDto>> CreatePhoto(string path);

        [OperationContract]
        Task<ApiResult<FileDto>> ChangeTitle(Guid id, string title);

        [OperationContract]
        Task<ApiResult<FileDto>> AddAttributeValue(Guid id, Guid attributeId, string value);

        [OperationContract]
        Task<ApiResult> DeletePhoto(Guid id);
    }
}