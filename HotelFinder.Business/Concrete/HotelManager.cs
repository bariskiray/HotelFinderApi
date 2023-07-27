using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public Hotel CreateHotel(Hotel hotel)
        {
            return _hotelRepository.CreateHotel(hotel);
        }

        public void DeleteHotel(int id)
        {
            _hotelRepository.DeleteHotel(id);
        }

        public List<Hotel> GetAllHotel()
        {
           return _hotelRepository.GetAllHotels();
        }

        public Hotel GetHotelById(int id)
        {
            if (id > 0)
            {
                return _hotelRepository.GetHotelById(id);
            }
            throw new Exception("Id Cannot be less than 1");
        }
            
        public Hotel UpdateHotel(Hotel hotel)
        {
            return _hotelRepository.UpdateHotel(hotel);

        }
    }
}
