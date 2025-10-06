using Microsoft.EntityFrameworkCore;
using Zelut.Domain.Entities;

public class ZelutDbContext : DbContext
{
    public ZelutDbContext(DbContextOptions options) : base(options)
    {
    }

    #region DbSet
    public DbSet<ZelutBuyers> ZelutBuyers { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}