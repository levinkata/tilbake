using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            ClaimDocuments = new HashSet<ClaimDocument>();
            ClientDocuments = new HashSet<ClientDocument>();
            ClientRiskDocuments = new HashSet<ClientRiskDocument>();
            ReceivableDocuments = new HashSet<ReceivableDocument>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? AddedBy { get; set; }
        public DateTime? DateAdded { get; set; }
        public Guid? ModifiedBy { get; set; }
        public DateTime? DateModified { get; set; }

        public virtual ICollection<ClaimDocument> ClaimDocuments { get; set; }
        public virtual ICollection<ClientDocument> ClientDocuments { get; set; }
        public virtual ICollection<ClientRiskDocument> ClientRiskDocuments { get; set; }
        public virtual ICollection<ReceivableDocument> ReceivableDocuments { get; set; }
    }
}
