using BioTranan.Core.Entities;
using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BioTranan.Api.Controllers
{
    [Route("api/[controller]")]
    public class ShowController : ControllerBase
    {
        private readonly IShowRepository _showRepository;

        public ShowController(IShowRepository showRepository)
        {
            _showRepository = showRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Show>> PostShow([FromBody] CreateShowDto show)
        {
            var result = await this._showRepository.CreateShow(show);

            if (show == null) return NoContent();

            return Ok(result);
        }
    }
}