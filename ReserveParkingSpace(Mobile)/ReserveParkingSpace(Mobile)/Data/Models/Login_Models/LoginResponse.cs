using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Data.Models.Login_Models
{
    public class LoginResponse
    {
        public bool success { get; set; }
        public User user { get; set; }
        public string token { get; set; }
    }
}
