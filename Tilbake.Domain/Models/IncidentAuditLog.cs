﻿using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class IncidentAuditLog
    {
        public Guid IncidentId { get; set; }
        public string DmlType { get; set; }
        public DateTime DmlTimestamp { get; set; }
        public string OldRowData { get; set; }
        public string NewRowData { get; set; }
        public Guid? DmlCreatedById { get; set; }
        public DateTime TrxTimestamp { get; set; }
    }
}
