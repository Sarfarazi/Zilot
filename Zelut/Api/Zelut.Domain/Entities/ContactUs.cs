namespace Zelut.Domain.Entities;

public class ContactUs : BaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Family { get; set; }
    public string? Mobile { get; set; }
    public string? Email { get; set; }
    public string? Message { get; set; }
    public string? Ip { get; set; }
}
