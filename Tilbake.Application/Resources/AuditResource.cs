using System;
using System.ComponentModel.DataAnnotations;

namespace Tilbake.Application.Resources
{
    public class AuditResource
    {
        public Guid Id { get; set; }

        [Display(Name = "User")]
        public string UserId { get; set; }

        [Display(Name = "Operation")]
        public string Type { get; set; }

        [Display(Name = "Table")]
        public string TableName { get; set; }

        [Display(Name = "Date & Time")]
        public DateTime DateTime { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string AffectedColumns { get; set; }
        public string PrimaryKey { get; set; }

        //  Description
        public string FullName { get; set; }
    }
}
