using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Application.IRepositories;
using VehicleHub.Domain.Base;

namespace VehicleHub.Application.IUnitOfWorks
{
    public interface IUnitOfWork: IAsyncDisposable
    {
        IReadRepository<T> GetReadRepository<T>() where T : BaseEntity, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : BaseEntity, new();
        Task<int> SaveAsync();  
        int Save();
    }
}
