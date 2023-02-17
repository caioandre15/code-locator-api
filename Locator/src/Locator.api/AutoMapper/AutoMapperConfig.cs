using AutoMapper;
using Locator.api.Dtos;
using Locator.Business.Models;

namespace Locator.api.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Car, CarDto>().ReverseMap();
            CreateMap<Car, CarDtoUpdate>().ReverseMap();
            CreateMap<Characteristic, CharacteristicDto>().ReverseMap();
            CreateMap<Optional, OptionalDto>().ReverseMap();
        }
    }
}
