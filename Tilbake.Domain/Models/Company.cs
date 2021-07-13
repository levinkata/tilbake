using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
    }
}
