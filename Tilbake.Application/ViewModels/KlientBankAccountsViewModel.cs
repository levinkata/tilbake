using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class KlientBankAccountsViewModel
    {
        public Guid KlientID { get; set; }
        public IEnumerable<KlientBankAccount> KlientBankAccounts { get; set; }
    }
}
