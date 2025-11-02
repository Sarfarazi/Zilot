namespace Zelut.LandingPage.DTOs;

public class SendPaperCommentApiRequest
{
    public int BlogId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}