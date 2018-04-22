using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
  public class HomeController : Controller
  {
    private AppDbContext dbContext;

    public HomeController(AppDbContext context)
    {
      this.dbContext = context;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Terms()
    {
      return View();
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Join(AccountModel account)
    {
      account.IpAddress = HttpContext.Connection.RemoteIpAddress.GetAddressBytes();

      this.dbContext.Accounts.Add(account);
      await this.dbContext.SaveChangesAsync();

      return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}