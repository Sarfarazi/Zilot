using Zelut.Application.DTOs;

namespace Zelut.Application.Services;

public interface IContactUsService
{
    Task<Result> InsertContactUs(CreateContactUsDto contactUs);
}