using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Domain.Base;

namespace VehicleHub.Application.IRepositories
{
    public interface IWriteRepository<T>where T:IBaseEntity,new()
    {
        Task<T> UpdateAsync(T entity);// Far açma/kapatma işlemi
        Task RemoveAsync(T entity);// Hard delete
        Task DeleteAsync(T entity);// Soft delete
    }
}
