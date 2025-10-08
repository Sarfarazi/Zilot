using Zelut.Domain.Entities;
using AutoMapper;

namespace Zelut.Application.Configuration.Mapper;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ZelutBuyerRequestDto, ZelutBuyers>();
    }
}