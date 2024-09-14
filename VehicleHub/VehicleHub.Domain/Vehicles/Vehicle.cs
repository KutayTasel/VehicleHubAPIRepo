using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleHub.Domain.Base;

namespace VehicleHub.Domain.Vehicles
{
    public abstract class Vehicle:BaseEntity
    {
        public string Color { get; set; }
    }
}
