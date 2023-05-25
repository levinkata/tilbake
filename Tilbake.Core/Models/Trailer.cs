using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Trailer
{
    public Guid Id { get; set; }

    public string RegNumber { get; set; } = null!;

    public string Make { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int RegYear { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<Risk> Risks { get; set; } = new List<Risk>();
}
