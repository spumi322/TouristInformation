using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TouristInformation.Data.Models;

public partial class ReservedTicket : BaseDomainEntity
{

    [Required]
    public string? GuestName { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int? Quantity { get; set; }

    [Required]
    public int? AttrId { get; set; }

    public virtual Attraction? Attr { get; set; }
}
