using Microsoft.AspNetCore.Mvc;
using Zelut.Application.DTOs.Blog;
using Zelut.Application.Services;

namespace Zelut.Api.Controllers;

public class BlogController : BaseController
{
    private readonly IBlogService _blogService;
    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet("blog/get-all")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _blogService.GetAll();
        if(!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet("blog/get/{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _blogService.GetById(id);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPost("blog/send-comment")]
    public async Task<IActionResult> SendComment([FromBody] SendCommentBlogRequest request)
    {
        var result = await _blogService.SendComment(request);
        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}