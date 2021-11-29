﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ClaimRoadsideAssist
    {
        public int ClaimNumber { get; set; }
        public Guid RoadsideAssistId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual RoadsideAssist RoadsideAssist { get; set; } = null!;
    }
}
