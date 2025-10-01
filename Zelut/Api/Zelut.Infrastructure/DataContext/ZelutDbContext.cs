using Microsoft.EntityFrameworkCore;
using Zelut.Domain.Entities;

public class ZelutDbContext : DbContext
{
    public ZelutDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<SaleCustomerInfoEntity> SaleCustomerInfo{ get; set; }
}