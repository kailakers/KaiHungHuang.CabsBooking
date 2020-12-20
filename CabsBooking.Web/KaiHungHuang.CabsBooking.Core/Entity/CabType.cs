using System.Collections;
using System.Collections.Generic;

namespace KaiHungHuang.CabsBooking.Core.Entity
{
    public class CabType
    {
        public int CabTypeId { get; set; }
        public string CabTypeName { get; set; }
        public ICollection<BookingHistory> BookingHistories { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}