﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Trailer
    {
        public Trailer()
        {
            Risks = new HashSet<Risk>();
        }

        public Guid Id { get; set; }
        public string RegNumber { get; set; } = null!;
        public string Make { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int RegYear { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Risk> Risks { get; set; }
    }
}
