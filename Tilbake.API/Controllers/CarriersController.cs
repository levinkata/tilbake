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
    public class CarriersController : ControllerBase
    {
        // GET: api/Carriers
        [HttpGet]
        public async Task<IActionResult> GetCarriers()
        {
            var carriers = Enum.GetValues(typeof(Carrier))
                                                .Cast<Carrier>().Select(c => new
                                                {
                                                    ID = c.ToString(),
                                                    Name = c.GetDisplayName()
                                                });
            return await Task.Run(() => Ok(carriers)).ConfigureAwait(true);
        }

        // GET: api/Carriers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarrier(string id)
        {
            var carrier = Enum.GetValues(typeof(Carrier))
                                                .Cast<Carrier>().Select(c => new
                                                {
                                                    ID = c.ToString(),
                                                    Name = c.GetDisplayName()
                                                }).Where(c => c.ID == id);
            
            if (carrier == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(carrier)).ConfigureAwait(true);
        }
    }
}
