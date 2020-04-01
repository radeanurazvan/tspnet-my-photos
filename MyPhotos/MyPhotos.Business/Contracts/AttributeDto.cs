using System;
using System.Runtime.Serialization;

namespace MyPhotos.Business.Contracts
{
    [DataContract]
    public sealed class AttributeDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool AllowsMultipleValues { get; set; }
    }
}