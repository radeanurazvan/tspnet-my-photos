using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MyPhotos.Domain;

namespace MyPhotos.Business.Contracts
{
    [DataContract]
    public sealed class FileDto
    {
        public FileDto()
        {
            
        }

        public FileDto(File file)
            : this()
        {
            Id = file.Id;
            Title = file.Title;
            Path = file.Path;
            CreatedAt = file.CreatedAt;
            Attributes = file.FileAttributes.Select(fa => new FileAttributeDto(fa));
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Title { get; set; }

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
        public FileAttributeDto()
        {
            
        }

        public FileAttributeDto(FileAttribute attribute)
            : this()
        {
            AttributeId = attribute.AttributeId.GetValueOrDefault();
            AttributeName = attribute.Attribute?.Name;
            Value = attribute.Value;
        }

        [DataMember]
        public Guid AttributeId { get; set; }

        [DataMember]
        public string AttributeName { get; set; }

        [DataMember]
        public string Value { get; set; }
    }

}