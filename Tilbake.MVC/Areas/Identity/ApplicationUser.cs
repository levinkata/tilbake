using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tilbake.MVC.Areas.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string MiddleName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string IdNumber { get; set; }

        [PersonalData]
        [Column(TypeName = "uniqueidentifier")]
        public Guid JobTitleId { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(50)")]
        public string ManNumber { get; set; }
    }
}
