using System;
using System.Data.Common;

namespace KaiHungHuang.CabsBooking.Core.Entity
{
    public class Booking
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime? BookingDate { get; set; }
        public string BookingTime { get; set; }
        public int? FromPlace { get; set; }
        public int? ToPlace { get; set; }
        public string PickupAddress { get; set; }
        public string Landmark { get; set; }
        public DateTime? PickupDate { get; set; }
        public string PickupTime { get; set; }
        public int? CabTypeId { get; set; }
        public string ContactNo { get; set; }
        public string Status { get; set; }
        public Place ToPlaceName { get; set; }
        public Place FromPlaceName { get; set; }
        public CabType CabType { get; set; }
    }
}