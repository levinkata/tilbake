using System.Collections.Generic;
using Tilbake.Domain.Models;

namespace Tilbake.Application.ViewModels
{
    public class BanksViewModel
    {
        public IEnumerable<Bank> Banks { get; set; }
    }
}
