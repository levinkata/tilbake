using System;

namespace Tilbake.Domain.Models
{
    public class PortfolioKlient
    {
        public Guid ID { get; set; }
        public Guid PortfolioID { get; set; }
        public Guid KlientID { get; set; }

        public virtual Klient Klient { get; private set; }
        public virtual Portfolio Portfolio { get; private set; }
    }
}
