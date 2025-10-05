using AutoMapper;
using Zelut.Domain.Entities;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ZelutBuyers, ZelutBuyerRequestDto>();
    }
}