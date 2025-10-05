namespace Zelut.Domain.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        SaveDate = DateTime.UtcNow;
    }
    public int Id { get; set; }
    public DateTime SaveDate { get; set; }
}