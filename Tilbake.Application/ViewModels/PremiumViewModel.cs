using System;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class PremiumViewModel
    {
        public Guid PolitikkID { get; set; }
        public Premium Premium { get; set; }
    }
}
