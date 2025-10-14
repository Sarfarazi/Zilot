using Zelut.Application.DTOs;
using Zelut.Application.Services;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.Query;

namespace Zelut.Infrastructure.Services;

public class BlogService : IBlogService
{
    private readonly IHostingEnvironment _environment;
    public BlogService(IHostingEnvironment environment)
    {
        _environment = environment;
    }

    public async Task<ResultData<List<BlogDto>>> GetAll()
    {
        var file_path = Path.Combine(_environment.WebRootPath, "Data", "blogs.json");
        if (!File.Exists(file_path))
        {
            return new ResultData<List<BlogDto>>
            {
                IsSuccess = false,
                Message = "بلاگی یافت نشد."
            };
        }

        var json_content = await File.ReadAllTextAsync(file_path);
        var blogs = JsonConvert.DeserializeObject<List<BlogDto>>(json_content);

        return new ResultData<List<BlogDto>>
        {
            Message = string.Empty,
            IsSuccess = true,
            Data = blogs
        };
    }

    public async Task<ResultData<BlogDto>> GetById(int id)
    {
        var file_path = Path.Combine(_environment.WebRootPath, "Data", "blogs.json");
        if (!File.Exists(file_path))
        {
            return new ResultData<BlogDto>
            {
                IsSuccess = false,
                Message = "بلاگی یافت نشد."
            };
        }

        var json_content = await File.ReadAllTextAsync(file_path);
        var blogs = JsonConvert.DeserializeObject<List<BlogDto>>(json_content);
        var blog = blogs.FirstOrDefault(blog => blog.Id == id);
        
        if(blog is null)
        {
            return new ResultData<BlogDto>
            {
                IsSuccess = false,
                Message = "بلاگی یافت نشد."
            };
        }

        return new ResultData<BlogDto>
        {
            Message= string.Empty,
            IsSuccess = true,
            Data = blog
        };
    }
}
