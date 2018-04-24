using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models
{
  public class RentEstimateModel
  {
    [Key]
    public Guid Id { get; set; }

    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    public decimal? RentZestimateLow { get; set; }

    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    public decimal? RentZestimateHigh { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Range(1, Int16.MaxValue, ErrorMessage = "The Expected rent field must be greater than 0.")]
    [Display(Name = "Expected rent")]
    public decimal ExpectedRent { get; set; }

    [ForeignKey("AccountModel")]
    public Guid AccountId { get; set; }

    [ForeignKey("AddressModel")]
    public Guid AddressId { get; set; }

    public virtual AccountModel Account { get; set; }

    public virtual AddressModel Address { get; set; }
  }
}