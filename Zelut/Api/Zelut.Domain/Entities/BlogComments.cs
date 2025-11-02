namespace Zelut.Domain.Entities;

public class BlogComments : BaseEntity
{
    public long Id { get; set; }
    public int BlogId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}   