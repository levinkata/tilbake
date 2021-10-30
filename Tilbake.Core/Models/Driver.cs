using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Driver
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid OccupationId { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid GenderId { get; set; }
        public Guid MaritalStatusId { get; set; }
        public string LicenceNumber { get; set; }
        public DateTime LicenceDate { get; set; }
        public string LicenceIssuePlace { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual MaritalStatus MaritalStatus { get; set; }
        public virtual Occupation Occupation { get; set; }
    }
}
