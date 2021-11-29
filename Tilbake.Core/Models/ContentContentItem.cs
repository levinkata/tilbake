using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ContentContentItem
    {
        public Guid Id { get; set; }
        public Guid ContentId { get; set; }
        public Guid ContentItemId { get; set; }
        public decimal SumInsured { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
