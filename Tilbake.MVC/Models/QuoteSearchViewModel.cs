using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.MVC.Models
{
    public class QuoteSearchViewModel
    {
        public Guid PortfolioId { get; set; }
        public string PortfolioName { get; set; }
        public string SearchString { get; set; }
        public IEnumerable<QuoteViewModel> QuoteViewModels { get; set; }
    }
}
