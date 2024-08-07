﻿using System;
using System.Collections.Generic;

namespace Tilbake.Core.Models;

public partial class CustomerBankAccount
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid BankAccountId { get; set; }

    public Guid? AddedById { get; set; }

    public DateTime? DateAdded { get; set; }

    public Guid? ModifiedById { get; set; }

    public DateTime? DateModified { get; set; }

    public virtual BankAccount BankAccount { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Policy> Policies { get; set; } = new List<Policy>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();
}
