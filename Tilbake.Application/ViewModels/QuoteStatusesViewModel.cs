using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class QuoteStatusesViewModel
    {
        public IEnumerable<QuoteStatus> QuoteStatuses { get; set; }
    }
}
