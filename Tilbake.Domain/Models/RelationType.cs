﻿using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class RelationType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
