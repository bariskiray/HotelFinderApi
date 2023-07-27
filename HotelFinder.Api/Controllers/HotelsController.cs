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

        public IActionResult Get()
        {
            var hotels = _service.GetAllHotel();
            return Ok(hotels);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotels = _service.GetHotelById(id);
            if (hotels!=null)
            {
                return Ok(hotels);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Post([FromBody] Hotel hotel)
        {       
            var createdhotel= _service.CreateHotel(hotel);
            return CreatedAtAction("Get", new {id=createdhotel.ID}, createdhotel)
        }
        [HttpPut]
        public IActionResult Put([FromBody] Hotel hotel)
        {
            if(_service.GetHotelById(hotel.ID) != null)
            {
                return Ok(_service.UpdateHotel(hotel);
            }
            return NotFound();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.GetHotelById(id) != null)
            {
                _service.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
