using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class LossAdjusterAuthority
    {
        public Guid Id { get; set; }
        public Guid ClaimLossAdjusterId { get; set; }
        public DateTime InstructionDate { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public bool IsAuthoriseRepairs { get; set; }
        public bool IsCloseFile { get; set; }
        public Guid? IssuedById { get; set; }
        public DateTime? IssuedDate { get; set; }
        public bool? IsAuthorised { get; set; }
        public Guid? AuthorisedById { get; set; }
        public DateTime? AuthorisedDate { get; set; }
        public string Remarks { get; set; }
        public Guid? AddedById { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedById { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
