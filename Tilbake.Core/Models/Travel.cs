using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Travel
{
    public Guid Id { get; set; }

    public Guid? PortfolioClientId { get; set; }

    public string PassportNumber { get; set; } = null!;

    public DateTime DepartureDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public string Destination { get; set; } = null!;

    public string PersonVisited { get; set; } = null!;

    public string Beneficiary { get; set; } = null!;

    public string DoctorName { get; set; } = null!;

    public string DoctorPhone { get; set; } = null!;

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual PortfolioClient? PortfolioClient { get; set; }

    public virtual ICollection<Risk> Risks { get; set; } = new List<Risk>();

    public virtual ICollection<TravelMember> TravelMembers { get; set; } = new List<TravelMember>();
}
