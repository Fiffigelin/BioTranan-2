using BioTranan.Core.Entities;
using BioTranan.Core.Repositories.Contracts;
using BioTranan.Core.Dto;
using Microsoft.AspNetCore.Mvc;

namespace BioTranan.Api.Controllers
{
    [Route("api/[controller]")]
    public class SalonController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly ISalonRepository _salonRepository;

        public SalonController(ILogger<MovieController> logger, ISalonRepository salonRepository)
        {
            _logger = logger;
            _salonRepository = salonRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Salon>> PostSalon([FromBody] CreateSalonDto salon)
        {
            var result = await this._salonRepository.CreateSalon(salon);

            if (salon == null) return NoContent();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Salon>> GetSalon(int id)
        {
            var result = await this._salonRepository.GetSalon(id);

            if (result == null) return NoContent();

            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Salon>> UpdateSalon(int id, [FromBody] CreateSalonDto updatedSalon)
        {
            var result = await this._salonRepository.UpdateSalon(id, updatedSalon);

            if (result == null) return NoContent();

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Salon>> DeleteSalon(int id)
        {
            var result = await this._salonRepository.DeleteSalon(id);

            if (result == null)
            {
                return NotFound("Salongen kunde inte hittas");
            }

            return Ok(result);
        }
    }
}