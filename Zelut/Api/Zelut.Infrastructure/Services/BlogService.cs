using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;
using Zelut.Application.DTOs.Blog;
using Zelut.Application.Services;
using Zelut.Domain.Entities;
using Zelute.Application.Repository;

namespace Zelut.Infrastructure.Services;

public class BlogService : IBlogService
{
    private readonly IHostingEnvironment _environment;
    private readonly IRepository<ZelutBlogComments> _blogCommentsRepository;
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

    public async Task<Result> SendComment(SendCommentBlogRequest request)
    {
        ZelutBlogComments blog_comment = new()
        {
            BlogId = request.BlogId,
            Description = request.Description,
            Email = request.Email,
            Name = request.Name,
        };

        await _blogCommentsRepository.Add(blog_comment);
        var save_result = await _blogCommentsRepository.SaveChangesAsync();

        if (!save_result.IsSuccess)
        {
            return new Result
            {
                IsSuccess = false,
                Message = string.Empty
            };
        }

        return new Result
        {
            IsSuccess= true,
            Message = "دیدگاه شما با موفقیت ثبت شد",
        };
    }
}