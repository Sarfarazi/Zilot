namespace Zelut.Application.DTOs.Blog;

public class SendCommentBlogRequest
{
    public int BlogId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}