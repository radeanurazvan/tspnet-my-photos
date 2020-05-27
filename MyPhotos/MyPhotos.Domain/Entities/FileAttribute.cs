using System;
using CSharpFunctionalExtensions;

namespace MyPhotos.Domain
{
    public partial class FileAttribute
    {
        private FileAttribute()
        {
            Id = Guid.NewGuid();
        }

        private FileAttribute(File file, Attribute attribute, string value)
            : this()
        {
            FileId = file.Id;
            File = file;
            AttributeId = attribute.Id;
            Attribute = attribute;
            Value = value;
        }

        internal static Result<FileAttribute> Create(File file, Attribute attribute, string value)
        {
            var attributeResult = Maybe<Attribute>.From(attribute).ToResult("Attribute is required!");
            var valuesResult = Maybe<string>.From(value).ToResult("Attribute is required!")
                .Ensure(s => !string.IsNullOrEmpty(s?.Trim()), "Invalid attribute value!");

            return Result.FirstFailureOrSuccess(attributeResult, valuesResult)
                .Map(() => new FileAttribute(file, attribute, value));
        }
    }
}