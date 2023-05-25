using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Company
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string PhysicalAddress { get; set; } = null!;

    public string? PhysicalAddress1 { get; set; }

    public string? PhysicalAddress2 { get; set; }

    public string PostalAddress { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Fax { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Website { get; set; }

    public string? TaxNumber { get; set; }

    public byte[]? ImageFile { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual ICollection<CompanyBankAccount> CompanyBankAccounts { get; set; } = new List<CompanyBankAccount>();
}
