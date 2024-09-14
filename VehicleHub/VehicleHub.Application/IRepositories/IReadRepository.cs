using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Domain.Base;

namespace VehicleHub.Application.IRepositories
{
    public interface IReadRepository<T> where T : IBaseEntity, new()
    {
        Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            bool enableTracking = false,
            bool includeDeleted = false);
        Task<T> GetByIdAsync(int id, bool tracking = true);
    }
}
