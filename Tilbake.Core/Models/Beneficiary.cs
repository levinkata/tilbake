using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Beneficiary
{
    public Guid Id { get; set; }

    public Guid PortfolioClientId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public Guid RelationTypeId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual PortfolioClient PortfolioClient { get; set; } = null!;

    public virtual RelationType RelationType { get; set; } = null!;
}
