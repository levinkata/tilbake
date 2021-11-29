using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Client
    {
        public Client()
        {
            Addresses = new HashSet<Address>();
            ClientBankAccounts = new HashSet<ClientBankAccount>();
            ClientCarriers = new HashSet<ClientCarrier>();
            ClientDocuments = new HashSet<ClientDocument>();
            ClientRisks = new HashSet<ClientRisk>();
            EmailAddresses = new HashSet<EmailAddress>();
            MobileNumbers = new HashSet<MobileNumber>();
            PortfolioClients = new HashSet<PortfolioClient>();
        }

        public Guid Id { get; set; }
        public Guid TitleId { get; set; }
        public int ClientNumber { get; set; }
        public Guid ClientTypeId { get; set; }
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

        public virtual ClientType ClientType { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
        public virtual Gender Gender { get; set; } = null!;
        public virtual IdDocumentType IdDocumentType { get; set; } = null!;
        public virtual MaritalStatus MaritalStatus { get; set; } = null!;
        public virtual Occupation Occupation { get; set; } = null!;
        public virtual Title Title { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<ClientBankAccount> ClientBankAccounts { get; set; }
        public virtual ICollection<ClientCarrier> ClientCarriers { get; set; }
        public virtual ICollection<ClientDocument> ClientDocuments { get; set; }
        public virtual ICollection<ClientRisk> ClientRisks { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        public virtual ICollection<MobileNumber> MobileNumbers { get; set; }
        public virtual ICollection<PortfolioClient> PortfolioClients { get; set; }
    }
}
