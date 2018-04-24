using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<AccountModel> Accounts { get; set; }

    public DbSet<AddressModel> Addresses { get; set; }

    public DbSet<RentEstimateModel> RentEstimates { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<AccountModel>()
                  .HasIndex(a => a.Email)
                  .IsUnique();

      modelBuilder.Entity<AddressModel>()
                  .HasIndex(a => a.GooglePlaceId)
                  .IsUnique();
    }
  }
}