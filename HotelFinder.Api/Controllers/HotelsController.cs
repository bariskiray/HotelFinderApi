using HotelFinder.Business.Abstract;
using HotelFinder.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelService _service;
        public HotelsController(IHotelService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _service.GetAllHotel();
            return Ok(hotels);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetHotelByID(int id)
        {
            var hotels = await _service.GetHotelById(id);
            if (hotels!=null)
            {
                return Ok(hotels);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateHotel([FromBody] Hotel hotel)
        {       
            var createdhotel= await _service.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = createdhotel.ID }, createdhotel);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
        {
            if(await _service.GetHotelById(hotel.ID) != null)
            {
                return Ok(await _service.UpdateHotel(hotel));
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (await _service.GetHotelById(id) != null)
            {
                await _service.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
