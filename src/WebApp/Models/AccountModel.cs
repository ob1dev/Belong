using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace WebApp.Models
{
  public class AccountModel
  {
    public Guid UserId { get; set; }

    [Required, MaxLength(255)]
    public string FirstName { get; set; }

    [Required, MaxLength(255)]
    public string LastName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, Phone]
    public string Phone { get; set; }

    public IPAddress IpAddress { get; set; }
  }
}