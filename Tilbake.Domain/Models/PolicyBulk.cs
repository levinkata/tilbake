using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class PolicyBulk
    {
        public Guid Id { get; set; }
        public Guid PortfolioClientId { get; set; }
        public string IdNumber { get; set; }
        public int PolicyNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
