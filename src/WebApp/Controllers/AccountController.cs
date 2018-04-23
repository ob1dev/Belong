using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
  [Route("[controller]/[action]")]
  public class AccountController : Controller
  {
    private AppDbContext dbContext;
    private ZillowClient zillowClient;

    public AccountController(AppDbContext context, ZillowClient client)
    {
      this.dbContext = context;
      this.zillowClient = client;
    }

    [HttpGet]
    public IActionResult Join()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Join(AccountModel account)
    {
      account.IpAddress = HttpContext.Connection.RemoteIpAddress.GetAddressBytes();

      this.dbContext.Accounts.Add(account);
      await this.dbContext.SaveChangesAsync();

      TempData.Clear();
      TempData.Add("Account.Id", account.Id);
      TempData.Add("Account.FirstName", account.FirstName);

      return RedirectToAction("Address");
    }

    [HttpGet]
    public IActionResult Address()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Address(AddressModel address)
    {
      var id = TempData["Account.Id"];
      var account = this.dbContext.Accounts.Find(id);

      this.dbContext.Addresses.Add(address);
      account.Address = address;

      this.dbContext.Attach(account).State = EntityState.Modified;
      await this.dbContext.SaveChangesAsync();

      return RedirectToAction("Customize");
    }

    [HttpGet]
    public IActionResult Customize()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Customize(AddressModel address)
    {
      return View();
    }
  }
}