﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Document
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public string? FileType { get; set; }

    public string? Extension { get; set; }

    public string? Description { get; set; }

    public DateTime DocumentDate { get; set; }

    public Guid DocumentTypeId { get; set; }

    public string? DocumentPath { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<ClaimDocument> ClaimDocuments { get; set; } = new List<ClaimDocument>();

    public virtual ICollection<CustomerDocument> CustomerDocuments { get; set; } = new List<CustomerDocument>();

    public virtual ICollection<CustomerRiskDocument> CustomerRiskDocuments { get; set; } = new List<CustomerRiskDocument>();

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<ReceivableDocument> ReceivableDocuments { get; set; } = new List<ReceivableDocument>();
}
