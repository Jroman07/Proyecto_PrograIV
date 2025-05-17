using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        // GET
        [HttpGet("skills-by-offer/{offerId}")]
        public List<Skill> GetSkillsByOffer(int offerId)
        {
            return _offerSkillService.GetSkillsByOffer(offerId);
        }

        // GET
        [HttpGet("offers-by-skill/{skillId}")]
        public List<Offer> GetOffersBySkill(int skillId)
        {
            return _offerSkillService.GetOffersBySkill(skillId);
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromQuery] int offerId, [FromQuery] int skillId)
        {
            _offerSkillService.AddSkillToOffer(offerId, skillId);
            return Ok("Skill assigned to offer successfully");
        }

        // DELETE
        [HttpDelete]
        public void Delete([FromQuery] int offerId, [FromQuery] int skillId)
        {
            _offerSkillService.RemoveSkillFromOffer(offerId, skillId);
        }
    }
}
