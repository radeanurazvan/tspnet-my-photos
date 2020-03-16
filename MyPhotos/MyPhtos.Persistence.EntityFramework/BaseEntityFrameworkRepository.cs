using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using MyPhotos.Domain.Common;
using MyPhotos.Domain.Interfaces;

namespace MyPhotos.Persistence.EntityFramework
{
    internal abstract class BaseEntityFrameworkRepository<T> : IRepository<T>
        where T : class, IEntity
    {
        private readonly DbContext context;
        private readonly IQueryable<T> entitiesSet;

        protected BaseEntityFrameworkRepository(DbContext context)
        {
            this.context = context;
            this.entitiesSet = DecorateEntities(context.Set<T>());
        }

        public async Task<Maybe<T>> GetById(Guid id)
        {
            return await entitiesSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entitiesSet.ToListAsync();
        }

        public Task Add(T entity)
        {
            context.Set<T>().Add(entity);
            return Task.CompletedTask;
        }

        public Task SaveChanges() => context.SaveChangesAsync();

        protected virtual IQueryable<T> DecorateEntities(IQueryable<T> entities) => entities;
    }
}