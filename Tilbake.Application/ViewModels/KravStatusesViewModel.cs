using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class KravStatusesViewModel
    {
        public IEnumerable<KravStatus> KravStatuses { get; set; }
    }
}
