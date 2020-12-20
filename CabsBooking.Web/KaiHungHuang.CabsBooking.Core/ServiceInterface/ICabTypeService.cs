using System.Collections.Generic;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Entity;

namespace KaiHungHuang.CabsBooking.Core.ServiceInterface
{
    public interface ICabTypeService
    {
        Task<CabType> CreateCabType(CabType cabType);
        Task<CabType> UpdateCabType(CabType cabType);
        Task DeleteCabType(CabType cabType);
        Task<IEnumerable<CabType>> GetAllCabType();
        Task<CabType> GetById(int id);
    }
}