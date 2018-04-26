using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
    [Remote(action: "VerifyEmail", controller: "Account")]
    public string Email { get; set; }

    [Required, MaxLength(14)]
    [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "The Phone field must be formated as (123) 456-7890.")]
    [Display(Name = "Phone number")]
    public string Phone { get; set; }

    [MinLength(4), MaxLength(16)]
    public byte[] IpAddress { get; set; }

    public virtual ICollection<RentEstimateModel> RentEstimates { get; set; }
  }
}