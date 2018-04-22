using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
  public class AppDbContext : DbContext
  {
    public DbSet<AccountModel> Accounts { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
  }
}