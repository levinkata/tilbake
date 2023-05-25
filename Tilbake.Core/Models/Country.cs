using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Country
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? DialingCode { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<TravelMember> TravelMembers { get; set; } = new List<TravelMember>();
}
