using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Data.Models.AddingReservation_Models
{
    public class ParkingReservationRequest
    {
        public string SpaceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ShiftType { get; set; }
        [DefaultValue(null)]
        public byte[]? ScheduleDocument { get; set; }
        [DefaultValue(null)]
        public string? ScheduleDocumentFileName { get; set; }
    }
}
