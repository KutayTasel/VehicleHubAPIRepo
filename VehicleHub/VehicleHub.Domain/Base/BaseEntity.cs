using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHub.Domain.Base
{
    public abstract class BaseEntity:IBaseEntity
    {
        public int Id { get; set; }
        public DataStatus Status { get; set; } = DataStatus.Created;
        public DateTime Created { get; set; }=DateTime.Now;
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
