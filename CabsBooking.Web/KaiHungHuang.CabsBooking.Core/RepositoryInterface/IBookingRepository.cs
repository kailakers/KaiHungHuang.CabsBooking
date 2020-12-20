using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Models.Response;
using KaiHungHuang.CabsBooking.Core.Entity;

namespace KaiHungHuang.CabsBooking.Core.RepositoryInterface
{
    public interface IBookingRepository: IAsyncRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByCabType(int cabTypeId);
    }
}