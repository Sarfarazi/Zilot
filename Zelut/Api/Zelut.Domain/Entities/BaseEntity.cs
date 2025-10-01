namespace Zelut.Domain.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        CreateDate = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public DateTime CreateDate { get; set; }
}