using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public List<Hotel> GetAll()
        {
            return _hotelService.GetAllHotels();
        }

        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            return hotel;
        }

        [HttpPost]
        public Hotel Add([FromBody] Hotel hotel)
        {
            _hotelService.CreateHotel(hotel);
            return hotel;
        }

        [HttpPut]
        public Hotel Update([FromBody] Hotel hotel)
        {
            _hotelService.UpdateHotel(hotel);
            return hotel;
        }

        [HttpDelete("{Id}")]
        public void Delete(int id)
        {
            _hotelService.DeleteHotel(id);
        }
    }
}
