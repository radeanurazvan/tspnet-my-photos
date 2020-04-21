using System.Data.Entity;
using MyPhotos.Domain.Common;

namespace MyPhotos.Persistence.EntityFramework
{
    internal sealed class EntityFrameworkRepository<T> : BaseEntityFrameworkRepository<T>
        where T : class, IEntity
    {
        public EntityFrameworkRepository(DbContext context) : base(context)
        {
        }
    }
}