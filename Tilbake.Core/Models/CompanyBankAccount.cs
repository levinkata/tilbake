﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class CompanyBankAccount
{
    public Guid Id { get; set; }

    public Guid CompanyId { get; set; }

    public Guid BankAccountId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual BankAccount BankAccount { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;
}
