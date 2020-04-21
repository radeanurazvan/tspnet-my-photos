using System;

namespace MyPhotos.Domain.Common
{
    public interface IEntity
    {
        Guid Id { get; }

        bool IsDeleted { get; }
    }
}