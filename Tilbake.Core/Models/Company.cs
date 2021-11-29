using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Company
    {
        public Company()
        {
            CompanyBankAccounts = new HashSet<CompanyBankAccount>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhysicalAddress { get; set; } = null!;
        public string PostalAddress { get; set; } = null!;
        public Guid CityId { get; set; }
        public string Phone { get; set; } = null!;
        public string Fax { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Website { get; set; }
        public string? TaxNumber { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual City City { get; set; } = null!;
        public virtual ICollection<CompanyBankAccount> CompanyBankAccounts { get; set; }
    }
}
