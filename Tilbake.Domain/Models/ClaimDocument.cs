﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class ClaimDocument
    {
        public Guid Id { get; set; }
        public int ClaimNumber { get; set; }
        public string Name { get; set; }
        public Guid DocumentTypeId { get; set; }
        public DateTime? DocumentDate { get; set; }
        public string DocumentPath { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Claim ClaimNumberNavigation { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}
