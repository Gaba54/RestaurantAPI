using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController:ControllerBase
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;

        //
        public RestaurantController(RestaurantDbContext dbContext, IMapper mapper)
        {
            //przez kontruktor wstrzykujemy ten obiekt
            _dbContext = dbContext;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var restaurants = _dbContext.Restaurants.Include(x => x.Address).Include(x=>x.Dishes).ToList();

            var restaurantsDtos = _mapper.Map<List<RestaurantDto>>(restaurants);

            return Ok(restaurantsDtos);
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<RestaurantDto>> GetById([FromRoute] int id)
        {
            var restaurant = _dbContext.Restaurants.Include(x => x.Address).Include(x => x.Dishes).FirstOrDefault(x => x.Id == id);
            if (restaurant is null)
            {
                return NotFound();
            }

            var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);
            return Ok(restaurantDto);
        }

        [HttpPost]
        public ActionResult CreateRestaurant([FromBody] CreateRestaurantdto dto)
        {
            var restaurant = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
            return Created($"/api/restaurant/{restaurant.Id}", null);
        }
    }
}
