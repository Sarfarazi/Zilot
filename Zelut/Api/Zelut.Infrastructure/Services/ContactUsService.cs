using AutoMapper;
using Microsoft.AspNetCore.Http;
using Zelut.Application.DTOs;
using Zelut.Application.Services;
using Zelut.Domain.Entities;
using Zelute.Application.Repository;

namespace Zelut.Infrastructure.Services;

public class ContactUsService : IContactUsService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRepository<ZelutContactUs> _contactUsRepository;
    private readonly IMapper _mapper;
    public ContactUsService(IHttpContextAccessor httpContextAccessor, IRepository<ZelutContactUs> contactUsRepository, IMapper mapper)
    {
        _httpContextAccessor = httpContextAccessor;
        _contactUsRepository = contactUsRepository;
        _mapper = mapper;
    }

    public async Task<Result> InsertContactUs(CreateContactUsDto contactUs)
    {
        var zelutContactUs = _mapper.Map<ZelutContactUs>(contactUs);
        var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        zelutContactUs.Ip = ip;

        await _contactUsRepository.Add(zelutContactUs);
        var saveData_result = await _contactUsRepository.SaveChangesAsync();
        if(!saveData_result.IsSuccess)
        {
            return new Result
            {
                IsSuccess = false,
                Message = "اطلاعات تماس با موفقیت ثبت نشد،لطفا دوباره تلاش کنید."
            };
        }

        return new Result
        {
            IsSuccess = true,
            Message = "اطلاعات تماس شما با موفقیت ثبت شد."
        };
    }
}
