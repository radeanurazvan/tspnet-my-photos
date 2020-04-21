using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MyPhotos.Business.Contracts
{
    [DataContract]
    public sealed class FileDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Path { get; set; }

        [DataMember]
        public IEnumerable<FileAttributeDto> Attributes { get; set; }

        [DataMember]
        public DateTime CreatedAt { get; set; }
    }

    [DataContract]
    public sealed class FileAttributeDto
    {
        [DataMember]
        public Guid AttributeId { get; set; }

        [DataMember]
        public string AttributeName { get; set; }

        [DataMember]
        public string Value { get; set; }
    }

}