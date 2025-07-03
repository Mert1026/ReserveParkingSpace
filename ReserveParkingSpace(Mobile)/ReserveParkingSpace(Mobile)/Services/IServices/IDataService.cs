using ReserveParkingSpace_Mobile_.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveParkingSpace_Mobile_.Services.IServices
{
    interface IDataService
    {
        public Task<List<Reservation>> GetReservationsAsync();
        public Task<LoginResponse> LoginAsync(string email, string password);
    }
}