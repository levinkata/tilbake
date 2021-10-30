using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ClientNumberGenerator
    {
        public Guid Id { get; set; }
        public int ClientNumber { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
