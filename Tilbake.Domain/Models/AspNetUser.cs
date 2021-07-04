using System;
using System.Collections.Generic;

namespace Tilbake.Domain.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AspnetUserPortfolios = new HashSet<AspnetUserPortfolio>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public Guid JobTitleId { get; set; }
        public string IdNumber { get; set; }
        public string ManNumber { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }

        public virtual ICollection<AspnetUserPortfolio> AspnetUserPortfolios { get; set; }
    }
}
