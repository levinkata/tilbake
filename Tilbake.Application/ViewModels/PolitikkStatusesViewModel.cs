using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class PolitikkStatusesViewModel
    {
        public IEnumerable<PolitikkStatus> PolitikkStatuses { get; set; }
    }
}
