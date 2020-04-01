using MyPhotos.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace MyPhotos.Domain.Interfaces
{
    public interface IRepository<T>
        where T : IEntity
    {
        Task<Maybe<T>> GetById(Guid id);

        Task<Maybe<T>> FindOne(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAll();

        Task Add(T entity);

        Task SaveChanges();
    }
}