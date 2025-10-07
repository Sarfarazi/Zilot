using AutoMapper;
using Zelut.LandingPage.DTOs;

namespace Zelut.LandingPage.ApplicationConfig.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<CreateSaleInfoDto, RestApiSaleInofDto>();
    }
}
