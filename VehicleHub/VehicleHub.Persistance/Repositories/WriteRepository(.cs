using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.IRepositories;
using VehicleHub.Domain.Base;

namespace VehicleHub.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity, new()
    {
        private readonly DbContext _dbContext;
        public WriteRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> Table { get => _dbContext.Set<T>(); }
        public async Task DeleteAsync(T entity)
        {
            entity.Status = DataStatus.Deleted;
            entity.Deleted = DateTime.UtcNow;
            Table.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            Table.Remove(entity);               
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            entity.Status = DataStatus.Updated; 
            entity.Updated = DateTime.UtcNow;  
            Table.Update(entity);               
            await _dbContext.SaveChangesAsync(); 
            return entity;
        }
    }
}
