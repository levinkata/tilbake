﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ClientDocument
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public string FileType { get; set; }
        public string Extension { get; set; }
        public string Description { get; set; }
        public DateTime DocumentDate { get; set; }
        public Guid DocumentTypeId { get; set; }
        public string DocumentPath { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Client Client { get; set; }
        public virtual DocumentType DocumentType { get; set; }
    }
}