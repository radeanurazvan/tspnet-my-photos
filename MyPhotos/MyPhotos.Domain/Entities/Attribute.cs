using System;
using CSharpFunctionalExtensions;
using MyPhotos.Domain.Common;

namespace MyPhotos.Domain
{
    public partial class Attribute : IEntity
    {
        private Attribute()
        {
            Id = Guid.NewGuid();
        }

        private Attribute(string name, bool allowMultiple)
            : this()
        {
            Name = name;
            AllowsMultipleValues = allowMultiple;
        }

        public static Result<Attribute> Create(string name, bool allowMultiple)
        {
            return Result.FailureIf(string.IsNullOrEmpty(name?.Trim()), "Invalid attribute name!")
                .Map(() => new Attribute(name, allowMultiple));
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}