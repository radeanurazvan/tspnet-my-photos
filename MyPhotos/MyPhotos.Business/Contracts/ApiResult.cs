using System.Runtime.Serialization;

namespace MyPhotos.Business.Contracts
{
    [DataContract]
    public class ApiResult
    {
        [DataMember]
        public bool IsSuccess { get; internal set; }

        [DataMember]
        public bool IsFailure { get; internal set; }

        [DataMember]
        public string Error { get; internal set; }
    }

    [DataContract]
    public sealed class ApiResult<T> : ApiResult
        where T : class
    {
        [DataMember]
        public T Value { get; internal set; }
    }
}