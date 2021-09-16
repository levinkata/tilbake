using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.Application.Resources
{
    public class MobileNumberResource
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public string Name { get; set; }
        public bool IsPrimary { get; set; }
    }
}
