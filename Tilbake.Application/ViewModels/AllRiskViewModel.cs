using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class AllRiskViewModel
    {
        public Guid KlientID { get; set; }
        public AllRisk AllRisk { get; set; }
    }
}
