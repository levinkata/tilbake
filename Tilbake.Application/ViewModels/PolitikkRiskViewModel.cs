using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class PolitikkRiskViewModel
    {
        public Guid PolitikkID { get; set; }
        public PolitikkRisk PolitikkRisk { get; set; }
    }
}
