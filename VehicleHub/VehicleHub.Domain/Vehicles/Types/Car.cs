﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHub.Domain.Vehicles.Types
{
    public class Car:Vehicle
    {
        public int NumberOfWheels { get; set; }
        public bool HeadlightsOn { get; set; }
    }
}
