using System.Security.AccessControl;
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
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        [Route("getAllPlaces")]
        public async Task<IActionResult> GetAllPlaces()
        {
            var places = await _placeService.GetAllPlace();
            if (places == null)
                return NotFound("No Data Found");
            return Ok(places);
        }

        [HttpPost]
        [Route("createPlace")]
        public async Task<IActionResult> CreatePlace(Place place)
        {
            if (ModelState.IsValid)
            {
                var response = await _placeService.CreateCabType(place);
                return Ok(response);
            }

            return BadRequest(new {Message = "Please Correct the data"});
        }

        [HttpPut]
        [Route("updatePlace")]
        public async Task<IActionResult> UpdatePlace(Place place)
        {
            if (ModelState.IsValid)
            {
                var response = await _placeService.UpdateCabType(place);
                return Ok(response);
            }
            return BadRequest(new {Message = "Please Correct the data"});
        }

        [HttpDelete]
        [Route("deletePlace")]
        public async Task<IActionResult> DeletePlace(int id)
        {
            var place = await _placeService.GetById(id);
            if (place == null)
                return NotFound("data not found");

            await _placeService.DeleteCabType(place);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var place = await _placeService.GetById(id);
            if (place == null)
                return NotFound("no data found");
            return Ok(place);
        }
    }
}