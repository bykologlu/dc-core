﻿using DC.Core.Data.DynamicQuery;
using DC.Core.Data.Paging;
using DC.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace DC.Core.Data.Repository
{
    public interface IEntityRepository<T> where T : class, IEntity
    {
        Task<T> Get(Expression<Func<T, bool>> predicate);

        Task<IPaginate<T>> GetList(Expression<Func<T, bool>>? predicate = null,
                                 Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
                                 Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                 int index = 0, int size = 10,
                                 bool enableTracking = true,
                                 CancellationToken cancellationToken = default);

        Task<IPaginate<T>> GetListByDynamic(Dynamic dynamic,
                                          Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
                                          int index = 0, int size = 10, bool enableTracking = true,
                                          CancellationToken cancellationToken = default);

        IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate);

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(T entity);

        Task DeleteById(int id);

        Task SaveChangesAsync();

        Task ExecuteSQL(string query);

        Task CreateExecutionStrategyAsync(Func<Task> operation);

        TContext GetContext<TContext>() where TContext : DbContext;
    }
}