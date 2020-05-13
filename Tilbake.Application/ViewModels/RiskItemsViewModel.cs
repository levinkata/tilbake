using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class RiskItemsViewModel
    {
        public IEnumerable<RiskItem> RiskItems { get; set; }
    }
}
