using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class Customer
{
    public Guid Id { get; set; }

    public Guid TitleId { get; set; }

    public int CustomerNumber { get; set; }

    public Guid CustomerTypeId { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public Guid GenderId { get; set; }

    public Guid IdDocumentTypeId { get; set; }

    public string IdNumber { get; set; } = null!;

    public Guid MaritalStatusId { get; set; }

    public Guid CountryId { get; set; }

    public string? Phone { get; set; }

    public Guid OccupationId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public Guid CustomerStatusId { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<CustomerBankAccount> CustomerBankAccounts { get; set; } = new List<CustomerBankAccount>();

    public virtual ICollection<CustomerCarrier> CustomerCarriers { get; set; } = new List<CustomerCarrier>();

    public virtual ICollection<CustomerDocument> CustomerDocuments { get; set; } = new List<CustomerDocument>();

    public virtual ICollection<CustomerRisk> CustomerRisks { get; set; } = new List<CustomerRisk>();

    public virtual CustomerStatus CustomerStatus { get; set; } = null!;

    public virtual CustomerType CustomerType { get; set; } = null!;

    public virtual ICollection<EmailAddress> EmailAddresses { get; set; } = new List<EmailAddress>();

    public virtual Gender Gender { get; set; } = null!;

    public virtual IdDocumentType IdDocumentType { get; set; } = null!;

    public virtual MaritalStatus MaritalStatus { get; set; } = null!;

    public virtual ICollection<MobileNumber> MobileNumbers { get; set; } = new List<MobileNumber>();

    public virtual Occupation Occupation { get; set; } = null!;

    public virtual ICollection<PortfolioCustomer> PortfolioCustomers { get; set; } = new List<PortfolioCustomer>();

    public virtual Title Title { get; set; } = null!;
}
