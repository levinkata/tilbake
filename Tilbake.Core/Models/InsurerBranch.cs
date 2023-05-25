using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class InsurerBranch
{
    public Guid Id { get; set; }

    public Guid InsurerId { get; set; }

    public string Name { get; set; } = null!;

    public string PhysicalAddress { get; set; } = null!;

    public string PostalAddress { get; set; } = null!;

    public Guid CityId { get; set; }

    public string Phone { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public bool IsPrimary { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual Insurer Insurer { get; set; } = null!;

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();
}
