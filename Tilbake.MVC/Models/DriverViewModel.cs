using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Tilbake.MVC.Models
{
    public class DriverViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid OccupationId { get; set; }
        public DateTime? BirthDate { get; set; }
        public Guid GenderId { get; set; }
        public Guid MaritalStatusId { get; set; }
        public string LicenceNumber { get; set; }
        public DateTime LicenceDate { get; set; }
        public string LicenceIssuePlace { get; set; }

        public GenderViewModel Gender { get; set; }
        public MaritalStatusViewModel MaritalStatus { get; set; }
        public OccupationViewModel Occupation { get; set; }

        public SelectList GenderList { get; set; }
        public SelectList MaritalStatusList { get; set; }
        public SelectList OccupationList { get; set; }
    }
}
