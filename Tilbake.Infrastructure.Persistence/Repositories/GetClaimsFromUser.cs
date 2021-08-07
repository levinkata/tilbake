using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class GetClaimsFromUser : IGetClaimsProvider
    {
        public GetClaimsFromUser(IHttpContextAccessor accessor)
        {
            UserId = accessor.HttpContext?
                .User.Claims.SingleOrDefault(x =>
                    x.Type == ClaimTypes.NameIdentifier)?.Value;
        }
        
        public string UserId { get; private set; }
    }
}
