using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class IncidentsViewModel
    {
        public IEnumerable<Incident> Incidents { get; set; }
    }
}