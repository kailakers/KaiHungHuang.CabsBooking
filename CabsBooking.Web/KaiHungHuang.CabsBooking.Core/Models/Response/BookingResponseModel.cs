using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using KaiHungHuang.CabsBooking.Core.Entity;

namespace KaiHungHuang.CabsBooking.Core.Models.Response
{
    public class BookingResponseModel
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

        public string ToPlaceName { get; set; }
        public string FromPlaceName { get; set; }
        public string CabTypeName { get; set; }
        
    }
}