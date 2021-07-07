﻿using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class ClientRiskDocument
    {
        public Guid Id { get; set; }
        public Guid ClientRiskId { get; set; }
        public string Description { get; set; }
        public DateTime DocumentDate { get; set; }
        public Guid DocumentTypeId { get; set; }
        public string DocumentPath { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ClientRisk ClientRisk { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}