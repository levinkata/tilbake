using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.MVC.Models
{
    public class ClientSearchViewModel
    {
        public string SearchString { get; set; }
        public IEnumerable<ClientViewModel> ClientViewModels { get; set; }
    }
}
