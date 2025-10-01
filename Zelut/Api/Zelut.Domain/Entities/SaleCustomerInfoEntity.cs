namespace Zelut.Domain.Entities;
public class SaleCustomerInfoEntity : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string StoreName { get; set; }
    public string SellerLastName { get; set; }
    public string SellerPhoneNumber { get; set; }
    public string SellerEmail { get; set; }
    public string CarpetName { get; set; }
    public int CarpetMetraj { get; set; }
    public int NumberOfSerials { get; set; }
    public string SerialsNumber { get; set; }
    public int CarpetUsage { get; set; }
    public string InvoiceUrl { get; set; }
    public string? Description { get; set; }
}