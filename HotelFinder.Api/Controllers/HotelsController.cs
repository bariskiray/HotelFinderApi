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
        public List<Hotel> Get()
        {
            return _service.GetAllHotel();
        }
        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return _service.GetHotelById(id);
        }
        [HttpPost]
        public Hotel Post([FromBody] Hotel hotel)
        {
            return _service.CreateHotel(hotel);
        }
        [HttpPut]
        public Hotel Put([FromBody] Hotel hotel)
        {
            return _service.UpdateHotel(hotel);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.DeleteHotel(id);
        }
    }
}
