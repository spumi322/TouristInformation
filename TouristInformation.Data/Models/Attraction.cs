using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TouristInformation.Data.Models;

public partial class Attraction : BaseDomainEntity
{

    [Required]
    [Display(Name = "Attraction Name")]
    public string AttrName { get; set; } = "";

    [Required]
    public string City { get; set; } = "";

    [Required]
    public string Category { get; set; } = "";

    public int Price { get; set; }

    public double Longitude { get; set; }

    public double Latitude { get; set; }

    public double RecommendedAge { get; set; }

    public int Duration { get; set; }

    public virtual ICollection<ReservedTicket> ReservedTickets { get; } = new List<ReservedTicket>();
}