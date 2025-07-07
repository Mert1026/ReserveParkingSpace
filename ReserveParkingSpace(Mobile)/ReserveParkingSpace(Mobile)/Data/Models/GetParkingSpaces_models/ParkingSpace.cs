using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_models
{
    public class ParkingSpace
    {
        public string Id { get; set; }
        public int SpaceNumber { get; set; }
        public ParkingAvailability IsAvailable { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
    }
}
