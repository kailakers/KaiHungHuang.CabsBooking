using System;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Entity;
using KaiHungHuang.CabsBooking.Core.Models.Request;
using KaiHungHuang.CabsBooking.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace KaiHungHuang.CabsBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingHistoryController : ControllerBase
    {
        private readonly IBookingHistoryService _bookingHistoryService;

        public BookingHistoryController(IBookingHistoryService bookingHistoryService)
        {
            _bookingHistoryService = bookingHistoryService;
        }

        [HttpGet]
        [Route("allBookingHistory")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookingHistories = await _bookingHistoryService.GetAllBookingHistory();
            if (bookingHistories == null)
                return NotFound("Cannot find any bookings");
            return Ok(bookingHistories);
        }

        [HttpPost]
        [Route("createBookingHistory")]
        public async Task<IActionResult> CreateBooking(BookingHistoryRequestModel bookingHistoryRequestModel)
        {
            if (ModelState.IsValid)
            {
                var bookingHistory = await _bookingHistoryService.CreateBookingHistory(bookingHistoryRequestModel);
                return Ok(bookingHistory);
            }

            return BadRequest(new {Message = "Please correct the information of the booking"});
        }

        [HttpPut]
        [Route("updateBookingHistory")]
        public async Task<IActionResult> UpdateBooking(BookingHistoryRequestModel bookingHistoryRequestModel)
        {
            if (ModelState.IsValid)
            {
                var bookingHistory = await _bookingHistoryService.UpdateBookingHistory(bookingHistoryRequestModel);
                return Ok(bookingHistory);
            }

            return BadRequest(new {Message = "Please correct the information of the booking"});
        }

        [HttpDelete]
        [Route("deleteBookingHistory")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var bookingHistory = await _bookingHistoryService.GetById(id);
            if (bookingHistory == null)
                return NotFound("data not found");
            
            await _bookingHistoryService.DeleteBookingHistory(bookingHistory);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var bookingHistory = await _bookingHistoryService.GetById(id);
            if (bookingHistory == null)
                return NotFound("no data found");
            return Ok(bookingHistory);
        }
    }
}