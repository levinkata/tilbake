using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilbake.MVC.Models
{
    public class ClientBulkViewModel
    {
        public Guid Id { get; set; }
        public Guid? PortfolioId { get; set; }
        public Guid TitleId { get; set; }
        public Guid ClientTypeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid GenderId { get; set; }
        public string IdNumber { get; set; }
        public Guid MaritalStatusId { get; set; }
        public Guid CountryId { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public Guid OccupationId { get; set; }
        public bool? IsExists { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
