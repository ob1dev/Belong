using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebApp.Data;
using WebApp.Models;
using WebApp.Services.Zillow;
using WebApp.Services.Zillow.Helpers;

namespace WebApp.Controllers
{
  [Route("[controller]/[action]")]
  public class AccountController : Controller
  {
    private AppDbContext dbContext;
    private ZillowClient zillowClient;
    private RentCalculator rentCalculator;

    public AccountController(AppDbContext context, ZillowClient client, RentCalculator rentCalculator)
    {
      this.dbContext = context;
      this.zillowClient = client;
      this.rentCalculator = rentCalculator;
    }

    [HttpGet]
    public IActionResult Join()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Join(AccountModel account)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }

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
      if (!ModelState.IsValid)
      {
        return View();
      }

      this.dbContext.Addresses.Add(address);
      await this.dbContext.SaveChangesAsync();

      TempData.Remove("Address.Id");
      TempData.Add("Address.Id", address.Id);

      return RedirectToAction("Customize", address);
    }

    [HttpGet]
    public async Task<IActionResult> Customize(AddressModel address)
    {
      var zestimate = await this.zillowClient.GetRentZestimate(address);

      ViewData["Zestimate.Low"] = zestimate.ValuationRangeLow;
      ViewData["Zestimate.High"] = zestimate.ValuationRangeHigh;

      TempData.Keep();

      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Customize(RentEstimateModel rentEstimate)
    {
      if (!ModelState.IsValid)
      {
        return View();
      }

      rentEstimate.AccountId = (Guid)TempData["Account.Id"];
      rentEstimate.AddressId = (Guid)TempData["Address.Id"];

      this.dbContext.RentEstimates.Add(rentEstimate);
      await this.dbContext.SaveChangesAsync();

      return RedirectToAction("ThankYou");
    }

    public IActionResult ThankYou()
    {
      return View();
    }
  }
}