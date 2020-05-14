using System;
using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class PolitikksViewModel
    {
        public Guid KlientID { get; set; }
        public IEnumerable<Politikk> Politikks { get; set; }
    }
}
