using System.Collections.Generic;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Entity;
using KaiHungHuang.CabsBooking.Core.Models.Request;
using KaiHungHuang.CabsBooking.Core.Models.Response;

namespace KaiHungHuang.CabsBooking.Core.ServiceInterface
{
    public interface IBookingHistoryService
    {
        Task<BookingHistoryResponseModel> CreateBookingHistory(BookingHistoryRequestModel bookingHistoryRequestModel);
        Task<BookingHistoryResponseModel> UpdateBookingHistory(BookingHistoryRequestModel bookingHistoryRequestModel);
        Task DeleteBookingHistory(BookingHistory bookingHistory);
        Task<IEnumerable<BookingHistory>> GetAllBookingHistory();
        Task<BookingHistory> GetById(int id);
    }
}