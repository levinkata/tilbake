using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class KravViewModel
    {
        public Guid PolitikkRiskID { get; set; }
        public Krav Krav { get; set; }
    }
}
