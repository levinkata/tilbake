using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Portfolio
    {
        public Portfolio()
        {
            AspnetUserPortfolios = new HashSet<AspnetUserPortfolio>();
            FileTemplates = new HashSet<FileTemplate>();
            PortfolioClients = new HashSet<PortfolioClient>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsScheme { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<AspnetUserPortfolio> AspnetUserPortfolios { get; set; }
        public virtual ICollection<FileTemplate> FileTemplates { get; set; }
        public virtual ICollection<PortfolioClient> PortfolioClients { get; set; }
    }
}
