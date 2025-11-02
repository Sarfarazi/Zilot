using Microsoft.EntityFrameworkCore;
using Zelut.Domain.Entities;

public class ZelutDbContext : DbContext
{
    public ZelutDbContext(DbContextOptions options) : base(options)
    {
    }

    #region DbSet
    public DbSet<Buyers> Buyers { get; set; }
    public DbSet<ContactUs> ContactUs { get; set; }
    public DbSet<BlogComments> BlogComments { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}