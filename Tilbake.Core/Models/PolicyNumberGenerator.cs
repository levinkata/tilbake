using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class PolicyNumberGenerator
    {
        public Guid Id { get; set; }
        public int PolicyNumber { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
