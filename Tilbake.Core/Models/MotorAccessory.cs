using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class MotorAccessory
    {
        public Guid Id { get; set; }
        public Guid MotorId { get; set; }
        public string Description { get; set; }
        public decimal PurchaseValue { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Motor Motor { get; set; }
    }
}
