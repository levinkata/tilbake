using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class LossAdjusterInstruction
    {
        public Guid Id { get; set; }
        public Guid ClaimLossAdjusterId { get; set; }
        public DateTime InstructionDate { get; set; }
        public string Location { get; set; }
        public string Excess { get; set; }
        public string AdditionalExcess { get; set; }
        public bool? IsAuthoriseRepairs { get; set; }
        public bool? IsAgreeCosts { get; set; }
        public Guid? IssuedById { get; set; }
        public DateTime? IssueDate { get; set; }
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
