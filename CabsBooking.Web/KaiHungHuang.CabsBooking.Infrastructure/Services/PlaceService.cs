using System.Collections.Generic;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Entity;
using KaiHungHuang.CabsBooking.Core.RepositoryInterface;
using KaiHungHuang.CabsBooking.Core.ServiceInterface;

namespace CabsBooking.Infrastructure.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IAsyncRepository<Place> _placeRepository;
        public PlaceService(IAsyncRepository<Place> placeRepository)
        {
            _placeRepository = placeRepository;
        }
        public async Task<Place> CreateCabType(Place place)
        {
            var response = await _placeRepository.AddAsync(place);
            return response;
        }

        public async Task<Place> UpdateCabType(Place place)
        {
            var response = await _placeRepository.UpdateAsync(place);
            return response;
        }

        public async Task DeleteCabType(Place place)
        {
            await _placeRepository.DeleteAsync(place);
        }

        public async Task<IEnumerable<Place>> GetAllPlace()
        {
            var places = await _placeRepository.ListAllAsync();
            return places;
        }

        public async Task<Place> GetById(int id)
        {
            var place = await _placeRepository.GetByIdAsync(id);
            return place;
        }
    }
}