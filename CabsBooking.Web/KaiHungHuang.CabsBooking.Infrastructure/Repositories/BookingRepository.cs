using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Entity;
using KaiHungHuang.CabsBooking.Core.Models.Response;
using KaiHungHuang.CabsBooking.Core.RepositoryInterface;
using CabsBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CabsBooking.Infrastructure.Repositories
{
    public class BookingRepository: EfRepository<Booking>, IBookingRepository
    {
        public BookingRepository(CabsBookingDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Booking>> GetBookingsByCabType(int cabTypeId)
        {
            var bookings = await _dbContext.Bookings
                .Include(b => b.CabType).Where(b=>b.CabTypeId == cabTypeId)
                .Include(b=>b.ToPlaceName)
                .Include(b=>b.FromPlaceName)
                .ToListAsync();

            return bookings;
        }
    }
}