using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class KravsViewModel
    {
        public Guid PolitikkRiskID { get; set; }
        public IEnumerable<Krav> Kravs { get; set; }
    }
}
