using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KlientsController : ControllerBase
    {
        private readonly IKlientService _klientService;

        public KlientsController(IKlientService klientService)
        {
            _klientService = klientService;
        }

        // GET: api/Klients
        [HttpGet]
        public async Task<IActionResult> GetKlients()
        {
            KlientsViewModel model = await _klientService.GetAllAsync().ConfigureAwait(true);
            var klients = from k in model.Klients
                          select new {
                                        k.ID,
                                        Title = k.Title.Name,
                                        k.KlientNumber,
                                        k.KlientType,
                                        k.FirstName,
                                        k.LastName,
                                        k.BirthDate,
                                        k.Gender,
                                        k.IDNumber,
                                        k.Phone,
                                        k.Mobile,
                                        k.Fax,
                                        k.Email,
                                        k.Carrier,
                                        Occupation = k.Occupation.Name,
                                        Land = k.Land.Name
                                     };

            return await Task.Run(() => Ok(klients)).ConfigureAwait(true);
        }

        // GET: api/Klients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKlient(Guid id)
        {
            KlientViewModel model = await _klientService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Klient)).ConfigureAwait(true);
        }

        // PUT: api/Klients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlient(Guid id, Klient klient)
        {
            if (klient == null)
            {
                throw new ArgumentNullException(nameof(klient));
            }

            if (id != klient.ID)
            {
                return BadRequest();
            }

            KlientViewModel model = new KlientViewModel()
            {
                Klient = klient
            };

            await _klientService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Klients
        [HttpPost]
        public async Task<IActionResult> PostKlient(Klient klient)
        {
            KlientViewModel model = new KlientViewModel()
            {
                Klient = klient
            };

            await _klientService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Klients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKlient(Guid id)
        {
            KlientViewModel model = await _klientService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _klientService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
