using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class Client
    {
        public Client()
        {
            ClientBankAccounts = new HashSet<ClientBankAccount>();
            ClientDocuments = new HashSet<ClientDocument>();
            ClientRisks = new HashSet<ClientRisk>();
            PortfolioClients = new HashSet<PortfolioClient>();
            Quotes = new HashSet<Quote>();
        }

        public Guid Id { get; set; }
        public Guid TitleId { get; set; }
        public int ClientNumber { get; set; }
        public Guid ClientTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid GenderId { get; set; }
        public string IdNumber { get; set; }
        public Guid MaritalStatusId { get; set; }
        public Guid CountryId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Guid CarrierId { get; set; }
        public Guid OccupationId { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Carrier Carrier { get; set; }
        public virtual ClientType ClientType { get; set; }
        public virtual Country Country { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual Occupation Occupation { get; set; }
        public virtual Title Title { get; set; }
        public virtual ICollection<ClientBankAccount> ClientBankAccounts { get; set; }
        public virtual ICollection<ClientDocument> ClientDocuments { get; set; }
        public virtual ICollection<ClientRisk> ClientRisks { get; set; }
        public virtual ICollection<PortfolioClient> PortfolioClients { get; set; }
        public virtual ICollection<Quote> Quotes { get; set; }
    }
}
