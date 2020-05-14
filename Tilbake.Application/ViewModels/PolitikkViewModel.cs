using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class PolitikkViewModel
    {
        public Guid KlientID { get; set; }
        public Politikk Politikk { get; set; }
    }
}
