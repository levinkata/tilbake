using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Invoice
{
    public Guid Id { get; set; }

    public Guid PolicyId { get; set; }

    public int InvoiceNumber { get; set; }

    public DateTime InvoiceDate { get; set; }

    public decimal Amount { get; set; }

    public decimal TaxAmount { get; set; }

    public Guid InvoiceStatusId { get; set; }

    public decimal ReducingBalance { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<InvoiceItem> InvoiceItems { get; set; } = new List<InvoiceItem>();

    public virtual InvoiceStatus InvoiceStatus { get; set; } = null!;

    public virtual Policy Policy { get; set; } = null!;

    public virtual ICollection<ReceivableInvoice> ReceivableInvoices { get; set; } = new List<ReceivableInvoice>();

    public virtual ICollection<Reconcilliation> Reconcilliations { get; set; } = new List<Reconcilliation>();
}
