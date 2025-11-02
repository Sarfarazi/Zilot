namespace Zelut.Domain.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        SaveDate = DateTime.Now;
    }
    public DateTime SaveDate { get; set; }
}