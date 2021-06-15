using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class Portfolio
    {
        public Portfolio()
        {
            FileTemplates = new HashSet<FileTemplate>();
            PortfolioClients = new HashSet<PortfolioClient>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<FileTemplate> FileTemplates { get; set; }
        public virtual ICollection<PortfolioClient> PortfolioClients { get; set; }
    }
}
