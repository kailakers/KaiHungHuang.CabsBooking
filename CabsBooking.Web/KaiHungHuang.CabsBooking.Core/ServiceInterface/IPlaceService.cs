using System.Collections.Generic;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Entity;

namespace KaiHungHuang.CabsBooking.Core.ServiceInterface
{
    public interface IPlaceService
    {
        Task<Place> CreateCabType(Place place);
        Task<Place> UpdateCabType(Place place);
        Task DeleteCabType(Place place);
        Task<IEnumerable<Place>> GetAllPlace();
        Task<Place> GetById(int id);
    }
}