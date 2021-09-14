using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Application.Resources
{
    public class PortfolioClientSearchResource
    {
        public Guid PortfolioId { get; set; }
        public string PortfolioName { get; set; }
        public string SearchString { get; set; }
        public IEnumerable<ClientResource> ClientResources { get; set; }
    }
}
