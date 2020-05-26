using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class InvoiceStatusesViewModel
    {
        public IEnumerable<InvoiceStatus> InvoiceStatuses { get; set; }
    }
}
