using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
  public class AccountModel
  {
    public Guid Id { get; set; }

    [Required, MaxLength(255)]
    public string FirstName { get; set; }

    [Required, MaxLength(255)]
    public string LastName { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, Phone]
    public string Phone { get; set; }

    [MinLength(4), MaxLength(16)]
    public byte[] IpAddress { get; set; }

    public Guid AddressId { get; set; }

    public AddressModel Address { get; set; }
  }
}