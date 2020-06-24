using System;

namespace Tilbake.Domain.Models
{
    public class PortfolioKlient
    {
        public Guid Id { get; set; }
        public Guid PortfolioId { get; set; }
        public Guid KlientId { get; set; }

        public virtual Klient Klient { get; private set; }
        public virtual Portfolio Portfolio { get; private set; }
    }
}
