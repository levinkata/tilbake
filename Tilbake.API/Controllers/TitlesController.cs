using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitlesController : ControllerBase
    {
        private readonly ITitleService _titleService;

        public TitlesController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        // GET: api/Titles
        [HttpGet]
        public async Task<IActionResult> GetTitles()
        {
            TitlesViewModel model = await _titleService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Titles)).ConfigureAwait(true);
        }

        // GET: api/Titles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTitle(Guid id)
        {
            TitleViewModel model = await _titleService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Title)).ConfigureAwait(true);
        }

        // PUT: api/Titles/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTitle(Guid id, Title title)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            if (id != title.ID)
            {
                return BadRequest();
            }

            TitleViewModel model = new TitleViewModel()
            {
                Title = title
            };

            await _titleService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Titles
        [HttpPost]
        public async Task<IActionResult> PostTitle(Title title)
        {
            TitleViewModel model = new TitleViewModel()
            {
                Title = title
            };

            await _titleService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Titles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle(Guid id)
        {
            TitleViewModel model = await _titleService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _titleService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
