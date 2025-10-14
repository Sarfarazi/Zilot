using Zelut.Application.DTOs;

namespace Zelut.Application.Services;

public interface IBlogService
{
    Task<ResultData<List<BlogDto>>> GetAll();
    Task<ResultData<BlogDto>> GetById(int id);
}
