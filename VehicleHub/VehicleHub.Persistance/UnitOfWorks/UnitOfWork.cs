using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.IRepositories;
using VehicleHub.Application.IUnitOfWorks;
using VehicleHub.Domain.Base;
using VehicleHub.Persistence.Context;
using VehicleHub.Persistence.Repositories;

namespace VehicleHub.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleHubDbContext _dbContext;
        public UnitOfWork(VehicleHubDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async ValueTask DisposeAsync()=>await _dbContext.DisposeAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepository<T>(_dbContext);

        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(_dbContext);

        public int Save() => _dbContext.SaveChanges();

        public async Task<int> SaveAsync() => await _dbContext.SaveChangesAsync();
    }
}
