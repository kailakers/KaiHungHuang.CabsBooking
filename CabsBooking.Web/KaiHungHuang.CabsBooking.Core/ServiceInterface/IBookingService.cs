using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Entity;
using KaiHungHuang.CabsBooking.Core.Models.Request;
using KaiHungHuang.CabsBooking.Core.Models.Response;

namespace KaiHungHuang.CabsBooking.Core.ServiceInterface
{
    public interface IBookingService
    {
        Task<BookingResponseModel> CreateBooking(BookingRequestModel bookingHistoryRequestModel);
        Task<BookingResponseModel> UpdateBooking(BookingRequestModel bookingHistoryRequestModel);
        Task DeleteBooking(Booking booking);
        Task<IEnumerable<Booking>> GetAllBooking();
        Task<Booking> GetById(int id);
        Task<IEnumerable<BookingResponseModel>> GetBookingByCabType(int cabTypeId);
    }
}