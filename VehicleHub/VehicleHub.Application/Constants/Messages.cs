using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleHub.Application.Constants
{
    public static class Messages
    {
        public static readonly string CarNotFound = "Car not found.";
        public static readonly string BusNotFound = "Bus not found.";
        public static readonly string BoatNotFound = "Boat not found.";
        public static readonly string CarDeletedSuccessfully = "Car successfully deleted.";
        public static readonly string HeadlightsTurnedOn = "Headlights have been turned on.";
        public static readonly string HeadlightsTurnedOff = "Headlights have been turned off.";
        public static readonly string InvalidColorSelection = "Invalid color selection. Please choose between red, blue, black, or white.";
        public static readonly string InvalidId = "Invalid vehicle ID.";
        public static readonly string ActionFailed = "An error occurred while performing the action. Please try again.";
        public static readonly string VehicleTypeNotSupported = "Unsupported vehicle type. Please select a valid vehicle type.";
    }
}
