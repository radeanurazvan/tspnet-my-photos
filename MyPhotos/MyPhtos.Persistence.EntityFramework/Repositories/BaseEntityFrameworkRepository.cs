using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Linq.Expressions;
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
            this.entitiesSet = DecorateEntities(context.Set<T>().Where(e => !e.IsDeleted));
        }

        public async Task<Maybe<T>> GetById(Guid id)
        {
            return await entitiesSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Maybe<T>> FindOne(Expression<Func<T, bool>> predicate)
        {
            return await entitiesSet.FirstOrDefaultAsync(predicate);
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

        public async Task SaveChanges()
        {
            await context.SaveChangesAsync();
        }

        protected virtual IQueryable<T> DecorateEntities(IQueryable<T> entities) => entities;
    }

    internal static class MissingDllHack
    {
        private static SqlProviderServices instance = SqlProviderServices.Instance;
    }
}