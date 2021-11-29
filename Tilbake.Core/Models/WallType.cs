﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class WallType
    {
        public WallType()
        {
            Buildings = new HashSet<Building>();
            Contents = new HashSet<Content>();
            Houses = new HashSet<House>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
        public virtual ICollection<House> Houses { get; set; }
    }
}
