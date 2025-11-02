using Zelut.Domain.Entities;
using AutoMapper;
using Zelut.Application.DTOs;

namespace Zelut.Application.Configuration.Mapper;
public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<ZelutBuyerRequestDto, Buyers>();
        CreateMap<CreateContactUsDto, ContactUs>();
    }
}