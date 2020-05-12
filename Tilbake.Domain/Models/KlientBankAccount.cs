using System;

namespace Tilbake.Domain.Models
{
    public class KlientBankAccount
    {
        public Guid KlientID { get; set; }
        public Guid BankAccountID { get; set; }

        public virtual BankAccount BankAccount { get; private set; }
        public virtual Klient Klient { get; private set; }
    }
}
