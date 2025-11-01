using Zelut.Application.DTOs.Blog;

namespace Zelut.Application.Services;

public interface IBlogService
{
    Task<ResultData<List<BlogDto>>> GetAll();
    Task<ResultData<BlogDto>> GetById(int id);
    Task<Result> SendComment(SendCommentBlogRequest request);
}
