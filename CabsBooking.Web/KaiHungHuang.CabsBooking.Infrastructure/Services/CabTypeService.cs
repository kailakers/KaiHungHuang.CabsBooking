using System.Collections.Generic;
using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Entity;
using KaiHungHuang.CabsBooking.Core.RepositoryInterface;
using KaiHungHuang.CabsBooking.Core.ServiceInterface;

namespace CabsBooking.Infrastructure.Services
{
    public class CabTypeService:ICabTypeService
    {
        private readonly IAsyncRepository<CabType> _cabTypeRepository;
        public CabTypeService(IAsyncRepository<CabType> cabTypeRepository)
        {
            _cabTypeRepository = cabTypeRepository;
        }
        
        public async Task<CabType> CreateCabType(CabType cabType)
        {
            var response = await _cabTypeRepository.AddAsync(cabType);
            return response;
        }

        public async Task<CabType> UpdateCabType(CabType cabType)
        {
            var response = await _cabTypeRepository.UpdateAsync(cabType);
            return response;
        }

        public async Task DeleteCabType(CabType cabType)
        {
            await _cabTypeRepository.DeleteAsync(cabType);
        }

        public Task<IEnumerable<CabType>> GetAllCabType()
        {
            var cabTypes = _cabTypeRepository.ListAllAsync();
            return cabTypes;
        }

        public async Task<CabType> GetById(int id)
        {
            var cabType = await _cabTypeRepository.GetByIdAsync(id);
            return cabType;
        }
    }
}