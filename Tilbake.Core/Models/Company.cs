﻿using System;
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
        public string Name { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
        public Guid CityId { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string TaxNumber { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<CompanyBankAccount> CompanyBankAccounts { get; set; }
    }
}