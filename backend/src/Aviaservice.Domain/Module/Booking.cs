using System;
using System.Collections.Generic;
using System.Text;

namespace Aviaservice.Domain.Module
{
    public class Booking
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public Guid FlightId { get; set; }
        public Enum Status { get; set; } = default!;
        public string SeatNumber { get; set; } = default!;
        public decimal Price { get; set; }
        public DateTime BookingDate { get; set;}
        public DateTime ExpiryDate { get; set; }
    }
}
