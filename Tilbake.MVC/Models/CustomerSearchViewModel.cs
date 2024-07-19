using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.MVC.Models
{
    public class CustomerSearchViewModel
    {
        public string SearchString { get; set; }
        public IEnumerable<CustomerViewModel> CustomerViewModels { get; set; }
    }
}
