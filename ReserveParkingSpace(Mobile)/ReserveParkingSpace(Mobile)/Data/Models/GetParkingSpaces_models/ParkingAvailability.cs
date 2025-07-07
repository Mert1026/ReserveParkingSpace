using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_models
{
    public class ParkingAvailability
    {
        public bool Morning { get; set; }
        public bool Afternoon { get; set; }
        public bool FullDay { get; set; }
    }
}
