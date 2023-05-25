using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Attorney
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string IdNumber { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? Phone { get; set; }

    public string? Fax { get; set; }

    public string? Email { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<ClaimAttorney> ClaimAttorneys { get; set; } = new List<ClaimAttorney>();
}
