using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.IRepositories;
using VehicleHub.Domain.Base;
using VehicleHub.Persistence.Context;

namespace VehicleHub.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity, new()
    {
        private readonly DbContext _dbContext;
        public ReadRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> Table => _dbContext.Set<T>();

        public async Task<IList<T>> GetAllAsync(
    Expression<Func<T, bool>>? predicate = null,
    Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    bool enableTracking = false,
    bool includeDeleted = false)
        {
            IQueryable<T> queryable = Table;

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include is not null)
                queryable = include(queryable);

            if (!includeDeleted)
                queryable = queryable.Where(x => x.Status != DataStatus.Deleted);

            if (predicate is not null)
                queryable = queryable.Where(predicate);

            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }


        public async Task<T> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();

            if (!tracking)
                query = query.AsNoTracking();

            var entity = await query.FirstOrDefaultAsync(data => data.Id == id);

            if (entity == null)
            {
                throw new KeyNotFoundException($"Entity with ID {id} could not be found.");
            }

            return entity;
        }
    }
}
