using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Receivable
{
    public Guid Id { get; set; }

    public string Reference { get; set; } = null!;

    public DateTime ReceivableDate { get; set; }

    public Guid PaymentTypeId { get; set; }

    public decimal Amount { get; set; }

    public string? BatchNumber { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual PaymentType PaymentType { get; set; } = null!;

    public virtual ICollection<ReceivableDocument> ReceivableDocuments { get; set; } = new List<ReceivableDocument>();

    public virtual ICollection<ReceivableInvoice> ReceivableInvoices { get; set; } = new List<ReceivableInvoice>();

    public virtual ICollection<ReceivableQuote> ReceivableQuotes { get; set; } = new List<ReceivableQuote>();
}
