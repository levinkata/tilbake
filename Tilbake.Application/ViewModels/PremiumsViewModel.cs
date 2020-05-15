using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class PremiumsViewModel
    {
        public Guid KlientID { get; set; }
        public IEnumerable<Premium> Premiums { get; set; }
    }
}
