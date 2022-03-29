using AutoMapper;
using RestaurantAPI.Entities;
using RestaurantAPI.Models;

namespace RestaurantAPI
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(x => x.City, x => x.MapFrom(s => s.Address.City))
                .ForMember(x => x.Street, x => x.MapFrom(s => s.Address.Street))
                .ForMember(x => x.PostalCode, x => x.MapFrom(s => s.Address.PostalCode));

            CreateMap<Dish, DishDto>();

            CreateMap<CreateRestaurantdto, Restaurant>()
                .ForMember(x => x.Address, x => x.MapFrom(dto => new Address()
                {
                    City = dto.City,
                    Street = dto.Street,
                    PostalCode = dto.PostalCode,
                }));
        }
    }
}
