using System;
using MyPhotos.Domain.Common;

namespace MyPhotos.Domain
{
    public partial class File : IEntity
    {
        protected File(string path)
            : this()
        {
            Id = Guid.NewGuid();
            Path = path;
            CreatedAt = DateTime.Now;
        }

        public void Delete()
        {
            this.IsDeleted = true;
        }
    }
}