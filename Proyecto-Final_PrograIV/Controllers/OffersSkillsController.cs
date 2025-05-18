using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Entities;
using Proyecto_Final_PrograIV.Services;

namespace Proyecto_Final_PrograIV.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferSkillsController : ControllerBase
    {
        private readonly IOfferSkillService _offerSkillService;

        public OfferSkillsController(IOfferSkillService offerSkillService)
        {
            _offerSkillService = offerSkillService;
        }

        // GET: api/offerskills?offerId=1&skillId=2
        [HttpGet]
        public ActionResult<IEnumerable<object>> Get([FromQuery] int? offerId, [FromQuery] int? skillId)
        {
            var results = _offerSkillService.GetOfferSkills(offerId, skillId);

            // Opcional: transformar salida si solo se quiere Skill u Offer
            if (offerId.HasValue && !skillId.HasValue)
                return Ok(results.Select(os => os.Skill));

            if (!offerId.HasValue && skillId.HasValue)
                return Ok(results.Select(os => os.Offer));

            // Si ambos están presentes o ninguno, devolver relaciones completas
            return Ok(results);
        }

        // POST: api/offerskills?offerId=1&skillId=2
        [HttpPost]
        public IActionResult AddRelation([FromQuery] int offerId, [FromQuery] int skillId)
        {
            try
            {
                _offerSkillService.AddSkillToOffer(offerId, skillId);
                return Ok(new { message = "Relación creada correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/offerskills?offerId=1&skillId=2
        [HttpDelete]
        public IActionResult DeleteRelation([FromQuery] int offerId, [FromQuery] int skillId)
        {
            try
            {
                _offerSkillService.RemoveSkillFromOffer(offerId, skillId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
