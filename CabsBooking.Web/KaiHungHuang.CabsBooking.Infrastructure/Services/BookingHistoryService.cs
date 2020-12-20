using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Entity;
using KaiHungHuang.CabsBooking.Core.Models.Request;
using KaiHungHuang.CabsBooking.Core.Models.Response;
using KaiHungHuang.CabsBooking.Core.RepositoryInterface;
using KaiHungHuang.CabsBooking.Core.ServiceInterface;

namespace CabsBooking.Infrastructure.Services
{
    public class BookingHistoryService : IBookingHistoryService
    {
        private readonly IAsyncRepository<BookingHistory> _bookingHistoryService;
        public BookingHistoryService(IAsyncRepository<BookingHistory> bookingHistoryService)
        {
            _bookingHistoryService = bookingHistoryService;
        }
        public async Task<BookingHistoryResponseModel> CreateBookingHistory(BookingHistoryRequestModel bookingHistoryRequestModel)
        {
            var bookingHistory = new BookingHistory
            {
                Email = bookingHistoryRequestModel.Email,
                BookingDate = bookingHistoryRequestModel.BookingDate,
                BookingTime = bookingHistoryRequestModel.BookingTime,
                FromPlace = bookingHistoryRequestModel.FromPlace,
                ToPlace = bookingHistoryRequestModel.ToPlace,
                PickupAddress = bookingHistoryRequestModel.PickupAddress,
                Landmark = bookingHistoryRequestModel.Landmark,
                PickupDate = bookingHistoryRequestModel.PickupDate,
                PickupTime = bookingHistoryRequestModel.PickupTime,
                CabTypeId = bookingHistoryRequestModel.CabTypeId,
                ContactNo = bookingHistoryRequestModel.ContactNo,
                Status = bookingHistoryRequestModel.Status,
                Comp_time = bookingHistoryRequestModel.Comp_time,
                Charge = bookingHistoryRequestModel.Charge,
                Feedback = bookingHistoryRequestModel.Feedback
            };
            var createdBookingHistory = await _bookingHistoryService.AddAsync(bookingHistory);
            var response = new BookingHistoryResponseModel()
            {
                Id = createdBookingHistory.Id,
                Email = createdBookingHistory.Email,
                BookingDate = createdBookingHistory.BookingDate,
                BookingTime = createdBookingHistory.BookingTime,
                FromPlace = createdBookingHistory.FromPlace,
                ToPlace = createdBookingHistory.ToPlace,
                PickupAddress = createdBookingHistory.PickupAddress,
                Landmark = createdBookingHistory.Landmark,
                PickupDate = createdBookingHistory.PickupDate,
                CabTypeId = createdBookingHistory.CabTypeId,
                ContactNo = createdBookingHistory.ContactNo,
                Status = createdBookingHistory.Status,
                Comp_time = createdBookingHistory.Comp_time,
                Charge = createdBookingHistory.Charge,
                Feedback = createdBookingHistory.Feedback
            };
            return response;
        }

        public async Task<BookingHistoryResponseModel> UpdateBookingHistory(BookingHistoryRequestModel bookingHistoryRequestModel)
        {
            var bookingHistory = new BookingHistory
            {
                Id = bookingHistoryRequestModel.Id,
                Email = bookingHistoryRequestModel.Email,
                BookingDate = bookingHistoryRequestModel.BookingDate,
                BookingTime = bookingHistoryRequestModel.BookingTime,
                FromPlace = bookingHistoryRequestModel.FromPlace,
                ToPlace = bookingHistoryRequestModel.ToPlace,
                PickupAddress = bookingHistoryRequestModel.PickupAddress,
                Landmark = bookingHistoryRequestModel.Landmark,
                PickupDate = bookingHistoryRequestModel.PickupDate,
                PickupTime = bookingHistoryRequestModel.PickupTime,
                CabTypeId = bookingHistoryRequestModel.CabTypeId,
                ContactNo = bookingHistoryRequestModel.ContactNo,
                Status = bookingHistoryRequestModel.Status,
                Comp_time = bookingHistoryRequestModel.Comp_time,
                Charge = bookingHistoryRequestModel.Charge,
                Feedback = bookingHistoryRequestModel.Feedback
            };
            var updatedBookingHistory = await _bookingHistoryService.UpdateAsync(bookingHistory);
            var response = new BookingHistoryResponseModel()
            {
                Id = updatedBookingHistory.Id,
                Email = updatedBookingHistory.Email,
                BookingDate = updatedBookingHistory.BookingDate,
                BookingTime = updatedBookingHistory.BookingTime,
                FromPlace = updatedBookingHistory.FromPlace,
                ToPlace = updatedBookingHistory.ToPlace,
                PickupAddress = updatedBookingHistory.PickupAddress,
                Landmark = updatedBookingHistory.Landmark,
                PickupDate = updatedBookingHistory.PickupDate,
                CabTypeId = updatedBookingHistory.CabTypeId,
                ContactNo = updatedBookingHistory.ContactNo,
                Status = updatedBookingHistory.Status,
                Comp_time = updatedBookingHistory.Comp_time,
                Charge = updatedBookingHistory.Charge,
                Feedback = updatedBookingHistory.Feedback
            };
            return response;
        }

        public async Task DeleteBookingHistory(BookingHistory bookingHistory)
        {
            var bookingHistories = await _bookingHistoryService
                .ListAsync(b => b.Id == bookingHistory.Id);
            await _bookingHistoryService.DeleteAsync(bookingHistories.First());
        }

        public async Task<IEnumerable<BookingHistory>> GetAllBookingHistory()
        {
            var bookings = await _bookingHistoryService.ListAllAsync();
            return bookings;
        }

        public async Task<BookingHistory> GetById(int id)
        {
            var bookingHistory = await _bookingHistoryService.GetByIdAsync(id);
            return bookingHistory;
        }
    }
}