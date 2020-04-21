using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace MyPhotos.Business.Contracts
{
    [ServiceContract]
    public interface IAttributesService
    {
        [OperationContract]
        Task<IEnumerable<AttributeDto>> GetAttributes();

        [OperationContract]
        Task<ApiResult<AttributeDto>> CreateAttribute(AttributeDto dto);

        [OperationContract]
        Task<ApiResult> DeleteAttribute(Guid id);
    }
}