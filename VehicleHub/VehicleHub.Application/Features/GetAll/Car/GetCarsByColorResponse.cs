using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHub.Application.Features.GetAll.Car
{
    public class GetCarsByColorResponse
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int NumberOfWheels { get; set; }
        public bool HeadlightsOn { get; set; }
    }

}
