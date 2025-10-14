using Zelut.Application.DTOs;
using Zelut.Application.Services;
using Microsoft.AspNetCore.Hosting;

namespace Zelut.Infrastructure.Services;

public class BlogService : IBlogService
{
    private readonly IHostingEnvironment _environment;
    public BlogService(IHostingEnvironment environment)
    {
        _environment = environment;
    }

    public Task<ResultData<List<BlogDto>>> GetAll()
    {
        var file_path = 
    }

    public Task<ResultData<BlogDto>> GetById(int id)
    {
        throw new NotImplementedException();
    }
}
