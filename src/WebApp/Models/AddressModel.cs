using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
  public class AddressModel
  {
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(60)]
    public string GooglePlaceId { get; set; }

    [Required, MaxLength(10)]
    public string StreetNumber { get; set; }

    [Required, MaxLength(255)]
    public string StreetName { get; set; }

    [Required, MaxLength(100)]
    public string City { get; set; }

    [Required, MaxLength(2)]
    public string State { get; set; }

    [Required, MaxLength(5)]
    public string PostalCode { get; set; }

    [Required, MaxLength(25)]
    public string Country { get; set; }

    public virtual ICollection<RentEstimateModel> RentEstimates { get; set; }
  }
}