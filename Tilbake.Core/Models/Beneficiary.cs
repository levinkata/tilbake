using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class Beneficiary
    {
        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid RelationTypeId { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual PortfolioClient PortfolioClient { get; set; }
        public virtual RelationType RelationType { get; set; }
    }
}
