using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class City
{
    public Guid Id { get; set; }

    public Guid CountryId { get; set; }

    public string Name { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<InsurerBranch> InsurerBranches { get; set; } = new List<InsurerBranch>();
}
