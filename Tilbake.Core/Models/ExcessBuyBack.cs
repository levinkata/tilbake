using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class ExcessBuyBack
{
    public Guid Id { get; set; }

    public Guid MotorId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual Motor Motor { get; set; } = null!;

    public virtual ICollection<Risk> Risks { get; set; } = new List<Risk>();
}
