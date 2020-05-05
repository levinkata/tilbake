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
    public class GendersController : ControllerBase
    {
        // GET: api/Genders
        [HttpGet]
        public async Task<IActionResult> GetGenders()
        {
            var genders = Enum.GetValues(typeof(Gender))
                                                .Cast<Gender>().Select(c => new
                                                {
                                                    ID = c.ToString(),
                                                    Name = c.GetDisplayName()
                                                });
            return await Task.Run(() => Ok(genders)).ConfigureAwait(true);
        }

        // GET: api/Genders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGender(string id)
        {
            var gender = Enum.GetValues(typeof(Gender))
                                                .Cast<Gender>().Select(c => new
                                                {
                                                    ID = c.ToString(),
                                                    Name = c.GetDisplayName()
                                                }).Where(c => c.ID == id);

            if (gender == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(gender)).ConfigureAwait(true);
        }
    }
}
