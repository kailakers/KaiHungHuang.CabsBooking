using System.Threading.Tasks;
using KaiHungHuang.CabsBooking.Core.Entity;
using KaiHungHuang.CabsBooking.Core.RepositoryInterface;
using KaiHungHuang.CabsBooking.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KaiHungHuang.CabsBooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabTypeController : ControllerBase
    {
        private readonly ICabTypeService _cabTypeService;

        public CabTypeController(ICabTypeService cabTypeService)
        {
            _cabTypeService = cabTypeService;
        }

        [HttpGet]
        [Route("allCabType")]
        public async Task<IActionResult> GetAllCabType()
        {
            var cabTypes = await _cabTypeService.GetAllCabType();
            if (cabTypes == null)
                return NotFound("No Data Found");
            return Ok(cabTypes);
        }

        [HttpPost]
        [Route("createCabType")]
        public async Task<IActionResult> CreateCabType(CabType cabType)
        {
            if (ModelState.IsValid)
            {
                var response = await _cabTypeService.CreateCabType(cabType);
                return Ok(response);
            }

            return BadRequest(new {Message = "Please Correct the data"});
        }

        [HttpPut]
        [Route("updateCabType")]
        public async Task<IActionResult> UpdateCabType(CabType cabType)
        {
            if (ModelState.IsValid)
            {
                var response = await _cabTypeService.UpdateCabType(cabType);
                return Ok(response);
            }

            return BadRequest(new {Message = "Please Correct the data"});
        }

        [HttpDelete]
        [Route("deleteCabType")]
        public async Task<IActionResult> DeleteCabType(int id)
        {
            var cabType = await _cabTypeService.GetById(id);
            if (cabType == null)
                return NotFound("no data found");
            
            await _cabTypeService.DeleteCabType(cabType);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cabType = await _cabTypeService.GetById(id);
            if (cabType == null)
                return NotFound("no data found");
            return Ok(cabType);
        }
    }
}