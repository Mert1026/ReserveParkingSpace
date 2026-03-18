using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Data.Models.GetParkingSpaces_Models
{
    public class ParkingDashboardResponse
    {
        public bool Success { get; set; }
        public string Date { get; set; }
        public List<ParkingSpace> Spaces { get; set; }
    }
}
