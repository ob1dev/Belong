using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
  public class RentEstimateModel
  {
    [Key]
    public Guid Id { get; set; }

    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    public Decimal? RentZestimateLow { get; set; }

    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    public Decimal? RentZestimateHigh { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
    [Display(Name = "What is your expected monthly rent?")]
    public Decimal ExpectedRent { get; set; }

    [ForeignKey("AccountModel")]
    public Guid AccountId { get; set; }

    [ForeignKey("AddressModel")]
    public Guid AddressId { get; set; }

    public AccountModel Account { get; set; }

    public AddressModel Address { get; set; }
  }
}