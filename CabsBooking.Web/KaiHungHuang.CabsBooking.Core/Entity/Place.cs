using System.Collections;
using System.Collections.Generic;

namespace KaiHungHuang.CabsBooking.Core.Entity
{
    public class Place
    {
        public int PlaceId { get; set; }
        public string PlaceName { get; set; }
        public ICollection<BookingHistory> FromPlaceBookingHistories { get; set; }
        public ICollection<BookingHistory> ToPlaceBookingHistories { get; set; }
        public ICollection<Booking> FromPlaceBookings { get; set; }
        public ICollection<Booking> ToPlaceBookings { get; set; }
    }
}