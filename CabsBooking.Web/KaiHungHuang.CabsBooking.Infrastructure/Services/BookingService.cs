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
    public class BookingService: IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IAsyncRepository<Place> _placeRepository;
        public BookingService(IBookingRepository bookingRepository, IAsyncRepository<Place> placeRepository)
        {
            _bookingRepository = bookingRepository;
            _placeRepository = placeRepository;
        }
        
        public async Task<BookingResponseModel> CreateBooking(BookingRequestModel bookingRequestModel)
        {
            var booking = new Booking
            {
                Email = bookingRequestModel.Email,
                BookingDate = bookingRequestModel.BookingDate,
                BookingTime = bookingRequestModel.BookingTime,
                FromPlace = bookingRequestModel.FromPlace,
                ToPlace = bookingRequestModel.ToPlace,
                PickupAddress = bookingRequestModel.PickupAddress,
                Landmark = bookingRequestModel.Landmark,
                PickupDate = bookingRequestModel.PickupDate,
                PickupTime = bookingRequestModel.PickupTime,
                CabTypeId = bookingRequestModel.CabTypeId,
                ContactNo = bookingRequestModel.ContactNo,
                Status = bookingRequestModel.Status
            };
            var createdBooking = await _bookingRepository.AddAsync(booking);
            var response = new BookingResponseModel
            {
                Id = createdBooking.Id,
                BookingDate = createdBooking.BookingDate,
                BookingTime = createdBooking.BookingTime,
                CabTypeId = createdBooking.CabTypeId,
                ContactNo = createdBooking.ContactNo,
                Email = createdBooking.Email,
                FromPlace = createdBooking.FromPlace,
                ToPlace = createdBooking.ToPlace,
                Landmark = createdBooking.Landmark,
                PickupAddress = createdBooking.PickupAddress,
                PickupDate = createdBooking.PickupDate,
                PickupTime = createdBooking.PickupTime,
                Status = createdBooking.Status,
            };
            return response;
        }

        public async Task<BookingResponseModel> UpdateBooking(BookingRequestModel bookingRequestModel)
        {
            var booking = new Booking
            {
                Id = bookingRequestModel.Id,
                Email = bookingRequestModel.Email,
                BookingDate = bookingRequestModel.BookingDate,
                BookingTime = bookingRequestModel.BookingTime,
                FromPlace = bookingRequestModel.FromPlace,
                ToPlace = bookingRequestModel.ToPlace,
                PickupAddress = bookingRequestModel.PickupAddress,
                Landmark = bookingRequestModel.Landmark,
                PickupDate = bookingRequestModel.PickupDate,
                PickupTime = bookingRequestModel.PickupTime,
                CabTypeId = bookingRequestModel.CabTypeId,
                ContactNo = bookingRequestModel.ContactNo,
                Status = bookingRequestModel.Status
            };
            var updatedBooking = await _bookingRepository.UpdateAsync(booking);
            var response = new BookingResponseModel
            {
                Id = updatedBooking.Id,
                Email = updatedBooking.Email,
                BookingDate = updatedBooking.BookingDate,
                BookingTime = updatedBooking.BookingTime,
                FromPlace = updatedBooking.FromPlace,
                ToPlace = updatedBooking.ToPlace,
                PickupAddress = updatedBooking.PickupAddress,
                Landmark = updatedBooking.Landmark,
                PickupDate = updatedBooking.PickupDate,
                CabTypeId = updatedBooking.CabTypeId,
                ContactNo = updatedBooking.ContactNo,
                Status = updatedBooking.Status
            };
            return response;
        }

        public async Task DeleteBooking(Booking booking)
        {
            var bookings = await _bookingRepository.ListAsync(b => b.Id == booking.Id);
            await _bookingRepository.DeleteAsync(bookings.First());
        }
        
        public async Task<IEnumerable<Booking>> GetAllBooking()
        {
            var bookings = await _bookingRepository.ListAllAsync();
            return bookings;
        }

        public async Task<Booking> GetById(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            return booking;
        }

        public async Task<IEnumerable<BookingResponseModel>> GetBookingByCabType(int cabTypeId)
        {
            var bookings = await _bookingRepository.GetBookingsByCabType(cabTypeId);
            var bookingResponseModel = new List<BookingResponseModel>();
            foreach (var booking in bookings)
            {
                bookingResponseModel.Add(new BookingResponseModel
                {
                    Id = booking.Id,
                    BookingDate = booking.BookingDate,
                    BookingTime = booking.BookingTime,
                    CabTypeId = booking.CabTypeId,
                    ContactNo = booking.ContactNo,
                    Email = booking.Email,
                    FromPlace = booking.FromPlace,
                    ToPlace = booking.ToPlace,
                    PickupAddress = booking.PickupAddress,
                    Landmark = booking.Landmark,
                    PickupDate = booking.PickupDate,
                    PickupTime = booking.PickupTime,
                    Status = booking.Status,
                    CabTypeName = booking.CabType.CabTypeName,
                    FromPlaceName = booking.FromPlaceName.PlaceName,
                    ToPlaceName = booking.ToPlaceName.PlaceName,
                });
            }

            return bookingResponseModel;
        }
    }
}