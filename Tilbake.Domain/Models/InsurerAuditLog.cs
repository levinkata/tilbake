using System;
using System.Collections.Generic;

#nullable disable

namespace Tilbake.Domain.Models
{
    public partial class InsurerAuditLog
    {
        public Guid InsurerId { get; set; }
        public string OldRowData { get; set; }
        public string NewRowData { get; set; }
        public string DmlType { get; set; }
        public DateTime DmlTimestamp { get; set; }
        public string DmlCreatedBy { get; set; }
        public DateTime? TrxTimestamp { get; set; }
    }
}
