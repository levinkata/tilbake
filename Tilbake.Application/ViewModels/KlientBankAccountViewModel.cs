using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class KlientBankAccountViewModel
    {
        public Guid KlientID { get; set; }
        public Guid BankAccountID { get; set; }
        public KlientBankAccount KlientBankAccount { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
