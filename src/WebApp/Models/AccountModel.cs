using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
  public class AccountModel
  {
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(35)]
    [Display(Name = "First name")]
    public string FirstName { get; set; }

    [Required, MaxLength(35)]
    [Display(Name = "Last name")]
    public string LastName { get; set; }

    [Required, EmailAddress]
    [Display(Name = "Email address")]
    public string Email { get; set; }

    [Required, Phone]
    [Display(Name = "Phone number")]
    public string Phone { get; set; }

    [MinLength(4), MaxLength(16)]
    public byte[] IpAddress { get; set; }

    public Guid? AddressId { get; set; }

    public AddressModel Address { get; set; }
  }
}