using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class ClaimThirdParty
{
    public int ClaimNumber { get; set; }

    public Guid ThirdPartyId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ThirdParty ThirdParty { get; set; } = null!;
}
