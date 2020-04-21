using System.Data.Entity;
using System.Linq;
using MyPhotos.Domain;

namespace MyPhotos.Persistence.EntityFramework
{
    internal sealed class PhotosRepository : BaseEntityFrameworkRepository<Photo>
    {
        public PhotosRepository(DbContext context) : base(context)
        {
        }

        protected override IQueryable<Photo> DecorateEntities(IQueryable<Photo> entities) =>
            entities.Include($"{nameof(File.FileAttributes)}.{nameof(FileAttribute.Attribute)}");
    }
}