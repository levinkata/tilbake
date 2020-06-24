using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tilbake.API.Resources
{
    public class KlientResource
    {
        public Guid Id { get; set; }
        public Guid TitleId { get; set; }
        public int KlientNumber { get; set; }
        public string KlientType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string IdNumber { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Carrier { get; set; }
        public Guid OccupationId { get; set; }
        public Guid LandId { get; set; }
    }
}
