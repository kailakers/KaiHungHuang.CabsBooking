using System;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Models.Request;
using KaiHungHuang.CabsBooking.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace KaiHungHuang.CabsBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        [Route("allBookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBooking();
            if (bookings == null)
                return NotFound("Cannot find any bookings");
            return Ok(bookings);
        }

        [HttpPost]
        [Route("createBooking")]
        public async Task<IActionResult> CreateBooking(BookingRequestModel bookingRequestModel)
        {
            if (ModelState.IsValid)
            {
                var booking = await _bookingService.CreateBooking(bookingRequestModel);
                return Ok(booking);
            }

            return BadRequest(new {Message = "Please correct the information of the booking"});
        }

        [HttpPut]
        [Route("updateBooking")]
        public async Task<IActionResult> UpdateBooking(BookingRequestModel bookingRequestModel)
        {
            Console.WriteLine(bookingRequestModel);
            if (ModelState.IsValid)
            {
                var booking = await _bookingService.UpdateBooking(bookingRequestModel);
                return Ok(booking);
            }

            return BadRequest(new {Message = "Please correct the information of the booking"});
        }

        [HttpDelete]
        [Route("deleteBooking")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _bookingService.GetById(id);
            if (booking == null)
                return NotFound("data not found");
            await _bookingService.DeleteBooking(booking);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var booking = await _bookingService.GetById(id);
            if (booking == null)
                return NotFound("No data found");
            return Ok(booking);
        }

        [HttpGet]
        [Route("CabType/{id:int}")]
        public async Task<IActionResult> GetByCabType(int id)
        {
            var bookings = await _bookingService.GetBookingByCabType(id);
            if (bookings == null)
                return NotFound("No data found");
            return Ok(bookings);
        }
    }
}