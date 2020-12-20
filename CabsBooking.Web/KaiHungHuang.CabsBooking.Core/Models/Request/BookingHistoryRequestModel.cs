using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace KaiHungHuang.CabsBooking.Core.Models.Request
{
    public class BookingHistoryRequestModel
    {
        public int Id { get; set; }
        [AllowNull]
        [StringLength(50)]
        public string Email { get; set; }
        public DateTime? BookingDate { get; set; }
        [AllowNull]
        [StringLength(5)]
        public string BookingTime { get; set; }
        public int? FromPlace { get; set; }
        public int? ToPlace { get; set; }
        [AllowNull]
        [StringLength(200)]
        public string PickupAddress { get; set; }
        [AllowNull]
        [StringLength(30)]
        public string Landmark { get; set; }
        public DateTime? PickupDate { get; set; }
        [AllowNull]
        [StringLength(5)]
        public string PickupTime { get; set; }
        public int? CabTypeId { get; set; }
        [AllowNull]
        [StringLength(25)]
        public string ContactNo { get; set; }
        [AllowNull]
        [StringLength(30)]
        public string Status { get; set; }
        [AllowNull]
        [StringLength(5)]
        public string Comp_time { get; set; }
        public decimal? Charge { get; set; }
        [AllowNull]
        [StringLength(1000)]
        public string Feedback { get; set; }
    }
}