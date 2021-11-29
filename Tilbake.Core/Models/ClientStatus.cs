using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class ClientStatus
    {
        public ClientStatus()
        {
            PortfolioClients = new HashSet<PortfolioClient>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<PortfolioClient> PortfolioClients { get; set; }
    }
}
