namespace Zelut.Domain.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        SaveDate = DateTime.UtcNow;
    }
    public DateTime SaveDate { get; set; }
}