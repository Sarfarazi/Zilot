using Zelut.Domain.Entities;
using AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ZelutBuyers, ZelutBuyerRequestDto>();
    }
}