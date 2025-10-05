using Microsoft.EntityFrameworkCore;
using Zelut.Domain.Entities;

public class ZelutDbContext : DbContext
{
    public ZelutDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ZelutBuyers> SaleCustomerInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}