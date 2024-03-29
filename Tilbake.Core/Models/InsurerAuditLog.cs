﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class InsurerAuditLog
{
    public Guid InsurerId { get; set; }

    public string? OldRowData { get; set; }

    public string? NewRowData { get; set; }

    public string DmlType { get; set; } = null!;

    public DateTime DmlTimestamp { get; set; }

    public string? DmlCreatedBy { get; set; }

    public DateTime? TrxTimestamp { get; set; }
}
