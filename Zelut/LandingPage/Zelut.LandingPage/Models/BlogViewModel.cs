using Zelut.LandingPage.DTOs;

namespace Zelut.LandingPage.Models;

public class BlogViewModel
{
    public BlogDto Blog { get; set; } = new();
    public SendPaperCommentRequest CommentRequest { get; set; } = new();
}
