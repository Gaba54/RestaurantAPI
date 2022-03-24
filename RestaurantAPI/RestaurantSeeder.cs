using RestaurantAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }

            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = " Kentucky Fried Chicken is a...",
                    ContactEmail = "kfc@kfc.com",
                    Dishes = new List<Dish>
                    {
                        new Dish()
                        {
                            Name = "Wtorkowy kubelek",
                            Price = 20,
                        },
                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 15,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Krakow",
                        Street = "Dluga 5",
                        PostalCode = "30-301"
                    }
                },

                new Restaurant()
                {
                    Name = "McDonalds",
                    Category = "Fast Food",
                    Description = " McDonalds is a...",
                    ContactEmail = "mc@mc.com",
                    Dishes = new List<Dish>
                    {
                        new Dish()
                        {
                            Name = "Fries",
                            Price = 8,
                        },
                        new Dish()
                        {
                            Name = "McWrap",
                            Price = 18,
                        },
                    },
                    Address = new Address()
                    {
                        City = "Krakow",
                        Street = "Wienczycka",
                        PostalCode = "39-381"
                    }
                }
            };

            return restaurants;
        }
    }
}
