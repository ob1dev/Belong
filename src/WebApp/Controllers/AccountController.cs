using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
  [Route("[controller]/[action]")]
  public class AccountController : Controller
  {
    private AppDbContext dbContext;

    public AccountController(AppDbContext context)
    {
      this.dbContext = context;
    }
  }
}