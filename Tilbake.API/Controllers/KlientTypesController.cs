using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.API.Extensions;
using Tilbake.Domain.Enums;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlientTypesController : ControllerBase
    {
        // GET: api/KlientTypes
        [HttpGet]
        public async Task<IActionResult> GetKlientTypes()
        {
            var klientTypes = Enum.GetValues(typeof(KlientType))
                                                .Cast<KlientType>().Select(c => new
                                                {
                                                    ID = c.ToString(),
                                                    Name = c.GetDisplayName()
                                                });
            return await Task.Run(() => Ok(klientTypes)).ConfigureAwait(true);
        }

        // GET: api/KlientTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKlientType(string id)
        {
            var klientType = Enum.GetValues(typeof(KlientType))
                                                .Cast<KlientType>().Select(c => new
                                                {
                                                    ID = c.ToString(),
                                                    Name = c.GetDisplayName()
                                                }).Where(c => c.ID == id);

            if (klientType == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(klientType)).ConfigureAwait(true);
        }
    }
}
