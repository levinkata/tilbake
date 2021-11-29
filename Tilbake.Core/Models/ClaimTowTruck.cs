using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ClaimTowTruck
    {
        public int ClaimNumber { get; set; }
        public Guid TowTruckId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual TowTruck TowTruck { get; set; } = null!;
    }
}
